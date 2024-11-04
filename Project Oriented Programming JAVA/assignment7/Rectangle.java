package assignment7;

public class Rectangle extends Shape {
	//parameterized constructor with three parameters. (2 from Shape.java)
	public Rectangle(String colour, double height, double width) {
        super(colour);
        this.height = height;
        this.width = width;
    }
    
    //making private class fields for getters and setters
	private double height;
	private double width;
	
	public double getHeight() {
		return height;
	}
	public void setHeight(double height) {
		this.height = height;
	}
	public double getWidth() {
		return width;
	}
	public void setWidth(double width) {
		this.width = width;
	}
	 
	public String getShapeType() {
	    return "I’m a Rectangle";
	}
	//Calculates Perimeter
	public double getPerimeter() {
		return 2 * (height + width);
	}
}
