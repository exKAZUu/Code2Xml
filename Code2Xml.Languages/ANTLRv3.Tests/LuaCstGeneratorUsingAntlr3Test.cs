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
        [TestCase(@"https://github.com/pygy/strung.lua.git",
                @"f17cdabe1973eaa5cb1ce7817822f7a8c37b8d8b", 23)]
        [TestCase(@"https://github.com/circumjacence/ConkyInfinitySVG.git",
                @"14aa1812dd4a596b23df70d58b78b8052258b9b5", 23)]
        [TestCase(@"https://github.com/lonelyplanet/openresty-statsd.git",
                @"9b1a788cabe1fcb20843f4dc0d78468ed04f9a62", 23)]
        [TestCase(@"https://github.com/Cluain/Lua-Simple-XML-Parser.git",
                @"2c318f3b01121dad61dee34b8c80c970ff938192", 23)]
        [TestCase(@"https://github.com/golgote/neturl.git",
                @"258c3f6e637030a39265b74ae1e9d681cf977296", 23)]
        [TestCase(@"https://github.com/JackH79/.dotfiles.git",
                @"b957416b6a83a0d05fa943067e821ed77732c201", 22)]
        [TestCase(@"https://github.com/kamaitama/Tiramisu--outdated--don-t-use-.git",
                @"15a847ad05042ae4d7b1117b887902e33470f076", 22)]
        [TestCase(@"https://github.com/Wiladams/LJIT2Win32.git",
                @"59e4419fc4fae4af2553e65fbbaa3d8a0125b4c4", 22)]
        [TestCase(@"https://github.com/haimanman/jx3.git",
                @"4fbdd1db34096d1c904ca426aa0f19c4f29595c5", 22)]
        [TestCase(@"https://github.com/PrinterLUA/FORGOTTENSERVER-ORTS.git",
                @"916b8b9341dac800a7adbbe76efb1b56d1bdb78d", 22)]
        [TestCase(@"https://github.com/Thalassicus/cep-bnw.git",
                @"a0f24cc82fd05ed2b1bfff411f276e8ef7ace176", 22)]
        [TestCase(@"https://github.com/affli/xCT.git",
                @"c20ea295aa816b53b6294eae47d6c4af2eb623d7", 22)]
        [TestCase(@"https://github.com/mascarenhas/luaclr.git",
                @"b0586fcba4320beab46a2d243ca80894fee02afd", 22)]
        [TestCase(@"https://github.com/Haleth/FreeUI.git",
                @"60353ebfe2a143c7beb32ba600701b6dd89e7398", 22)]
        [TestCase(@"https://github.com/speedata/publisher.git",
                @"8f4415a068bd7561f514b7cc6cc603e415a1bde6", 22)]
        [TestCase(@"https://github.com/FPtje/Sublime-GLua-Highlight.git",
                @"7a5a310f440519a25d4f344fcd25906fdd5baf98", 22)]
        [TestCase(@"https://github.com/xolox/lua-lxsh.git",
                @"ee16ce4903616030a26c15c4f8ce2222434f0ade", 22)]
        [TestCase(@"https://github.com/davidm/lua-bit-numberlua.git",
                @"30b6828b298b46411b548202d40524caba06a99c", 22)]
        [TestCase(@"https://github.com/mikar/awesome-themes.git",
                @"877511213c3db9397166bcd1436087b39387aa5d", 22)]
        [TestCase(@"https://github.com/ansca/Storyboard-Sample.git",
                @"500f3bfeda09abf6cf82f679b3e14cad65b40900", 22)]
        [TestCase(@"https://github.com/zrong/lua.git",
                @"5e3e50524a36552e95a4cdda2025dbb8b1694a65", 22)]
        [TestCase(@"https://github.com/lovelyrpgcommunity/A-Whiff-of-Steam.git",
                @"e44aea49b6de9955603cb4db5cd88beea003f3f0", 21)]
        [TestCase(@"https://github.com/fperrad/lua-TestMore.git",
                @"627b3b84afae5c0395f2c336ee710539792e4fac", 21)]
        [TestCase(@"https://github.com/DracoBlue/lua-oauth.git",
                @"e09c6325713cde008416b9211fb57b284352f9a3", 21)]
        [TestCase(@"https://github.com/creationix/nodeconf2012.git",
                @"879fcbe34143e3784fc3110637d467a62552d472", 21)]
        [TestCase(@"https://github.com/Meneth/PB-git.git",
                @"0b1a1abafea33f8009f6502a3a5807ee89065d2e", 21)]
        [TestCase(@"https://github.com/RafaelDeJongh/cap.git",
                @"c411140a3d0aa69f5752388c83d281bd5eb39755", 21)]
        [TestCase(@"https://github.com/RafaelDeJongh/cap_resources.git",
                @"049e4f6a34937c5ac969d611e6e5f668e27f481a", 21)]
        [TestCase(@"https://github.com/davidm/lua-matrix.git",
                @"7a33f9652ddc6808ec9eb866d9e214546bbfc765", 21)]
        [TestCase(@"https://github.com/quaker66/vortex.git",
                @"2993be665f412b8243470597e34bd9f61f5513d1", 21)]
        [TestCase(@"https://github.com/Wiladams/LJIT2RPi.git",
                @"43cf70d697de45344b660c05ef36b53c3df81617", 21)]
        [TestCase(@"https://github.com/TekNoLogic/Cork.git",
                @"1b40e35a31c1048033b6f6b94600581b389a46d9", 21)]
        [TestCase(@"https://github.com/hoelzro/lua-term.git",
                @"76d7c992a22d4481969a977ad36d6d35d3b2ca6f", 21)]
        [TestCase(@"https://github.com/ansca/Pinball-Madness.git",
                @"70679e4d288cf21cc612146f11c8d24fcdb51834", 21)]
        [TestCase(@"https://github.com/duff333/Parallax-Class.git",
                @"cf6c6f4a4e90208ca9b6fd10d439825017a900b3", 21)]
        [TestCase(@"https://github.com/coronalabs/CoronaCrush.git",
                @"211be29c3c9b90d4e762c8c502c543f6e6937d63", 21)]
        [TestCase(@"https://github.com/wscherphof/lua-htmlparser.git",
                @"a8b5f6fb3160ababb5bc2c11bc4b2b0b67439be5", 21)]
        [TestCase(@"https://github.com/clementfarabet/torch-tutorials.git",
                @"844457015aa1c23f60b4d75fc4a79e745f322e2e", 21)]
        [TestCase(@"https://github.com/roaminggamer/RG_FreeStuff.git",
                @"8c27742b04911fe1f1ed348390681a46d04be6c7", 20)]
        [TestCase(@"https://github.com/sharpobject/panel-attack.git",
                @"129b7094c1fc7bf26494acf9f819b164e95e1cc6", 20)]
        [TestCase(@"https://github.com/minetest-technic/technic.git",
                @"44dbc75b6115d5235ba0538925e44484037459a1", 20)]
        [TestCase(@"https://github.com/joshtynjala/gtween.lua.git",
                @"572000edf616c2c7ce2c5ab15e550da97f8d928f", 20)]
        [TestCase(@"https://github.com/Movimento5StelleLazio/ParlamentoElettronicoM5S.git",
                @"415d0b8c03bbda585171e1a795b7dc45d7d15bb7", 20)]
        [TestCase(@"https://github.com/CK2Plus/CK2Plus.git",
                @"d34cdd807f66990e040edcbba462191d56f36852", 20)]
        [TestCase(@"https://github.com/codepunkschmidt/Codepunk-s-Code.git",
                @"f2f76b3c1662e864269ca34f3540e90b61a375a4", 20)]
        [TestCase(@"https://github.com/mkottman/lua-git.git",
                @"d64218a227fe26b1fc971a8802f74a1921e0187e", 20)]
        [TestCase(@"https://github.com/bartbes/Class-Commons.git",
                @"53f6f546d20f9ff68d72b894b4c585be9dab9160", 20)]
        [TestCase(@"https://github.com/keplerproject/cgilua.git",
                @"4ef15e7b641202325ba220e1700c60a23692f8dd", 20)]
        [TestCase(@"https://github.com/graue/luasynth.git",
                @"4ddb9e9b587cfb62b2bca4914b3c67bb862338ab", 20)]
        [TestCase(@"https://github.com/altuzar/Appsamuck_Corona_SDK.git",
                @"b4015eb491f6a8408a8201218048f49253665f25", 20)]
        [TestCase(@"https://github.com/jolicloud/jolicloud-desktop-environment.git",
                @"77cb7b64647d1d10cbf40f30d6c11b8c05a9e96a", 20)]
        [TestCase(@"https://github.com/bungle/lua-resty-template.git",
                @"aadc42ba718de8dc97fe8d2dd3f64fdd837f9910", 20)]
        [TestCase(@"https://github.com/06wj/cocos2d_lua_snippets.git",
                @"e8486c6d51a63ef79552afd5bb556ae07b8558af", 20)]
        [TestCase(@"https://github.com/norman/grackle.git",
                @"f0b88c9f7a3b3a2df197decbd4b90147c9ac4c05", 19)]
        [TestCase(@"https://github.com/pixeltailgames/cinema.git",
                @"3bbc936bae1a2c538f5fbc8cc9e31da8fe238212", 19)]
        [TestCase(@"https://github.com/ar2rsawseen/GiderosCodingEasy.git",
                @"9778dc91ed6d88b36b6140d59ec92d942705af87", 19)]
        [TestCase(@"https://github.com/stevedonovan/Orbiter.git",
                @"92378b529bad80669ade6f989933fbb37d445319", 19)]
        [TestCase(@"https://github.com/flukso/flm02.git",
                @"7564cae07ac0cea60fbb137e1a96424d6bd397f4", 19)]
        [TestCase(@"https://github.com/iGARET/MovieClipX.git",
                @"6046016454c5814513f50e54c029f61bad1b7fc0", 19)]
        [TestCase(@"https://github.com/michal-h21/tex4ebook.git",
                @"cbe484bcaa764f8874dab0666c00091df5e55cd3", 19)]
        [TestCase(@"https://github.com/clementfarabet/torch7-demos.git",
                @"0991dec5d6c09ceba6452a6d6b6a5f466de6a12c", 19)]
        [TestCase(@"https://github.com/SimonLarsen/sienna.git",
                @"ba33bd8aa5a49ec3565f9580f6ff84b06f0b4ed2", 19)]
        [TestCase(@"https://github.com/liquidbase/Duffed-UI.git",
                @"6fc01613c88f991350d9d1cbd50258282479ed32", 18)]
        [TestCase(@"https://github.com/corsix/ffi-reflect.git",
                @"b01e2421722e591173cd53fd082b6372c358b4d5", 18)]
        [TestCase(@"https://github.com/jdesgats/ILuaJIT.git",
                @"dde5d2597b2e3142c937191a30906f72f463f9e8", 18)]
        [TestCase(@"https://github.com/bennychen/Moai-based-Pacman.git",
                @"865f9d6fa27ec65c83d4c4100a84dced32b41fa1", 18)]
        [TestCase(@"https://github.com/TekNoLogic/teksLoot.git",
                @"ab416d90d878d9def517f20043989b9bdd3e8715", 18)]
        [TestCase(@"https://github.com/mabako/mta-paradise.git",
                @"6d4a852e27a276920943827426b9cf88e20a6b7d", 18)]
        [TestCase(@"https://github.com/ayourtch/gliese.git",
                @"4635b1b1874c877c291169c3298b64b5d030fe57", 18)]
        [TestCase(@"https://github.com/jnwhiteh/luasandbox.git",
                @"3623705ef17767aa31125f124023a1f8d48e644f", 18)]
        [TestCase(@"https://github.com/andrewmcwatters/steamweb-lua-sdk.git",
                @"f86cfd6b5a2e32196c1bb433266a34395618b9b7", 18)]
        [TestCase(@"https://github.com/agladysh/luatexts.git",
                @"2ca61795384aa9a9685776527515266894d3471b", 18)]
        [TestCase(@"https://github.com/kikito/memoize.lua.git",
                @"30218efdba2fe563117f4176849afa2e76ddaa9d", 18)]
        [TestCase(@"https://github.com/3SillyHats/LoveHotel.git",
                @"b5858b621afde54272a7b057a3011851d7382a73", 18)]
        [TestCase(@"https://github.com/leegao/Rocket-for-Lua.git",
                @"7767a250d2e52579a34d2da6a19e43a9a8810994", 18)]
        [TestCase(@"https://github.com/JesterXL/PlaneShooter.git",
                @"d0a80f993e2b94ee7eba9bc07f60d9f125ddaf1a", 18)]
        [TestCase(@"https://github.com/latestpost/Moai-Examples.git",
                @"aea47812478686184dfc9f0f974b1fe63b23ebc1", 18)]
        [TestCase(@"https://github.com/randrews/color.git",
                @"62b72b6b45a0ceb19d8bae7deca8ac0a9d62d169", 18)]
        [TestCase(@"https://github.com/Shadowed/ShadowedUnitFrames.git",
                @"0e15e2e55c08ad922657a6850823d15d7145d049", 18)]
        [TestCase(@"https://github.com/cldrn/nmap-nse-scripts.git",
                @"9cc8c91f7b16c4eaa1735642be9807e174c4177d", 18)]
        [TestCase(@"https://github.com/bsm/fakengx.git",
                @"20920a35d2d3d0104e36784efbbafa873b4cb134", 18)]
        [TestCase(@"https://github.com/coronalabs/framework-widgets-legacy.git",
                @"ad47e84c5febfd9c8c40ca9b163cace973db0dca", 18)]
        [TestCase(@"https://github.com/ittner/lua-iconv.git",
                @"2205a0fe274ee0e59b1b15dcd5a11a4325fecead", 18)]
        [TestCase(@"https://github.com/xspacesoft/PropHunt.git",
                @"5f38363f44080d173515c48c9977a57f226f4d6a", 18)]
        [TestCase(@"https://github.com/malkia/luajit-opencl.git",
                @"72cba1c258b604ee301015cd6ac00dc264b0eef7", 17)]
        [TestCase(@"https://github.com/francois2metz/pomodoro-awesome.git",
                @"d6a4b06308b713abf396e622e507bd8c64daf388", 17)]
        [TestCase(@"https://github.com/iamwilhelm/frock.git",
                @"957eb561d41ea15b3ce0f6af5ceb3132378fcbf3", 17)]
        [TestCase(@"https://github.com/Adze1502/mwan.git",
                @"e7ce8cc03e9ca563a341021b729325f8f0847027", 17)]
        [TestCase(@"https://github.com/alexander-yakushev/Orglendar.git",
                @"a33fbe7adb838d5292ebe38cc829c6b3771df348", 17)]
        [TestCase(@"https://github.com/mikejsavage/flea.git",
                @"de59a9c3072aff59ece9a5808f31decae0e029d3", 17)]
        [TestCase(@"https://github.com/sacek/Luajit-LPEG.git",
                @"12a777b074d27a2724cf4e3bd344fddc2b0b3008", 17)]
        [TestCase(@"https://github.com/gigamo/awesome-configs.git",
                @"8417a0c6fc906b110d3be3cf47b1f7ceeca1a03d", 17)]
        [TestCase(@"https://github.com/spc476/LPeg-Parsers.git",
                @"92bc1752975abc8e1a713e210271fa9f0d0f7843", 17)]
        [TestCase(@"https://github.com/cornelisse/LuaFSM.git",
                @"efbb263562917165e1d7ecdd905348619c59746f", 17)]
        [TestCase(@"https://github.com/dvv/luvit-websocket.git",
                @"02b74c14fe547a32e858c56717af78757076e258", 17)]
        [TestCase(@"https://github.com/bowerhaus/BhWax.git",
                @"43a1bdd811a77fe0fbc2dd92963946d855a7a340", 17)]
        [TestCase(@"https://github.com/slact/lua-ohm.git",
                @"91b7fb3649d8a120c8329949c0b92272914488ef", 17)]
        [TestCase(@"https://github.com/gideros/Scene-Manager.git",
                @"c62d27d52752d5e49df80cb1d6ee05ee66a3d11a", 17)]
        [TestCase(@"https://github.com/kainosnoema/remq.git",
                @"3cd3deb56d62bb2ebcc353103db04e8717878f5b", 17)]
        [TestCase(@"https://github.com/torque/Aegisub-Motion.git",
                @"fad9f464a0faf3741ab751efdcbb2936b31c77ea", 17)]
        [TestCase(@"https://github.com/ppissanetzky/AndThen.git",
                @"95575c7ef883554c3f3f61d3aaee7139ec071817", 17)]
        [TestCase(@"https://github.com/callin2/ParticleSugar.git",
                @"4c0e661db118ef6dbe8c472e5de627f68ac3a721", 17)]
        [TestCase(@"https://github.com/Tieske/date.git",
                @"ac569c1a7036b7a2131b94776543c1e7bdc378b3", 17)]
        [TestCase(@"https://github.com/kikito/gamera.git",
                @"bf85cbf8416e82e1d2399c0e2ca81f27500959ce", 17)]
        [TestCase(@"https://github.com/menudoproblema/Wireshark-MQTT.git",
                @"d208c656126c393d018c692aaba7a7a8459e7673", 17)]
        [TestCase(@"https://github.com/fperrad/lua-CodeGen.git",
                @"fa086ff237875753d8b26f98728e489b1aca2d1d", 16)]
        [TestCase(@"https://github.com/weshoke/codepeg.git",
                @"51ef031a2463f075b53f0dba95b91ab46eb9736f", 16)]
        [TestCase(@"https://github.com/adamdburton/pointshop.git",
                @"53c8896258437a4cb4317e8b7f09f44add4be6bc", 16)]
        [TestCase(@"https://github.com/davidm/lua-fish.git",
                @"9e5183da866f2b71636492734170d30191ec198a", 16)]
        [TestCase(@"https://github.com/Person8880/Shine.git",
                @"63ffc5f7d3c94afd785f7bc376420e78a12440c6", 16)]
        [TestCase(@"https://github.com/timn/lua-xmlrpc.git",
                @"b12ac249d62dc66ba76e7da4adbced8aa37fe8a3", 16)]
        [TestCase(@"https://github.com/SpaceTown-Developers/Lemon-Gate.git",
                @"8d561d204a52929670718c9c58956d2dda03eb8a", 16)]
        [TestCase(@"https://github.com/radare/lum.git",
                @"70abe3deb2de18f53b3f635008f230889d61668a", 16)]
        [TestCase(@"https://github.com/Jasje/JasjeUI.git",
                @"3473486d3142e135d8450ae7606cbd5013ce5164", 16)]
        [TestCase(@"https://github.com/dodo/uzful.git",
                @"51898ac2a28f8869d0e1983ab1e492b7b45ee375", 16)]
        [TestCase(@"https://github.com/ansca/Flight-Path.git",
                @"6d65ac819354e740f1bc28e01d69ab6775801083", 16)]
        [TestCase(@"https://github.com/rit-sse/RapDevXI.git",
                @"ac966362765f8f877fc3e05f40d6b46a95bac9cb", 16)]
        [TestCase(@"https://github.com/pkulchenko/ZeroBraneEduPack.git",
                @"37a15344f1ac162e53956ce6b83188a560063499", 16)]
        [TestCase(@"https://github.com/s2games/Heroes-of-Newerth-Bots.git",
                @"d267b6df4f0ea1e19d6419606251a6c38a7065fc", 16)]
        [TestCase(@"https://github.com/ayourtch/luajit-fun.git",
                @"54fd54d2b6f173c33428bd984365f05a36e33821", 16)]
        [TestCase(@"https://github.com/nanoant/glua.git",
                @"6eb2c470d9b430ffe1e9af7c3e60676f38eff9ad", 16)]
        [TestCase(@"https://github.com/bakins/lua-resty-riak.git",
                @"c14c61b3035869d8424de9c4ee47ec380544d742", 16)]
        [TestCase(@"https://github.com/perky/Goo.git",
                @"c4101d31b1915381788901c3027bdcd2da423893", 16)]
        [TestCase(@"https://github.com/ansca/Simple-Pool.git",
                @"cc261ca0dac4099b024a596d684417dcc158fbf3", 16)]
        [TestCase(@"https://github.com/ea/nmap-scripts.git",
                @"30858bb1ae8778bf4aba1ea631325a91a1bca4b2", 16)]
        [TestCase(@"https://github.com/Patsky/Match-3-Gems-Puzzle-Game.git",
                @"cbc564e7e322b07863effed66f7fbb5a1ee008a3", 16)]
        [TestCase(@"https://github.com/Xandaros/evolve.git",
                @"946852f4fc0dade9f63a61a65ff1d106dfa6ae2c", 16)]
        [TestCase(@"https://github.com/clementfarabet/lua---parallel.git",
                @"bbeb0ae7f6c8c41a580e61210fd9aafcc3d51f53", 16)]
        [TestCase(@"https://github.com/daly88/lutem.git",
                @"a15bda104ff6cb758599b9bf3efc5ee742f3ba41", 16)]
        [TestCase(@"https://github.com/freifunk/luci.git",
                @"14c50067dc6aed27bc5e53e2ebab015849a7845e", 16)]
        [TestCase(@"https://github.com/adriweb/EEPro-for-Nspire.git",
                @"b2be315f3e9fbf3ce017f10cade657c613ad09e1", 16)]
        [TestCase(@"https://github.com/gorlowski/couth.git",
                @"f6ffc89e32e3b6c9f6a394c70708aa78d492eb07", 15)]
        [TestCase(@"https://github.com/norman/hops.git",
                @"b89744c7b2fe54ae2e3e9f8e632d5a78bee77243", 15)]
        [TestCase(@"https://github.com/loghound/Corona-Transitions.git",
                @"6f2c661893eaafc1935a53cef969f91284040c5d", 15)]
        [TestCase(@"https://github.com/ansca/Gear-Animation.git",
                @"082bd66b2589d37624e09f0be8d6501512c8ddf7", 15)]
        [TestCase(@"https://github.com/kengonakajima/luvit-mysql.git",
                @"1c93b1c63a8d35fd139d5ed5720752c9c68a94e3", 15)]
        [TestCase(@"https://github.com/lloydpick/gathererdb_wowhead.git",
                @"a404fa4f372d59f48836479d125e7a2b213aaadc", 15)]
        [TestCase(@"https://github.com/Etiene/valua.git",
                @"5c541c55c1a16469ef7ed1c34de2511f6916c6a3", 15)]
        [TestCase(@"https://github.com/rxi/lume.git",
                @"c7471b32fbfcd0f1cc3b94eefbb4c76d3f99a20e", 15)]
        [TestCase(@"https://github.com/Fizzadar/Luawa.git",
                @"4cc4c97f9ca4d61e73f20eeb3aa23a55dba59f8e", 15)]
        [TestCase(@"https://github.com/unifiedremote/sandbox.git",
                @"840c864a692ed00b62235273832e399dd11232de", 15)]
        [TestCase(@"https://github.com/mascarenhas/cosmo.git",
                @"52ba6e3b25649d5b771721a6b7cc19150fbfadcd", 15)]
        [TestCase(@"https://github.com/Olivine-Labs/luassert.git",
                @"365522d7586079ca2c8d233051f355b3f3eda4a9", 15)]
        [TestCase(@"https://github.com/TheLinx/SocialLua.git",
                @"37cd94d2f79bc64b309116155dba807476e51f82", 15)]
        [TestCase(@"https://github.com/Krevlorne/Tukui_Castbar.git",
                @"3c2b58b687ea96b9dd327288160c74338ead9f2f", 15)]
        [TestCase(@"https://github.com/farhaven/awesome-configs.git",
                @"6b0a8b6b0f30836d1d0bc2e30d7b9dbd613c61d4", 15)]
        [TestCase(@"https://github.com/davidhollander/ox.git",
                @"f63d0dfd30da567e5604b9a92d2f6f64e1cd9de0", 15)]
        [TestCase(@"https://github.com/openitg/itg3theme.git",
                @"7aa72330b22f0a37f4acaa666904b6a93ae9efe9", 15)]
        [TestCase(@"https://github.com/jasonsantos/remdebug.git",
                @"8d16df8262d21cee5a882cec46964f72e4a353de", 15)]
        [TestCase(@"https://github.com/liyanrui/zhfonts.git",
                @"714bab914a770b6c594b0f32fd84a5d69b47bbd1", 15)]
        [TestCase(@"https://github.com/mkosler/LoveAStar.git",
                @"d8ab63403b084dcb52587cf3264ab415e0523cc1", 15)]
        [TestCase(@"https://github.com/tomasguisasola/luasoap.git",
                @"af1e100281cee4b972df10121e37e51d53367a98", 15)]
        [TestCase(@"https://github.com/zm33y/vlc-lua-sia.git",
                @"6f6f1f1012e5e8c9f05d83e1dacb4b1281e62811", 15)]
        [TestCase(@"https://github.com/GmodStarfall/Starfall.git",
                @"27677e471dc07ebb9ad1456622c2d76dcd1d462f", 15)]
        [TestCase(@"https://github.com/moteus/lzmq.git",
                @"185e626ef6236b0bcddcaa37f0b0590406aba2ab", 15)]
        [TestCase(@"https://github.com/Elv13/blind.git",
                @"f6f2057d898b671d6bcf78c192ba2eba722f3104", 15)]
        [TestCase(@"https://github.com/linkedin/dmarc-msys.git",
                @"d05cc79753b87701d0ee0e99ee7e3fd29f2e4a37", 15)]
        [TestCase(@"https://github.com/gvx/richtext.git",
                @"28bc742afbb39a27a3dd38ea8976a4e9d56189b1", 14)]
        [TestCase(@"https://github.com/rjpower/luajit-interpreter.git",
                @"1bb90c05f3819d763653fbe889849e7ecfffd384", 14)]
        [TestCase(@"https://github.com/neomantra/nm-luajit-playground.git",
                @"32dadfd516e2a3d5c3fb6d91206707fd990f7146", 14)]
        [TestCase(@"https://github.com/CapsAdmin/pac3.git",
                @"762cb8dc2c322786fba95ff8773f2b9b2559d7ee", 14)]
        [TestCase(@"https://github.com/microlua/release.git",
                @"b54d7d186799a9d1655dcd41889dda27184155e1", 14)]
        [TestCase(@"https://github.com/Zireael07/The-Veins-of-the-Earth.git",
                @"0c3018ffb67bef0f65b7550326c75e593b6bd02e", 14)]
        [TestCase(@"https://github.com/Spyder638/SuperSprite.git",
                @"c42de75cbec3db94531e3ed9c52b9aca0ece9607", 14)]
        [TestCase(@"https://github.com/dmzgroup/io.git",
                @"621e0bb486641c69e7049cf9ea26dae80f736aa4", 14)]
        [TestCase(@"https://github.com/koniu/awesome-configs.git",
                @"9e540de676b305857e526830f14fabe7e65ce53b", 14)]
        [TestCase(@"https://github.com/haste/oGlow.git",
                @"fb0007a86fb334cbca8a8e2f99992d8e44cd23c9", 14)]
        [TestCase(@"https://github.com/mikelovesrobots/lua-enumerable.git",
                @"be92fdc222684608aacec82020eff9dfc8bcd231", 14)]
        [TestCase(@"https://github.com/prefanatic/exsto.git",
                @"fcbf79c7f1ef5d84fe6fb57738ca3f4747ccd866", 14)]
        [TestCase(@"https://github.com/philnelson/A-Star-Pathfinding-For-Lua.git",
                @"486dcd36709215bec7a8d8841439c168149cbd84", 14)]
        [TestCase(@"https://github.com/alfredbaudisch/Corona-Transition-Manager.git",
                @"126189b0e8cfd5853e8663e55c3cde5283db0889", 14)]
        [TestCase(@"https://github.com/nanomsg/luajit-nanomsg.git",
                @"fdeb72d290f0fc0c02ee4c96ee9e08b96bb53b80", 14)]
        [TestCase(@"https://github.com/GloryFish/lua-astar.git",
                @"5dcffa1d5dddf19592385b798d9310eafa0aeec2", 14)]
        [TestCase(@"https://github.com/sinaris/AsphyxiaUI---v6.git",
                @"b0f568239cf8c42a639f3627306c9c519f417a46", 14)]
        [TestCase(@"https://github.com/ColonelThirtyTwo/lsqlite3-ffi.git",
                @"a7e36bb057ad9f22010912f3ecf732e5333973d4", 14)]
        [TestCase(@"https://github.com/aconbere/vert.git",
                @"8974337bca570830c68a9dce42fcf1e05c1efec1", 14)]
        [TestCase(@"https://github.com/amireh/lua_cliargs.git",
                @"504e5aa9ab8929404d129046fb9493386962a95a", 14)]
        [TestCase(@"https://github.com/Saegor/isomap.git",
                @"a6e54476a05a171f72493c7ccb7dde0d3e095a81", 14)]
        [TestCase(@"https://github.com/weshoke/DSL.git",
                @"da0791b4e6855efd0f63b8a1a597db1186ff0854", 14)]
        [TestCase(@"https://github.com/tophermade/Menu-Structure.git",
                @"0a32c1809a325c904df9143fdfec03c02a17f69d", 14)]
        [TestCase(@"https://github.com/speedata/luaqrcode.git",
                @"6f48c2f990d0e2a2d0964c299a3a8b38bdcc4370", 14)]
        [TestCase(@"https://github.com/bsm/lua-resty-http.git",
                @"50210eb954a25cf497d5395a3dadf6a3b1027940", 14)]
        [TestCase(@"https://github.com/kikito/i18n.lua.git",
                @"4e2b9c2a945bd9681f811f885a9148ae09653299", 14)]
        [TestCase(@"https://github.com/SidaBoL/Scripts.git",
                @"8fd8b9551ee13f5caf3c318db68d9a0571ce1f78", 14)]
        [TestCase(@"https://github.com/vfasky/catke-for-luvit.git",
                @"578f642191086d0ea00095fcb3f38e5f106229d9", 14)]
        [TestCase(@"https://github.com/Xruptor/BagSync.git",
                @"c9129b229a1a8a941567826136d079bf6339ad4b", 13)]
        [TestCase(@"https://github.com/Abica/lime.git",
                @"faf1e6074abc76ec22300f1d88dac466aebb834d", 13)]
        [TestCase(@"https://github.com/pib/calabash.git",
                @"2c837819bd3d5c9fa618a06f898c5fc80c2bf480", 13)]
        [TestCase(@"https://github.com/capmar/spriter-love2d.git",
                @"4867632e829a1e2c4384cc77bf4f9d25e1273e31", 13)]
        [TestCase(@"https://github.com/alexander-yakushev/menubar.git",
                @"b2a184d8b3312b48ec1e17e2c5092cc0f15323c2", 13)]
        [TestCase(@"https://github.com/Repooc/ElvUI_SLE.git",
                @"4f5e0ad360a9ee6392d656da50bc2448b334206c", 13)]
        [TestCase(@"https://github.com/jzwinck/redis-wireshark.git",
                @"23842e5a9dc891782466f7a1eee5f303482edc52", 13)]
        [TestCase(@"https://github.com/ELLIOTTCABLE/System.git",
                @"d8a54cbc8dba8af73c26087506c458272037ab8b", 13)]
        [TestCase(@"https://github.com/thehunmonkgroup/luchia.git",
                @"3f70eb6b6ac510c710e5052c7db9d727a7a3530f", 13)]
        [TestCase(@"https://github.com/DanielFGray/dotfiles.git",
                @"880e84e14699212436cafb3c20d8f07319862a2f", 13)]
        [TestCase(@"https://github.com/dmzgroup/lmk.git",
                @"134c9237e48fc17a2252a2a705f5c36a467b40ac", 13)]
        [TestCase(@"https://github.com/Shrike78/Shilke2D.git",
                @"8da54c029e2e121511144f17d2f600cd267d4c1c", 13)]
        [TestCase(@"https://github.com/Sorroko/cclite.git",
                @"da8fc58b7e5f9d6907971d84bfa1a7b6f1d8b7da", 13)]
        [TestCase(@"https://github.com/clementfarabet/graphicsmagick.git",
                @"4c28978faf1b5e7a63170553eb4d2b2274b0307b", 13)]
        [TestCase(@"https://github.com/katcipis/luanotify.git",
                @"de6abf748c1aeae2eaec760da4420d8ee2e41e60", 13)]
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