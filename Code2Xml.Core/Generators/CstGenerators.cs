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
using Code2Xml.Core.Generators.ANTLRv3.C;
using Code2Xml.Core.Generators.ANTLRv3.CSharp;
using Code2Xml.Core.Generators.ANTLRv3.Java;
using Code2Xml.Core.Generators.ANTLRv3.JavaScript;
using Code2Xml.Core.Generators.ANTLRv3.Lua;
using Code2Xml.Core.Generators.ANTLRv3.Php;
using Code2Xml.Core.Generators.ANTLRv4.C;
using Code2Xml.Core.Generators.ANTLRv4.Clojure;
using Code2Xml.Core.Generators.ANTLRv4.ECMAScript;
using Code2Xml.Core.Generators.ANTLRv4.Erlang;
using Code2Xml.Core.Generators.ANTLRv4.GarryLua;
using Code2Xml.Core.Generators.ANTLRv4.Java;
using Code2Xml.Core.Generators.ANTLRv4.Lua;
using Code2Xml.Core.Generators.ANTLRv4.ObjectiveC;
using Code2Xml.Core.Generators.ANTLRv4.R;
using Code2Xml.Core.Generators.ANTLRv4.Smalltalk;
using Code2Xml.Core.Generators.ANTLRv4.Swift;
using Code2Xml.Core.Generators.ANTLRv4.Verilog2001;
using Code2Xml.Core.Generators.ExternalGenerators.Python;
using Paraiba.Core;
using Paraiba.Linq;

namespace Code2Xml.Core.Generators {
    public static class CstGenerators {
        private class Loader {
#pragma warning disable 649
            [ImportMany] internal IEnumerable<CstGenerator> Processors;
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
        /// Gets all <c>CstGenerator</c> instances including preset and user-added processors.
        /// </summary>
        public static IEnumerable<CstGenerator> All {
            get { return Instance.Processors.OrderBy(c => c.LanguageNameWithVersion); }
        }

        #region Preset CstGenerators using ANTLR 3

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

        #endregion

        #region Preset CstGenerators using ANTLR 4

        private static CCstGenerator _cUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset C processor using ANTLR 4.
        /// </summary>
        public static CCstGenerator C {
            get {
                return _cUsingAntlr4
                       ?? (_cUsingAntlr4 = All.CastWhere<CCstGenerator>().First());
            }
        }

        private static ClojureCstGenerator _clojureUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Clojure processor using ANTLR 4.
        /// </summary>
        public static ClojureCstGenerator Clojure {
            get {
                return _clojureUsingAntlr4
                       ?? (_clojureUsingAntlr4 = All.CastWhere<ClojureCstGenerator>().First());
            }
        }

        private static EcmaScriptCstGenerator _ecmaScriptUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset EcmaScript processor using ANTLR 4.
        /// </summary>
        public static EcmaScriptCstGenerator EcmaScript {
            get {
                return _ecmaScriptUsingAntlr4
                       ?? (_ecmaScriptUsingAntlr4 = All.CastWhere<EcmaScriptCstGenerator>().First());
            }
        }

        private static ErlangCstGenerator _erlangUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Erlang processor using ANTLR 4.
        /// </summary>
        public static ErlangCstGenerator Erlang {
            get {
                return _erlangUsingAntlr4
                       ?? (_erlangUsingAntlr4 = All.CastWhere<ErlangCstGenerator>().First());
            }
        }

        private static GarryLuaCstGenerator _garryLuaUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset GarryLua processor using ANTLR 4.
        /// </summary>
        public static GarryLuaCstGenerator GarryLua {
            get {
                return _garryLuaUsingAntlr4
                       ?? (_garryLuaUsingAntlr4 = All.CastWhere<GarryLuaCstGenerator>().First());
            }
        }

        private static JavaCstGenerator _javaUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Java processor using ANTLR 4.
        /// </summary>
        public static JavaCstGenerator Java {
            get {
                return _javaUsingAntlr4
                       ?? (_javaUsingAntlr4 = All.CastWhere<JavaCstGenerator>().First());
            }
        }

        private static LuaCstGenerator _luaUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Lua processor using ANTLR 4.
        /// </summary>
        public static LuaCstGenerator Lua {
            get {
                return _luaUsingAntlr4
                       ?? (_luaUsingAntlr4 = All.CastWhere<LuaCstGenerator>().First());
            }
        }

        private static ObjectiveCCstGenerator _objectiveCUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset ObjectiveC processor using ANTLR 4.
        /// </summary>
        public static ObjectiveCCstGenerator ObjectiveC {
            get {
                return _objectiveCUsingAntlr4
                       ?? (_objectiveCUsingAntlr4 = All.CastWhere<ObjectiveCCstGenerator>().First());
            }
        }

        private static RCstGenerator _rUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset R processor using ANTLR 4.
        /// </summary>
        public static RCstGenerator R {
            get {
                return _rUsingAntlr4
                       ?? (_rUsingAntlr4 = All.CastWhere<RCstGenerator>().First());
            }
        }

        private static SmalltalkCstGenerator _smalltalkUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Smalltalk processor using ANTLR 4.
        /// </summary>
        public static SmalltalkCstGenerator Smalltalk {
            get {
                return _smalltalkUsingAntlr4
                       ?? (_smalltalkUsingAntlr4 = All.CastWhere<SmalltalkCstGenerator>().First());
            }
        }

        private static SwiftCstGenerator _swiftUsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Swift processor using ANTLR 4.
        /// </summary>
        public static SwiftCstGenerator Swift {
            get {
                return _swiftUsingAntlr4
                       ?? (_swiftUsingAntlr4 = All.CastWhere<SwiftCstGenerator>().First());
            }
        }

        private static Verilog2001CstGenerator _verilog2001UsingAntlr4;

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance of the preset Verilog2001 processor using ANTLR 4.
        /// </summary>
        public static Verilog2001CstGenerator Verilog2001 {
            get {
                return _verilog2001UsingAntlr4
                       ?? (_verilog2001UsingAntlr4 =
                               All.CastWhere<Verilog2001CstGenerator>().First());
            }
        }

        #endregion

        #region Preset CstGenerators using external generators

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

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance by the specified language name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CstGenerator GetProcessorByName(string name) {
            var lowerName = name.Replace(" ", "").ToLower();
            return All.MaxElementOrDefault(
                    gen => lowerName.CalculateSimilarity(
                            gen.LanguageName.Replace(" ", "").ToLower()));
        }

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance by the specified language full name including the language version.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static CstGenerator GetProcessorByNameWithVersion(string fullName) {
            var lowerName = fullName.Replace(" ", "").ToLower();
            return All.MaxElementOrDefault(
                    gen => lowerName.CalculateSimilarity(
                            gen.LanguageNameWithVersion.Replace(" ", "").ToLower()));
        }

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance by the specified file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static CstGenerator GetProcessorByPath(string path) {
            return GetProcessorByExtension(Path.GetExtension(path));
        }

        /// <summary>
        /// Gets a <c>CstGenerator</c> instance by the specified file extension.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static CstGenerator GetProcessorByExtension(string extension) {
            var lowerExt = extension.ToLower();
            return All.Where(
                    ast => ast.SupportedExtensions.Select(e => e.ToLower())
                            .Contains(lowerExt))
                    .MinElementOrDefault(ast => ast.GetType().Name.Length);
        }
    }
}