public class Condition1 {
	
	public static boolean f(boolean i) {
		return !i;
	}

	public static void main(String[] args) {
		boolean a = false, b = false, c = true;
		
		if (a ^ (b && c)) {
			System.out.println("test");
		}
		
		if (a) {
			System.out.println("test");
		}
		else if (a && b) {
			System.out.println("test");
		}
		
		if (a && b || c) {
			System.out.println("test");
		}
		else if (a && (b || c)) {
			System.out.println("test");
		}
		
		if (0 < (~1 | 1 & 1 ^ 1 + 1 - 1 / 1 * 1)) {
			System.out.println("test");
		}
		else if (a && b) {
			System.out.println("test");
		}
		
		if (args[a ? 0 : 1]) {
			System.out.println("test");
		}
		
		if (args[a ? 0 : 1]) {
			System.out.println("test");
		}
		
		if (f(a)) {
			System.out.println("test");
		}
		else if (a && b) {
			System.out.println("test");
		}
		
		if (f(a && b || c)) {
			System.out.println("test");
		}
		else if (f(a && (b || c))) {
			System.out.println("test");
		}
		
		if (f(0 < (~1 | 1 & 1 ^ 1 + 1 - 1 / 1 * 1))) {
			System.out.println("test");
		}
		else if (f(a && b)) {
			System.out.println("test");
		}
	}
}
