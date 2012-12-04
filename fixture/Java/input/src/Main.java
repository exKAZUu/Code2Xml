import java.io.File;
import java.io.IOException;

import numericLiterals.BinaryLiterals;
import numericLiterals.State;
import stringSwitch.StringInSwitchStatements;
import diamonds.TypeInference;
import diamonds.InstanceGetter;
import tryWithStatements.TryWithStatements;
import multipleException.*;

public class Main {
	public static void main(String[] args) {
		  BinaryLiterals binary = new BinaryLiterals();
		  State state = new State();
		  binary.decodeInstruction(binary.aByte, state);

		  StringInSwitchStatements strings = new StringInSwitchStatements();
		  System.out.println(strings.getTypeOfDayWithSwitchStatement("Wednesday"));
		  System.out.println(strings.getTypeOfDayWithSwitchStatement("Sunday"));

		  TypeInference<String> typeinference = InstanceGetter.getInstance();

		  try {
		  System.out.println(TryWithStatements.readFirstLineFromFile("test.txt"));
		  } catch (IOException e) {
			  e.printStackTrace();
		  }

		  CatchingMultipleException exception = new CatchingMultipleException();
		  try {
			  exception.rethrowException();
		  } catch (FirstException | LastException e) {
			  System.out.println("catched!");
		  }
	  }
}
