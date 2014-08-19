#region License

// Copyright (C) 2011-2014 Kazunori Sakamoto
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using Accord.Statistics.Filters;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Generators.ANTLRv3.Java;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;
using Code2Xml.Learner.Core.Learning;
using Code2Xml.Learner.Core.Learning.Experiments;
using Code2Xml.Objects.Learner;
using Paraiba.Linq;
using Sgry.Azuki;
using Sgry.Azuki.Highlighter;

namespace Occf.Learner.Experiment {
    public partial class MainForm : Form {
        private static readonly int[] MaxLengths = { int.MaxValue / 2, 4, int.MaxValue / 2 };
        private static readonly int[] PaddingLengths = { 0, 0, 8 };
        private CstGenerator _activeProcessor;
        private CodeFile _activeFile;
        private ListViewItem _lastSelectedItem;
        private bool _eventEnabled;
        private LearningExperiment _activeExperiment;
        private int _count;

        public string Code {
            get { return azuki.Text; }
            set { azuki.Text = value; }
        }

        private IEnumerable<CodeFile> Files {
            get {
                return lvModifiableFile.Items.Cast<FileListViewItem>()
                        .Concat(lvFreezedFile.Items.Cast<FileListViewItem>())
                        .Select(item => item.File);
            }
        }

        private IEnumerable<CodeFile> FreezedFiles {
            get {
                return lvFreezedFile.Items.Cast<FileListViewItem>()
                        .Select(item => item.File);
            }
        }

        public MainForm() {
            _eventEnabled = true;

            InitializeComponent();
            Marking.Register(new MarkingInfo(0, "selected"));
            Marking.Register(new MarkingInfo(1, "selected_head"));
            Marking.Register(new MarkingInfo(2, "infered_head"));
            azuki.ColorScheme.SetMarkingDecoration(
                    0,
                    new BgColorTextDecoration(Color.Yellow));
            azuki.ColorScheme.SetMarkingDecoration(
                    1,
                    new UnderlineTextDecoration(LineStyle.Solid, Color.Red));
            azuki.ColorScheme.SetMarkingDecoration(
                    2,
                    new UnderlineTextDecoration(LineStyle.Waved, Color.Blue));
            Activate();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            var menuItems = new List<ToolStripMenuItem>();
            var processors = new CstGenerator[] {
                CstGenerators.JavaUsingAntlr3,
                CstGenerators.CSharpUsingAntlr3,
                CstGenerators.JavaScriptUsingAntlr3,
                CstGenerators.Python2,
                CstGenerators.PhpUsingAntlr3,
                CstGenerators.LuaUsingAntlr3,
            };
            foreach (var processor in processors) {
                var menuItem =
                        menuItemLanguage.DropDownItems.Add(processor.LanguageNameWithVersion) as
                                ToolStripMenuItem;
                menuItems.Add(menuItem);
                var processorForClosure = processor;
                menuItem.Click += (o, args) => {
                    _activeProcessor = processorForClosure;
                    foreach (var item in menuItems) {
                        item.Checked = false;
                    }
                    menuItem.Checked = true;

                    Code = "";
                    _activeFile = null;
                    lvModifiableFile.Items.Clear();
                    lvFreezedFile.Items.Clear();
                    lvModifiableRule.Items.Clear();
                    lvFreezedRule.Items.Clear();
                    lvWillBeMarkedElements.Items.Clear();
                    lvMarkedElements.Items.Clear();
                };
                // Set default processor
                if (processor is JavaCstGeneratorUsingAntlr3) {
                    menuItem.PerformClick();
                }
            }
            InitializeModeMenu();
        }

        private void InitializeModeMenu() {
            var menuItems = new List<ToolStripMenuItem>();
            var exps = new LearningExperiment[] {
                new JavaComplexStatementExperiment(),
                new JavaSuperComplexBranchExperiment(),
            };
            foreach (var exp in exps) {
                var menuItem = menuItemModes.DropDownItems.Add(
                        exp.GetType().Name.Contains("Statement")
                                ? "Statement" : "Branch") as ToolStripMenuItem;
                menuItems.Add(menuItem);
                menuItem.Click += (o, args) => {
                    _activeExperiment = exp;
                    foreach (var item in menuItems) {
                        item.Checked = false;
                    }
                    menuItem.Checked = true;
                };
            }
            menuItems[1].PerformClick();
        }

