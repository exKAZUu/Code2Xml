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
using Code2Xml.Languages.ExternalGenerators.Generators.Ruby;
using Paraiba.Core;
using Paraiba.Linq;

namespace Code2Xml.Core.Generators {
    public class AstGenerators {
        private class Loader {
#pragma warning disable 649
            [ImportMany] internal IEnumerable<AstGenerator> Processors;
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
        /// Gets all <c>AstGenerator</c> instances including preset and user-added processors.
        /// </summary>
        public static IEnumerable<AstGenerator> All {
            get { return Instance.Processors.OrderBy(c => c.LanguageNameWithVersion); }
        }

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
        /// Gets a <c>AstGenerator</c> instance by the specified language name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static AstGenerator GetProcessorByName(string name) {
            var lowerName = name.Replace(" ", "").ToLower();
            return All.MaxElementOrDefault(
                    gen => lowerName.CalculateSimilarity(
                            gen.LanguageName.Replace(" ", "").ToLower()));
        }

        /// <summary>
        /// Gets a <c>AstGenerator</c> instance by the specified language full name including the language version.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static AstGenerator GetProcessorByNameWithVersion(string fullName) {
            var lowerName = fullName.Replace(" ", "").ToLower();
            return All.MaxElementOrDefault(
                    gen => lowerName.CalculateSimilarity(
                            gen.LanguageNameWithVersion.Replace(" ", "").ToLower()));
        }

        /// <summary>
        /// Gets a <c>AstGenerator</c> instance by the specified file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AstGenerator GetProcessorByPath(string path) {
            return GetProcessorByExtension(Path.GetExtension(path));
        }

        /// <summary>
        /// Gets a <c>AstGenerator</c> instance by the specified file extension.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static AstGenerator GetProcessorByExtension(string extension) {
            var lowerExt = extension.ToLower();
            return All.Where(
                    ast => ast.SupportedExtensions.Select(e => e.ToLower())
                            .Contains(lowerExt))
                    .MinElementOrDefault(ast => ast.GetType().Name.Length);
        }
    }
}