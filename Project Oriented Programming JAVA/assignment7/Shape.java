package assignment7;

public class Shape {
	//making private class field for getters and setters
	private String colour;

	public String getColour() {
		return colour;
	}

	public void setColour(String colour) {
		this.colour = colour;
	}

	public Shape(String colour) {
		this.colour = colour;
	}
	public String getShapeType() {
		return "I’m a Shape";
		
	}
}
