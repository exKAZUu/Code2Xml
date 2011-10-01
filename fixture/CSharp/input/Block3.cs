using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code2XmlTest
{
	class Block3
	{
		public void method3()
		{
			int i = 0;

			if (i == 0) ;

			while (i != 0) ;

			do ; while (i != 0);

			for (i = 0; i < 0; i++) ;

			foreach (var j in new[] { 1, 2 }) ;

			Action act = () => Console.WriteLine(i);

			if (i == 0)
			{
			}

			switch (i)
			{
			}

			while (i != 0)
			{
			}

			do
			{
			} while (i != 0);

			for (i = 0; i < 0; i++)
			{
			}

			foreach (var j in new[] { 1, 2 })
			{
			}

			Action act1 = () => {
				Console.WriteLine(i);
			};

			Action act2 = delegate {
				Console.WriteLine(i);
			};
		}
	}
}
