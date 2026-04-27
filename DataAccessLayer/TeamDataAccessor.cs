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
                                players.Add(new Player(line));
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
                                teams.Add(new Team(line, players));
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
                teamsStrings.Add(team.ConvertToCSVString());
                playersStrings.AddRange(team.PlayerList.Select(x => x.ConvertToCSV()));
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

    }


}
