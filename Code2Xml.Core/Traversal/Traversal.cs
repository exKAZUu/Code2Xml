using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Code2Xml.Core.Traversal
{
	public static class Traversal
	{
		public static HashSet<string> GetSurroundingKeys(
				this XElement element, int length, bool inner = true, bool outer = true) {
			//inner = outer = true;

			var ret = new HashSet<string>();
			var childElements = new List<Tuple<XElement, string>>();
			if (inner) {
				childElements.Add(Tuple.Create(element, element.Name()));
				var ancestorStr = "";
				foreach (var e in element.AncestorsOfOnlyChildAndSelf()) {
					ancestorStr = ancestorStr + "<" + e.NameWithId();
					ret.Add(ancestorStr);
				}
			}
			var i = 1;
			if (outer) {
				var parentElement = Tuple.Create(element, element.Name());
				var descendantStr = "";
				foreach (var e in element.DescendantsOfOnlyChildAndSelf()) {
					descendantStr = descendantStr + "<" + e.NameWithId();
					ret.Add(descendantStr);
				}
				// 自分自身の位置による区別も考慮する
				ret.Add(element.NameOrTokenWithId());
				for (; i <= length; i++) {
					var newChildElements = new List<Tuple<XElement, string>>();
					foreach (var t in childElements.Where(t2 => !t2.Item1.IsTokenSet())) {
						foreach (var e in t.Item1.Elements()) {
							var key = t.Item2 + ">" + e.NameOrTokenWithId();
							newChildElements.Add(Tuple.Create(e, key));
							// トークンが存在するかチェックする弱い条件
							// for Preconditions.checkArguments()
							ret.Add(t.Item2 + ">'" + e.TokenText() + "'");
						}
						foreach (var e in t.Item1.Descendants().Where(e => e.IsTokenSet())) {
							// トークンが存在するかチェックする弱い条件
							//ret.Add(t.Item2 + ">>'" + e.TokenText() + "'");
						}
					}
					foreach (var e in parentElement.Item1.Siblings(10)) {
						var key = parentElement.Item2 + "-" + e.NameOrTokenWithId();
						newChildElements.Add(Tuple.Create(e, key));
						// トークンが存在するかチェックする弱い条件
						// for Preconditions.checkArguments()
						ret.Add(parentElement.Item2 + "-'" + e.TokenText() + "'");
						//// 先祖に存在するかチェックする弱い条件
						//var iLastName = parentElement.Item2.LastIndexOf("<");
						//var weakKey = "<<" + parentElement.Item2.Substring(iLastName + 1) + "-" + e.NameOrTokenWithId();
						//newChildElements.Add(Tuple.Create(e, weakKey));
					}
					ret.UnionWith(newChildElements.Select(t => t.Item2));
					childElements = newChildElements;

					var newParentElement = parentElement.Item1.Parent;
					if (newParentElement == null) {
						break;
					}
					parentElement = Tuple.Create(
							newParentElement,
							parentElement.Item2 + "<" + newParentElement.NameOrTokenWithId());
					ret.Add(parentElement.Item2);
				}
			}
			for (; i <= length; i++) {
				var newChildElements = new List<Tuple<XElement, string>>();
				foreach (var t in childElements.Where(t2 => !t2.Item1.IsTokenSet())) {
					foreach (var e in t.Item1.Elements()) {
						var key = t.Item2 + ">" + e.NameOrTokenWithId();
						newChildElements.Add(Tuple.Create(e, key));
						// トークンが存在するかチェックする弱い条件
						// for Preconditions.checkArguments()
						ret.Add(t.Item2 + ">'" + e.TokenText() + "'");
					}
				}
				ret.UnionWith(newChildElements.Select(t => t.Item2));
				childElements = newChildElements;
			}
			return ret;
		}
	}
}
