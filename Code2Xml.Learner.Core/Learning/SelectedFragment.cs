using System;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Learner.Core.Learning {
    public class SelectedFragment {
        public CodeRange SurroundingRange { get; private set; }
        public CodeRange TargetRange { get; private set; }
        public CstNode Node { get; private set; }

        public readonly string SurroundingText;
        public readonly string TargetText;
        public readonly int StartLine;

        /// <summary>
        /// To reduce code in XXXXExperiment classes.
        /// </summary>
        private static int _lastStartLine;

        /// <summary>
        /// Update SurroundingRange, TargetRange, and Node properties then return the last index of the code processed.
        /// </summary>
        /// <param name="structuredCode">The structured code processed</param>
        /// <param name="cst">The concrete syntax tree</param>
        /// <param name="lastIndex">The last index of the code processed (initial value should be -1)</param>
        /// <returns>The updated last index of the code processed</returns>
        public int Update(StructuredCode structuredCode, CstNode cst, int lastIndex = -1) {
            var startLineIndex = structuredCode.GetIndex(StartLine, 0);
            var surroundingIndex = structuredCode.Code.IndexOf(SurroundingText,
                    Math.Max(lastIndex + 1, startLineIndex));
            var targetIndex = structuredCode.Code.IndexOf(TargetText, surroundingIndex);
            if (surroundingIndex < 0 || targetIndex < 0) {
                throw new Exception("The selected code fragment is invalid.");
            }
            SurroundingRange = structuredCode.GetRange(surroundingIndex,
                    surroundingIndex + SurroundingText.Length);
            TargetRange = structuredCode.GetRange(targetIndex, targetIndex + TargetText.Length);
            Node = TargetRange.FindOutermostNode(cst);
            return surroundingIndex;
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
