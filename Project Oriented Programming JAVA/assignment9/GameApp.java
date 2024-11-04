package assignment9;
import static java.lang.System.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.*;


public class GameApp {
	Scanner input = new Scanner(in);
	private List<Country> countryList;
	public GameApp(String filename) throws IOException {
		countryList = new LinkedList<>();
		readData(filename);
	}
	public void readData(String filename) throws IOException {
		countryList = new LinkedList<>();
		Path path = Paths.get(filename);
		List<String> lines = Files.readAllLines(path);
		//sorting out the data in countrylist
		for (String line : lines) {
			String[] items = line.split(",");
			String name = items[0];
			String capital = items[1];
			int population = Integer.parseInt(items[2]);
			Country c = new Country(name, capital, population);
			countryList.add(c);
		}
	}

	public void game() {
		if (countryList == null || countryList.isEmpty()) 
			return; //if list is null or empty
		while (true) {
			Country randCountry = countryList.get(new Random().nextInt(countryList.size())); //making a variable that gives a random country
			out.printf("What is the capital city of %s?: ", randCountry.getName());
			String Guess = input.nextLine(); //assigning a variable to the input
			if (Guess.equalsIgnoreCase(randCountry.getCapital())) { //checks the guess and makes it not k sensitive
				out.println("Well done!");
			} else {
				out.printf("Incorrect. The correct answer is %s.\n", randCountry.getCapital()); 
			}
			out.printf("%s is a country of %d million people.\n", randCountry.getName(), randCountry.getPopulation());
			break;
			
		}
	}
}

