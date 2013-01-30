#region License

// Copyright (C) 2011-2013 Kazunori Sakamoto
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

using Antlr.Runtime;

namespace Code2Xml.Core.Antlr {
	public class XToken : IToken {
		private readonly IToken _token;

		public XToken(IToken token, string name) {
			_token = token;
			Name = name;
		}

		public string Name { private set; get; }

		#region IToken Members

		public int Type {
			get { return _token.Type; }
			set { _token.Type = value; }
		}

		public int Line {
			get { return _token.Line; }
			set { _token.Line = value; }
		}

		public int CharPositionInLine {
			get { return _token.CharPositionInLine; }
			set { _token.CharPositionInLine = value; }
		}

		public int Channel {
			get { return _token.Channel; }
			set { _token.Channel = value; }
		}

		public int StartIndex {
			get { return _token.StartIndex; }
			set { _token.StartIndex = value; }
		}

		public int StopIndex {
			get { return _token.StopIndex; }
			set { _token.StopIndex = value; }
		}

		public int TokenIndex {
			get { return _token.TokenIndex; }
			set { _token.TokenIndex = value; }
		}

		public ICharStream InputStream {
			get { return _token.InputStream; }
			set { _token.InputStream = value; }
		}

		public string Text {
			get { return _token.Text; }
			set { _token.Text = value; }
		}

		#endregion
	}
}