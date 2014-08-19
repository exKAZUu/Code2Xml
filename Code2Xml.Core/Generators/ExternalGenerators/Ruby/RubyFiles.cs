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
using Code2Xml.Core.Properties;
using Paraiba.IO;

namespace Code2Xml.Core.Generators.ExternalGenerators.Ruby {
    public static class RubyFiles {
        public static void DeployCommonFiles(string dirPath) {
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(
                            dirPath,
                            "composite_sexp_processor.rb"), Resources.composite_sexp_processor);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "pt_testcase.rb"), Resources.pt_testcase);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "README_ruby_parser.txt"),
                    Resources.README_ruby_parser);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "README_sexp_processor.txt"),
                    Resources.README_sexp_processor);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "ruby_lexer.rb"), Resources.ruby_lexer);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "ruby_parser.rb"), Resources.ruby_parser);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "ruby_parser_extras.rb"),
                    Resources.ruby_parser_extras);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "ruby18_parser.rb"), Resources.ruby18_parser);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "ruby19_parser.rb"), Resources.ruby19_parser);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "ruby20_parser.rb"), Resources.ruby20_parser);
            ParaibaFile.WriteIfDifferentSize(Path.Combine(dirPath, "sexp.rb"), Resources.sexp);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "sexp_processor.rb"), Resources.sexp_processor);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "unique.rb"), Resources.unique);

            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "ruby2ruby.rb"), Resources.ruby2ruby);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "README_ruby2ruby.txt"), Resources.README_ruby2ruby);
        }
    }
}