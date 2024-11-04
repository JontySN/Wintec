package assignment5;

import static java.lang.System.*;


public class Note {
	//making private class fields for getters and setters
	private String pitch;
	private int duration;
	
	//Creates constructor
	public Note(String pitch, int duration) {
		this.setPitch(pitch);
		this.setDuration(duration);
	}
	
	public String getPitch() {
		return pitch;
	}
	public void setPitch(String pitch) {
		this.pitch = pitch;
	}
	public int getDuration() {
		return duration;
	}
	public void setDuration(int duration) {
		this.duration = duration;
	}
	//Creates method for playNote()
	public void playNote() {
		out.printf("The Note %s is played for %s seconds.\n", pitch, duration);
	}
	//Creates method for total()
	public void total() {
		int total = 0;
		total += getDuration();
		Integer.sum(getDuration(), total);
		out.printf("Total duration: %s seconds.\n", total);
			
		}
	}
	

