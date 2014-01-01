using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Antlr.Runtime;

namespace Code2Xml.Languages.ANTLRv3.Processors.CSharp {
	/// <summary> PreProcessor
	///   The lexer preprocesses the CSharp code.
	/// </summary>
	public class csLexerWithPreProcessor : csLexer {
		// if there's an #if / #else mismatch, don't complain every token :)
		private bool _warn = true;

		public csLexerWithPreProcessor(ICharStream stream, IEnumerable<string> defines) : base(stream) {
			// By default we are preprocessing input
			Processing.Push(true);

			// Grab what's defined from the command line
			MacroDefines.UnionWith(defines);
		}

		public csLexerWithPreProcessor(ICharStream stream) : this(stream, Enumerable.Empty<string>()) {}

		public override void mTokens() {
			base.mTokens();
			// if we aren't processing, skip this token
			// if the Count is 0, we are in a bad state.
			if (Processing.Count > 0) {
				if (!Processing.Peek()) {
					state.channel = Hidden;
				}
			} else if (_warn) {
				// Don't warn every token
				_warn = false;
				Debug.Assert(Processing.Count > 0, "Stack underflow preprocessing.  mTokens");
				Console.WriteLine("Found unexpected else.");
			}
		}
	}
}