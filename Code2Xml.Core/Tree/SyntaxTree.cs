using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeDotNet;

namespace Code2Xml.Core.Tree
{
	/// <summary>
	/// 
	/// </summary>
	public class STNode : Node<STNode, STNodeCore>
	{
	}

	public struct STNodeCore {
		public STToken Token;
		public List<STToken> HiddenTokens;
	}

	public struct STToken {
		public string Token;
		public int StartPos;
		public int EndPos;
		public int StartLine;
		public int EndLine;
	}
}
