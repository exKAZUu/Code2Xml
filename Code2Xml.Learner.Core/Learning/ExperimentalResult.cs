#region License

// Copyright (C) 2011-2014 Kazunori Sakamoto
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

        public Dictionary<BigInteger, CstNode> Feature2Element {
            get { return _feature2Element; }
        }

        public List<KeyValuePair<BigInteger, string>> WronglyAcceptedFeatures {
            get { return _wronglyAcceptedFeatures; }
        }

        public List<KeyValuePair<BigInteger, string>> WronglyRejectedFeatures {
            get { return _wronglyRejectedFeatures; }
        }

        public IList<CstNode> WronglyAcceptedElements {
            get {
                return _wronglyAcceptedFeatures.Select(kv => kv.Key)
                        .Select(f => _feature2Element[f])
                        .ToList();
            }
        }

        public IList<CstNode> WronglyRejectedElements {
            get {
                return _wronglyRejectedFeatures.Select(kv => kv.Key)
                        .Select(f => _feature2Element[f])
                        .ToList();
            }
        }

        private readonly List<KeyValuePair<BigInteger, string>> _wronglyAcceptedFeatures =
                new List<KeyValuePair<BigInteger, string>>();

        private readonly List<KeyValuePair<BigInteger, string>> _wronglyRejectedFeatures =
                new List<KeyValuePair<BigInteger, string>>();

        private readonly Dictionary<BigInteger, CstNode> _feature2Element;

        public ExperimentalResult(Dictionary<BigInteger, CstNode> feature2Element) {
            _feature2Element = feature2Element;
        }
    }
}