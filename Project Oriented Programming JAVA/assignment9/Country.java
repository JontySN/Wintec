package assignment9;

public class Country {
	
	//making private class fields for getters and setters 
	private String name;
	private String capital;
	private int population;

	//parameterized constructor with three parameters.
	public Country(String name, String capital, int population) {
		this.setName(name);
		this.setCapital(capital);
		this.setPopulation(population);
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getCapital() {
		return capital;
	}
	public void setCapital(String capital) {
		this.capital = capital;
	}
	public int getPopulation() {
		return population;
	}
	public void setPopulation(int population) {
		this.population = population;
	}
}
