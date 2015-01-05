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

namespace Code2Xml.Core.Generators.ExternalGenerators.SrcML {
    public static class SrcMLFiles {
        public static void DeployCommonFiles(string dirPath) {
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "iconv.dll"), Resources.iconv);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libantlr2-0.dll"), Resources.libantlr2_0);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libarchive-13.dll"), Resources.libarchive_13);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libbz2-1.dll"), Resources.libbz2_1);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libcrypto-10.dll"), Resources.libcrypto_10);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libcurl-4.dll"), Resources.libcurl_4);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libexslt-0.dll"), Resources.libexslt_0);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libgcc_s_sjlj-1.dll"), Resources.libgcc_s_sjlj_1);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libgnurx-0.dll"), Resources.libgnurx_0);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libidn-11.dll"), Resources.libidn_11);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libintl-8.dll"), Resources.libintl_8);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "liblzma-5.dll"), Resources.liblzma_5);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libsrcml.dll"), Resources.libsrcml);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libssh2-1.dll"), Resources.libssh2_1);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libssl-10.dll"), Resources.libssl_10);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libstdc++-6.dll"), Resources.libstdc___6);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libxml2-2.dll"), Resources.libxml2_2);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "libxslt-1.dll"), Resources.libxslt_1);
            ParaibaFile.WriteIfDifferentSize(
                    Path.Combine(dirPath, "zlib1.dll"), Resources.zlib1);
        }
    }
}