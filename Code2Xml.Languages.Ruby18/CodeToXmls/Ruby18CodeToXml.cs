#region License

// Copyright (C) 2011-2012 Kazunori Sakamoto
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
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.Resources;
using Code2Xml.Languages.Ruby18.Properties;

namespace Code2Xml.Languages.Ruby18.CodeToXmls {
    [Export(typeof(CodeToXml))]
    public class Ruby18CodeToXml : CodeToXml {
        private static readonly string DirectoryPath = Path.Combine(
                "ParserScripts", "IronRubyParser");

        private static Ruby18CodeToXml _instance;

        private Ruby18CodeToXml() {
            ResourceManager.WriteResourceFiles(
                    DirectoryPath,
                    new[] {
                            Tuple.Create(
                                    Path.Combine("racc", "parser.py"),
                                    Resources.racc_parser),
                            Tuple.Create(
                                    "composite_sexp_processor.rb",
                                    Resources.composite_sexp_processor),
                            Tuple.Create(
                                    "gauntlet_rubyparser.rb",
                                    Resources.gauntlet_rubyparser),
                            Tuple.Create("parser.rb", Resources.parser),
                            Tuple.Create("ruby_lexer.rb", Resources.ruby_lexer),
                            Tuple.Create(
                                    "ruby_parser.rb", Resources.ruby_parser),
                            Tuple.Create(
                                    "ruby_parser_extras.rb",
                                    Resources.ruby_parser_extras),
                            Tuple.Create(
                                    "ruby_parser_README.txt",
                                    Resources.ruby_parser_README),
                            Tuple.Create("ruby2ruby.rb", Resources.ruby2ruby),
                            Tuple.Create(
                                    "ruby2ruby_README.txt",
                                    Resources.ruby2ruby_README),
                            Tuple.Create("sexp.rb", Resources.sexp),
                            Tuple.Create(
                                    "sexp_processor.rb",
                                    Resources.sexp_processor),
                            Tuple.Create(
                                    "SexpProcessor_README.txt",
                                    Resources.SexpProcessor_README)
                            ,
                            Tuple.Create("sjis.rb", Resources.sjis),
                            Tuple.Create("stringio.rb", Resources.stringio),
                            Tuple.Create("strscan.rb", Resources.strscan),
                            Tuple.Create("unique.rb", Resources.unique),
                            Tuple.Create(
                                    "zkcount_08a2.rb", Resources.zkcount_08a2),
                    });
        }

        public static Ruby18CodeToXml Instance {
            get { return _instance ?? (_instance = new Ruby18CodeToXml()); }
        }

        public override string ParserName {
            get { return "Ruby18"; }
        }

        public override IEnumerable<string> TargetExtensions {
            get { return new[] { ".rb" }; }
        }

        public override XElement Generate(
                TextReader reader, bool throwingParseError) {
            return Generate(reader.ReadToEnd());
        }

        public override XElement Generate(string code, bool throwingParseError) {
            var ast = IronRubyParser.ParseCodeFromString(code);
            NodeInserter.ReplaceSafely(
                    GetLackingBlockNodesAround(ast),
                    node => {
                        if (node.Name.LocalName == "block") {
                            return node;
                        }
                        return node.Name.LocalName != "nil"
                                       ? new XElement("block", node)
                                       : new XElement("block");
                    });

            NodeInserter.InsertAfter(
                    GetLackingBlockNodesAfter(ast),
                    node => new XElement("block"));
            return ast;
        }

        public IEnumerable<XElement> GetLackingBlockNodesAround(XElement root) {
            var ifs = RubyElements.If(root)
                    .SelectMany(
                            e => new[] {
                                    RubyElements.IfProcess(e),
                                    RubyElements.ElseProcess(e),
                            });
            var untils = RubyElements.WhileUntil(root)
                    .Select(RubyElements.WhileUntilProcess);
            var fors = RubyElements.For(root)
                    .Select(RubyElements.ForProcess)
                    .Where(e => e != null);
            var iters = RubyElements.Iterator(root)
                    .Select(RubyElements.IteratorProcess)
                    .Where(e => e != null);

            return ifs.Concat(untils).Concat(fors).Concat(iters);
        }

        public IEnumerable<XElement> GetLackingBlockNodesAfter(XElement root) {
            var fors = RubyElements.SimpleFor(root)
                    .Select(RubyElements.ForProcessBefore);
            var iters = RubyElements.SimpleIterator(root)
                    .Select(RubyElements.IteratorProcessBefore);

            return fors.Concat(iters);
        }
    }
}