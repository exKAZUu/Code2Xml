using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Code2Xml.Learner.Core.Learning.Experiments {
    public class Experiment {
        protected readonly Dictionary<string, StreamWriter> Writers;

        public const int SkipCount = 0;
        public const int TakeCount = 1;

        public Experiment() {
            Writers = new Dictionary<string, StreamWriter>();
        }

        public void Test(List<string> seedPaths, string searchPattern, LearningExperiment exp, string projectPath) {
            StreamWriter writer;
            var expName = exp.GetType().Name;
            if (!Writers.TryGetValue(expName, out writer)) {
                writer = File.CreateText(@"C:\Users\exKAZUu\Dropbox\Data\" + expName + SkipCount + "_" + TakeCount + ".csv");
                Writers.Add(expName, writer);
            }
            var ret = exp.Learn(seedPaths, writer, projectPath, searchPattern);
            writer.WriteLine();
            writer.Flush();
            if (ret.WrongFeatureCount > 0) {
                Console.WriteLine("--------------- WronglyAcceptedElements ---------------");
                foreach (var we in ret.WronglyAcceptedElements) {
                    var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                    Console.WriteLine(we.Code);
                    Console.WriteLine(e.Code);
                    Console.WriteLine("---------------------------------------------");
                }
                Console.WriteLine("---- WronglyRejectedElements ----");
                foreach (var we in ret.WronglyRejectedElements) {
                    var e = we.AncestorsAndSelf().ElementAtOrDefault(5) ?? we;
                    Console.WriteLine(we.Code);
                    Console.WriteLine(e.Code);
                    Console.WriteLine("---------------------------------------------");
                }
            }
            exp.Clear();
            Assert.That(ret.WrongFeatureCount, Is.EqualTo(0));
        }
    }
}