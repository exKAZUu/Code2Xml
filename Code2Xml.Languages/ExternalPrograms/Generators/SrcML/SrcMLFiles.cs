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
using Code2Xml.Languages.ExternalGenerators.Properties;
using Paraiba.IO;

namespace Code2Xml.Languages.ExternalGenerators.Generators.SrcML {
    public static class SrcMLFiles {
        public static void DeployCommonFiles(string dirPath) {
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "bz2-1.dll"), Resources.bz2_1);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "iconv.dll"), Resources.iconv);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libantlr2-0.dll"), Resources.libantlr2_0);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libarchive-2.dll"), Resources.libarchive_2);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libexslt.dll"), Resources.libexslt);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libgcc_s_sjlj-1.dll"), Resources.libgcc_s_sjlj_1);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libgcrypt-11.dll"), Resources.libgcrypt_11);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libgnurx-0.dll"), Resources.libgnurx_0);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libgpg-error-0.dll"), Resources.libgpg_error_0);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libsrcml.dll"), Resources.libsrcml);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libstdc++-6.dll"), Resources.libstdc___6);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libxml2.dll"), Resources.libxml2);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libxslt.dll"), Resources.libxslt);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "zlib1.dll"), Resources.zlib1);
        }
    }
}