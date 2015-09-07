using System.Collections.Generic;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Learner.Core.Learning {
    public class Cluster<T>
            where T : class {
        private readonly IDictionary<string, T> _values;

        public T this[CstNode node] {
            get {
                var path = node.Name;
                T lastValue = null, value;
                while (_values.TryGetValue(path, out value)) {
                    lastValue = value;
                    node = node.Parent;
                    if (node == null) {
                        break;
                    }
                    path += ">" + node.Name + node.RuleId;
                }
                return lastValue;
            }
        }

        public Cluster(IDictionary<string, T> values) {
            _values = values;
        }
    }
}