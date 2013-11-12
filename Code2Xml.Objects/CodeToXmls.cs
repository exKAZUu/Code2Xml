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
using Paraiba.Linq;

namespace Code2Xml.Objects {
    public class CodeToXmls {
        private static CodeToXmls _instance;

#pragma warning disable 649
        [ImportMany] private IEnumerable<CodeToXml> _codeToXmls;
#pragma warning restore 649

        private CodeToXmls() {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog("."));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        private static CodeToXmls Instance {
            get { return _instance ?? (_instance = new CodeToXmls()); }
        }

        public static IEnumerable<CodeToXml> All {
            get { return Instance._codeToXmls.OrderBy(a => a.ParserName); }
        }

        public static CodeToXml GetCodeToXmlByName(string name) {
            var lowerName = name.ToLower();
            return All.Where(ast => ast.ParserName.ToLower().Contains(lowerName))
                    .MinElementOrDefault(ast => Math.Abs(ast.ParserName.Length - name.Length));
        }

        public static CodeToXml GetCodeToXmlByPath(string path) {
            return GetCodeToXmlByExtension(Path.GetExtension(path));
        }

        public static CodeToXml GetCodeToXmlByExtension(string ext) {
            var lowerExt = ext.ToLower();
            return All.FirstOrDefault(
                    ast => ast.TargetExtensions
                            .Select(e => e.ToLower())
                            .Contains(lowerExt));
        }
    }
}