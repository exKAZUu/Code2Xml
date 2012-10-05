package tryWithStatements;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class TryWithStatements {
	  public static String readFirstLineFromFile(String path) throws IOException {
		    try (BufferedReader br = new BufferedReader(new FileReader(path))) {
		      return br.readLine();
		    }
		  }
}
