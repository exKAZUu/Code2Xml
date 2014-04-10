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

using System.Diagnostics.Contracts;
using System.IO;

namespace Code2Xml.Core.Serialization {
    public class BinarySerializer : Serializer {
        private readonly BinaryWriter _writer;

        public BinarySerializer(BinaryWriter writer) {
            Contract.Requires(writer != null);
            _writer = writer;
        }

        public override void Serialize(bool value) {
            _writer.Write(value);
        }

        public override void Serialize(int value) {
            _writer.Write(value);
        }

        public override void Serialize(string text) {
            _writer.Write(text);
        }
    }
}