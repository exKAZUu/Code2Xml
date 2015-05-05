using System;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Learner.Core.Learning {
    public class SelectedFragment {
        public CodeRange SurroundingRange { get; set; }
        public CodeRange TargetRange { get; set; }
        public CstNode Node { get; set; }

        public string SurroundingText { get; set; }
        public string TargetText { get; set; }
        public int StartLine { get; set; }

        private static int _lastStartLine;
        private static int _lastIndex;

        public void Update(StructuredCode structuredCode, CstNode cst) {
            var startLineIndex = structuredCode.GetIndex(StartLine, 0);
            var surroundingIndex = structuredCode.Code.IndexOf(SurroundingText,
                    Math.Max(_lastIndex + 1, startLineIndex));
            var targetIndex = structuredCode.Code.IndexOf(TargetText, surroundingIndex);
            if (surroundingIndex < 0 || targetIndex < 0) {
                throw new Exception("The selected code fragment is invalid.");
            }
            SurroundingRange = structuredCode.GetRange(surroundingIndex,
                    surroundingIndex + SurroundingText.Length);
            TargetRange = structuredCode.GetRange(targetIndex, targetIndex + TargetText.Length);
            Node = TargetRange.FindOutermostNode(cst);
            _lastIndex = surroundingIndex;
        }

        public SelectedFragment(int startLine, string surroundingText, string targetText) {
            StartLine = startLine;
            SurroundingText = surroundingText;
            TargetText = targetText;
            _lastStartLine = startLine;
        }

        public SelectedFragment(int startLine, string surroundingText)
                : this(startLine, surroundingText, surroundingText) {}

        public SelectedFragment(string surroundingText, string targetText)
                : this(++_lastStartLine, surroundingText, targetText) {}

        public SelectedFragment(string surroundingText) : this(++_lastStartLine, surroundingText) {}
    }
}
