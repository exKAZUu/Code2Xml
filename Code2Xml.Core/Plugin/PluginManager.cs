﻿#region License

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
using System.Linq;
using System.Reflection;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.Processors;
using Code2Xml.Core.XmlToCodes;
using Paraiba.Linq;

namespace Code2Xml.Core.Plugin {
	public class PluginManager {
		private static PluginManager _instance;

#pragma warning disable 649
		[ImportMany] private IEnumerable<CodeToXml> _codeToXmls;
		[ImportMany] private IEnumerable<XmlToCode> _xmlToCodes;
		[ImportMany] private IEnumerable<LanguageProcessor> _processors;
#pragma warning restore 649

		private PluginManager() {
			var catalog = new AggregateCatalog();
			catalog.Catalogs.Add(
					new AssemblyCatalog(Assembly.GetExecutingAssembly()));
			catalog.Catalogs.Add(new DirectoryCatalog("."));
			//catalog.Catalogs.Add(new DirectoryCatalog("Extensions"));
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

		public static IEnumerable<LanguageProcessor> Processors {
			get {
				return Instance._processors
						.OrderBy(c => c.FullLanguageName);
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

		/// <summary>
		/// Gets a <c>LanguageProcessor</c> instance by the specified language name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static LanguageProcessor GetProcessorByName(string name) {
			var lowerName = name.ToLower();
			return Processors
					.Where(ast => ast.LanguageName.ToLower().Contains(lowerName))
					.MinElementOrDefault(
							ast => Math.Abs(ast.LanguageName.Length - name.Length));
		}

		/// <summary>
		/// Gets a <c>LanguageProcessor</c> instance by the specified language full name including the language version.
		/// </summary>
		/// <param name="fullName"></param>
		/// <returns></returns>
		public static LanguageProcessor GetProcessorByFullName(string fullName) {
			var lowerName = fullName.ToLower();
			return Processors
					.Where(ast => ast.FullLanguageName.ToLower().Contains(lowerName))
					.MinElementOrDefault(
							ast => Math.Abs(ast.FullLanguageName.Length - fullName.Length));
		}

		/// <summary>
		/// Gets a <c>LanguageProcessor</c> instance by the specified file extension.
		/// </summary>
		/// <param name="extension"></param>
		/// <returns></returns>
		public static LanguageProcessor GetProcessorByExtension(string extension) {
			var lowerExt = extension.ToLower();
			return Processors
					.FirstOrDefault(
							ast => ast.SupportedExtensions
									.Select(e => e.ToLower())
									.Contains(lowerExt));
		}
	}
}