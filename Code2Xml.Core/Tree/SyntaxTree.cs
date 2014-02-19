using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using Code2Xml.Core.Location;
using TreeDotNet;

namespace Code2Xml.Core.Tree
{
	/// <summary>
	/// 
	/// </summary>
	public class STNode
	{
		public Token Token { get; private set; }
		public List<Token> HiddenTokens { get; private set; }

		/// <summary>
		/// Initialzies a new instance of the Node class with a default value.
		/// The Create static method should be used instead of the constructor.
		/// </summary>
		protected STNode() {
			Prev = This;
			Next = This;
			Token = new Token();
		}

		/// <summary>
		/// Initialzies a new instance of the Node class with a default value.
		/// </summary>
		/// <returns></returns>
		public static STNode Create(string tokenText) {
			return new STNode { Value = new Token(tokenText)};
		}

		/// <summary>
		/// Initialzies a new instance of the Node class with the specified value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static STNode Create(Token value) {
			return new STNode { Value = value };
		}

		/// <summary>
		/// The casted this instance for the simplicity.
		/// </summary>
		private STNode This {
			get { return this; }
		}

		/// <summary>
		/// Gets the first sibling node or the current node.
		/// </summary>
		public STNode FirstSibling {
			get { return Parent != null ? Parent.FirstChild : This; }
		}

		/// <summary>
		/// Gets the last sibling node or the current node.
		/// </summary>
		public STNode LastSibling {
			get { return Parent != null ? Parent.FirstChild.Prev : This; }
		}

		/// <summary>
		/// Gets the first child node.
		/// </summary>
		public STNode FirstChild { get; private set; }

		/// <summary>
		/// Gets the parent node.
		/// </summary>
		public STNode Parent { get; private set; }

		/// <summary>
		/// Gets the Prev node.
		/// </summary>
		public STNode Prev { get; private set; }

		/// <summary>
		/// Gets the next node.
		/// </summary>
		public STNode Next { get; private set; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		public Token Value { get; set; }

		public STNode LastChild {
			get { return FirstChild == null ? null : FirstChild.Prev; }
		}

		public IEnumerable<STNode> Children {
			get {
				var node = FirstChild;
				if (node == null) {
					yield break;
				}
				var terminal = node;
				do {
					yield return node;
					node = node.Next;
				} while (node != terminal);
			}
		}

		public IEnumerable<STNode> NextAll {
			get {
				var node = Next;
				var terminal = FirstSibling;
				while (node != terminal) {
					yield return node;
					node = node.Next;
				}
			}
		}

		public IEnumerable<STNode> NextAllWithSelf {
			get {
				var node = This;
				var terminal = FirstSibling;
				do {
					yield return node;
					node = node.Next;
				} while (node != terminal);
			}
		}

		public IEnumerable<STNode> ReverseNextAll {
			get {
				var node = LastSibling;
				var terminal = This;
				while (node != terminal) {
					yield return node;
					node = node.Prev;
				}
			}
		}

		public IEnumerable<STNode> ReverseNextAllWithSelf {
			get {
				var node = FirstSibling;
				var terminal = This;
				do {
					node = node.Prev;
					yield return node;
				} while (node != terminal);
			}
		}

		public IEnumerable<STNode> PrevAll {
			get {
				var node = FirstSibling;
				var terminal = This;
				while (node != terminal) {
					yield return node;
					node = node.Next;
				}
			}
		}

		public IEnumerable<STNode> PrevAllWithSelf {
			get {
				var node = LastSibling;
				var terminal = This;
				do {
					node = node.Next;
					yield return node;
				} while (node != terminal);
			}
		}

		public IEnumerable<STNode> ReversePrevAll {
			get {
				var node = Prev;
				var terminal = LastSibling;
				while (node != terminal) {
					yield return node;
					node = node.Prev;
				}
			}
		}

		public IEnumerable<STNode> ReversePrevAllWithSelf {
			get {
				var node = This;
				var terminal = LastSibling;
				do {
					yield return node;
					node = node.Prev;
				} while (node != terminal);
			}
		}

		public STNode AddPrev(STNode node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Parent == null);
			Contract.Requires(Parent != null);
			if (Parent.FirstChild == This) {
				Parent.FirstChild = node;
			}
			return AddPrevIgnoringFirstChild(node);
		}

		public STNode AddPrev(Token value) {
			Contract.Requires(Parent != null);
			var node = Create(value);
			if (Parent.FirstChild == This) {
				Parent.FirstChild = node;
			}
			return AddPrevIgnoringFirstChild(node);
		}

		public STNode AddNext(STNode node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Parent == null);
			Contract.Requires(Parent != null);
			return This.Next.AddPrevIgnoringFirstChild(node);
		}

		public STNode AddNext(Token value) {
			Contract.Requires(Parent != null);
			return This.Next.AddPrevIgnoringFirstChild(Create(value));
		}

		public STNode AddFirst(STNode node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Parent == null);
			return AddFirstPrivate(node);
		}

		public STNode AddFirst(Token value) {
			return AddFirstPrivate(Create(value));
		}

		private STNode AddFirstPrivate(STNode node) {
			AddLastPrivate(node);
			FirstChild = node;
			return node;
		}

		private STNode AddPrevIgnoringFirstChild(STNode node) {
			node.Parent = This.Parent;
			node.Next = This;
			node.Prev = Prev;
			Prev.Next = node;
			Prev = node;
			return node;
		}

		public STNode AddLast(STNode node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Parent == null);
			return AddLastPrivate(node);
		}

		public STNode AddLast(Token value) {
			return AddLastPrivate(Create(value));
		}

		private STNode AddLastPrivate(STNode node) {
			var second = FirstChild;
			if (second == null) {
				node.Parent = This;
				node.Next = node;
				node.Prev = node;
				FirstChild = node;
			} else {
				second.AddPrevIgnoringFirstChild(node);
			}
			return node;
		}

		public override String ToString() {
			var builder = new StringBuilder();
			ToStringPrivate(This, 0, builder);
			return builder.ToString();
		}

		private static void ToStringPrivate(
				STNode node, int depth, StringBuilder builder) {
			if (node == null) {
				return;
			}
			for (int i = 0; i < depth; i++) {
				builder.Append("  ");
			}
			builder.AppendLine(node.Value.ToString());
			foreach (var child in node.Children) {
				ToStringPrivate(child, depth + 1, builder);
			}
		}
	}

	public class Token {
		public string TokenText { get; private set; }
		public CodeRange CodeRange { get; private set; }

		public int StartPos { get { return CodeRange.StartPosition; } }
		public int EndPos { get { return CodeRange.EndPosition; } }
		public int StartLine { get { return CodeRange.StartLine; } }
		public int EndLine { get { return CodeRange.EndLine; } }

		public Token() {
			TokenText = "";
		}

		public Token(string token) {
			TokenText = token;
		}

		public Token(string token, CodeRange codeRange) {
			TokenText = token;
			CodeRange = codeRange;
		}
	}
}
