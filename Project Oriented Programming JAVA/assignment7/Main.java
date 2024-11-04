package assignment7;
import java.util.LinkedList;
import java.util.List;
import static java.lang.System.*;

public class Main {
	public static void main(String[] args) {
		//Creates list and fills them with data: "Colour", "height" and "width"
		List<Shape> shapes = new LinkedList<>();
		shapes.add(new Shape("white"));
		shapes.add(new Rectangle("red", 10, 6));
		shapes.add(new Rectangle("black", 20, 9));
		shapes.add(new Shape("orange"));
		showShapeNames(shapes);
		
		//Creates rectangle array1
		Rectangle[] rectangleArray1 = {
				new Rectangle("white", 4, 3),
				new Rectangle("red", 9, 5),
				new Rectangle("purple", 3, 6),
				new Rectangle("orange", 15, 10),
				new Rectangle("black", 4, 14),
		};
		//Creates rectangle array2
		Rectangle[] rectangleArray2 = {
				new Rectangle("pink", 3, 4),
				new Rectangle("red", 10, 2),
				new Rectangle("white", 8, 5),
				new Rectangle("blue", 14, 4),
				new Rectangle("bindle", 10, 15),
		};
		//executes the count overlapping rectangles method with both arrays
		countOverlapRectangles(rectangleArray1, rectangleArray2);
	}//end of main() method
	
	//method to print shape names
	public static void showShapeNames(List<Shape> shapes){
		for (Shape shape : shapes) {
			out.println(shape.getShapeType());
		}
	}
	public static void countOverlapRectangles(Rectangle[] group1, Rectangle[] group2){
		
		//Assign variables
		int overlapColourCount = 0;
		int overlapPerimeterCount = 0;

		//Basically merging the 2 arrays and counting them
		for (Rectangle rect1 : group1) {
			for (Rectangle rect2 : group2) {
				if (rect1.getColour().equals(rect2.getColour())) {
					overlapColourCount++;
				}
				if (rect1.getPerimeter() == rect2.getPerimeter()) {
					overlapPerimeterCount++;
				}
			}
		}
		//Print data
		out.println("There are " + overlapColourCount + " Rectangle objects with overlapping colour between the two arrays");
		out.println("There are " + overlapPerimeterCount + " Rectangle objects with overlapping perimeter between the two arrays");
	}
}//end of Main class