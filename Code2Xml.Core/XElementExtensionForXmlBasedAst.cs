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

using System.Linq;
using System.Xml.Linq;

namespace Code2Xml.Core {
	public static class XElementExtensionForXmlBasedAst {
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
			var attr = e.Attribute(Code2XmlConstants.HiddenName);
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
								var attr = e2.Attribute(Code2XmlConstants.HiddenName);
								return attr == null ? e2.Value : attr.Value;
							});
			return string.Join("", values);
		}
	}
}