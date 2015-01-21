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
using System.Numerics;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Learner.Core.Learning {
	[Serializable]
	public class EncodingResult {
		public int SeedAbstractCount { get; set; }

		public IDictionary<BigInteger, string> Vector2GroupPath { get; private set; }
		public IDictionary<BigInteger, string> IdealAcceptedVector2GroupPath { get; private set; }
		public IDictionary<BigInteger, string> IdealRejectedVector2GroupPath { get; private set; }
		public IDictionary<BigInteger, string> SeedAcceptedVector2GroupPath { get; private set; }
		public IDictionary<BigInteger, string> SeedRejectedVector2GroupPath { get; private set; }

		public IDictionary<BigInteger, CstNode> Vector2Node { get; private set; }
		public IDictionary<BigInteger, int> Vector2Count { get; private set; }
		public IDictionary<BigInteger, string> Vector2Path { get; private set; }

		public EncodingResult() {
			SeedAbstractCount = 0;

			Vector2GroupPath = new Dictionary<BigInteger, string>();
			IdealAcceptedVector2GroupPath = new Dictionary<BigInteger, string>();
			IdealRejectedVector2GroupPath = new Dictionary<BigInteger, string>();
			SeedAcceptedVector2GroupPath = new Dictionary<BigInteger, string>();
			SeedRejectedVector2GroupPath = new Dictionary<BigInteger, string>();

			Vector2Node = new Dictionary<BigInteger, CstNode>();
			Vector2Count = new Dictionary<BigInteger, int>();
			Vector2Path = new Dictionary<BigInteger, string>();
		}

		public void MakeImmutable() {
			Vector2GroupPath = Vector2GroupPath.ToImmutableDictionary();
			IdealAcceptedVector2GroupPath = IdealAcceptedVector2GroupPath.ToImmutableDictionary();
			IdealRejectedVector2GroupPath = IdealRejectedVector2GroupPath.ToImmutableDictionary();
			SeedAcceptedVector2GroupPath = SeedAcceptedVector2GroupPath.ToImmutableDictionary();
			SeedRejectedVector2GroupPath = SeedRejectedVector2GroupPath.ToImmutableDictionary();

			Vector2Node = Vector2Node.ToImmutableDictionary();
			Vector2Count = Vector2Count.ToImmutableDictionary();
			Vector2Path = Vector2Path.ToImmutableDictionary();
		}
	}
}