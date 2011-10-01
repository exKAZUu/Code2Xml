using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code2XmlTest
{
	public class Block2
	{
		public static int method1()
		{
			int i = 0;

			if (i == 0) {
				Console.WriteLine("test");
			}

			switch (i)
			{
			case 0:
				Console.WriteLine("test");
				break;
			}

			while (i != 0) {
				Console.WriteLine("test");
			}

			do {
				Console.WriteLine("test");
			} while (i != 0);

			for (i = 0; i < 0; i++) {
				Console.WriteLine("test");
			}

			foreach (var j in new[] { 1, 2 }) {
				Console.WriteLine(j);
			}

			Action act = () => {
				Console.WriteLine(i);
			};

			Action act2 = delegate {
				Console.WriteLine(i);
			};

			return 0;
		}
	}
}
