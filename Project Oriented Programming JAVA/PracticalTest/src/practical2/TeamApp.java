package practical2;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;

import static java.lang.System.*;

class TeamApp {
	
	public List<Team> getTeams() {
		return teams;
	}
	
	Scanner input = new Scanner(in);
    private List<Team> teams;
    public TeamApp(String filename) throws IOException {
        teams = new LinkedList<Team>();
        readTeamData(filename);

    }

    public void readTeamData(String filename) throws IOException {
    	teams = new LinkedList<>();
		Path path = Paths.get(filename);
		List<String> lines = Files.readAllLines(path);
		for (String line : lines) {
			String[] items = line.split(",");
			String name = items[0];
			int groupSize = Integer.parseInt(items[1]);
			String ID = items[2];
			double score = Double.parseDouble(items[3]);
			Team t = new Team(name, groupSize, ID, score);
			teams.add(t);
		}
    }

    public int countTeams() {
		int count = 0;
		for (Team t : teams) {
			if (t.getScore() >= 50 && t.getScore() <= 90) {
				count++;
			}
		}
		return count;
	}
  
    public void searchTeam() {
    	if(teams == null || teams.size() == 0) return;
    	out.print("Enter team id: ");
		String id = input.nextLine();
		Team team = null; //flag variable
		for (Team t: teams) {
			if(t.getID().equalsIgnoreCase(id)) {
				team = t;//update the flag
				out.printf("Search results: " + t.getName() + " " + t.getGroupSize() + " " + t.getID() + " " + t.getScore() + "\n");
				break;
			}
		}
	
	if (team == null) {
		out.printf("No result found for id: %s\n", id);
		}
    }

    public double getAverageScore() {
    	if(teams == null || teams.size() == 0)
    		return 0;
    	
    	List<Team> sub = teams.subList(1, teams.size());
		double Score = teams.get(0).getScore();
		return Score + getAverageScore();
    }
}
