package numericLiterals;



public class BinaryLiterals {
	  // An 8-bit 'byte' value with underscores:
	  public byte aByte = (byte)0b001_0000_1;

	  // A 16-bit 'short' value with underscores:
	  short aShort = (short)0b1010_00010_1000101;

	  // Some 32-bit 'int' values:
	  int anInt1 = 0B10100001010001011010000101000101;

	  // A 64-bit 'long' value. Note the "L" suffix:
	  long aLong = 0b1010000101000101101000010100010110100001010001011010000101000101L;

	  float pi = 	3.14_15F;
	  long hexWords = 0xCAFE_BABE;
	  byte nybbles = 0b0010_0101;

	  public State decodeInstruction(int instruction, State state) {
		  if ((instruction & 0b11100000) == 0b00000000) {
		    final int register = instruction & 0b00001111;
		    switch (instruction & 0b11110000) {
		      case 0b00000000: return state.nop();
		      case 0b00010000: return state.copyAccumTo(register);
		      case 0b00100000: return state.addToAccum(register);
		      case 0b00110000: return state.subFromAccum(register);
		      case 0b01000000: return state.multiplyAccumBy(register);
		      case 0b01010000: return state.divideAccumBy(register);
		      case 0b01100000: return state.copyAccumTo(register);
		      case 0b01110000: return state.copyAccumTo(register);
		      default: throw new IllegalArgumentException();
		    }
		  } else {
		    final int address = instruction & 0b00011111;
		    switch (instruction & 0b11100000) {
		      case 0b00100000: return state.copyAccumTo(address);
		      case 0b01000000: return state.addToAccum(address);
		      case 0b01100000: return state.multiplyAccumBy(address);
		      case 0b10100000: return state.divideAccumBy(address);
		      case 0b11000000: return state.copyAccumTo(address);
		      default: throw new IllegalArgumentException();
		    }
		  }
		}
}
