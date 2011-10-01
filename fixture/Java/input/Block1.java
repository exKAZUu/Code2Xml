public class Block1
{
	int method1()
	{
		int i = 0;

		if (i <= 0)
			System.out.println("0");

		if (i == 0)
			System.out.println("0");
		else
			System.out.println("else");

		if (i == 0)
			System.out.println("0");
		else if (i == 1)
			System.out.println("1");
		else if (i == 2)
			System.out.println("2");
		else
			System.out.println("else");
		
		switch (i) {
		case 0:
			System.out.println("test");
			break;
		}

		test:
		while (i != 0)
			System.out.println("test");

		do
			System.out.println("test");
		while (i != 0);

		for (i = 0; i < 0; i++)
			System.out.println("test");

		for (int j : new int[] {1, 2})
			System.out.println(j);

		return 0;
	}
}
