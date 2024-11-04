package practical2;

public class Team extends Group {
	
	private String ID;
	private double score;
	
	public String getID() {
		return ID;
	}
	public void setID(String iD) {
		ID = iD;
	}
	public double getScore() {
		return score;
	}
	public void setScore(double score) {
		this.score = score;
	}
	
	public Team (String name, int groupSize, String ID, double score) {
		super(name, groupSize);
		this.ID = ID;
		this.score = score;
	}
}
