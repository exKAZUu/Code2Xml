using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using ParserTests;

namespace Code2Xml.Languages.Tests
{
    [TestFixture]
    public class CleanUp
    {
        [Test]
        public void ShowCandidates() {
            var fixturePath = Fixture.FixturePath;
            var directories = Directory.GetDirectories(
                    fixturePath, ".git", SearchOption.AllDirectories)
                    .Select(Path.GetDirectoryName)
                    .Where(
                            path =>
                                    Directory.GetDirectories(path).Length
                                    + Directory.GetFiles(path).Length <= 1);
            foreach (var directory in directories) {
                try {
                    Directory.Delete(directory, true);
                } catch (Exception e) {
                    Console.WriteLine(directory);
                }
            }
        }
    }
}
