package assignment4;

import java.util.ArrayList;
import java.util.Scanner;
import static java.lang.System.*;
public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(in);
     //Read two lines of inputed color names
     out.print("Enter first line of colours: ");
     String firstLine = scanner.nextLine();
     out.print("Enter second line of colours: ");
     String secondLine = scanner.nextLine();

     //Split each string into an array
     String[] firstColors = firstLine.split(",");
     String[] secondColors = secondLine.split(",");

     //Create an empty list to store duplicate color names
     ArrayList<String> commonColors = new ArrayList<>();

     //Find and store duplicate color names
     for (String firstColor : firstColors) {
         for (String secondColor : secondColors) {
             if (firstColor.trim().equalsIgnoreCase(secondColor.trim())) {
                 commonColors.add(firstColor.trim());
                 break;
             }
         }
     }

     //Calculates the number of common color names
     int numCommonColors = commonColors.size();

     //Displays common color names
    out.println("You entered " + firstColors.length + " colours in first list");
    out.println("You entered " + secondColors.length + " colours in second list");
    out.println("Number of overlapping colours: " + numCommonColors);
    out.println("Overlapping colours are as follows:");
     for (String color : commonColors) {
         System.out.println(color);
     }
     //stops scanner
     scanner.close();
 }
}
    




