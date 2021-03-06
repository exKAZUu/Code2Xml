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

namespace Code2Xml.Core.SyntaxTree {
    public static class Traversal {
        public static string NameWithId(this CstNode node) {
            return node.Name + node.RuleId;
        }

        public static string NameAndTokenWithId(this CstNode node) {
            var ret = node.NameWithId();
            if (node.HasToken) {
                ret += node.Token.Text;
            }
            return ret;
        }
    }
}