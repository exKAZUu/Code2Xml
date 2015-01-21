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
using System.Linq;
using System.Numerics;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.SyntaxTree;
using Paraiba.Collections.Generic;

namespace Code2Xml.Learner.Core.Learning {
	public class Classifier {
		public ISet<string> SelectedNodeNames { get; private set; }

		private Dictionary<BigInteger, string> _trainingAcceptedVector2GroupPath;
		private Dictionary<BigInteger, string> _trainingRejectedVector2GroupPath;


		private int _acceptingFeatureCount;
		private BigInteger _acceptingFeatureBitMask;
		private BigInteger _rejectingFeatureBitMask;
		private BigInteger _allFeatureBitMask;

		private List<string> _currentGroupPaths;

		public List<ClassifierUnit> Classifiers { get; set; }

		public Classifier(FeatuerSet featureSet) {
			_acceptingFeatureCount = featureSet.AcceptingFeatures.Count;

			_allFeatureBitMask = (BigInteger.One << _featureString2Bit.Count) - BigInteger.One;
			_acceptingFeatureBitMask = (BigInteger.One << acceptingFeatures.Count) - BigInteger.One;
			_rejectingFeatureBitMask = _allFeatureBitMask ^ _acceptingFeatureBitMask;
		}

		#region for Debug

		public List<List<string>> GetAllAcceptingFeatureStrings() {
			return Classifiers.Select(
					cl => LearningExperimentUtil.GetFeatureStringsByVector(_featureString2Bit, cl.Accepting)
							.ToList())
					.ToList();
		}

		public List<List<string>> GetAllRejectingFeatureStrings() {
			return Classifiers.Select(
					cl => LearningExperimentUtil.GetFeatureStringsByVector(_featureString2Bit, cl.Rejecting)
							.ToList())
					.ToList();
		}

		public string GetClassifierSummary(IReadOnlyList<ClassifierUnit> classifiers) {
			return "AP: "
			       + String.Join(
					       ", ", classifiers.Select(c => LearningExperimentUtil.CountBits(c.Accepting)))
			       + ", RP: "
			       + String.Join(
					       ", ",
					       classifiers.Select(
							       c => LearningExperimentUtil.CountRejectingBits(c.Rejecting, _acceptingFeatureCount)));
		}

		#endregion
	}
}