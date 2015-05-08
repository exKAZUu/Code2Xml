using System;
using AForge.Neuro;
using AForge.Neuro.Learning;
using NUnit.Framework;

namespace Code2Xml.Learner.Core.Learning.Perceptron {
    [TestFixture]
    internal class PerceptronTest {
        [Test]
        public void test() {
            // initialize input and output values
            var input = new double[4][] {
                new double[] { 0, 0 }, new double[] { 0, 1 },
                new double[] { 1, 0 }, new double[] { 1, 1 }
            };
            var output = new double[4][] {
                new double[] { 0 }, new double[] { 1 },
                new double[] { 1 }, new double[] { 1 }
            };
            // create neural network
            var network = new ActivationNetwork(
                    new SigmoidFunction(2),
                    2, // two inputs in the network
                    //2, // two neurons in the first layer
                    1); // one neuron in the second layer
            // create teacher
            var teacher =
                    new BackPropagationLearning(network);
            // loop
            while (true) {
                // run epoch of learning procedure
                var error = teacher.RunEpoch(input, output);
                // check error value to see if we need to stop
                // ...
                if (error < 0.001) {
                    break;
                }
            }
            Console.WriteLine(network.Compute(new double[] { 0, 0 })[0] + ","
                              + network.Compute(new double[] { 0, 1 })[0] + ","
                              + network.Compute(new double[] { 1, 0 })[0] + ","
                              + network.Compute(new double[] { 1, 1 })[0]);
        }
    }
}