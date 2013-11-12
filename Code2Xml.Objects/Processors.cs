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
using Code2Xml.Core.Processors;
using Code2Xml.Languages.ANTLRv3.Processors.C;
using Code2Xml.Languages.ANTLRv3.Processors.CSharp;
using Code2Xml.Languages.ANTLRv3.Processors.Java;
using Code2Xml.Languages.ANTLRv3.Processors.JavaScript;
using Code2Xml.Languages.ANTLRv3.Processors.Lua;
using Code2Xml.Languages.ANTLRv3.Processors.Php;
using Code2Xml.Languages.ExternalProcessors.Processors.Python;
using Code2Xml.Languages.ExternalProcessors.Processors.Ruby;
using Paraiba.Linq;

namespace Code2Xml.Objects {
	public class Processors {
		private static Processors _instance;

#pragma warning disable 649
		[ImportMany] private IEnumerable<Processor> _processors;
#pragma warning restore 649

		private Processors() {
			var catalog = new AggregateCatalog();
			catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
			catalog.Catalogs.Add(new DirectoryCatalog("."));
			var container = new CompositionContainer(catalog);
			container.ComposeParts(this);
		}

		private static Processors Instance {
			get { return _instance ?? (_instance = new Processors()); }
		}

		/// <summary>
		/// Gets all <c>Processor</c> instances including preset and user-added processors.
		/// </summary>
		public static IEnumerable<Processor> All {
			get { return Instance._processors.OrderBy(c => c.FullLanguageName); }
		}

		#region Preset processors

		private static CProcessorUsingAntlr3 _cUsingAntlr3;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset C processor using ANTLR 3.
		/// </summary>
		public static CProcessorUsingAntlr3 CUsingAntlr3 {
			get {
				return _cUsingAntlr3
				       ?? (_cUsingAntlr3 = All.CastWhere<CProcessorUsingAntlr3>().First());
			}
		}

		private static CSharpProcessorUsingAntlr3 _csharpUsingAntlr3;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset C# processor using ANTLR 3.
		/// </summary>
		public static CSharpProcessorUsingAntlr3 CSharpUsingAntlr3 {
			get {
				return _csharpUsingAntlr3
				       ?? (_csharpUsingAntlr3 = All.CastWhere<CSharpProcessorUsingAntlr3>().First());
			}
		}

		private static JavaProcessorUsingAntlr3 _javaUsingAntlr3;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset Java processor using ANTLR 3.
		/// </summary>
		public static JavaProcessorUsingAntlr3 JavaUsingAntlr3 {
			get {
				return _javaUsingAntlr3
				       ?? (_javaUsingAntlr3 = All.CastWhere<JavaProcessorUsingAntlr3>().First());
			}
		}

		private static JavaScriptProcessorUsingAntlr3 _javaScriptUsingAntlr3;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset JavaScript processor using ANTLR 3.
		/// </summary>
		public static JavaScriptProcessorUsingAntlr3 JavaScriptUsingAntlr3 {
			get {
				return _javaScriptUsingAntlr3
				       ?? (_javaScriptUsingAntlr3 = All.CastWhere<JavaScriptProcessorUsingAntlr3>().First());
			}
		}

		private static LuaProcessorUsingAntlr3 _luaUsingAntlr3;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset Lua processor using ANTLR 3.
		/// </summary>
		public static LuaProcessorUsingAntlr3 LuaUsingAntlr3 {
			get {
				return _luaUsingAntlr3
				       ?? (_luaUsingAntlr3 = All.CastWhere<LuaProcessorUsingAntlr3>().First());
			}
		}

		private static PhpProcessorUsingAntlr3 _phpUsingAntlr3;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset PHP processor using ANTLR 3.
		/// </summary>
		public static PhpProcessorUsingAntlr3 PhpUsingAntlr3 {
			get {
				return _phpUsingAntlr3
				       ?? (_phpUsingAntlr3 = All.CastWhere<PhpProcessorUsingAntlr3>().First());
			}
		}

		private static Python2Processor _python2;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset Python2 processor.
		/// </summary>
		public static Python2Processor Python2 {
			get { return _python2 ?? (_python2 = All.CastWhere<Python2Processor>().First()); }
		}

		private static Python3Processor _python3;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset Python3 processor.
		/// </summary>
		public static Python3Processor Python3 {
			get { return _python3 ?? (_python3 = All.CastWhere<Python3Processor>().First()); }
		}

		private static Ruby18Processor _ruby18;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset Ruby 1.8.x processor.
		/// </summary>
		public static Ruby18Processor Ruby18 {
			get { return _ruby18 ?? (_ruby18 = All.CastWhere<Ruby18Processor>().First()); }
		}

		private static Ruby19Processor _ruby19;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset Ruby 1.9.x processor.
		/// </summary>
		public static Ruby19Processor Ruby19 {
			get { return _ruby19 ?? (_ruby19 = All.CastWhere<Ruby19Processor>().First()); }
		}

		private static Ruby20Processor _ruby20;

		/// <summary>
		/// Gets a <c>Processor</c> instance of the preset Ruby 2.0.x processor.
		/// </summary>
		public static Ruby20Processor Ruby20 {
			get { return _ruby20 ?? (_ruby20 = All.CastWhere<Ruby20Processor>().First()); }
		}

		#endregion

		/// <summary>
		/// Gets a <c>Processor</c> instance by the specified language name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static Processor GetProcessorByName(string name) {
			var lowerName = name.ToLower();
			return All.Where(ast => ast.LanguageName.ToLower().Contains(lowerName))
					.MinElementOrDefault(
							ast => Math.Abs(ast.LanguageName.Length - name.Length) * 100
							       + ast.GetType().Name.Length);
		}

		/// <summary>
		/// Gets a <c>Processor</c> instance by the specified language full name including the language version.
		/// </summary>
		/// <param name="fullName"></param>
		/// <returns></returns>
		public static Processor GetProcessorByFullName(string fullName) {
			var lowerName = fullName.ToLower();
			return All.Where(ast => ast.FullLanguageName.ToLower().Contains(lowerName))
					.MinElementOrDefault(
							ast => Math.Abs(ast.FullLanguageName.Length - fullName.Length) * 100
							       + ast.GetType().Name.Length);
		}

		/// <summary>
		/// Gets a <c>Processor</c> instance by the specified file path.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static Processor GetProcessorByPath(string path) {
			return GetProcessorByExtension(Path.GetExtension(path));
		}

		/// <summary>
		/// Gets a <c>Processor</c> instance by the specified file extension.
		/// </summary>
		/// <param name="extension"></param>
		/// <returns></returns>
		public static Processor GetProcessorByExtension(string extension) {
			var lowerExt = extension.ToLower();
			return All.Where(
					ast => ast.SupportedExtensions
							.Select(e => e.ToLower())
							.Contains(lowerExt))
					.MinElementOrDefault(ast => ast.GetType().Name.Length);
		}
	}
}