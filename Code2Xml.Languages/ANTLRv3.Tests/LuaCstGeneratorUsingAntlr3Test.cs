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

using System.Linq;
using Code2Xml.Core.Generators;
using Code2Xml.Core.Tests.Generators;
using Code2Xml.Languages.ANTLRv3.Generators.Lua;
using Code2Xml.Objects.Tests.Learning.Experiments;
using NUnit.Framework;

namespace Code2Xml.Languages.ANTLRv3.Tests {
    [TestFixture]
    public class LuaCstGeneratorUsingAntlr3Test : CstGeneratorTest {
        protected override CstGenerator CreateGenerator() {
            return new LuaCstGeneratorUsingAntlr3();
        }

        [Test]
        [TestCase(@"a = 1")]
        [TestCase(@"#!/usr/bin/lua
a = 1")]
        [TestCase(@"#!/if/while/lua
a = 1")]
        [TestCase(@"--")]
        [TestCase(@"--[")]
        [TestCase(@"--[==")]
        [TestCase(@"--[==[]==]")]
        [TestCase(@"if true then end --[[SCars]] ")]
        [TestCase(@"if true then --[[SCars]] end")]
        [TestCase(@"if true --[[SCars]] then end")]
        [TestCase(@"--[=")]
        [TestCase(@"--a")]
        [TestCase("-- running the tests and examples\nrequire 'pl'\n")]
        [TestCase("require 'pl'\n")]
        [TestCase(@"print(1)")]
        [TestCase(@"print(1, 2)")]
        [TestCase("a = [=[one [[two]] three]=]")]
        [TestCase("a = func()[1]")]
        [TestCase(@"local s = '/[^() ]*lib' .. '%.so[^() ]*'")]
        [TestCase("--[[Any--]]")]
        [TestCase(@"
--
print(1)
")]
        [TestCase(@"--")]
        [TestCase(@"
if true --[[xx]] then
	print(1)
end
")]
        [TestCase(@"
if true then --[[VERBOSE]] print(1) end
")]
        [TestCase(@"-- comment
")]
        [TestCase(@"i = 0 + 1 - 2 * 3/ 4;")]
        public void Parse(string code) {
            VerifyRestoringCode(code);
        }

        [Test]
        [TestCase("Block1.lua")]
        [TestCase("Block2.lua")]
        [TestCase("Block3.lua")]
        public void ParseFile(string fileName) {
            VerifyRestoringFile("Lua", fileName);
        }

        [Test]
        [TestCase(@"https://github.com/solso/api-aggregator.git",
                @"2ea1f6b38f9bd4465255cd3a60a6dd6a6442dd9b", 36)]
        [TestCase(@"https://github.com/tdy/dots.git",
                @"c74fbd925b41c6189ed394854ea289131399f3f1", 36)]
        [TestCase(@"https://github.com/fediaFedia/Omnimo.git",
                @"a98cdf9cc5fa51b1aa82f2834218a3a11085f0b3", 36)]
        [TestCase(@"https://github.com/Windower/Lua.git",
                @"28926d6c45907ca91d3883599745903173eb15ad", 35)]
        [TestCase(@"https://github.com/chatid/fend.git",
                @"72dc6b024e2cabb4b707250b89097d4ff0da22f2", 35)]
        [TestCase(@"https://github.com/dluksza/screenful.git",
                @"758057633588cb35d54417783af1ce14864b8a3c", 35)]
        [TestCase(@"https://github.com/cloudwu/ldebug.git",
                @"b80bcd31944d7ea4c504dc915601d3e2080e73d9", 35)]
        [TestCase(@"https://github.com/Elv13/awesome-configs.git",
                @"18bbb46a2c8d2fc69e65e0d0a6fe66db9b5e0055", 34)]
        [TestCase(@"https://github.com/ggcrunchy/corona-sdk-snippets.git",
                @"e89f4547a36c4b8b817855e2a3e7c50b9ae19a4d", 34)]
        [TestCase(@"https://github.com/leafo/heroku-openresty.git",
                @"5945df6f7641e456e51c518947a5f9e50f0cc4d5", 34)]
        [TestCase(@"https://github.com/deniza/Ad-Mediator-for-Corona.git",
                @"084d12b45bd576f6abbb34cb3e849aaaa294e91c", 34)]
        [TestCase(@"https://github.com/silentbicycle/tamale.git",
                @"6d8ef8315348b01c88bb9d2245f84d6b1cd68c07", 34)]
        [TestCase(@"https://github.com/kikito/stateful.lua.git",
                @"eede90c5a5ec97639154b5e4413c337175ed21e2", 34)]
        [TestCase(@"https://github.com/hoelzro/lua-repl.git",
                @"b5fde2ac342def303eda8eb8d51b2bc807fdc4ba", 34)]
        [TestCase(@"https://github.com/brimworks/lua-http-parser.git",
                @"7adc3e7310091db5ffd1c09a87edcbc55255f730", 34)]
        [TestCase(@"https://github.com/nrk/hige.git",
                @"f8ccf97063c62b93224fe6991551522fdaba9083", 34)]
        [TestCase(@"https://github.com/SpiderLabs/Nmap-Tools.git",
                @"0282df407ae5ba426bd96415fcbe36a166a74838", 34)]
        [TestCase(@"https://github.com/bartbes/love-misc-libs.git",
                @"79faade695182e728cd7a5eda1304f3ed5df1073", 34)]
        [TestCase(@"https://github.com/philipbl/Day-One-Lightroom-Plugin.git",
                @"f48bee6370a144fb83c23f669b731be88196c3cd", 34)]
        [TestCase(@"https://github.com/mpeterv/luacheck.git",
                @"43721c92786dc0b0fded70abe5b51880ec42e5e2", 33)]
        [TestCase(@"https://github.com/Floobits/diffshipper.git",
                @"8542aeac030cc4f8fa93088a145574e8c379fdd9", 33)]
        [TestCase(@"https://github.com/cycojesus/awesome-solarized.git",
                @"7f9f3615bc0bf283888a60d72f5f8453d8ce8bc0", 33)]
        [TestCase(@"https://github.com/Jeija/minetest-mod-mesecons.git",
                @"1f666875807c3c8e6c1771e4fb46c374d2e40ccb", 33)]
        [TestCase(@"https://github.com/Jasoco/LOVE-Adventure-Game-Engine.git",
                @"5ed8cb4f6b561090ef9b5fccda187b5b32217dbf", 33)]
        [TestCase(@"https://github.com/OutlawGameTools/Lime2DTileEngine.git",
                @"b61f2b5ba47bbeef7674436aa8925d2f04c3d926", 33)]
        [TestCase(@"https://github.com/pintsized/lua-resty-rack.git",
                @"4d8f8e166c01a7aa8ce9a9f06969699fd0aebf47", 33)]
        [TestCase(@"https://github.com/vain/awesome-vain.git",
                @"a83343157e11efc1e1cbbe7b80ab01d38fca373a", 32)]
        [TestCase(@"https://github.com/tekkub/libdatabroker-1-1.git",
                @"1a63ede0248c11aa1ee415187c1f9c9489ce3e02", 32)]
        [TestCase(@"https://github.com/JakobOvrum/LuaIRC.git",
                @"16057be815ec4408e32988c561e7ea4038bc53ba", 32)]
        [TestCase(@"https://github.com/catwell/luajit-msgpack-pure.git",
                @"a7f16a0826831dc78ff29b94a834b66847988506", 32)]
        [TestCase(@"https://github.com/ToxicFrog/vstruct.git",
                @"f230429b6aa0791d0a0f3755ff670372186fb63c", 32)]
        [TestCase(@"https://github.com/z1lt0id/awesome.git",
                @"a93c6274fcd411dcd2224b963238928ab821a064", 32)]
        [TestCase(@"https://github.com/Nayruden/Ulysses.git",
                @"3860886d9dabf36b1ad7e7f81d7e26776c6960c3", 32)]
        [TestCase(@"https://github.com/kikito/cron.lua.git",
                @"170f7d9463de36ecd73c16fd008b3789de2e54cb", 31)]
        [TestCase(@"https://github.com/mailru/tntlua.git",
                @"15d742d541725e6eeea96a24d1e60fff38294af5", 31)]
        [TestCase(@"https://github.com/creationix/moonslice-luv.git",
                @"717f5ce1ce96f0c1abb58b97c44e90bbaef814f2", 31)]
        [TestCase(@"https://github.com/Mic92/vicious.git",
                @"1c626ec7a6988e91f8ffe6c94d516b18bf95f9d9", 31)]
        [TestCase(@"https://github.com/waf/nice-and-clean-theme.git",
                @"8a0ae5950921c2cadb609ba1c735fd9392bee70c", 31)]
        [TestCase(@"https://github.com/wiremod/wire-extras.git",
                @"a2db0eb86660e4f0bbfff935368a6dcd29acfb80", 31)]
        [TestCase(@"https://github.com/sroccaserra/object-lua.git",
                @"64f6a91318a310cf2a7ef8eb0884f82d46beead6", 31)]
        [TestCase(@"https://github.com/wingify/lua-resty-rabbitmqstomp.git",
                @"a8c9a0d9ad5e150b6f284a594e239e7baa766622", 31)]
        [TestCase(@"https://github.com/ansca/Air-Hockey.git",
                @"ff05ac99ec276259249ec423520064dafaac0eb7", 31)]
        [TestCase(@"https://github.com/jtarchie/sinatra-openresty.git",
                @"7f7ed65eb389f432bd0a80bd226e8c1bbdc15352", 31)]
        [TestCase(@"https://github.com/clementfarabet/ipam-tutorials.git",
                @"e0cfcf4749d88f7a41fa5989ee94605942b205eb", 31)]
        [TestCase(@"https://github.com/GlitchGames/GGData.git",
                @"283673459586a92c75473da7fe97855ec85517a5", 30)]
        [TestCase(@"https://github.com/craigmj/json4lua.git",
                @"0459abdca8145b4965b9a818c526c634725986b1", 30)]
        [TestCase(@"https://github.com/khaledhosny/euler-otf.git",
                @"6c76de44dcff216f2d91d0638386cb575a52ded5", 30)]
        [TestCase(@"https://github.com/Wiladams/LAPHLibs.git",
                @"aed3531fb6face76c5634bde995e9cf503d6136b", 29)]
        [TestCase(@"https://github.com/cloudwu/luacc.git",
                @"cbf858da578aa75c6e3651e78ea78c19e5e12159", 29)]
        [TestCase(@"https://github.com/Chessnut/NutScript.git",
                @"10ae4f18968a265c158a78a14327a56a6a9088ee", 29)]
        [TestCase(@"https://github.com/kikito/bump.lua.git",
                @"f3e2033bf248c4278ca2dc2c7c4e66d5cf413a2f", 29)]
        [TestCase(@"https://github.com/tales/sourceoftales.git",
                @"f259c99ebb42a4956f6e4c5464051651a3226d5a", 29)]
        [TestCase(@"https://github.com/paulofmandown/rotLove.git",
                @"bb089f3294ba9cd1f7cc031dffc0b695fa2ed4bf", 29)]
        [TestCase(@"https://github.com/ansca/TinyPenguin.git",
                @"865b63634e55d6769e3a00b1da902c79ede68787", 29)]
        [TestCase(@"https://github.com/slembcke/debugger.lua.git",
                @"49baebfe73e3cc2ae5f17ee2997ad82b5ecd06d3", 29)]
        [TestCase(@"https://github.com/Olivine-Labs/lusty.git",
                @"97ff69c9ccc09a339969c4b2e08d94da9581c06d", 29)]
        [TestCase(@"https://github.com/RobSis/treesome.git",
                @"6486454d586f86ee4eebd9edcc6df76664ff9227", 29)]
        [TestCase(@"https://github.com/kindy/lj-web.git",
                @"81081dc8f29e09c977f864a035695d46a55395c1", 29)]
        [TestCase(@"https://github.com/fsantanna/luagravity.git",
                @"58c761ded3b8f27e1f2f7a0810898a9e91d7437a", 28)]
        [TestCase(@"https://github.com/DarkstarProject/darkstar.git",
                @"367bd9591cc586b06171c4679d7722cedad00557", 28)]
        [TestCase(@"https://github.com/derickd/moaigui.git",
                @"9e0300469df5c65bf2445705c2cda6df9bc81b1f", 28)]
        [TestCase(@"https://github.com/Eonblast/fleece-lite.git",
                @"06103ea87601c74801ca5780bc9014011243bbec", 28)]
        [TestCase(@"https://github.com/mason-larobina/luakit-plugins.git",
                @"d5c774952d1ebdb36b20f5dfedb0f831abb8743a", 28)]
        [TestCase(@"https://github.com/500px/500pxPublisher.lrplugin.git",
                @"09aa4a317c56f856ffef770ef1d37d1cc3d13f96", 28)]
        [TestCase(@"https://github.com/andycai/kodelua.git",
                @"b8556d073ef658959a1afc32fa6d2313e4285923", 28)]
        [TestCase(@"https://github.com/stevedonovan/luaish.git",
                @"6c5ea145e8faedd6bf65d7e80cb4fc741629cf16", 27)]
        [TestCase(@"https://github.com/Asphyxia/Tukui.git",
                @"3c8e581abc23fc8bcd7aa8668affe30e6204be5d", 27)]
        [TestCase(@"https://github.com/tullamods/Dominos.git",
                @"6d5b7bf1883d62c26b64ff635244a0e435c2074d", 27)]
        [TestCase(@"https://github.com/tadeuszwojcik/luvit-redis.git",
                @"a91d4584f5b1eab95923c3e48f838a4096b8499d", 27)]
        [TestCase(@"https://github.com/dmccuskey/Ghost-vs-Monsters---OOP.git",
                @"c9bbaadc02941f71f518d3258a7b0d0624ac9daf", 27)]
        [TestCase(@"https://github.com/rgieseke/locco.git",
                @"139fc5b8b3cd3fa6e1a4de777ec98ce59715ec18", 27)]
        [TestCase(@"https://github.com/Phrogz/SLAXML.git",
                @"8aa52bc271eb9a28b1f8f3c5260202ad1b6fcaf8", 27)]
        [TestCase(@"https://github.com/johnpolacek/Match-The-Letter-Game.git",
                @"4f164f80e997755f0999b678896058aa4e767818", 27)]
        [TestCase(@"https://github.com/GrahamRanson/Ice.git",
                @"0efbc709ce9b65526ed0939921ce0933e486ccb9", 27)]
        [TestCase(@"https://github.com/LazyZhu/lua-resty-ssdb.git",
                @"c7bdbcc8dc3ee23790fa9ca6ee3631e84fa0bf5d", 27)]
        [TestCase(@"https://github.com/Yonaba/Lua-Class-System.git",
                @"7c4b0f345e7d89835024c1aee763e8fde055ca3a", 27)]
        [TestCase(@"https://github.com/fgprodigal/RayUI.git",
                @"2ffd999fec0a372a70247058c6c00f8cb766acab", 26)]
        [TestCase(@"https://github.com/ildyria/iFilger.git",
                @"d092e040143146a551b6821b6a9b199a4b98e9db", 26)]
        [TestCase(@"https://github.com/sergeyzavadski/breeze.git",
                @"b17da085ca4691feb189690038b8d054b861d6e0", 26)]
        [TestCase(@"https://github.com/bioe007/awesome-revelation.git",
                @"2f28b196352199acd51d6967b19dcaf3d95a55e8", 26)]
        [TestCase(@"https://github.com/tullamods/OmniCC.git",
                @"434fb78fba9e891efdd9a43978efe00ab3232ad2", 26)]
        [TestCase(@"https://github.com/TACC/Lmod.git",
                @"4f4a3eae00a8c2d26daf42bb6038be9674971faa", 26)]
        [TestCase(@"https://github.com/Nayruden/ns2lua.git",
                @"9dc97d8b7aa7eee606e2fc0d55107b1cf52bc70a", 26)]
        [TestCase(@"https://github.com/fperrad/lua-Spore.git",
                @"af3be83d6569c17bd9b87d170b2530564ec7b3aa", 26)]
        [TestCase(@"https://github.com/silentbicycle/sidereal.git",
                @"145f788b5246e73f7cd9f82097161b63ee05b6f8", 26)]
        [TestCase(@"https://github.com/perky/FEZ.git",
                @"39186578f86f42bc554526ebb6184f943b16a2dc", 26)]
        [TestCase(@"https://github.com/desbouis/nginx-redis-proxy.git",
                @"1e9048f67c518f5093b6f516af240c39c4d1b678", 26)]
        [TestCase(@"https://github.com/decltype/forgottenmapeditor.git",
                @"bae6c103c688ab58c1e422179871779fbd6a8687", 26)]
        [TestCase(@"https://github.com/neomantra/lds.git",
                @"d3b054dc48ab7428ea0020ea81e79688ad160fa1", 26)]
        [TestCase(@"https://github.com/josemota/dotfiles.git",
                @"23abfcce78efc084854868dca9d57cb95b4feeff", 26)]
        [TestCase(@"https://github.com/robmiracle/Corona-SDK-RSS-Reader.git",
                @"0ff21a80b3c9548e265d9816428aa256007ff8a5", 26)]
        [TestCase(@"https://github.com/jaydipdave/quickdefencewaf.git",
                @"d6a0412e56beb856a06641c9d401a1a35e1ad7ca", 26)]
        [TestCase(@"https://github.com/diegofn/TuneIn-Radio-VLC.git",
                @"4e02c6b807ac31dd5256d7b370931db2a1ed4ccc", 26)]
        [TestCase(@"https://github.com/setkeh/Awesome-Laptop-3.5.git",
                @"3c96c14cfeed1beb7781097ef8a139e3296db362", 26)]
        [TestCase(@"https://github.com/ierton/awesomerc-ierton.git",
                @"7d0cbecc84266e2e11223f8fac5a25833589a21c", 25)]
        [TestCase(@"https://github.com/haveatry823/QSanguoshaAI.git",
                @"97b9a4cc39f3b320c741f20f53368ef490b9e753", 25)]
        [TestCase(@"https://github.com/leegao/see.lua.git",
                @"4f326f0ce435d6056787ded652e78729c60c439d", 25)]
        [TestCase(@"https://github.com/affli/Tukui_DBM.git",
                @"4d637aa6ea9c48fb55d5755ae98a8750cb6a762f", 25)]
        [TestCase(@"https://github.com/bartbes/lovelybigplanet.git",
                @"a8ff90107788e1b2375e0f347a89a0f47b16f2bb", 25)]
        [TestCase(@"https://github.com/kengonakajima/lua-msgpack.git",
                @"91fcc8910a5f5cb83de6119357402940ce309fcc", 25)]
        [TestCase(@"https://github.com/TheLinx/ltwitter.git",
                @"1859f60816a2c8d1b999db4d2fdfe0d671f047d6", 25)]
        [TestCase(@"https://github.com/johnpolacek/Video-Gallery.git",
                @"bad64b606c222165606237b204a4f5a57024cd4c", 25)]
        [TestCase(@"https://github.com/geekscape/mqtt_lua.git",
                @"aba95ca2f790d0aa0ca910a8c26f2455f8d3b166", 25)]
        [TestCase(@"https://github.com/ilua/ilua.git",
                @"c9ef6799113e71d89d629b29b266d1eba4105038", 25)]
        [TestCase(@"https://github.com/christopho/zsdx.git",
                @"878df4510abea1dcd6b05d861941a2926c0c265e", 25)]
        [TestCase(@"https://github.com/Etiene/sailor.git",
                @"5472932a2483fc3e7b69a4e69f7fa85caa245230", 25)]
        [TestCase(@"https://github.com/Senscape/Asylum-Teaser.git",
                @"52f4f5a0dcb868fd1ebb9b86f3e4c2dbdb4579d0", 24)]
        [TestCase(@"https://github.com/npryce/codea-controllers.git",
                @"38bbfb87a15627a594c625ccc6c4b90e7c63aae3", 24)]
        [TestCase(@"https://github.com/renstrom/NeavUI.git",
                @"e16a5b8fd402fd67b3d61b66531b2adbd1e24c8c", 24)]
        [TestCase(@"https://github.com/sacek/LPegLJ.git",
                @"a97c49b36abc172221fedbfc984dba108ede7f01", 24)]
        [TestCase(@"https://github.com/karai17/Simple-Tiled-Implementation.git",
                @"936a563e383366c7a68bd87148b8d535ebedd2f3", 24)]
        [TestCase(@"https://github.com/kikito/passion.git",
                @"1fb7233b4035cddb4e58ea18a9f590d011eb2f72", 24)]
        [TestCase(@"https://github.com/khaledhosny/luaotfload.git",
                @"9291e1983240e72d93815a096963dc28a7acd770", 24)]
        [TestCase(@"https://github.com/TekNoLogic/Panda.git",
                @"32b4d6e53446ae3579e9d72838c81113edd3549d", 24)]
        [TestCase(@"https://github.com/Elv13/radical.git",
                @"8da00cbd657f77fdfcd4b6a9cc81420daa2cb5e7", 24)]
        [TestCase(@"https://github.com/mydevelopergames/AutoLAN.git",
                @"b5353864003cb0ba20d5b1e37284dd97114cf1df", 24)]
        [TestCase(@"https://github.com/kikito/beholder.lua.git",
                @"9f1a31eb51f5e3775f1c111fab37a9f72db6deae", 24)]
        [TestCase(@"https://github.com/jgrahamc/lulip.git",
                @"4049423de9c02c25d1deebd54553211bf583e9d8", 24)]
        [TestCase(@"https://github.com/mlnlover11/LuaAssemblyTools.git",
                @"e496bc6df2e49ea0beebb26f216aca3821a2b28e", 24)]
        [TestCase(@"https://github.com/kikito/love-loader.git",
                @"d29176b54e5bf0ee2496d89f6eb5bbc4b35ae06d", 24)]
        [TestCase(@"https://github.com/TekNoLogic/GnomishVendorShrinker.git",
                @"dbf481f2cd0da671169c9673f976bf9a2d61e957", 23)]
        [TestCase(@"https://github.com/kikito/middleclass-extras.git",
                @"840a6b250f7fd8d46d796a3ec99c363651c626c0", 23)]
        [TestCase(@"https://github.com/Metapyziks/finalfrontier.git",
                @"3b22cc19b155834c0e9af7c107ee58f1cd4deea8", 23)]
        [TestCase(@"https://github.com/Wiladams/TINN.git",
                @"e588fff7f9e147ef4bc56e872cb385b56f712913", 23)]
        [TestCase(@"https://github.com/RustOxide/Oxide.git",
                @"b69be445c99762f70ebe4c3e42e53170d09a21cf", 23)]
        public void ParseGitRepository(string url, string commitPointer, int starCount) {
            var exp = new LuaComplexStatementExperiment();
            VerifyRestoringGitRepoSavingThem(
                    url, commitPointer, "lua_repo.csv", starCount,
                    cst => cst.DescendantsAndSelf()
                            .Where(exp.OriginalIsAcceptedUsingOracle)
                            .Count(), "*.lua");
        }
    }
}