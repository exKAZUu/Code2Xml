#region License

// Copyright (C) 2011-2012 Kazunori Sakamoto
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

namespace Code2Xml.Core.Resources {
    public static class ResourceManager {
        public static void WriteResourceFiles(
                string directoryPath,
                IEnumerable<Tuple<string, byte[]>> resources) {
            foreach (var resource in resources) {
                var path = Path.Combine(directoryPath, resource.Item1);
                var fileInfo = new FileInfo(path);
                if (fileInfo.Exists && fileInfo.Length == resource.Item2.Length) {
                    continue;
                }
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (var outStream = new FileStream(path, FileMode.Create)) {
                    outStream.Write(resource.Item2, 0, resource.Item2.Length);
                }
            }
        }
    }
}