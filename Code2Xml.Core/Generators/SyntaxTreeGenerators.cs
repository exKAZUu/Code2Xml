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
using Code2Xml.Core.Generators.ExternalGenerators.Python;
using Code2Xml.Core.Generators.ExternalGenerators.Ruby;
using Paraiba.Core;
using Paraiba.Linq;

namespace Code2Xml.Core.Generators {
    public static class SyntaxTreeGenerators {
        /// <summary>
        /// Gets all <c>SyntaxTreeGenerator</c> instances including preset and user-added processors.
        /// </summary>
        public static IEnumerable<SyntaxTreeGenerator> All {
            get { return CstGenerators.All.Cast<SyntaxTreeGenerator>().Concat(AstGenerators.All); }
        }

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