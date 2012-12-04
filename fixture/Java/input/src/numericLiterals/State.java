package numericLiterals;
public class State {
	private int address = 0;

	public State nop() {
		return this;
	};

	public State copyAccumTo(int register) {
		address = register;
		System.out.println("address: " + address);
		return this;
	}

	public State addToAccum(int register) {
		address += register;
		System.out.println("address: " + address);
		return this;
	}

	public State subFromAccum(int register) {
		address -= register;
		System.out.println("address: " + address);
		return this;
	}

	public State multiplyAccumBy(int register) {
		address *= register;
		System.out.println("address: " + address);
		return this;
	}

	public State divideAccumBy(int register) {
		address /= register;
		System.out.println("address: " + address);
		return this;
	}

}