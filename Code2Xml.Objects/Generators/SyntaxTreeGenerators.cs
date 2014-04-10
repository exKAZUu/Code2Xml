#region License

// Copyright (C) 2011-2014 Kazunori Sakamoto
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

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using Code2Xml.Languages.ANTLRv3.Generators.C;
using Code2Xml.Languages.ANTLRv3.Generators.CSharp;
using Code2Xml.Languages.ANTLRv3.Generators.Java;
using Code2Xml.Languages.ANTLRv3.Generators.JavaScript;
using Code2Xml.Languages.ANTLRv3.Generators.Lua;
using Code2Xml.Languages.ANTLRv3.Generators.Php;
using Code2Xml.Languages.ExternalGenerators.Generators.Python;
using Code2Xml.Languages.ExternalGenerators.Generators.Ruby;
using Paraiba.Core;
using Paraiba.Linq;

namespace Code2Xml.Core.Generators {
    public static class SyntaxTreeGenerators {
        private class Loader {
#pragma warning disable 649
            [ImportMany] internal IEnumerable<SyntaxTreeGenerator> Processors;
#pragma warning restore 649

            internal Loader() {
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
                catalog.Catalogs.Add(new DirectoryCatalog("."));
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
        }

        private static Loader _instance;

        private static Loader Instance {
            get { return _instance ?? (_instance = new Loader()); }
        }

        /// <summary>
        /// Gets all <c>SyntaxTreeGenerator</c> instances including preset and user-added processors.
        /// </summary>
        public static IEnumerable<SyntaxTreeGenerator> All {
            get { return Instance.Processors.OrderBy(c => c.LanguageNameWithVersion); }
        }

        #region Preset CstGenerators

        private static CCstGeneratorUsingAntlr3 _cUsingAntlr3;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset C processor using ANTLR 3.
        /// </summary>
        public static CCstGeneratorUsingAntlr3 CUsingAntlr3 {
            get {
                return _cUsingAntlr3
                       ?? (_cUsingAntlr3 = All.CastWhere<CCstGeneratorUsingAntlr3>().First());
            }
        }

        private static CSharpCstGeneratorUsingAntlr3 _csharpUsingAntlr3;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset C# processor using ANTLR 3.
        /// </summary>
        public static CSharpCstGeneratorUsingAntlr3 CSharpUsingAntlr3 {
            get {
                return _csharpUsingAntlr3
                       ?? (_csharpUsingAntlr3 =
                               All.CastWhere<CSharpCstGeneratorUsingAntlr3>().First());
            }
        }

        private static JavaCstGeneratorUsingAntlr3 _javaUsingAntlr3;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Java processor using ANTLR 3.
        /// </summary>
        public static JavaCstGeneratorUsingAntlr3 JavaUsingAntlr3 {
            get {
                return _javaUsingAntlr3
                       ?? (_javaUsingAntlr3 = All.CastWhere<JavaCstGeneratorUsingAntlr3>().First());
            }
        }

        private static JavaScriptCstGeneratorUsingAntlr3 _javaScriptUsingAntlr3;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset JavaScript processor using ANTLR 3.
        /// </summary>
        public static JavaScriptCstGeneratorUsingAntlr3 JavaScriptUsingAntlr3 {
            get {
                return _javaScriptUsingAntlr3
                       ?? (_javaScriptUsingAntlr3 =
                               All.CastWhere<JavaScriptCstGeneratorUsingAntlr3>().First());
            }
        }

        private static LuaCstGeneratorUsingAntlr3 _luaUsingAntlr3;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Lua processor using ANTLR 3.
        /// </summary>
        public static LuaCstGeneratorUsingAntlr3 LuaUsingAntlr3 {
            get {
                return _luaUsingAntlr3
                       ?? (_luaUsingAntlr3 = All.CastWhere<LuaCstGeneratorUsingAntlr3>().First());
            }
        }

        private static PhpCstGeneratorUsingAntlr3 _phpUsingAntlr3;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset PHP processor using ANTLR 3.
        /// </summary>
        public static PhpCstGeneratorUsingAntlr3 PhpUsingAntlr3 {
            get {
                return _phpUsingAntlr3
                       ?? (_phpUsingAntlr3 = All.CastWhere<PhpCstGeneratorUsingAntlr3>().First());
            }
        }

        private static Python2CstGenerator _python2;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Python2 processor.
        /// </summary>
        public static Python2CstGenerator Python2 {
            get { return _python2 ?? (_python2 = All.CastWhere<Python2CstGenerator>().First()); }
        }

        private static Python3CstGenerator _python3;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Python3 processor.
        /// </summary>
        public static Python3CstGenerator Python3 {
            get { return _python3 ?? (_python3 = All.CastWhere<Python3CstGenerator>().First()); }
        }

        #endregion

        #region Preset AstGenerators

        private static Ruby18AstGenerator _ruby18;

        /// <summary>
        /// Gets a <c>AstGenerator</c> instance of the preset Ruby 1.8.x processor.
        /// </summary>
        public static Ruby18AstGenerator Ruby18 {
            get { return _ruby18 ?? (_ruby18 = All.CastWhere<Ruby18AstGenerator>().First()); }
        }

        private static Ruby19AstGenerator _ruby19;

        /// <summary>
        /// Gets a <c>AstGenerator</c> instance of the preset Ruby 1.9.x processor.
        /// </summary>
        public static Ruby19AstGenerator Ruby19 {
            get { return _ruby19 ?? (_ruby19 = All.CastWhere<Ruby19AstGenerator>().First()); }
        }

        private static Ruby20AstGenerator _ruby20;

        /// <summary>
        /// Gets a <c>AstGenerator</c> instance of the preset Ruby 2.0.x processor.
        /// </summary>
        public static Ruby20AstGenerator Ruby20 {
            get { return _ruby20 ?? (_ruby20 = All.CastWhere<Ruby20AstGenerator>().First()); }
        }

        #endregion

        /// <summary>
        /// Gets a <c>SyntaxTreeGenerator</c> instance by the specified language name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SyntaxTreeGenerator GetProcessorByName(string name) {
            var lowerName = name.Replace(" ", "").ToLower();
            return All.MaxElementOrDefault(
                    gen => lowerName.CalculateSimilarity(
                            gen.LanguageName.Replace(" ", "").ToLower()));
        }

        /// <summary>
        /// Gets a <c>SyntaxTreeGenerator</c> instance by the specified language full name including the language version.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static SyntaxTreeGenerator GetProcessorByNameWithVersion(string fullName) {
            var lowerName = fullName.Replace(" ", "").ToLower();
            return All.MaxElementOrDefault(
                    gen => lowerName.CalculateSimilarity(
                            gen.LanguageNameWithVersion.Replace(" ", "").ToLower()));
        }

        /// <summary>
        /// Gets a <c>SyntaxTreeGenerator</c> instance by the specified file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static SyntaxTreeGenerator GetProcessorByPath(string path) {
            return GetProcessorByExtension(Path.GetExtension(path));
        }

        /// <summary>
        /// Gets a <c>SyntaxTreeGenerator</c> instance by the specified file extension.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static SyntaxTreeGenerator GetProcessorByExtension(string extension) {
            var lowerExt = extension.ToLower();
            return All.Where(
                    ast => ast.SupportedExtensions.Select(e => e.ToLower())
                            .Contains(lowerExt))
                    .MinElementOrDefault(ast => ast.GetType().Name.Length);
        }
    }
}