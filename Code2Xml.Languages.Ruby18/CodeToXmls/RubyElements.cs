using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Code2Xml.Languages.Ruby18.CodeToXmls {
	public static class RubyElements {
		public static IEnumerable<XElement> Class(XElement root) {
			return root.Descendants("class");
		}

		public static IEnumerable<XElement> SingularClass(XElement root) {
			return root.Descendants("sclass");
		}

		public static IEnumerable<XElement> Module(XElement root) {
			return root.Descendants("module");
		}

		public static IEnumerable<XElement> Method(XElement root) {
			return root.Descendants("defn");
		}

		public static IEnumerable<XElement> Case(XElement root) {
			return root.Descendants("case");
		}

		public static IEnumerable<XElement> When(XElement element) {
			return element.Elements("when");
		}

		public static XElement CaseElse(XElement element) {
			return element.Elements().Last();
		}

		public static IEnumerable<XElement> If(XElement root) {
			return root.Descendants("if");
		}

		public static XElement IfCondition(XElement element) {
			return element.Elements().First();
		}

		public static XElement IfProcess(XElement element) {
			return element.Elements().ElementAt(1);
		}

		public static XElement ElseProcess(XElement element) {
			return element.Elements().ElementAt(2);
		}

		public static IEnumerable<XElement> For(XElement root) {
			return root.Descendants("for");
		}

		public static IEnumerable<XElement> SimpleFor(XElement root) {
			return For(root)
				.Where(e => e.Elements().Count() == 2);
		}

		public static XElement ForSource(XElement element) {
			return element.Elements().First();
		}

		public static XElement ForVariable(XElement element) {
			return element.Elements().ElementAt(1);
		}

		public static XElement ForProcessBefore(XElement element) {
			return ForVariable(element);
		}

		public static XElement ForProcess(XElement element) {
			return element.Elements().ElementAtOrDefault(2);
		}

		public static IEnumerable<XElement> WhileUntil(XElement root) {
			return root.Descendants("until");
		}

		public static XElement WhileUntilCondition(XElement element) {
			return element.Elements().First();
		}

		public static XElement WhileUntilProcess(XElement element) {
			return element.Elements().ElementAt(1);
		}

		public static IEnumerable<XElement> Iterator(XElement root) {
			return root.Descendants("iter");
		}

		public static IEnumerable<XElement> SimpleIterator(XElement root) {
			return Iterator(root)
				.Where(e => e.Elements().Count() == 2);
		}

		public static XElement IteratorMethod(XElement element) {
			return element.Elements().First();
		}

		public static XElement IteratorVariable(XElement element) {
			return element.Elements().ElementAt(1);
		}

		public static XElement IteratorProcessBefore(XElement element) {
			return IteratorVariable(element);
		}

		public static XElement IteratorProcess(XElement element) {
			return element.Elements().ElementAtOrDefault(2);
		}
	}
}