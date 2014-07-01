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
using System.IO;
using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ExternalGenerators.Generators.Python;
using Code2Xml.Objects.Tests.Learning.Experiments;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Languages.ExternalGenerators.Tests {
    [TestFixture]
    public class Python2CstGeneratorTest : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new Python2CstGenerator();
        }

        [Test]
        [TestCase("a = 1\n\n")]
        [TestCase("a = 1\nb = 2\n\n")]
        [TestCase(@"'''
'''")]
        [TestCase(@"# coding: utf-8
pass")]
        [TestCase(@"i = 0 + 1 - 2 * 3 / 4 % 5")]
        [TestCase(@"str(1 + 2)")]
        public void Parse(string code) {
            VerifyRestoringCodeAndInspect(code);
        }

        [Test]
        [TestCase(@"https://github.com/kennethreitz/clint.git",
                @"f1ab574413631de12166469e87257784785d3da6", 1364)]
        [TestCase(@"https://github.com/taobao/nginx-book.git",
                @"b1cba2dc114393766e863581b34dbe179b28c18e", 1363)]
        [TestCase(@"https://github.com/codelucas/newspaper.git",
                @"e0718be363470a19055b1e894957d127c6ae541d", 1361)]
        [TestCase(@"https://github.com/Pylons/pyramid.git",
                @"77005d96fa57a83ac91c2547892fbb3e3c34e553", 1352)]
        [TestCase(@"https://github.com/treeio/treeio.git",
                @"a4fbffabec2644a98f8b06d678a94d2949304235", 1335)]
        [TestCase(@"https://github.com/surfly/gevent.git",
                @"f6831bfa5cac1fcbdbc76b8d9595ec4f6c53889e", 1331)]
        [TestCase(@"https://github.com/rembo10/headphones.git",
                @"d6cd9cd7e4cd95e2e4d2fd845fa0c64b91e5e4a5", 1319)]
        [TestCase(@"https://github.com/koenbok/Cactus.git",
                @"10cd41a4a06ab0c88daf625e5a1b7fda202d7126", 1319)]
        [TestCase(@"https://github.com/nvie/rq.git",
                @"aef7af9c77fb6c1e5836403660a4e71fe3c05230", 1316)]
        [TestCase(@"https://github.com/mongodb/mongo-python-driver.git",
                @"a7575fa14f5a9aaeb0149981899f776af9e1ad1c", 1286)]
        [TestCase(@"https://github.com/lihaoyi/macropy.git",
                @"13993ccb08df21a0d63b091dbaae50b9dbb3fe3e", 1271)]
        [TestCase(@"https://github.com/torchbox/wagtail.git",
                @"d3ac6c072886a1c4cd8d27b94c4a9b6e9d51f218", 1256)]
        [TestCase(@"https://github.com/pypa/pip.git",
                @"7bda9c3e6fba43260aef822421627b7f7bdc7005", 1255)]
        [TestCase(@"https://github.com/kennethreitz/envoy.git",
                @"94c24eeaea8ba171a87e99194a59b36932424a66", 1254)]
        [TestCase(@"https://github.com/Bitmessage/PyBitmessage.git",
                @"700e3d1f17a820dd80108c08c8e1679debed2fd3", 1239)]
        [TestCase(@"https://github.com/Eugeny/ajenti.git",
                @"75013c621095775887f514ba014b36578ca48fae", 1237)]
        [TestCase(@"https://github.com/martinblech/xmltodict.git",
                @"23b9f41d90bf29d119246e3dcac29fec3a5fbc8e", 1229)]
        [TestCase(@"https://github.com/samuraisam/pyapns.git",
                @"a56912f3b83b72c497e716c34ed6b5fda6bd21f3", 1223)]
        [TestCase(@"https://github.com/litl/rauth.git",
                @"97b6c6a3cff0379bd915acd2de382ccc5f22c4cf", 1218)]
        [TestCase(@"https://github.com/openstack/nova.git",
                @"66e4e32f8b8f1fa004ca0289b843e0a4fa5600d1", 1198)]
        [TestCase(@"https://github.com/AppScale/appscale.git",
                @"1d1d24d7ae1890f39db9775ebfb3efddb12ad79d", 1197)]
        [TestCase(@"https://github.com/django-compressor/django-compressor.git",
                @"aba8c5f6b59dd78831d2bf1e53222f8475b2f9f8", 1197)]
        [TestCase(@"https://github.com/pennersr/django-allauth.git",
                @"3fee3665b86cc9a56174e81267a187b36b1290de", 1162)]
        [TestCase(@"https://github.com/gorakhargosh/watchdog.git",
                @"a8391941d4ff450483f0dfe2b5a3c02ecdd8f818", 1159)]
        [TestCase(@"https://github.com/jokkedk/webgrind.git",
                @"dc3539340dba1c6d6308a62a9701fdc3f3343de5", 1154)]
        [TestCase(@"https://github.com/coleifer/peewee.git",
                @"e24cdd19204d63984d537842336cbc5426217cc0", 1149)]
        [TestCase(@"https://github.com/pudo/dataset.git",
                @"e08565609e2439ac9a88f98081a36e42ba44a6a0", 1141)]
        [TestCase(@"https://github.com/dotcloud/zerorpc-python.git",
                @"1dee8bdb1ce78ee792cb4b46a47d894e70f26cb6", 1137)]
        [TestCase(@"https://github.com/gurgeh/selfspy.git",
                @"75792f48e280575366ce855a947f2bff6eea513b", 1135)]
        [TestCase(@"https://github.com/spadgos/sublime-jsdocs.git",
                @"da6294af5301d108cf42f90eb11e01f32395c8ac", 1132)]
        [TestCase(@"https://github.com/DanMcInerney/LANs.py.git",
                @"791d794b3851891e2c50be39336459d515307271", 1125)]
        [TestCase(@"https://github.com/edx/edx-platform.git",
                @"36be4e543c41284172031585ae8fe0dc825166bc", 1122)]
        [TestCase(@"https://github.com/rstacruz/sparkup.git",
                @"ea35be6c0bac75e6308ebf72a9c737fb8c21e3ae", 1122)]
        [TestCase(@"https://github.com/google/pyringe.git",
                @"6309eb6215cb3750fc3e914c17f6e472aec12824", 1122)]
        [TestCase(@"https://github.com/crsmithdev/arrow.git",
                @"b7eb832c08a1e376ffbacb70e95366b03a844379", 1117)]
        [TestCase(@"https://github.com/livid/v2ex.git",
                @"c8af57e2d2c4c8701901fb346cc98a4cde13b54b", 1116)]
        [TestCase(@"https://github.com/spotify/luigi.git",
                @"8b13063c398a3fa9f7b1dadacefa0512b407f164", 1114)]
        [TestCase(@"https://github.com/khamidou/kite.git",
                @"5ed8ba0c002b38733804d50410792245474520c6", 1090)]
        [TestCase(@"https://github.com/numba/numba.git",
                @"36d4596430ee4e3761cdd5adf14509160dad213c", 1079)]
        [TestCase(@"https://github.com/scipy/scipy.git",
                @"87df1db4f0137dd30d6841565dd88f16bddccb02", 1076)]
        [TestCase(@"https://github.com/Yelp/mrjob.git",
                @"94a67a42d36e69aada9e31d1975be32e730f1656", 1076)]
        [TestCase(@"https://github.com/rtfd/readthedocs.org.git",
                @"fc4dbc905010c0a47764e19366f8b1f09231df53", 1073)]
        [TestCase(@"https://github.com/sivel/speedtest-cli.git",
                @"18408ee93884de3d28142d0afac12714049e293b", 1073)]
        [TestCase(@"https://github.com/sympy/sympy.git",
                @"9ba613eb3385c9fc63a834efc624595b0d7ac7b7", 1072)]
        [TestCase(@"https://github.com/ajalt/fuckitpy.git",
                @"9db07766ceb73e95f7e5f6bd1245967535e8e2c3", 1070)]
        [TestCase(@"https://github.com/etianen/django-reversion.git",
                @"7a163dde302f072904e1f0e102cc8d98b64dfe92", 1063)]
        [TestCase(@"https://github.com/paramiko/paramiko.git",
                @"e96e2653a2ca0a465d2773b1fe468c0f87e758bc", 1063)]
        [TestCase(@"https://github.com/RuudBurger/CouchPotatoV1.git",
                @"135b3331d1b88ef645e29b76f2d4cc4a732c9232", 1059)]
        [TestCase(@"https://github.com/freedomofpress/securedrop.git",
                @"3e794a7052225bcb9bde0f498bd4797b475a40e0", 1058)]
        [TestCase(@"https://github.com/milkbikis/powerline-shell.git",
                @"e8300222fed3e5424956b9ef7e026e26edc227fd", 1053)]
        [TestCase(@"https://github.com/etsy/logster.git",
                @"7475c53822c2e22d0994ea059bfd482044019a5b", 1053)]
        [TestCase(@"https://github.com/davidhalter/jedi.git",
                @"4ff8b921a3b252895ed43b9598a5a40f0cbd487c", 1040)]
        [TestCase(@"https://github.com/newsapps/beeswithmachineguns.git",
                @"5eeb3cabfecc31add46f2dabe804c7a9277cd035", 1040)]
        [TestCase(@"https://github.com/seatgeek/fuzzywuzzy.git",
                @"7d8f2f89b69bd21707f5b66036d568c81f81d64e", 1033)]
        [TestCase(@"https://github.com/wrobstory/vincent.git",
                @"c2e4e34cb6e008e759d63066c9b8420fd2f0e71c", 1027)]
        [TestCase(@"https://github.com/kennethreitz/tablib.git",
                @"fc4cc7fa148c3e292fb33e9c07eb9e47a3e45fcf", 1025)]
        [TestCase(@"https://github.com/sightmachine/SimpleCV.git",
                @"fd26f7ea451db9ed24ab8cfceff23251fbac350b", 1023)]
        [TestCase(@"https://github.com/alex/django-taggit.git",
                @"f478e34f8e82c20b04f5992ae5299d7cf41c2b9f", 1002)]
        [TestCase(@"https://github.com/hyde/hyde.git",
                @"b29ba60b2b752ee31ecb5894409529d9ed99202e", 1000)]
        [TestCase(@"https://github.com/iBaa/PlexConnect.git",
                @"e076e37cb30ac9f72d7a52a8c1cc7da6fa4f6315", 992)]
        [TestCase(@"https://github.com/kachayev/fn.py.git",
                @"dc5c57345dc05398c0b0a1a12c479a986b970995", 991)]
        [TestCase(@"https://github.com/gaubert/gmvault.git",
                @"02f33060eb3744658681a7f667bcb513132706e9", 990)]
        [TestCase(@"https://github.com/python-imaging/Pillow.git",
                @"994c9a7e56a8a74da9044d9a732a29e41b4d30b6", 982)]
        [TestCase(@"https://github.com/elvanderb/TCP-32764.git",
                @"fc014066bac5fd3158d21e5336f5be85582b36a8", 981)]
        [TestCase(@"https://github.com/sixohsix/twitter.git",
                @"83c7a242415861d7f0f18037c2866f308782164d", 978)]
        [TestCase(@"https://github.com/gmate/gmate.git",
                @"f77cb109ab50959ad0b0ac6138ba16d1ecff6d4d", 976)]
        [TestCase(@"https://github.com/DanMcInerney/wifijammer.git",
                @"386a4399c6d54777e716b64138ab9a2722afcbaf", 976)]
        [TestCase(@"https://github.com/sebastien/cuisine.git",
                @"329e0bf2a956a1c153dc3b1ca17067378ef376e7", 972)]
        [TestCase(@"https://github.com/sublimehq/anim_encoder.git",
                @"06f6fec3c459db5c77778c3aa8804289f8bb1960", 958)]
        [TestCase(@"https://github.com/tgalal/yowsup.git",
                @"938cf1f0d0aedf650be748dcc258a43b8c87a6b3", 942)]
        [TestCase(@"https://github.com/kennethreitz/inbox.py.git",
                @"551b4f44b144564504c687cebdb4c543cb8e9adf", 936)]
        [TestCase(@"https://github.com/pythonforfacebook/facebook-sdk.git",
                @"e30370fa71a73129979cdd838307a37812d94d1b", 930)]
        [TestCase(@"https://github.com/tangentlabs/django-oscar.git",
                @"f3f983ac3faed17a242ac1fbb9e2dbfbb8385f50", 929)]
        [TestCase(@"https://github.com/martinrusev/amonone.git",
                @"c882215aa3b970db8f4da1eb7789b6199cf4610a", 928)]
        [TestCase(@"https://github.com/tschellenbach/Django-facebook.git",
                @"4a57628766afe5a09525faf246f0bc2563b9c3a0", 928)]
        [TestCase(@"https://github.com/chrisallenlane/cheat.git",
                @"406cf0dcf3c86305bce7a471feb592a36a80b791", 921)]
        [TestCase(@"https://github.com/buildbot/buildbot.git",
                @"d3364bff14663a422a7bc4a5a6cdede14645cc56", 920)]
        [TestCase(@"https://github.com/nathanborror/django-basic-apps.git",
                @"3a90090857549ea4198a72c44f45f6edb238e2a8", 919)]
        [TestCase(@"https://github.com/charlierguo/gmail.git",
                @"4626823d3fbf159d242a50b33251576aeddbd9ad", 917)]
        [TestCase(@"https://github.com/revolunet/sublimetext-markdown-preview.git",
                @"3b94b8489b2c9b6f54eabf50bd19984e9b588f2c", 911)]
        [TestCase(@"https://github.com/overviewer/Minecraft-Overviewer.git",
                @"8e5944d5c3fc1c1aae8331daa1b72af0c29d8702", 909)]
        [TestCase(@"https://github.com/emre/storm.git",
                @"92fb3a77f4f39578a327aba419a7f4a1afcf1199", 902)]
        [TestCase(@"https://github.com/Supervisor/supervisor.git",
                @"65221682eb2590b2de504586f5736d55327e81d6", 894)]
        [TestCase(@"https://github.com/mikemaccana/python-docx.git",
                @"e507db84bdaa65010b616033a8ac6639ac4f6a12", 890)]
        [TestCase(@"https://github.com/symfony/symfony-docs.git",
                @"98288fcf789197b5c7a26a6a44ccbdabc911690f", 889)]
        [TestCase(@"https://github.com/pypa/virtualenv.git",
                @"5858d32f913f626c536c78fdd17c9c67d1d1fb70", 889)]
        [TestCase(@"https://github.com/etsy/skyline.git",
                @"90d7bb16ea6ebc8a61b66e67428c8e669b1082a1", 887)]
        [TestCase(@"https://github.com/paulhammond/webkit2png.git",
                @"8c6fbb435990c81ce721ba3bc6bc12dfb332aaa2", 879)]
        [TestCase(@"https://github.com/titoBouzout/SideBarEnhancements.git",
                @"067db326b805163840333721cf2708d0e224e9fe", 878)]
        [TestCase(@"https://github.com/mothran/bunny.git",
                @"8a61d0eddf7d655b6493847f106e7ee6110f53fe", 875)]
        [TestCase(@"https://github.com/Rip-Rip/clang_complete.git",
                @"5b3ced59588dc9f65e9e916890cb6795764c3fe4", 875)]
        [TestCase(@"https://github.com/wuub/SublimeREPL.git",
                @"f2b2a79140fe8423a5233fd9b962fe9bde052ca6", 872)]
        [TestCase(@"https://github.com/lra/mackup.git",
                @"565fbc6c9f48f3e1082fba2965948f609ef64f4d", 867)]
        [TestCase(@"https://github.com/noamraph/tqdm.git",
                @"da5fdbf7c05a9127f04ac5887292457e8335f480", 867)]
        [TestCase(@"https://github.com/madisonmay/CommonRegex.git",
                @"2cf86259676da169b480f734181a5831eb62f8b9", 866)]
        [TestCase(@"https://github.com/klbostee/dumbo.git",
                @"ca79358a061d18df45b1ab8010cfd69f5943ef6b", 863)]
        [TestCase(@"https://github.com/Jahaja/psdash.git",
                @"f05c8e0a1011603d5ef408d32f7cf34e2a2f2470", 862)]
        [TestCase(@"https://github.com/simon-weber/Unofficial-Google-Music-API.git",
                @"e23d2f51f533b47c90df6120a4f2ecc588cf1737", 859)]
        [TestCase(@"https://github.com/jacobian/djangobook.com.git",
                @"e205e45759fdd4ae2e4f9e6ed8fbf87a0e158c53", 855)]
        [TestCase(@"https://github.com/bread-and-pepper/django-userena.git",
                @"f07ba8e209ee97b16467cf3cddb4b4a77a7f04a8", 852)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            var exp = new PythonComplexStatementExperiment();
            VerifyRestoringGitRepoSavingThem(
                    url, commitPointer, "python2_repo.csv", starCount,
                    cst => cst.DescendantsAndSelf()
                            .Where(exp.OriginalIsAcceptedUsingOracle)
                            .Count(), "*.py");
        }

        [Test]
        public void AnalyzeLocation() {
            var code = @"
a = 1
if b == 2:
    c = 3
d = 4";
            var xml = Generator.GenerateTreeFromCodeText(code);
            VerifyLocation(code, xml);
            Console.WriteLine(xml);
        }

        [Test]
        public void CanParse() {
            var path = Fixture.GetInputCodePath("Python2", "Block1.py");
            Generator.GenerateTreeFromCode(new FileInfo(path), null, true);
        }

        [Test]
        public void CanParseJapanese() {
            var xml = Generator.GenerateTreeFromCodeText(@"print('あ')", true);
            Assert.That(xml.ToString(), Is.StringContaining("あ"));
        }
    }
}