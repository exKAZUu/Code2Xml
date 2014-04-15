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
using Code2Xml.Core.Generators;
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ExternalGenerators.Generators.Python;
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
        public void Parse(string code) {
            VerifyRestoringCodeAndInspect(code);
        }

        [Test]
        [TestCase(@"https://github.com/serge-sans-paille/pythran.git",
                @"882533b10570344701561709d4631b1a8b5554c5")] // Star: 100
        [TestCase(@"https://github.com/musalbas/heartbleed-masstest.git",
                @"bc10baf20e5a1a29610443a67e14340701101f20")] // Star: 435
        [TestCase(@"https://github.com/jasperproject/jasper-client.git",
                @"9c240bafb55b0c8de45b024a606d903c125b9ae1")] // Star: 686
        [TestCase(@"https://github.com/mitsuhiko/flask.git",
                @"d4b3d16c142e2189c6faf8f784a195e7f827c596")] // Star: 9247
        [TestCase(@"https://github.com/Lekensteyn/pacemaker.git",
                @"32be5b09a14058795a754824e4162e0324155629")] // Star: 180
        [TestCase(@"https://github.com/ansible/ansible.git",
                @"b0556ab1fbc0652147b86a809cf8b69d4c3cd188")] // Star: 5532
        [TestCase(@"https://github.com/ctfs/write-ups.git",
                @"c8f47b7babd7ccd8cefe24eea4546d7711686eb1")] // Star: 92
        [TestCase(@"https://github.com/dropbox/pyxl.git",
                @"6beb8c3a46bf9db0e1484f397a8795d720412efd")] // Star: 138
        [TestCase(@"https://github.com/jeffknupp/sandman.git",
                @"e534defd803082feee0af30b64d2c9fb4c5ed2ac")] // Star: 1477
        [TestCase(@"https://github.com/lebinh/ngxtop.git",
                @"3694d55b15f73b531d8c7951711799ffa3c7521a")] // Star: 2782
        [TestCase(@"https://github.com/kennethreitz/requests.git",
                @"07ee20d07dfd316a0fdd5ec4f5d276a72fe4cc62")] // Star: 9433
        [TestCase(@"https://github.com/takluyver/pynsist.git",
                @"b973a078f059d416b224f4d13f388f6ed17aa00e")] // Star: 99
        [TestCase(@"https://github.com/rg3/youtube-dl.git",
                @"fd50bf623c3b3696ade7b8e1e5f4e0c283eabaaf")] // Star: 4137
        [TestCase(@"https://github.com/naspeh/mailr.git",
                @"940d991ba73469326ae00eff48de15d039a02df4")] // Star: 379
        [TestCase(@"https://github.com/django/django.git",
                @"63d0cbab042c981d6ef63a3193fb1fa0027db0fd")] // Star: 9387
        [TestCase(@"https://github.com/fengsp/shortly.git",
                @"7d2ca08082ab2f069ab9dc89496260ea52dcc80f")] // Star: 37
        [TestCase(@"https://github.com/scrapinghub/portia.git",
                @"55f97e61fc558d243a0806ae8bf4a26b080026de")] // Star: 2128
        [TestCase(@"https://github.com/sampsyo/beets.git",
                @"cf2f78ef55a45981405e9aa871b0bfe5f7d52068")] // Star: 2733
        [TestCase(@"https://github.com/matplotlib/matplotlib.git",
                @"3c8fe522356de92811bf0aecb244b5603b6e48c6")] // Star: 1459
        [TestCase(@"https://github.com/MongoEngine/mongoengine.git",
                @"f099dc6a379e890e1cffdff6deaf6e7b32f6dbab")] // Star: 605
        [TestCase(@"https://github.com/scrapy/scrapy.git",
                @"21bff7b3b366ac3fb81a225c5c5bdf7d24dbfa33")] // Star: 4517
        [TestCase(@"https://github.com/kennethreitz/python-guide.git",
                @"f010d20802c4d33ef3eda43fc6d3cd2341165404")] // Star: 4745
        [TestCase(@"https://github.com/reddit/reddit.git",
                @"b50f91c53149671c4039ff1de4250ac0d5bc89c0")] // Star: 5475
        [TestCase(@"https://github.com/getpelican/pelican.git",
                @"c6ff88d0fce7f7ab5e05f2c414a365aa9faa6454")] // Star: 3281
        [TestCase(@"https://github.com/kivy/kivy.git",
                @"84a6bbcae99278928c996ddcbc39d683c2803e57")] // Star: 1721
        [TestCase(@"https://github.com/vhf/free-programming-books.git",
                @"fb457bb8a3bf95d093540b26b7add196fe4e3535")] // Star: 23722
        [TestCase(@"https://github.com/FiloSottile/Heartbleed.git",
                @"c79a1106aa365a92cdbc735bb5d61d8490372fa8")] // Star: 1835
        [TestCase(@"https://github.com/Famous/famous.git",
                @"a53fbb4dd8d753171258c0e710b01b1cb30f3127")] // Star: 1421
        [TestCase(@"https://github.com/GitbookIO/gitbook.git",
                @"1bbef540157b513d3e336325a3d636885e15357e")] // Star: 3393
        [TestCase(@"https://github.com/mgcrea/angular-strap.git",
                @"a3ff0667f4897b210c70f350f9a994c6cd391747")] // Star: 3213
        [TestCase(@"https://github.com/AlexNisnevich/untrusted.git",
                @"2f0372ed0f139e392cdf0d094c73712f789628e1")] // Star: 816
        [TestCase(@"https://github.com/kenwheeler/slick.git",
                @"bc3b346c0156af627ef543ced10e24ddae6621d7")] // Star: 4938
        [TestCase(@"https://github.com/uberVU/grid.git",
                @"0ae9f19444d1c25c10691ca848b5313b34517d25")] // Star: 2193
        [TestCase(@"https://github.com/mortardata/mortar-recsys.git",
                @"617fbf66a8e8fb7738354c224760dc2419ed0c13")] // Star: 650
        [TestCase(@"https://github.com/jetpacapp/DeepBeliefSDK.git",
                @"eb4ad0057af4a47ff33e8811c502557d0dc60a2f")] // Star: 633
        [TestCase(@"https://github.com/kolinkrewinkel/Polychromatic.git",
                @"ca4d832d363ae7a756678923b7d848cfc15829f2")] // Star: 494
        [TestCase(@"https://github.com/winjs/winjs.git",
                @"e6f28372046afedef2493d9c748a4dab081c0912")] // Star: 2162
        [TestCase(@"https://github.com/EddyBorja/EBPhotoPages.git",
                @"a27078b52444f11a764c106334025f0a27f8f518")] // Star: 425
        [TestCase(@"https://github.com/adamschwartz/magic-of-css.git",
                @"901f7c00b4f1a381fe8e43319f9bbc420e87d688")] // Star: 970
        [TestCase(@"https://github.com/titanous/heartbleeder.git",
                @"16661a0c71df54ac0c862e7d952875b96dc03c63")] // Star: 401
        [TestCase(@"https://github.com/mbostock/d3.git",
                @"49ba8afebb2ae813ab66dc2f48f533aa7f333c3c")] // Star: 24554
        [TestCase(@"https://github.com/twbs/bootstrap.git",
                @"ee7498a69366c516ccba01ca7c977fb83ea23a7b")] // Star: 66685
        [TestCase(@"https://github.com/alskipp/ASValueTrackingSlider.git",
                @"3b23340f143c30f21909fa58ec10ba9ad9017f62")] // Star: 341
        [TestCase(@"https://github.com/angular/angular.js.git",
                @"b10a4371a6592ea1c54b5b9eb401842af7f63c90")] // Star: 22633
        [TestCase(@"https://github.com/dropbox/pyston.git",
                @"1fe94923ff6ff780fb6a0b3efba4a96119a991e8")] // Star: 1446
        [TestCase(@"https://github.com/modocache/MDCSwipeToChoose.git",
                @"6acf0b476f297fd7298a4847c575d89e059fba8e")] // Star: 290
        [TestCase(@"https://github.com/gnab/remark.git",
                @"9cbdd217a0b0bf57e06555c8fa2799220c643f06")] // Star: 969
        [TestCase(@"https://github.com/FortAwesome/Font-Awesome.git",
                @"0373b63c16d7aa31b6715c3f81a98a2ffb9f40a6")] // Star: 22130
        [TestCase(@"https://github.com/Jahaja/psdash.git",
                @"f05c8e0a1011603d5ef408d32f7cf34e2a2f2470")] // Star: 860
        [TestCase(@"https://github.com/facebook/planout.git",
                @"98130799cb008296a78d2c05da971e735a09adb9")] // Star: 393
        [TestCase(@"https://github.com/ipython/ipython.git",
                @"fb1283edcacdeb0aaad12201741e5502a341f0eb")] // Star: 3549
        [TestCase(@"https://github.com/facebook/tornado.git",
                @"c5292057a8db3ebec4a80d9c9207bfadff7fa784")] // Star: 7024
        [TestCase(@"https://github.com/saltstack/salt.git",
                @"bdb40bdcf8191af4533a28214704f9b08fc7648f")] // Star: 3268
        [TestCase(@"https://github.com/pagekite/Mailpile.git",
                @"556c9e16855dea71db23bc2180e4cef1cf2a40ef")] // Star: 4048
        [TestCase(@"https://github.com/andrewromanenco/pyjvm.git",
                @"b43cd1f95d39a5a025db165c5fa0c173729d6d46")] // Star: 171
        [TestCase(@"https://github.com/lingthio/Flask-User.git",
                @"0ff337bcb68474c6878b04dda8a1bce5ce060ed5")] // Star: 173
        [TestCase(@"https://github.com/getsentry/sentry.git",
                @"94e56e691f4081db7680faf49db5592ec29edd23")] // Star: 4702
        public void ParseGitRepository(string url, string commitPointer) {
            VerifyRestoringGitRepositorySavingRepo(url, commitPointer, "python2_repo.txt", "*.py");
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