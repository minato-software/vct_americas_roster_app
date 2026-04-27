using DataDomain;
using System;

namespace DataAccessLayer
{
    public class TeamDataAccessor
    {
        private string teamsFilePath = FileStorage.GetFilePathForUser(AppConstants.DataFolder) + "\\teamlist.csv";
        private string playersFilePath = FileStorage.GetFilePathForUser(AppConstants.DataFolder) + "\\playerlist.csv";

        public List<Team> GetTeams()
        {
            List<Player> players = new List<Player>();
            List<Team> teams = new List<Team>();

            try
            {
                if (File.Exists(playersFilePath))
                {
                    // Load Players
                    using (StreamReader fileReader = new StreamReader(playersFilePath))
                    {
                        while (fileReader.EndOfStream == false)
                        {
                            string line = fileReader.ReadLine();

                            if (line.Length > 0)
                            {
                                players.Add(ConvertCSVStringToPlayer(line));
                            }
                        }
                    }
                }
                if (File.Exists(teamsFilePath))
                {
                    // Load Teams
                    using (StreamReader fileReader = new StreamReader(teamsFilePath))
                    {
                        while (fileReader.EndOfStream == false)
                        {
                            string line = fileReader.ReadLine();

                            if (line.Length > 0)
                            {
                                teams.Add(ConvertCSVStringToTeam(line, players));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return teams;
        }

        // TODO: add logic for updating a team instead of adding a new one everytime we save. Updating a team name could cause problems here
        public bool SaveTeam(Team team)
        {
            var teams = GetTeams();
            teams.Add(team);
            return SaveTeams(teams);
        }

        public bool SaveTeams(List<Team> teams)
        {
            bool result = false;

            // build a list of strings from the list of fruit
            List<string> teamsStrings = new List<string>();
            List<string> playersStrings = new List<string>();

            foreach (Team team in teams)
            {
                teamsStrings.Add(ConvertTeamToCSVString(team));
                playersStrings.AddRange(team.PlayerList.Select(x => ConvertPlayerToCSVString(x)));
            }
            //teamsStrings.Sort();

            try
            {

                // Write the players csv file
                using (StreamWriter fileWriter = new StreamWriter(playersFilePath))
                {
                    foreach (string str in playersStrings)
                    {
                        fileWriter.WriteLine(str);
                    }
                }
                // Write the teams csv file
                using (StreamWriter fileWriter = new StreamWriter(teamsFilePath))
                {
                    foreach (string str in teamsStrings)
                    {
                        fileWriter.WriteLine(str);
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public string ConvertTeamToCSVString(Team team)
        {
            string f =
                // TeamName = parts[0]
                team.TeamName + "," +
                // CoachName = parts[1]
                team.CoachName + "," +
                team.TeamLogoImagePath + "," +
                team.PlayerList.JoinPlayerNamesWithPipe();

            return f;
        }

        public Team ConvertCSVStringToTeam(string csvLine, List<Player> players)
        {
            Team team = new Team();
            var parts = csvLine.Split(',');
            // TODO: update this if condition maybe?
            if (parts.Count() >= 0)
            {
                team.TeamName = parts[0];
                team.CoachName = parts[1];
                team.TeamLogoImagePath = parts[2];
                team.PlayerNameList = parts[3];

                if (team.PlayerNameList != null && team.PlayerNameList.Length > 0 && players.Count > 0)
                {
                    var tempPlayerNames = team.PlayerNameList.Split('|');
                    team.PlayerList = players.Where(x => tempPlayerNames.Contains(x.PlayerInGameName)).ToList();
                }
            }
            return team;
        }

        public string ConvertPlayerToCSVString(Player player)
        {
            string f =
                // PlayerInGameName = parts[0]
                player.PlayerInGameName + "," +
                // PortraitFilePath = parts[1]
                player.PortraitFilePath + ",";

            return f;
        }

        public Player ConvertCSVStringToPlayer(string csvLine)
        {
            Player player = new Player();
            var parts = csvLine.Split(',');
            // TODO: update this if condition maybe?
            if (parts.Count() >= 0)
            {
                player.PlayerInGameName = parts[0];
                player.PortraitFilePath = parts[1];
            }
            return player;
        }

    }

    public static class PlayerListExtensions
    {
        public static string JoinPlayerNamesWithPipe(this IEnumerable<Player> values)
        {
            if (values == null)
                return string.Empty;

            return string.Join("|", values.Select(x => x.PlayerInGameName));
        }

    }

    public static class StringListExtensions
    {
        public static List<string> SplitFromPipe(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new List<string>();

            return value.Split('|').ToList();
        }

        public static string JoinWithPipe(this IEnumerable<string> values)
        {
            if (values == null)
                return string.Empty;

            return string.Join("|", values);
        }
    }

}
