using System.Collections.Generic;
using System.ComponentModel.Composition;
using Code2Xml.Core;
using Code2Xml.Core.CodeToXmls;

namespace Code2Xml.Languages.Python3.CodeToXmls {
	[Export(typeof(CodeToXml))]
	public class Python3CodeToXml : ExternalCodeToXml {
		private static Python3CodeToXml _instance;

		private static readonly string[] PrivateArguments = new[] {
			"ParserScripts/Python3/st2xml.py",
		};

		private readonly string _processorPath;

		public Python3CodeToXml()
			: this(Settings.GetPythonInstallPath("3.") ?? "python")
		{ }

		public Python3CodeToXml(string processorPath) {
			_processorPath = processorPath;
		}

		public static Python3CodeToXml Instance {
			get { return _instance ?? (_instance = new Python3CodeToXml()); }
		}

		protected override string ProcessorPath {
			get { return _processorPath; }
		}

		protected override string[] Arguments {
			get { return PrivateArguments; }
		}

		public override string ParserName {
			get { return "Python3"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".py" }; }
		}
	}
}