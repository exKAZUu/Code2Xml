﻿#region License

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

using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using Code2Xml.Core.SyntaxTree;

namespace Code2Xml.Core.Generators.ANTLRv3.C {
    /// <summary>
    /// Represents a C parser and a C code generator using GCC as a preprocessor.
    /// </summary>
    [Export(typeof(CstGenerator))]
    public class CCstGeneratorUsingAntlr3AndGcc : CCstGeneratorUsingAntlr3 {
        private readonly string _defaultWorkingDirectory;

        public CCstGeneratorUsingAntlr3AndGcc() {
            _defaultWorkingDirectory = ".";
        }

        public CCstGeneratorUsingAntlr3AndGcc(string defaultWorkingDirectory) {
            _defaultWorkingDirectory = defaultWorkingDirectory;
        }

        public override CstNode GenerateTreeFromCode(
                TextReader codeReader, bool throwingParseError = DefaultThrowingParseError) {
            return GenerateTreeFromCodeText(codeReader.ReadToEnd(), throwingParseError);
        }

        public override CstNode GenerateTreeFromCodeText(
                string code, bool throwingParseError = DefaultThrowingParseError) {
            return base.GenerateTreeFromCodeText(
                    PreprocessCode(code, _defaultWorkingDirectory), throwingParseError);
        }

        public static string PreprocessCode(string code, string workingDirectory) {
            var dirs = Directory.EnumerateDirectories(
                    workingDirectory, "*", SearchOption.AllDirectories);
            var args =
                    dirs.Select(
                            dir => "-I/cygdrive/" + dir[0] + dir.Substring(2).Replace("\\", "/"))
                            .Concat(new[] { "-E", "-P", "-" });
            var code2 = ExternalProgramUtils.InvokeProcess(code, "gcc", args, workingDirectory);
            return code2.Replace("int ((FILE *stream)->_file);", "");
        }
    }
}