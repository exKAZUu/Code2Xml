using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Code2Xml.Languages.SrcML.Properties;
using Paraiba.IO;

namespace Code2Xml.Languages.SrcML
{
	public static class SrcMLFiles
	{
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
