package practical2;

public class Group {
	
	private String name;
	private int groupSize;
	
	public String getName() {
		return name;
	}
	public void setName(String Name) {
		Name = name;
	}
	public int getGroupSize() {
		return groupSize;
	}
	public void setGroupSize(int groupSize) {
		this.groupSize = groupSize;
	}
	public Group(String Name, int groupSize) {
		this.name = Name;
		this.groupSize = groupSize;
	}
}