        private void btnInfer_Click(object sender, EventArgs e) {
            NormalizeAllRange2Element(); // To infer good rules
            var learningRecrods = FreezedFiles
                    .Concat(Enumerable.Repeat(_activeFile, 1))
                    .Select(f => new LearningRecord(f.Ast, f.Range2Elements.Values))
                    .ToList();
            var filters = RuleLearner.Learn(learningRecrods).ToList();
            var newModifiableItems = new List<RuleListViewItem>();
            _eventEnabled = false;
            foreach (var filter in filters) {
                var freezedRuleItem = lvFreezedRule.Items.Cast<RuleListViewItem>()
                        .FirstOrDefault(i => i.Filter.TryUpdateProperties(filter));
                if (freezedRuleItem != null) {
                    freezedRuleItem.Update(Files);
                    continue;
                }

                var modifiableRuleItem = lvModifiableRule.Items.Cast<RuleListViewItem>()
                        .FirstOrDefault(i => i.Filter.TryUpdateProperties(filter));
                if (modifiableRuleItem != null) {
                    modifiableRuleItem.Update(Files);
                    newModifiableItems.Add(modifiableRuleItem);
                    continue;
                }

                var item = new RuleListViewItem(filter, Files);
                if (filter is NopFilter) {
                    item.Checked = true; //TODO: should use "filter is NopFilter;" ?
                }
                newModifiableItems.Add(item);
            }
            lvModifiableRule.Items.Clear();
            var sortedModifiableItems = newModifiableItems
                    .OrderByDescending(i => i.ExactMatch)
                    .ThenByDescending(i => i.Filter.LivingTime);
            foreach (var item in sortedModifiableItems) {
                lvModifiableRule.Items.Add(item);
            }
            _eventEnabled = true;
            lvRule_ItemChecked(null, null);
        }

        private void btnApply_Click(object sender, EventArgs e) {
            var rule = InferRule();
            _activeFile.Range2Elements = rule.ExtractRange2Elements(_activeFile.Ast);
            NormalizeAllRange2Element(); // To show good element lists
            RedrawActiveFile();
        }

        private void btnApplyAll_Click(object sender, EventArgs e) {
            var rule = InferRule();
            foreach (var file in lvModifiableFile.Items.Cast<FileListViewItem>().Select(i => i.File)
                    ) {
                file.Range2Elements = rule.ExtractRange2Elements(file.Ast);
            }
            NormalizeAllRange2Element(); // To show good element lists
            RedrawActiveFile();
        }

        private void markToolStripMenuItem_Click(object sender, EventArgs e) {
            // Calculate the selected range
            var selectedRange = GetSelectedRange();
            // Get the selected element
            // TODO: Should be use FindInnerElement or FindOuterElement ?
            var element = selectedRange.FindOutermostElement(_activeFile.Ast);
            var range = CodeRange.Locate(element);
            if (!_activeFile.Range2Elements.ContainsKey(range)) {
                _activeFile.Range2Elements.Add(range, element);
                NormalizeAllRange2Element(); // To show good element lists
                DrawMarkers(_activeFile.Range2Elements, 0, 1);
                ListElements(_activeFile.Range2Elements, lvMarkedElements);
            }
            btnInfer.PerformClick(); // TODO: added
        }

        private void unmarkToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedRange = GetSelectedRange();
            var range = _activeFile.Range2Elements.Keys.Where(r => r.Contains(selectedRange))
                    .OrderBy(
                            r =>
                                    (r.EndLine - r.StartLine) * 65536
                                    + (r.EndPosition - r.StartPosition))
                    .FirstOrDefault();
            if (range == default(CodeRange)) {
                return;
            }
            _activeFile.Range2Elements.Remove(range);
            DrawMarkers(_activeFile.Range2Elements, 0, 1);
            ListElements(_activeFile.Range2Elements, lvMarkedElements);
        }

        private void azuki_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void azuki_DragDrop(object sender, DragEventArgs e) {
            var paths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var count = lvModifiableFile.Items.Count;
            var filePaths = paths.SelectMany(
                    path =>
                            Directory.Exists(path)
                                    ? Directory.EnumerateFiles(
                                            path, "*", SearchOption.AllDirectories)
                                            .Where(
                                                    filePath =>
                                                            _activeProcessor.SupportedExtensions
                                                                    .Contains(
                                                                            Path.GetExtension(
                                                                                    filePath)))
                                    : Enumerable.Repeat(path, 1));
            foreach (var filePath in filePaths) {
                var file = new FileInfo(filePath);
                var codeFile = new CodeFile(_activeProcessor, file);
                var item = new FileListViewItem(codeFile);
                lvModifiableFile.Items.Add(item);
            }
            lvModifiableFile.Items[count].Selected = true;
        }

