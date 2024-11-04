package assignment1;


import static java.lang.System.*;
public class Main {

    public static void main(String[] args) {
        out.println("Escape sequence \t Description");
        lines();;
        String fmt = "%-25s%-20s\n"; //"String" is to define a word variable. "%" defines a place. "-15" defines how many characters. "s" Means string. the second % starts a second placeholder. \n starts it on a new line
		out.printf(fmt, "\\n", "New line character");
        out.printf(fmt, "\\t", "Horizontal tab character");
        out.printf(fmt, "\\\"", "Double quote character ");
        out.printf(fmt, "\\b", "Backspace character");
    }
    
    public static void lines() {
		out.println("-".repeat(50)); //produces 40 "-" lines
    }
}