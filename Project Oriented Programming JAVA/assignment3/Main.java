package assignment3;

import static java.lang.System.out;
import java.util.Scanner;
public class Main {
    public static void main(String[] args) {
       userInputStatement(); 
    }
    static void userInputStatement()
    {
            double score;
            try(Scanner input = new Scanner(System.in)){
                while(true){
                    out.printf("Enter a score: ");
                    score = input.nextDouble(); //scans the input and turns it into a variable
                    
                    if(score <0 || score >100){ //parameter for the input to show which to print
                        out.printf("Invalid score.\n");
                    }
                    else if(score >=0 && score < 50){
                        out.printf("Score" + " " +  score + " " + "will recieve grade D\n");
                        break;
                    }
                    else if(score >= 50 && score < 70){
                        out.printf("Score" + " " +  score + " " + "will recieve grade C\n");
                        break;
                    }
                    else if(score >=70 && score < 80){
                        out.printf("Score" + " " +  score + " " + "will recieve grade B\n");
                        break;
                    }
                    else if(score >= 80 && score <= 100){
                        out.printf("Score" + " " +  score + " " + "will recieve grade A\n");
                        break;
                    }
                    }//end of while loop
        }

    
    }
    
    
}  
        
        
           