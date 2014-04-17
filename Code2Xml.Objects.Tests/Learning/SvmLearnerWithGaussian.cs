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
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;

namespace Code2Xml.Objects.Tests.Learning {
	public class SvmLearnerWithGaussian : LearningAlgorithm {
		private readonly IKernel _kernel;

		public override string Description {
			get { return "SVM with " + _kernel; }
		}

		public SvmLearnerWithGaussian() {
			_kernel = new Gaussian();
		}

		public SvmLearnerWithGaussian(IKernel kernel) {
			_kernel = kernel;
		}

		public override Func<double[], double> Learn(LearningData learningData) {
			var svm = new KernelSupportVectorMachine(_kernel, learningData.Variables.Count);
			var smo = new SequentialMinimalOptimization(svm, learningData.Inputs, learningData.Outputs);
			smo.Run();
			return svm.Compute;
		}
	}
}