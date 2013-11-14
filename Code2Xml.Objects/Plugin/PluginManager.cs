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

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.XmlToCodes;
using Paraiba.Linq;

namespace Code2Xml.Core.Plugin {
	/// <summary>
	/// Please use <see cref="ProcessorLoader"/> class.
	/// </summary>
	[Obsolete]
	public class PluginManager {
		private static PluginManager _instance;

#pragma warning disable 649
		[ImportMany] private IEnumerable<CodeToXml> _codeToXmls;
		[ImportMany] private IEnumerable<XmlToCode> _xmlToCodes;
#pragma warning restore 649

		private PluginManager() {
			var catalog = new AggregateCatalog();
			catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
			catalog.Catalogs.Add(new DirectoryCatalog("."));
			var container = new CompositionContainer(catalog);
			container.ComposeParts(this);
		}

		private static PluginManager Instance {
			get { return _instance ?? (_instance = new PluginManager()); }
		}

		public static IEnumerable<CodeToXml> CodeToXmls {
			get {
				return Instance._codeToXmls
						.OrderBy(a => a.ParserName);
			}
		}

		public static IEnumerable<XmlToCode> XmlToCodes {
			get {
				return Instance._xmlToCodes
						.OrderBy(c => c.ParserName);
			}
		}

		public static CodeToXml GetCodeToXmlByName(string name) {
			var lowerName = name.ToLower();
			return CodeToXmls
					.Where(ast => ast.ParserName.ToLower().Contains(lowerName))
					.MinElementOrDefault(
							ast => Math.Abs(ast.ParserName.Length - name.Length));
		}

		public static CodeToXml GetCodeToXmlByExtension(string ext) {
			var lowerExt = ext.ToLower();
			return CodeToXmls
					.FirstOrDefault(
							ast => ast.TargetExtensions
									.Select(e => e.ToLower())
									.Contains(lowerExt));
		}

		public static CodeToXml GetCodeToXmlByPath(string path) {
			return GetCodeToXmlByExtension(Path.GetExtension(path));
		}

		public static XmlToCode GetXmlToCodeByName(string name) {
			var lowerName = name.ToLower();
			return XmlToCodes
					.Where(
							code =>
									code.ParserName.ToLower().Contains(lowerName))
					.MinElementOrDefault(
							code =>
									Math.Abs(code.ParserName.Length - name.Length));
		}

		public static XmlToCode GetXmlToCodeByExtension(string ext) {
			var lowerExt = ext.ToLower();
			return XmlToCodes
					.FirstOrDefault(
							ast => ast.DefaultExtension.ToLower() == lowerExt);
		}

		public static XmlToCode GetXmlToCodeByPath(string path) {
			return GetXmlToCodeByExtension(Path.GetExtension(path));
		}
	}
}