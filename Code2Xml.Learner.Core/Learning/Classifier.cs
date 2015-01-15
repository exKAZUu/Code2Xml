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

namespace Code2Xml.Learner.Core.Learning {
	public class Classifier {
		private ISet<string> _selectedNames;

		private IDictionary<string, BigInteger> _featureString2Bit;
		private int _acceptingFeatureCount;
		private BigInteger _acceptingFeatureBitMask;
		private BigInteger _rejectingFeatureBitMask;
		private BigInteger _allFeatureBitMask;

		private List<string> _currentGroupPaths;
		private Dictionary<BigInteger, int> _vector2GroupIndex;

		public List<ClassifierUnit> Classifiers { get; set; }

		#region for Debug

		public List<List<string>> GetAllAcceptingFeatureStrings() {
			return Classifiers.Select(
					cl => LearningExperimentUtil
							.GetFeatureStringsByVector(_featureString2Bit, cl.Accepting)
							.ToList())
					.ToList();
		}

		public List<List<string>> GetAllRejectingFeatureStrings() {
			return Classifiers.Select(
					cl => LearningExperimentUtil
							.GetFeatureStringsByVector(_featureString2Bit, cl.Rejecting)
							.ToList())
					.ToList();
		}

		public string GetClassifierSummary(IReadOnlyList<ClassifierUnit> classifiers) {
			return "AP: "
			       + string.Join(
					       ", ", classifiers.Select(c => LearningExperimentUtil.CountBits(c.Accepting)))
			       + ", RP: "
			       + string.Join(
					       ", ",
					       classifiers.Select(
							       c => LearningExperimentUtil.CountRejectingBits(c.Rejecting, _acceptingFeatureCount)));
		}

		#endregion
	}
}