        private void lvFile_ItemSelectionChanged(
                object sender, ListViewItemSelectionChangedEventArgs e) {
            var item = e.Item as FileListViewItem;
            if (item != null && item != _lastSelectedItem) {
                _lastSelectedItem = item;
                ChangeActiveFile(item.File);
            }
        }

        private void lvFile_Click(object sender, EventArgs e) {
            var listView = (ListView)sender;
            if (listView.SelectedItems.Count == 0) {
                return;
            }
            var item = listView.SelectedItems.Cast<FileListViewItem>()
                    .FirstOrDefault();
            if (item != null && item != _lastSelectedItem) {
                _lastSelectedItem = item;
                ChangeActiveFile(item.File);
            }
        }

        private void lvFile_MouseClick(object sender, MouseEventArgs e) {
            var src = (ListView)sender;
            var dst = src == lvModifiableFile ? lvFreezedFile : lvModifiableFile;
            var readOnly = src == lvModifiableFile;
            if (e.Button == MouseButtons.Right) {
                foreach (FileListViewItem item in src.SelectedItems) {
                    item.Remove();
                    dst.Items.Add(item);
                    item.File.ReadOnly = readOnly;
                    azuki.ContextMenuStrip = _activeFile.ReadOnly ? null : contextMenuStrip;
                }
                var rule = InferRule();
                var range2Elements = rule.ExtractRange2Elements(_activeFile.Ast);
                btnApply.Enabled = CanApplyThis(range2Elements);
                btnGoToNext.Enabled = CanApplyAll(rule);
            }
        }

        private void lvRule_ItemChecked(object sender, ItemCheckedEventArgs e) {}

        private void lvRule_MouseClick(object sender, MouseEventArgs e) {}

        private void lvElements_MouseDoubleClick(object sender, MouseEventArgs e) {
            var listView = (ListView)sender;
            var item = listView.SelectedItems.Cast<ElementListViewItem>().FirstOrDefault();
            if (item != null) {
                var indicies = item.Range.ConvertToIndicies(Code);
                azuki.SetSelection(indicies.Item1, indicies.Item2);
            }
        }

        #region Helper Methods

        private ExtractingRule InferRule() {
            var filters = lvModifiableRule.CheckedItems.Cast<RuleListViewItem>()
                    .Concat(lvFreezedRule.CheckedItems.Cast<RuleListViewItem>())
                    .Select(item => item.Filter);
            return new ExtractingRule(filters);
        }

        private void NormalizeAllRange2Element() {
            var name2Count = new Dictionary<string, int>();
            var elements = Files
                    .SelectMany(file => file.Range2Elements.Values)
                    .SelectMany(e => e.DescendantsOfOnlyChildAndSelf());
            foreach (var element in elements) {
                int count = 0;
                name2Count.TryGetValue(element.Name.LocalName, out count);
                name2Count[element.Name.LocalName] = count + 1;
            }

            foreach (var codeFile in Files) {
                var newRange2Elements = new Dictionary<CodeRange, CstNode>();
                foreach (var nameAndElement in codeFile.Range2Elements) {
                    var newElement = nameAndElement.Value.DescendantsOfOnlyChildAndSelf()
                            .OrderByDescending(e => name2Count[e.Name.LocalName])
                            .First();
                    newRange2Elements[nameAndElement.Key] = newElement;
                }
                codeFile.Range2Elements = newRange2Elements;
            }
        }

        private CodeRange GetSelectedRange() {
            int start, end;
            azuki.GetSelection(out start, out end);
            return CodeRange.ConvertFromIndiciesSkippingWhitespaces(Code, ref start, ref end);
        }

