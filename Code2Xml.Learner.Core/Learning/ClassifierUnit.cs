using System;
using System.Numerics;

namespace Code2Xml.Learner.Core.Learning {
    [Serializable]
    public class ClassifierUnit {
        public BigInteger Accepting;
        public BigInteger Rejecting;

        public ClassifierUnit(BigInteger accepting, BigInteger rejecting) {
            Accepting = accepting;
            Rejecting = rejecting;
        }

        public ClassifierUnit Clone() {
            return new ClassifierUnit(Accepting, Rejecting);
        }

        protected bool Equals(ClassifierUnit other) {
            return Accepting.Equals(other.Accepting) && Rejecting.Equals(other.Rejecting);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((ClassifierUnit)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (Accepting.GetHashCode() * 397) ^ Rejecting.GetHashCode();
            }
        }
    }
}