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
using System.Linq;
using Code2Xml.Core.Location;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Linq;

namespace Code2Xml.Learner.Core.Learning {
    [Serializable]
    public class FeatuerSet {
        public IList<string> AcceptingFeatures { get; }
        public IList<string> RejectingFeatures { get; }

        public int AcceptingFeatureCount => AcceptingFeatures.Count;
        public int RejectingFeatureCount => RejectingFeatures.Count;
        public int FeatureCount => AcceptingFeatureCount + RejectingFeatureCount;

        public FeatuerSet(
                SeedNodeSet seedNodeSet, FeatureExtractor extractor,
                ICollection<SelectedFragment> acceptingFragments, ICollection<SelectedFragment> rejectingFragments) {
            AcceptingFeatures =
                    CreateAcceptingFeatures(seedNodeSet.AcceptedNodes, extractor,acceptingFragments)
                            .ToImmutableList();
            RejectingFeatures =
                    CreateRejectingFeatures(seedNodeSet.RejectedNodes, extractor,rejectingFragments)
                            .ToImmutableList();
        }

        private IEnumerable<string> CreateRejectingFeatures(
                ICollection<CstNode> rejectedNodes, FeatureExtractor extractor, ICollection<SelectedFragment> fragments) {
            var rejectingFeatureSet = rejectedNodes
                    .GetUnionKeys(fragments, extractor)
                    .ToHashSet();
            rejectingFeatureSet.ExceptWith(AcceptingFeatures);
            var rejectingFeatures = rejectingFeatureSet.ToList();
            rejectingFeatures.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
            return rejectingFeatures;
        }

        private static IEnumerable<string> CreateAcceptingFeatures(
                ICollection<CstNode> acceptedNodes, FeatureExtractor extractor, ICollection<SelectedFragment> fragments) {
            var acceptingFeatures = acceptedNodes
                    .GetUnionKeys(fragments, extractor)
                    .Distinct()
                    .ToList();
            acceptingFeatures.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
            return acceptingFeatures;
        }
    }
}