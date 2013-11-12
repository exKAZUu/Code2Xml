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
using System.Linq;
using System.Reflection;
using Code2Xml.Core.XmlToCodes;
using Paraiba.Linq;

namespace Code2Xml.Objects {
    public class XmlToCodes {
        private static XmlToCodes _instance;

#pragma warning disable 649
        [ImportMany] private IEnumerable<XmlToCode> _xmlToCodes;
#pragma warning restore 649

        private XmlToCodes() {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog("."));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        private static XmlToCodes Instance {
            get { return _instance ?? (_instance = new XmlToCodes()); }
        }

        public static IEnumerable<XmlToCode> All {
            get {
                return Instance._xmlToCodes.OrderBy(c => c.ParserName);
            }
        }

        public static XmlToCode GetXmlToCodeByName(string name) {
            var lowerName = name.ToLower();
            return All
                    .Where(code => code.ParserName.ToLower().Contains(lowerName))
                    .MinElementOrDefault(code => Math.Abs(code.ParserName.Length - name.Length));
        }

        public static XmlToCode GetXmlToCodeByExtension(string ext) {
            var lowerExt = ext.ToLower();
            return All
                    .FirstOrDefault(ast => ast.DefaultExtension.ToLower() == lowerExt);
        }
    }
}