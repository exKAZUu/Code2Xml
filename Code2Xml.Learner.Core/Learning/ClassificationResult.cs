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

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Learner.Core.Learning {
	public class ClassificationResult {
		public readonly int WrongFeatureCount;
		public readonly int WrongElementCount;
		public readonly IList<SuspiciousNode> SuspiciousNodes;
		public readonly IList<BigInteger> WronglyAcceptedFeatures;
		public readonly IList<BigInteger> WronglyRejectedFeatures;

		public ClassificationResult(
				IEnumerable<SuspiciousNode> suspiciousNodes, IEnumerable<BigInteger> wronglyAcceptedFeatures,
				IEnumerable<BigInteger> wronglyRejectedFeatures, int wrongFeatureCount, int wrongElementCount) {
			SuspiciousNodes = suspiciousNodes.ToImmutableList();
			WronglyAcceptedFeatures = wronglyAcceptedFeatures.ToImmutableList();
			WronglyRejectedFeatures = wronglyRejectedFeatures.ToImmutableList();
			WrongFeatureCount = wrongFeatureCount;
			WrongElementCount = wrongElementCount;
		}

		public IList<CstNode> GetWronglyAcceptedElements(EncodingResult result) {
			return WronglyAcceptedFeatures
					.Select(f => result.Vector2Node[f])
					.ToList();
		}

		public IList<CstNode> WronglyRejectedElements(EncodingResult result) {
			return WronglyRejectedFeatures
					.Select(f => result.Vector2Node[f])
					.ToList();
		}
	}
}