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
using Code2Xml.Languages.ANTLRv3.Processors.Java;
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

        public static IEnumerable<Processor> All {
            get { return Instance._processors.OrderBy(c => c.FullLanguageName); }
        }

        private static JavaProcessorUsingAntlr3 _javaUsingAntlr3;
        public static JavaProcessorUsingAntlr3 JavaUsingAntlr3 {
            get { return _javaUsingAntlr3 ?? (_javaUsingAntlr3 = All.Cast<JavaProcessorUsingAntlr3>().First()); }
        }

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