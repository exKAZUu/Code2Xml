#region License

// Copyright (C) 2011-2015 Kazunori Sakamoto
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
using System.Collections.Immutable;
using System.Linq;
using Code2Xml.Core.SyntaxTree;
using Code2Xml.Learner.Core.Learning;

namespace Code2Xml.Learner.Core {
	public class SeedNodeSet {
		public ISet<string> SelectedNodeNames { get; private set; }
		public ISet<CstNode> SeedAcceptedNodes { get; private set; }
		public IList<CstNode> SeedRejectedNodes { get; private set; }

		public SeedNodeSet(
				IEnumerable<CstNode> seedNodes, IList<CstNode> seedCsts, LearningExperiment oracle) {
			var uppermostSeedAcceptedNodes = SelectUppermostNodes(seedNodes)
					.ToImmutableHashSet();
			SelectedNodeNames = SelectNodeNames(uppermostSeedAcceptedNodes)
					.ToImmutableHashSet();

			SeedAcceptedNodes = CreateAcceptedNodes(uppermostSeedAcceptedNodes)
					.ToImmutableHashSet();
			if (!SeedAcceptedNodes.Any()) {
				throw new Exception("There are no accepted seed nodes!");
			}
			VerifySeedAcceptedNodes(seedCsts, uppermostSeedAcceptedNodes, oracle);

			SeedRejectedNodes = CreateRejectedNodes(seedCsts, SeedAcceptedNodes)
					.ToImmutableList();
		}

		private static IEnumerable<string> SelectNodeNames(
				ICollection<CstNode> uppermostSeedAcceptedNodes) {
			return LearningExperimentUtil.FindGoodNodeNames(uppermostSeedAcceptedNodes);
		}

		private static IEnumerable<CstNode> SelectUppermostNodes(IEnumerable<CstNode> elements) {
			return elements.Select(e => e.AncestorsWithSingleChildAndSelf().Last());
		}

		private IEnumerable<CstNode> CreateRejectedNodes(
				IEnumerable<CstNode> csts, ICollection<CstNode> acceptedNodes) {
			var uppermostNodes = csts
					.SelectMany(cst => LearningExperimentUtil.GetUppermostNodesByNames(cst, SelectedNodeNames));
			return uppermostNodes.Where(node => !acceptedNodes.Contains(node));
		}

		private IEnumerable<CstNode> CreateAcceptedNodes(IEnumerable<CstNode> uppermostAcceptedNodes) {
			return uppermostAcceptedNodes
					.Select(
							e => e.DescendantsOfSingleAndSelf()
									.First(e2 => SelectedNodeNames.Contains(e2.Name)));
		}

		private void VerifySeedAcceptedNodes(
				IEnumerable<CstNode> seedCsts, ICollection<CstNode> uppermostSeedAcceptedNodes,
				LearningExperiment oracle) {
			var anotherUppermostSeedAcceptedNodes = seedCsts
					.SelectMany(cst => LearningExperimentUtil.GetUppermostNodesByNames(cst, SelectedNodeNames))
					.Where(oracle.ProtectedIsAcceptedUsingOracle)
					.ToList();
			var b1 = !uppermostSeedAcceptedNodes.All(oracle.IsAcceptedUsingOracle);
			var b2 = SelectUppermostNodes(anotherUppermostSeedAcceptedNodes)
					.Any(e => !uppermostSeedAcceptedNodes.Contains(e));
			var b3 = uppermostSeedAcceptedNodes.Count != anotherUppermostSeedAcceptedNodes.Count;
			Console.WriteLine("Initial: " + String.Join(", ", oracle.OracleNames));
			Console.WriteLine("Learned: " + String.Join(", ", SelectedNodeNames));
			if (b1 || b2 || b3) {
				Console.WriteLine("--------------------------------------------------");
				foreach (var e in uppermostSeedAcceptedNodes) {
					Console.WriteLine(e);
				}
				Console.WriteLine("--------------------------------------------------");
				foreach (var e in anotherUppermostSeedAcceptedNodes) {
					Console.WriteLine(e);
				}
				throw new Exception("Wrong Oracle.");
			}
		}
	}
}