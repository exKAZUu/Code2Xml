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

namespace Code2Xml.Core {
    public class Code2XmlConstants {
        public const string SyntaxTreeCacheExtension = ".cached_xml";
        public const string LearningCacheExtension = ".learning_cache_11_git";
        public const string DependenciesDirectoryName = "Dependencies";

        public const string EofTokenName = "EOF";
        public const string EofRuleId = "EOF";
        public const string DefaultRuleId = "-1";
        public const string DefaultHiddenRuleId = "-2";

        public const string StartLineName = "startline";
        public const string StartPositionName = "startpos";
        public const string EndLineName = "endline"; // Inclusive 
        public const string EndPositionName = "endpos"; // Inclusive 
        public const string HiddenAttributeName = "hidden";
        public const string IdAttributeName = "id";

        public const string TokenElementName = "TOKEN";
        public const string HiddenElementName = "HIDDEN";
        public const string TokenSetElementName = "TOKENS";
    }
}