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
using System.Linq;
using System.Numerics;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Learner.Core.Learning {
    public class ExperimentalResult {
        public int WrongFeatureCount { get; set; }
        public int WrongElementCount { get; set; }

        public Dictionary<BigInteger, CstNode> FeatureVector2Element { get; private set; }
        public Dictionary<BigInteger, string> FeatureBit2Path { get; private set; }

        public List<BigInteger> WronglyAcceptedFeatures {
            get { return _wronglyAcceptedFeatures; }
        }

        public List<BigInteger> WronglyRejectedFeatures {
            get { return _wronglyRejectedFeatures; }
        }

        public IList<CstNode> WronglyAcceptedElements {
            get {
                return _wronglyAcceptedFeatures
                        .Select(f => FeatureVector2Element[f])
                        .ToList();
            }
        }

        public IList<CstNode> WronglyRejectedElements {
            get {
                return _wronglyRejectedFeatures
                        .Select(f => FeatureVector2Element[f])
                        .ToList();
            }
        }

        private readonly List<BigInteger> _wronglyAcceptedFeatures = new List<BigInteger>();

        private readonly List<BigInteger> _wronglyRejectedFeatures = new List<BigInteger>();

        public ExperimentalResult(
                Dictionary<BigInteger, CstNode> featureVector2Element,
                Dictionary<BigInteger, string> featureBit2Path) {
            FeatureVector2Element = featureVector2Element;
            FeatureBit2Path = featureBit2Path;
        }
    }
}