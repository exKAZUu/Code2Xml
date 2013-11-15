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
using System.Linq;
using System.Xml.Linq;
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
    public static class XmlBasedAstManipulator {
        public static bool IsTokenSet(this XElement e) {
            return e.LastElementOrDefault().IsToken();
        }

        public static bool IsToken(this XElement e) {
            return e.Name() == Code2XmlConstants.TokenElementName;
        }

        public static bool IsHidden(this XElement e) {
            return e.Attribute(Code2XmlConstants.HiddenAttributeName) != null;
        }

        public static IEnumerable<XElement> PreviousHiddens(this XElement tokenElement) {
            var tokens = tokenElement.Descendants(Code2XmlConstants.TokenElementName);
            foreach (var token in tokens) {
                return token.ElementsBeforeSelf();
            }
            return Enumerable.Empty<XElement>();
        }

        public static IEnumerable<XElement> NextHiddens(this XElement element) {
            var tokens = element.AllAfterSelf()
                    .DescendantsAndSelf(Code2XmlConstants.TokenElementName);
            foreach (var token in tokens) {
                return token.ElementsBeforeSelf();
            }
            return Enumerable.Empty<XElement>();
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
        public static string TokenText(this XElement e) {
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
        public static string HiddenText(this XElement e) {
            if (e == null) {
                return null;
            }
            var texts = e.DescendantsAndSelf()
                    .Where(e2 => !e2.HasElements)
                    .Select(e2 => e2.Attribute(Code2XmlConstants.HiddenAttributeName))
                    .Where(attr => attr != null)
                    .Select(attr => attr.Value);
            return string.Join("", texts);
        }

        /// <summary>
        /// Returns conbined all tokens and all hidden tokens which the specified node contains.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string Text(this XElement e) {
            if (e == null) {
                return null;
            }
            var texts = e.DescendantsAndSelf()
                    .Where(e2 => !e2.HasElements)
                    .Select(
                            e2 => {
                                var attr = e2.Attribute(Code2XmlConstants.HiddenAttributeName);
                                return attr == null ? e2.Value : attr.Value;
                            });
            return string.Join("", texts);
        }

        public static IEnumerable<XElement> AllAfterSelf(this XElement element) {
            while (element != null) {
                foreach (var e in element.ElementsAfterSelf()) {
                    yield return e;
                }
                element = element.Parent;
            }
        }

        public static IEnumerable<XElement> AllAfterSelf(this XElement element, XName name) {
            while (element != null) {
                foreach (var e in element.ElementsAfterSelf(name)) {
                    yield return e;
                }
                element = element.Parent;
            }
        }
    }
}