package assignment8;
import java.util.List;
import java.util.LinkedList;
import static java.lang.System.*;

public class Main {
    public static void main(String[] args) {
        
    	//Creates list and fills them with data: "Colour", "Weight"
    	List<Bag> bags = new LinkedList<>();

        bags.add(new Bag("Red", 3.5));
        bags.add(new Bag("Blue", 5.2));
        bags.add(new Bag("Green", 4.2));

        //New variable
        BagApp bgapp = new BagApp();
        double totalCapacity = bgapp.calcTotalCapacity(bags);
        
        //Prints data
        out.printf("Total capacity: %.2f\n", totalCapacity);
        out.printf("Total number of bags: %d\n", bags.size());
    }
}//End of class Main
