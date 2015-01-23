﻿#region License

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
using System.IO;
using System.Linq;
using System.Numerics;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Learner.Core.Learning {
	[Serializable]
	public class EncodingResult {
		public int SeedNodeCount { get; set; }
		public int SeedAcceptedNodeCount { get; set; }

		public int SeedVectorCount {
			get { return SeedVectorSet.Count; }
		}

		public int VectorCount {
			get { return IdealVectorSet.Count; }
		}

		public readonly RevealedVectorSet IdealVectorSet;
		public readonly RevealedVectorSet SeedVectorSet;

		public IDictionary<BigInteger, string> IdealAcceptedVector2GroupPath {
			get { return IdealVectorSet.Accepted; }
		}

		public IDictionary<BigInteger, string> IdealRejectedVector2GroupPath {
			get { return IdealVectorSet.Rejected; }
		}

		public IDictionary<BigInteger, string> SeedAcceptedVector2GroupPath {
			get { return SeedVectorSet.Accepted; }
		}

		public IDictionary<BigInteger, string> SeedRejectedVector2GroupPath {
			get { return SeedVectorSet.Rejected; }
		}

		public IDictionary<BigInteger, string> Vector2GroupPath { get; private set; }
		public IDictionary<BigInteger, CstNode> Vector2Node { get; private set; }
		public IDictionary<BigInteger, int> Vector2Count { get; private set; }
		public IDictionary<BigInteger, string> Vector2Path { get; private set; }

		public EncodingResult() {
			Vector2GroupPath = new Dictionary<BigInteger, string>();
			Vector2Node = new Dictionary<BigInteger, CstNode>();
			Vector2Count = new Dictionary<BigInteger, int>();
			Vector2Path = new Dictionary<BigInteger, string>();

			IdealVectorSet = new RevealedVectorSet();
			SeedVectorSet = new RevealedVectorSet();
		}

		public RevealedVectorSet CreateTrainingVectorSet() {
			return new RevealedVectorSet(
					new Dictionary<BigInteger, string>(SeedVectorSet.Accepted),
					new Dictionary<BigInteger, string>(SeedVectorSet.Rejected));
		}

		public void MakeImmutable() {
			Vector2GroupPath = Vector2GroupPath.ToImmutableDictionary();
			Vector2Node = Vector2Node.ToImmutableDictionary();
			Vector2Count = Vector2Count.ToImmutableDictionary();
			Vector2Path = Vector2Path.ToImmutableDictionary();

			IdealVectorSet.MakeImmutable();
			SeedVectorSet.MakeImmutable();
		}

		public void WriteResult(StreamWriter writer, RevealedVectorSet trainingSet = null) {
			if (writer == null) {
				return;
			}
			trainingSet = trainingSet ?? new RevealedVectorSet();
			writer.Write(IdealAcceptedVector2GroupPath.Concat(IdealRejectedVector2GroupPath)
					.Sum(f => Vector2Count[f.Key]));
			writer.Write(",");
			writer.Write(trainingSet.Accepted.Concat(trainingSet.Rejected)
					.Sum(f => Vector2Count[f.Key]));
			writer.Write(",");
			writer.Write(IdealVectorSet.Count);
			writer.Write(",");
			writer.Write(trainingSet.Count);
			writer.Write(",");
			writer.Write(SeedNodeCount);
			writer.Write(",");
			writer.Write(SeedVectorCount);
			writer.Write(",");
			writer.Write(SeedAcceptedNodeCount);
			writer.Write(",");
		}
	}
}