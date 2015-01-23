using System.Collections.Generic;
using System.Collections.Immutable;
using System.Numerics;

namespace Code2Xml.Learner.Core.Learning {
	public class RevealedVectorSet {
		public IDictionary<BigInteger, string> Accepted { get; private set; }
		public IDictionary<BigInteger, string> Rejected { get; private set; }

		public int AcceptedCount {
			get { return Accepted.Count; }
		}

		public int RejectedCount {
			get { return Rejected.Count; }
		}

		public int Count {
			get { return AcceptedCount + RejectedCount; }
		}

		public RevealedVectorSet()
				: this(new Dictionary<BigInteger, string>(), new Dictionary<BigInteger, string>()) {}

		public RevealedVectorSet(
				IDictionary<BigInteger, string> accepted,
				IDictionary<BigInteger, string> rejected) {
			Accepted = accepted;
			Rejected = rejected;
		}

		public void MakeImmutable() {
			Accepted = Accepted.ToImmutableDictionary();
			Rejected = Rejected.ToImmutableDictionary();
		}
	}
}