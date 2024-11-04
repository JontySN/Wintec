package assignment8;

import java.util.List;

public class BagApp {
	public double calcTotalCapacity(List<Bag> bagList) {
		if(bagList == null || bagList.size() == 0)//If list size is empty or 0
			return 0; //base case

		List<Bag> sub = bagList.subList(1, bagList.size());
		double firstBag = bagList.get(0).getCapacity();
		return firstBag + calcTotalCapacity(sub);
    }//Write the code for this recursive method
		//This calculates and returns the total capacity of all instances in “bagList”.
		//Hint: make use of the capacity getter: getCapacity().
	
}//End of class BagApp