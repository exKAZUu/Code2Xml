#region License

// Copyright (C) 2011-2015 Kazunori Sakamoto
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

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Learner.Core.Learning {
	[Serializable]
	public class FeatureExtractor {
		public FeatureExtractor() {
			IsInner = true;
		}

		public bool IsInner { get; set; }

		public virtual string GetToken(CstNode e) {
			if (e.TokenText.Length == 1) {
				var ch = e.TokenText[0];
				if (Char.IsDigit(ch)) {
					return "0";
				}
				if (Char.IsLetter(ch)) {
					return "i";
				}
			}
			return e.TokenText;
		}

		public static FeatureExtractor BuildBySeedNodes(
				ICollection<CstNode> nodes, ICollection<string> codes) {
			Contract.Requires<ArgumentException>(nodes.Count == codes.Count);

			int maxUp = 0, maxDown = 0, maxLeft = 0, maxRight = 0;
			var isInner = true;

			foreach (var nodeAndCode in nodes.Zip(codes, Tuple.Create)) {
				var node = nodeAndCode.Item1;
				var code = nodeAndCode.Item2.Trim();

				var ancestorAndIndex = node.AncestorsAndSelf()
						.Select(Tuple.Create<CstNode, int>)
						.First(nodeAndIndex => nodeAndIndex.Item1.Code.Contains(code));
				var ancestor = ancestorAndIndex.Item1;
				var index = ancestorAndIndex.Item2;

				maxUp = Math.Max(maxUp, index);
				maxDown = Math.Max(maxUp, ancestor.LengthFromDeepestChild);

				if (index > 0) {
					isInner = false;
					var children = ancestor.Children().ToList();
					var left = 0;
					var right = children.Count - 1;
					while (children.Skip(left + 1).Code().Contains(code)) {
						left++;
					}
					while (children.Skip(left).Take(right - left).Code().Contains(code)) {
						right--;
					}

					var leftCount = node.AncestorsAndSelf()
							.ElementAt(index - 1)
							.PrevsFromFirst()
							.Count();
					maxLeft = Math.Max(maxLeft, leftCount - left);
					maxRight = Math.Max(maxRight, right - leftCount);
				}
			}
			return isInner ? new FeatureExtractor() : new FeatureExtractor();
		}
	}

	public class PhpFeatureExtractor : FeatureExtractor {
	    public override string GetToken(CstNode e) {
			return base.GetToken(e).ToLower();
		}
	}
}