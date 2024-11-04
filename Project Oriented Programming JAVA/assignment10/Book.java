package assignment10;

public class Book {
	//making private class fields for getters and setters
	private String name;
	private int year;
	
	//making a parameterized constructor
	public Book(String name, int year) {
		this.name = name;
		this.year = year;
	}
	
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public int getYear() {
		return year;
	}
	public void setYear(int year) {
		this.year = year;
	}
}