        /// <summary>
        /// Draws markers on the editor with the specified dictionary of ranges and elements and the specified marking ids.
        /// </summary>
        /// <param name="range2Elements"></param>
        /// <param name="markingIds"></param>
        private void DrawMarkers(
                IEnumerable<KeyValuePair<CodeRange, CstNode>> range2Elements,
                params int[] markingIds) {
            foreach (var markingId in markingIds) {
                azuki.Document.Unmark(0, azuki.TextLength, markingId);
            }
            foreach (var rangeAndElement in range2Elements) {
                var range = rangeAndElement.Key;
                int inclusiveStart, exclusiveEnd;
                range.ConvertToIndicies(azuki.Text, out inclusiveStart, out exclusiveEnd);
                foreach (var markingId in markingIds) {
                    var end = Math.Min(exclusiveEnd, inclusiveStart + MaxLengths[markingId]);
                    if (end - inclusiveStart > PaddingLengths[markingId] * 2) {
                        inclusiveStart += PaddingLengths[markingId];
                        end -= PaddingLengths[markingId];
                    }
                    azuki.Document.Mark(inclusiveStart, end, markingId);
                }
            }
            azuki.Invalidate();
        }

        /// <summary>
        /// Shows the specified dictionary of ranges and elements on the list.
        /// </summary>
        private void ListElements(
                IEnumerable<KeyValuePair<CodeRange, CstNode>> range2Elements, ListView listView) {
            listView.Items.Clear();
            foreach (var rangeAndElement in range2Elements) {
                var item = new ElementListViewItem(rangeAndElement.Key, rangeAndElement.Value);
                listView.Items.Add(item);
            }
        }

        private void RedrawActiveFile() {
            DrawMarkers(_activeFile.Range2Elements, 0, 1, 2);
            ListElements(_activeFile.Range2Elements, lvMarkedElements);
            ListElements(_activeFile.Range2Elements, lvWillBeMarkedElements);
        }

        private void ChangeActiveFile(CodeFile activeFile) {
            _activeFile = activeFile;
            Code = _activeFile.Code;
            RedrawActiveFile();
            var rule = InferRule();
            var range2Elements = rule.ExtractRange2Elements(_activeFile.Ast);
            DrawMarkers(range2Elements, 2);
            ListElements(range2Elements, lvWillBeMarkedElements);
            btnApply.Enabled = CanApplyThis(range2Elements);
            azuki.ContextMenuStrip = _activeFile.ReadOnly ? null : contextMenuStrip;
        }

        private bool CanApplyThis(Dictionary<CodeRange, CstNode> range2Elements) {
            return !_activeFile.ReadOnly || _activeFile.RangesEquals(range2Elements);
        }

        private bool CanApplyAll(ExtractingRule rule = null) {
            rule = rule ?? InferRule();
            return btnApply.Enabled && FreezedFiles.All(
                    f => f.RangesEquals(rule.ExtractRange2Elements(f.Ast)));
        }

        #endregion

        #region Inner Classes

        public class FileListViewItem : ListViewItem {
            public CodeFile File { get; private set; }

            public FileListViewItem(CodeFile file)
                    : base(file.Info.Name, file.Info.FullName) {
                File = file;
            }
        }

        public class RuleListViewItem : ListViewItem {
            public IFilter Filter { get; private set; }

            public bool ExactMatch { get; private set; }

            public RuleListViewItem(IFilter filter, IEnumerable<CodeFile> files) {
                Filter = filter;
                Update(files);
            }

            public void Update(IEnumerable<CodeFile> files) {
                var filter = Filter;
                var rule = new ExtractingRule(Enumerable.Repeat(filter, 1));
                var fileList = files.ToList();
                ExactMatch = fileList.Where(f => f.ReadOnly).All(
                        f => f.RangesEquals(filter.ElementName, rule.ExtractRange2Elements(f.Ast)));
                Text = (ExactMatch ? "* " : "")
                       + fileList.Select(f => f.Ast).Select(filter.CountRemovableTargets).Sum()
                       + ": " + filter;
            }
        }

        public class ElementListViewItem : ListViewItem {
            public CodeRange Range { get; private set; }
            public CstNode Element { get; private set; }

            public ElementListViewItem(CodeRange range, CstNode element)
                    : base(new[] { element.Name.LocalName, element.Value }) {
                Range = range;
                Element = element;
                ToolTipText = element.ToString();
            }
        }

        public class Highlighter : IHighlighter {
            public void Highlight(Document doc) {}

            public void Highlight(Document doc, ref int dirtyBegin, ref int dirtyEnd) {
                throw new NotImplementedException();
            }

