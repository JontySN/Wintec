package assignment2;

import static java.lang.System.*;
import java.util.Scanner;
public class Main {
    

    static Scanner input = new Scanner(in);//this allows input and sits inside of main
        
        
    public static void main(String[] args) {//this is where you run the classes
            calculations();
        }
        
        public static void calculations() {
            out.print("Enter circle radius: ");
            double radius = Double.parseDouble(input.nextLine());
            double perimeter = 2 * Math.PI * radius;
            double area = Math.PI * radius * radius;
            
            String format = "%-20s%-20s%-20s\n"; 
            out.printf(format, "Radius", "Perimeter", "Area");
            out.println("-".repeat(45)); 
            
            
            out.printf(format, radius, String.format("%.2f", perimeter), String.format("%.2f", area));
        }
    }

