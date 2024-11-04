package assignment10;

public class AudioBook extends Book {
	//making private class field for getters and setters
	private double length;

	//parameterized constructor with three parameters. (2 from Book.java)
	public AudioBook(String name, int year, double length) {
		super(name, year);
		this.length = length;
	}
	
	public double getLength() {
		return length;
	}

	public void setLength(double length) {
		this.length = length;
	}
	public void DisplayInfo() {
		return;
	}	
}
