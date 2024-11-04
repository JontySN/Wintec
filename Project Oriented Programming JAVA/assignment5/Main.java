package assignment5;

import java.util.List;

import java.util.LinkedList;
import static java.lang.System.*;

public class Main {
	
	public static void main(String[] args){
		
		
		//Creates list and fills them with data: "notes", "Duration"
		List<Note> notes = new LinkedList<>();
		notes.add(new Note("D", 19));
		notes.add(new Note("C", 20));
		notes.add(new Note("F", 31));
		notes.add(new Note("B", 45));
		notes.add(new Note("C", 73));
		notes.add(new Note("F", 13));
		notes.add(new Note("B", 34));
		notes.add(new Note("C", 53));
		//Executes the method "prossessNotes"
		processNotes(notes);
		
	}//end of main method
	public static void processNotes(List<Note> list){
		double total = 0; //Creates total variable
		if(list !=null && list.size() > 0) {	//If list is not null and the list isnt empty
			for(Note n : list) {
				n.playNote(); //plays note
				total += n.getDuration(); //total + duration
			}
			out.printf("Total duration: %s seconds", total);
		
		}
	}
}	
			
	
		



