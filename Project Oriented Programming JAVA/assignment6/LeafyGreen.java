package assignment6;

public class LeafyGreen extends Vegetable {
	//making private class field for getters and setters
	private String type;

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}
	//Creates constructor from this class and Vegetable.java
	public LeafyGreen(double weight, double price, String type) {
		super(weight, price);
		this.type = type;
	}
}




