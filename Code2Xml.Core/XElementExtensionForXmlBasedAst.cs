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

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Linq;
using Paraiba.Xml.Linq;

namespace Code2Xml.Core {
	/// <summary>
	/// Here is a sample xml structure.
	/// The TOKEN element is a neccessary tokens representing code.
	/// The WS and COMMENT elements are hidden tokens such as spaces and comments.
	/// The IDENTIFIER element is a set of neccessary and hidden tokens and indicates the name of the TOKEN element.
	/// We call elements like TOKEN tokens, ones like WS and COMMENT hiddens and ones like IDENTIFIER token sets.
	/// 
	/// &lt;IDENTIFIER&gt;
	///   &lt;WS&gt;&lt;/WS&gt;
	///   &lt;COMMENT&gt;&lt;/COMMENT&gt;
	///   &lt;TOKEN&gt;&lt;/TOKEN&gt;
	/// &lt;/IDENTIFIER&gt;
	/// </summary>
	public static class XElementExtensionForXmlBasedAst {
		public static bool IsTokenSet(this XElement e) {
			return e.LastElementOrDefault().Name() == Code2XmlConstants.TokenElementName;
		}

		public static bool IsToken(this XElement e) {
			return e.Name() == Code2XmlConstants.TokenElementName;
		}

		public static bool IsHidden(this XElement e) {
			return e.Attribute(Code2XmlConstants.HiddenAttributeName) != null;
		}

		public static IEnumerable<XElement> BeforeHiddens(this XElement tokenElement) {
			Contract.Requires(tokenElement.IsTokenSet());
			return tokenElement.Elements().SkipLast();
		}

		/// <summary>
		/// Returns 
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public static string Name(this XElement e) {
			if (e == null) {
				return null;
			}
			return e.Name.LocalName;
		}

		/// <summary>
		/// Returns combined all tokens which the specified node contains.
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public static string Token(this XElement e) {
			if (e == null) {
				return null;
			}
			return e.Value;
		}

		/// <summary>
		/// Returns combined all tokens or a hidden token.
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public static string TokenOrHidden(this XElement e) {
			if (e == null) {
				return null;
			}
			var attr = e.Attribute(Code2XmlConstants.HiddenAttributeName);
			return attr == null ? e.Value : attr.Value;
		}

		/// <summary>
		/// Returns conbined all tokens and all hidden tokens which the specified node contains.
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		public static string TokenWithHiddens(this XElement e) {
			if (e == null) {
				return null;
			}
			var values = e.DescendantsAndSelf()
					.Where(e2 => !e2.HasElements)
					.Select(
							e2 => {
								var attr = e2.Attribute(Code2XmlConstants.HiddenAttributeName);
								return attr == null ? e2.Value : attr.Value;
							});
			return string.Join("", values);
		}
	}
}