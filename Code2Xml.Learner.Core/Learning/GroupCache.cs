using System.Collections.Generic;
using System.Numerics;

namespace Code2Xml.Learner.Core.Learning {
	public class GroupCache {
		private readonly EncodingResult _encodingResult;
		private Dictionary<BigInteger, int> _vector2GroupIndex;

		public GroupCache(EncodingResult encodingResult, Classifier classifier) {
			_encodingResult = encodingResult;
			UpdateGroupCache(classifier);
		}

		public int GetGroupIndex(BigInteger feature) {
			return _vector2GroupIndex[feature];
		}

		public void UpdateGroupCache(Classifier classifier) {
			_vector2GroupIndex = new Dictionary<BigInteger, int>();
			foreach (var kv in _encodingResult.IdealAcceptedVector2GroupPath) {
				var index = classifier.GetGroupIndex(kv.Value);
				_vector2GroupIndex.Add(kv.Key, index);
			}
			foreach (var kv in _encodingResult.IdealRejectedVector2GroupPath) {
				var index = classifier.GetGroupIndex(kv.Value);
				_vector2GroupIndex.Add(kv.Key, index);
			}
		}
	}
}