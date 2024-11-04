package assignment8;

public class Bag {
	//parameterized constructor with two parameters. 
	public Bag(String colour, double capacity) {
	        this.colour = colour;
	        this.capacity = capacity;
	}
	
	//making private class fields for getters and setters
	private String colour;
	private double capacity;
	
	public String getColour() {
		return colour;
	}
	public void setColour(String colour) {
		this.colour = colour;
	}
	public double getCapacity() {
		return capacity;
	}
	public void setCapacity(double capacity) {
		this.capacity = capacity;
	}
	
}
