package assignment10;

import static java.lang.System.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.LinkedList;
import java.util.*;
import java.util.Random;


public class AudioBookApp {
	private List<AudioBook> bookList;

	public List<AudioBook> getBookList() {
		return bookList;
	}
	
	public AudioBookApp(String filename) throws IOException {
		bookList = new LinkedList<>();
		readData(filename);
	}
	//a method readData() to read the data file content and populate the list of AudioBook instances.
	public void readData(String filename) throws IOException {
		bookList= new LinkedList<>();
		Path path = Paths.get(filename);
		List<String> lines = Files.readAllLines(path);
		for (String line : lines) {
			String[] items = line.split(",");
			String name = items[0];
			int year = Integer.parseInt(items[1]);
			double length = Double.parseDouble(items[2]);
			AudioBook b = new AudioBook(name, year, length);
			bookList.add(b);
		}
	}
	//a method getShortestBooks() that calculates and returns a list of AudioBook instances with the shortest length. 
	public List<AudioBook> getShortestBooks() {
		List<AudioBook> shortestBooks = new LinkedList<>();
		if (bookList.isEmpty()) {
			return shortestBooks;
		}
		double Shortest = bookList.get(0).getLength();
		for (AudioBook book : bookList) {
			if (book.getLength() < Shortest) {
				Shortest = book.getLength();
			}
		}
		for (AudioBook book : bookList) {
			if (book.getLength() == Shortest) {
				shortestBooks.add(book);
			}
		}
		return shortestBooks;
	}

	//a method countBooks() that counts the number of AudioBook instances that were published during the period specified in the main. 
	public int countBooks() {
		int count = 0;
		for (Book b : bookList) {
			if (b.getYear() >= 2010 && b.getYear() <= 2020) {
				count++;
			}
		}
		return count;
	}
	
	//a method randomBookList() that divides the Book instance list into three random lists.
	public void randomBookList() {
		if(bookList == null || bookList.size() == 0) return;
		
		List<AudioBook> b1 = new ArrayList<>();
        List<AudioBook> b2 = new ArrayList<>();
        List<AudioBook> b3 = new ArrayList<>();
            
		int c1 = 0, c2 = 0, c3 = 0, ran;
        Random rand = new Random();
		
		for (AudioBook b : bookList) {
			ran = rand.nextInt(3) + 1;//1-3
			if (ran == 3) {
				b1.add(b);
				c1++;
			} else if(ran == 2) {
				b2.add(b);
				c2++;
			} else {
				b3.add(b);
				c3++;
			}
		}
		out.printf("%d books in list #1:\n", c1);
		for (AudioBook a : b1) {
			out.printf(a.getName() + " " + a.getYear() + " " + a.getLength() + "\n");
		}
		out.printf("\n");
		
		out.printf("%d books in list #2:\n", c2);
		for (AudioBook a : b2) {
			out.printf(a.getName() + " " + a.getYear() + " " + a.getLength() + "\n");
		}
		out.printf("\n");
		
		out.printf("%d books in list #3:\n", c3);
		for (AudioBook a : b3) {
			out.printf(a.getName() + " " + a.getYear() + " " + a.getLength() + "\n");
		}
		out.printf("\n");
	}
}



