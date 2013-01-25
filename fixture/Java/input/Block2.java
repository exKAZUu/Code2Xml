
public class Block2
{
	public static int method1()
	{
		int i = 0;

		if (i == 0) {
			System.out.println("test");
		}

		switch (i) {
		case 0:
			System.out.println("test");
			break;
		}

		while (i != 0) {
			System.out.println("test");
		}

		do {
			System.out.println("test");
		} while (i != 0);

		for (i = 0; i < 0; i++) {
			System.out.println("test");
		}

		for (int j : new int[] {1, 2}) {
			System.out.println(j);
		}
		
		return 0;
	}
}
