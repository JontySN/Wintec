package assignment9;
import static java.lang.System.*;
import java.io.IOException;

public class Main {
	public static void main(String[] args) {
		String txtfile = "data/gamedata.txt"; //turns the .txt file into a string
		
		//try catch method
		try {
			GameApp app = new GameApp(txtfile);
			app.game();//prints game method from GameApp.java
		}catch(IOException ioe) {
			out.printf("Perhaps missing text file: %s/%s? \n\n", 
					new Main().getClass().getPackage().getName(), txtfile);
		}
	}
}