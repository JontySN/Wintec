package assignment6;
import java.util.LinkedList;
import java.util.List;
import static java.lang.System.*;

public class Main {
	public static void main(String[] args){
		//Creates list and fills them with data: "weight", "price" and "type"
		List<LeafyGreen> veges = new LinkedList<>();
		veges.add(new LeafyGreen(10, 3.5, "Cabbage"));
		veges.add(new LeafyGreen(5, 2.94, "Lettuce"));
		veges.add(new LeafyGreen(20, 5.45, "Broccoli"));
		veges.add(new LeafyGreen(7, 1.94, "Lettuce"));
		veges.add(new LeafyGreen(15, 2.8, "Lettuce"));
		veges.add(new LeafyGreen(30, 2.5, "Cabbage"));
		veges.add(new LeafyGreen(28, 4.4, "Broccoli"));
		veges.add(new LeafyGreen(20, 5.5, "Cabbage"));
		veges.add(new LeafyGreen(16, 3.9, "Broccoli"));
		veges.add(new LeafyGreen(26, 4.8, "Broccoli"));
		calculateStats(veges);
	}//end of main
	public static void calculateStats(List<LeafyGreen> veges){
		//creates variables
		int totalCost = 0;
        double cabbageWeight = 0;
        double broccoliWeight = 0;
        double lettuceWeight = 0;

        for (LeafyGreen veg : veges) {
        	//Calculating total cost
            totalCost += veg.getWeight() * veg.getPrice();
            
            //Retriving data to work out total weight for each vege
            if (veg.getType().equalsIgnoreCase("cabbage")) {
                cabbageWeight += veg.getWeight();
            } else if (veg.getType().equalsIgnoreCase("broccoli")) {
                broccoliWeight += veg.getWeight();
            } else if (veg.getType().equalsIgnoreCase("lettuce")) {
                lettuceWeight += veg.getWeight();
			}
		}
        //Prints data
        out.printf("Total vegetable cost: $%s \n", totalCost);
        out.printf("Total Cabbage weight: %skg \n", cabbageWeight);
        out.printf("Total Broccoli weight: %skg \n", broccoliWeight);
        out.printf("Total Lettuce weight: %skg \n", lettuceWeight);
	}
}//end of class Main

