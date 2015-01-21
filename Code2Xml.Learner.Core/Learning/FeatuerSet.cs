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
using Paraiba.Linq;

namespace Code2Xml.Learner.Core.Learning {
	[Serializable]
	public class FeatuerSet {
		private const int SurroundingLength = 7;

		public ISet<string> SelectedNodeNames { get; private set; }
		public IList<string> AcceptingFeatures { get; private set; }
		public IList<string> RejectingFeatures { get; private set; }

		public FeatuerSet(SeedNodeSet seedNodeSet, FeatureExtractor extractor, ILearningExperiment oracle) {
			SelectedNodeNames = seedNodeSet.SelectedNodeNames;
			AcceptingFeatures = CreateAcceptingFeatures(seedNodeSet.SeedAcceptedNodes, extractor, oracle)
					.ToImmutableList();
			RejectingFeatures = CreateRejectingFeatures(seedNodeSet.SeedRejectedNodes, extractor, oracle)
					.ToImmutableList();
		}

		public IEnumerable<CstNode> GetTargetNodes(CstNode cst) {
			return LearningExperimentUtil.GetUppermostNodesByNames(cst, SelectedNodeNames);
		}

		private IEnumerable<string> CreateRejectingFeatures(
				IEnumerable<CstNode> rejectedNodes, FeatureExtractor extractor, ILearningExperiment oracle) {
			var rejectingFeatureSet = rejectedNodes.GetUnionKeys(SurroundingLength, extractor, oracle)
					.ToHashSet();
			rejectingFeatureSet.ExceptWith(AcceptingFeatures);
			var rejectingFeatures = rejectingFeatureSet.ToList();
			rejectingFeatures.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
			return rejectingFeatures;
		}

		private static IEnumerable<string> CreateAcceptingFeatures(
				IEnumerable<CstNode> acceptedNodes, FeatureExtractor extractor, ILearningExperiment oracle) {
			var acceptingFeatures = acceptedNodes
					.GetUnionKeys(SurroundingLength, extractor, oracle)
					.Distinct()
					.ToList();
			acceptingFeatures.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
			return acceptingFeatures;
		}
	}
}