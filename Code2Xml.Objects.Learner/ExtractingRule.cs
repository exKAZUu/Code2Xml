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
using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Location;

namespace Code2Xml.Objects.Learner {
    public class ExtractingRule {
        public Dictionary<string, List<IFilter>> FilterDictionary { get; private set; }

        public IEnumerable<IFilter> Filters {
            get { return FilterDictionary.Values.SelectMany(f => f); }
        }

        public ExtractingRule(IEnumerable<IFilter> filters) {
            FilterDictionary = new Dictionary<string, List<IFilter>>();
            foreach (var filter in filters) {
                var name = filter.ElementName;
                List<IFilter> rules;
                if (!FilterDictionary.TryGetValue(name, out rules)) {
                    rules = new List<IFilter>();
                    FilterDictionary.Add(name, rules);
                }
                rules.Add(filter);
            }
        }

        public IEnumerable<CstNode> ExtractElements(CstNode ast) {
            foreach (var nameAndRules in FilterDictionary) {
                var elements = ast.DescendantsAndSelf(nameAndRules.Key);
                var rules = nameAndRules.Value;
                var results = elements.Where(e => rules.All(rule => rule.IsAcceptable(e)));
                foreach (var result in results) {
                    yield return result;
                }
            }
        }

        public Dictionary<CodeRange, CstNode> ExtractRange2Elements(CstNode ast) {
            var elements = ExtractElements(ast);
            // Elements having the same range can appear so can't use ToDictiornary
            var ret = new Dictionary<CodeRange, CstNode>();
            foreach (var element in elements) {
                var range = CodeRange.Locate(element);
                ret[range] = element;
            }
            return ret;
        }
    }
}