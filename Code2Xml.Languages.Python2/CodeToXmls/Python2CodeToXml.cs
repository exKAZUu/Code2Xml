using System.Collections.Generic;
using System.ComponentModel.Composition;
using Code2Xml.Core;
using Code2Xml.Core.CodeToXmls;

namespace Code2Xml.Languages.Python2.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class Python2CodeToXml : ExternalCodeToXml {
		private static Python2CodeToXml _instance;

		private static readonly string[] PrivateArguments = new[] {
			"ParserScripts/Python2/ast2xml.py",
		};

		private readonly string _processorPath;

		public Python2CodeToXml()
			: this(Settings.GetPythonInstallPath("2.") ?? "python")
		{ }

		public Python2CodeToXml(string processorPath) {
			_processorPath = processorPath;
		}

		public static Python2CodeToXml Instance {
			get { return _instance ?? (_instance = new Python2CodeToXml()); }
		}

		protected override string ProcessorPath {
			get { return _processorPath; }
		}

		protected override string[] Arguments {
			get { return PrivateArguments; }
		}

		public override string ParserName {
			get { return "Python2"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".py" }; }
		}
	}
}