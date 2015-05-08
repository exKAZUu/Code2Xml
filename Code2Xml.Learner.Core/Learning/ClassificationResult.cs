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
		public readonly int WrongVectorCount;
		public readonly int WrongElementCount;
		public readonly IList<SuspiciousNode> SuspiciousNodes;
		public readonly IList<BigInteger> WronglyAcceptedVectors;
		public readonly IList<BigInteger> WronglyRejectedVectors;
		private readonly IDictionary<BigInteger, CstNode> _vector2Node;

		public IList<CstNode> WronglyAcceptedNodes {
			get {
				return WronglyAcceptedVectors
						.Select(f => _vector2Node[f])
						.ToList();
			}
		}

		public IList<CstNode> WronglyRejectedNodes {
			get {
				return WronglyRejectedVectors
						.Select(f => _vector2Node[f])
						.ToList();
			}
		}

		public ClassificationResult(
				IEnumerable<SuspiciousNode> suspiciousNodes, IEnumerable<BigInteger> wronglyAcceptedFeatures,
				IEnumerable<BigInteger> wronglyRejectedFeatures, int wrongVectorCount, int wrongElementCount,
				EncodingResult encodingResult) {
			SuspiciousNodes = suspiciousNodes != null ? suspiciousNodes.ToImmutableList() : null;
			WronglyAcceptedVectors = wronglyAcceptedFeatures.ToImmutableList();
			WronglyRejectedVectors = wronglyRejectedFeatures.ToImmutableList();
			WrongVectorCount = wrongVectorCount;
			WrongElementCount = wrongElementCount;
			_vector2Node = encodingResult.Vector2Node;
		}
	}
}