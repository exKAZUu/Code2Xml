using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Learner.Core.Learning {
    public class SelectedFragment {
        public readonly string SurroundingText;
        public readonly string TargetText;
        public readonly int StartLine;

        /// <summary>
        /// To reduce code in XXXXExperiment classes.
        /// </summary>
        private static int _lastStartLine;

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

    public class SeedNode {
        public CodeRange SurroundingRange { get; }
        public CodeRange TargetRange { get; private set; }
        public CstNode Node { get; private set; }

        private SeedNode(CstNode node, CodeRange targetRange, CodeRange surroundingRange) {
            Node = node;
            TargetRange = targetRange;
            SurroundingRange = surroundingRange;
        }

        /// <summary>
        /// Update SurroundingRange, TargetRange, and Node properties then return the last index of the code processed.
        /// </summary>
        /// <param name="structuredCode">The structured code processed</param>
        /// <param name="cst">The concrete syntax tree</param>
        /// <param name="fragments"></param>
        /// <returns>The updated last index of the code processed</returns>
        public static List<SeedNode> ConstructAcceptingFragments(StructuredCode structuredCode, CstNode cst, IList<SelectedFragment> fragments) {
            var seedNodes = CreateSeedNodes(structuredCode, cst, fragments);

            var uppermostSeedAcceptedNodes = seedNodes
                    .Select(node => node.Node.AncestorWithSingleChild())
                    .ToImmutableHashSet();
            // We can select multiple nodes in corresponding to a fragment selected by a user
            // and it means that we have multiple choices for selecting node names to filter nodes
            // This code tries to select good node names to not filter nodes wanted by a user
            var selectedNodeNames = LearningExperimentUtil.FindGoodNodeNames(uppermostSeedAcceptedNodes)
                    .ToImmutableHashSet();
            foreach (var seedNode in seedNodes) {
                // Update the node in corresponding to the selected node names keeping the code range of the node
                seedNode.Node = seedNode.Node.DescendantsOfSingleAndSelf()
                        .First(e => selectedNodeNames.Contains(e.Name));
                var rootNode = seedNode.SurroundingRange.FindInnermostNode(cst);
                var node = seedNode.Node;
                var path = node.Name;
                while ((node = node.Parent) != rootNode) {
                    path = path + "<" + node.Name + node.RuleId;
                }
                seedNode.Path = path;
            }
            return seedNodes;
        }

        private static List<SeedNode> CreateSeedNodes(StructuredCode structuredCode, CstNode cst, IEnumerable<SelectedFragment> fragments) {
            var lastIndex = -1;
            return fragments.Select(fragment => {
                var startLineIndex = Math.Max(lastIndex + 1, structuredCode.GetIndex(fragment.StartLine, 0));
                var surroundingIndex = structuredCode.Code.IndexOf(fragment.SurroundingText, startLineIndex);
                var targetIndex = structuredCode.Code.IndexOf(fragment.TargetText, surroundingIndex);
                if (surroundingIndex < 0 || targetIndex < 0) {
                    throw new Exception("The selected code fragment is invalid.");
                }
                var surroundingRange = structuredCode.GetRange(surroundingIndex,
                        surroundingIndex + fragment.SurroundingText.Length);
                var targetRange = structuredCode.GetRange(targetIndex,
                        targetIndex + fragment.TargetText.Length);
                var node = targetRange.FindOutermostNode(cst);
                lastIndex = surroundingIndex;
                return new SeedNode(node, targetRange, surroundingRange);
            }).ToList();
        }

        public string Path { get; set; }
    }
}
