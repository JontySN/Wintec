package assignment6;


public class Vegetable {
		//making private class field for getters and setters
		private double weight;
		private double price;
		
		//Creates Constructor
		public Vegetable(double weight, double price) {
	        this.weight = weight;
	        this.price = price;
	    }
		
		public double getWeight() {
			return weight;
		}
		public void setWeight(double weight) {
			this.weight = weight;
		}
		public double getPrice() {
			return price;
		}
		public void setPrice(double price) {
			this.price = price;
		}
		
		
}

