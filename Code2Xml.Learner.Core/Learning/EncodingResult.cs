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

        [NonSerialized] private IDictionary<BigInteger, CstNode> _vector2Node;

        public IDictionary<BigInteger, CstNode> Vector2Node {
            get { return _vector2Node; }
        }

        public IDictionary<BigInteger, int> Vector2Count { get; private set; }

        public EncodingResult() {
            _vector2Node = new Dictionary<BigInteger, CstNode>();
            Vector2Count = new Dictionary<BigInteger, int>();

            IdealVectorSet = new RevealedVectorSet();
            SeedVectorSet = new RevealedVectorSet();
        }

        public RevealedVectorSet CreateTrainingVectorSet() {
            return new RevealedVectorSet(
                    new Dictionary<BigInteger, string>(SeedVectorSet.Accepted),
                    new Dictionary<BigInteger, string>(SeedVectorSet.Rejected));
        }

        public EncodingResult MakeImmutable() {
            if (_vector2Node != null) {
                _vector2Node = _vector2Node.ToImmutableDictionary();
            }
            Vector2Count = Vector2Count.ToImmutableDictionary();

            IdealVectorSet.MakeImmutable();
            SeedVectorSet.MakeImmutable();
            if (IdealVectorSet.Accepted.Keys.Intersect(IdealVectorSet.Rejected.Keys).Any()) {
                throw new Exception();
            }
            if (IdealVectorSet.Accepted.Keys.Intersect(SeedVectorSet.Rejected.Keys).Any()) {
                throw new Exception("Strange!");
            }
            if (IdealVectorSet.Rejected.Keys.Intersect(SeedVectorSet.Accepted.Keys).Any()) {
                throw new Exception("Strange!");
            }
            return this;
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