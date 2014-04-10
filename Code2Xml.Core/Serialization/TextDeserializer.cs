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

using System.IO;

namespace Code2Xml.Core.Serialization {
    public class TextDeserializer : Deserializer {
        private readonly TextReader _reader;
        private char[] _buffer;

        public TextDeserializer(TextReader reader) {
            _reader = reader;
            _buffer = new char[256];
        }

        private void ExtendBuffer(int size) {
            var currentSize = _buffer.Length;
            while (currentSize < size) {
                currentSize <<= 1;
            }
            _buffer = new char[currentSize];
        }

        public override bool DeserializeBoolean() {
            return _reader.Read() != '0';
        }

        public override int DeserializeInt() {
            char ch;
            var index = 0;
            while ((ch = (char)_reader.Read()) != ',') {
                _buffer[index++] = ch;
            }
            return int.Parse(new string(_buffer, 0, index));
        }

        public override string DeserializeString() {
            var length = DeserializeInt();
            ExtendBuffer(length);
            _reader.Read(_buffer, 0, length);
            return new string(_buffer, 0, length);
        }
    }
}