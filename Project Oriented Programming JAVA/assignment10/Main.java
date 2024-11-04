package assignment10;

import static java.lang.System.*;

import java.io.IOException;
import java.util.List;

public class Main {

	public static void main(String[] args) {
		String txtfile = "data/bookdata.txt";
		try {
			AudioBookApp app = new AudioBookApp(txtfile);
			out.println("Shortest Books:");
			displayBooks(app.getShortestBooks());
			out.printf("Books published between 2010-2020: %d\n", app.countBooks());
			out.printf("\n");
			app.randomBookList();
		}catch(IOException ioe) {
			out.printf("Perhaps missing text file: %s/%s? \n\n",
					new Main().getClass().getPackage().getName(), txtfile);
		}
		
	}

	public static void displayBooks(List<AudioBook> list) {
		out.println("Title\tYear\tLength");
		out.println("-".repeat(65));// produces "-" 65 times
		for (AudioBook b : list) {
			out.printf("%s\t%d\t%.1f\n", b.getName(), b.getYear(), b.getLength());
		}
	}
}//End of class Main
