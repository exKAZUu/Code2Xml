using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Learner.Core.Learning
{
	[Serializable]
	public class EncodingResult
	{
		private Dictionary<BigInteger, string> _idealAcceptedVector2GroupPath;
		private Dictionary<BigInteger, string> _idealRejectedVector2GroupPath;
		private Dictionary<BigInteger, string> _trainingAcceptedVector2GroupPath;
		private Dictionary<BigInteger, string> _trainingRejectedVector2GroupPath;

		private Dictionary<BigInteger, CstNode> _vector2Node;
		private Dictionary<BigInteger, int> _vector2Count;
		private Dictionary<BigInteger, string> _vector2Path;
	}
}