            public bool CanUseHook { get; private set; }
            public HighlightHook HookProc { get; set; }
        }

        #endregion

        private void btnStart_Click(object sender, EventArgs e) {
            _activeExperiment.LearnUntilBeStable(
                    Files.Select(f => f.Ast).Where(ast => ast != _activeFile.Ast),
                    Enumerable.Repeat(_activeFile.Ast, 1), _activeFile.Range2Elements.Values);

            _count = 0;
            while (true) {
                _count = _activeExperiment.LearnAndApply(_count);
                var ret = AddNewElements();
                if (!ret) {
                    _count = 0;
                } else if (_count < 0) {
                    break;
                }
            }
        }

        private bool AddNewElements() {
            var acceptedFeatureAndElements = _activeExperiment.SuspiciousAcceptedInAccepting
                    .Select(
                            t =>
                                    Tuple.Create(
                                            t.Feature, _activeExperiment.Feature2Element[t.Feature]));
            var rejectedFeatureAndElements = _activeExperiment.SuspiciousRejectedInAccepting
                    .Concat(_activeExperiment.SuspiciousRejectedInRejecting)
                    .Select(
                            t =>
                                    Tuple.Create(
                                            t.Feature, _activeExperiment.Feature2Element[t.Feature]));
            var acceptedFeature = new List<BigInteger>();

            MessageBox.Show("測定対象と判断された要素を確認して下さい．", "", MessageBoxButtons.OK);
            foreach (var featureAndElement in acceptedFeatureAndElements) {
                var text = CreateText(featureAndElement);
                var accepted = MessageBox.Show(text, "これは測定対象ですか？", MessageBoxButtons.YesNo)
                               == DialogResult.Yes;
                if (accepted) {
                    acceptedFeature.Add(featureAndElement.Item1);
                }
                if (accepted != _activeExperiment.IsAcceptedUsingOracle(featureAndElement.Item2)) {
                    throw new Exception("選択が間違っています！");
                }
            }
            MessageBox.Show("測定対象ではないと判断された要素を確認して下さい．", "", MessageBoxButtons.OK);
            foreach (var featureAndElement in rejectedFeatureAndElements) {
                var text = CreateText(featureAndElement);
                var accepted = MessageBox.Show(text, "これは測定対象ですか？", MessageBoxButtons.YesNo)
                               == DialogResult.Yes;
                if (accepted) {
                    acceptedFeature.Add(featureAndElement.Item1);
                }
                if (accepted != _activeExperiment.IsAcceptedUsingOracle(featureAndElement.Item2)) {
                    throw new Exception("選択が間違っています！");
                }
            }

            return _activeExperiment.AddNewElements(acceptedFeature.ToHashSet());
        }

        private string CreateText(Tuple<BigInteger, CstNode> featureAndElement) {
            var t = (featureAndElement.Item2.AncestorsAndSelf().Skip(2).FirstOrDefault()
                     ?? featureAndElement.Item2).Text();
            var tt = " ** " + t + " ** ";
            var t2 = tt.Replace(
                    featureAndElement.Item2.Text(),
                    " ***** " + featureAndElement.Item2.Text() + " ***** ");
            var text = _activeExperiment.GetType().Name.Contains("Statement")
                    ? featureAndElement.Item2.Text()
                    : featureAndElement.Item2.Text()
                      + "\r\n------------------------------------------------------------------------\r\n"
                      +
                      (featureAndElement.Item2.AncestorsAndSelf().Skip(2).FirstOrDefault()
                       ?? featureAndElement.Item2).Text().Replace(t, tt).Replace(tt, t2)
                      + "\r\n------------------------------------------------------------------------\r\n"
                      +
                      (featureAndElement.Item2.AncestorsAndSelf().Skip(5).FirstOrDefault()
                       ?? featureAndElement.Item2).Text().Replace(t, tt).Replace(tt, t2)
                      + "\r\n------------------------------------------------------------------------\r\n"
                      +
                      (featureAndElement.Item2.AncestorsAndSelf().Skip(10).FirstOrDefault()
                       ?? featureAndElement.Item2).Text().Replace(t, tt).Replace(tt, t2);
            return text;
        }

        private void btnGoToNext_click(object sender, EventArgs e) {}

        private void modeToolStripMenuItem_Click(object sender, EventArgs e) {}

        private void azuki_Click(object sender, EventArgs e) {}
    }
}