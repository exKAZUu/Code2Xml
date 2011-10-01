using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Paraiba.Core;

namespace Code2Xml.Core.XmlToCodes {
	public abstract class ExternalXmlToCode : XmlToCode {
		protected abstract string ProcessorPath { get; }

		protected abstract string[] Arguments { get; }

		protected virtual string WorkingDirectory {
			get {
				Contract.Ensures(Contract.Result<string>() != null);
				return "";
			}
		}

		public override string Generate(XElement root) {
			var info = new ProcessStartInfo {
					FileName = ProcessorPath,
					Arguments = Arguments.JoinString(" "),
					CreateNoWindow = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					WorkingDirectory = WorkingDirectory,
			};
			using (var p = Process.Start(info)) {
				p.StandardInput.Write(root);
				p.StandardInput.Close();
				return p.StandardOutput.ReadToEnd();
			}
		}
	}
}