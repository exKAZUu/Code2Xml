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

using System;
using System.Collections.Generic;
using System.IO;
using Code2Xml.Core.Generators;
using Paraiba.Text;

namespace Code2Xml.Tools.Console {
    public static class Parser {
        public static void ParseCodeToXml(
                IEnumerable<string> filePaths,
                string parserName, OutputType outputType,
                string outputPath) {
            var getOutPutFunc = GetGetOutputFunc(outputType, outputPath, ".xml");
            foreach (var path in filePaths) {
                var extension = Path.GetExtension(path);
                var parser = parserName != null
                        ? SyntaxTreeGenerators.GetProcessorByNameWithVersion(parserName)
                        : SyntaxTreeGenerators.GetProcessorByExtension(extension);
                if (parser == null) {
                    continue;
                }
                var ast = parser.GenerateXmlFromCodePath(path);
                getOutPutFunc.Item1(path, ast.ToString());
            }
            getOutPutFunc.Item2();
        }

        public static void ParseXmlToCode(
                IEnumerable<string> filePaths,
                string parserName, OutputType isOutputFile,
                string outputPath) {
            var parser = SyntaxTreeGenerators.GetProcessorByNameWithVersion(parserName);
            var getOutPutFunc = GetGetOutputFunc(
                    isOutputFile, outputPath,
                    parser.DefaultExtension);
            foreach (var path in filePaths) {
                var code = parser.GenerateCodeFromXmlPath(path);
                getOutPutFunc.Item1(path, code);
            }
            getOutPutFunc.Item2();
        }

        private static Tuple<Action<string, string>, Action> GetGetOutputFunc
                (OutputType outputType, string outPath, string outExtension) {
            Action<string, string> action1;
            Action action2;
            switch (outputType) {
            case OutputType.DefaultStream:
                action1 =
                        (inputPath, content) =>
                                System.Console.WriteLine(content);
                action2 = () => { }; // disposer
                break;
            case OutputType.File: {
                var writer = new StreamWriter(outPath, false, XEncoding.SJIS);
                action1 = (inputPath, content) => writer.WriteLine(content);
                action2 = writer.Close; // disposer
                break;
            }
            case OutputType.Directory: {
                action1 = (inputPath, content) => {
                    var newPath = Path.Combine(
                            outPath ?? Path.GetDirectoryName(inputPath),
                            Path.GetFileNameWithoutExtension(inputPath)
                            + outExtension);
                    using (
                            var writer = new StreamWriter(
                                    newPath, false, XEncoding.SJIS)) {
                        writer.WriteLine(content);
                    }
                };
                action2 = () => { }; // disposer
                break;
            }
            default:
                throw new ArgumentOutOfRangeException("outputType");
            }
            return Tuple.Create(action1, action2);
        }
    }
}