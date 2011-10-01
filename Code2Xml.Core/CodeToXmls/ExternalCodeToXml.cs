using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Paraiba.Core;
using Paraiba.IO;

namespace Code2Xml.Core.CodeToXmls {
	[ContractClass(typeof(ExternalCodeToXmlContract))]
	public abstract class ExternalCodeToXml : CodeToXml {
		protected abstract string ProcessorPath { get; }

		protected abstract string[] Arguments { get; }

		protected virtual string WorkingDirectory {
			get {
				Contract.Ensures(Contract.Result<string>() != null);
				return "";
			}
		}

		public override XElement Generate(TextReader reader, bool throwingParseError) {
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
				p.StandardInput.WriteFromStream(reader);
				p.StandardInput.Close();
				var xml = p.StandardOutput.ReadToEnd();
				//TODO: 応急処置をやめる
				var buf = new StringBuilder(xml.Length);
				for (int i = 0; i < xml.Length; i++) {
					var c = xml[i];
					if (char.IsControl(c) && c != '\r' && c != '\n') {
						c = ' ';
					}
					buf.Append(c);
				}
				return XDocument.Parse(buf.ToString()).Root;
			}
		}
	}
}