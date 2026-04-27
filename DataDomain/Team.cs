using System.IO;

namespace DataDomain
{

    // The constructor is converting the line of text from the csv file into a team object
    // ConvertToCSVString() is converting the team object into a line of text that can be saved in csv file
    public class Team
    {

        public Team() { }

        public Team(string csvLine, List<Player> players)
        {
            var parts = csvLine.Split(',');
            // TODO: update this if condition maybe?
            if (parts.Count() >= 0)
            {
                TeamName = parts[0];
                CoachName = parts[1];
                TeamLogoImagePath = parts[2];
                PlayerNameList = parts[3];

                if (PlayerNameList != null && PlayerNameList.Length > 0 && players.Count > 0)
                {
                    var tempPlayerNames = PlayerNameList.Split('|');
                    PlayerList = players.Where(x => tempPlayerNames.Contains(x.PlayerInGameName)).ToList();
                }
            }

        }

        public string TeamName { get; set; }
        public string CoachName { get; set; }
        public string TeamLogoImagePath { get; set; }
        private string PlayerNameList { get; set; }

        public List<Player> PlayerList { get; set; } = new List<Player>();
        
        public string ConvertToCSVString()
        {
            string f = 
                // TeamName = parts[0]
                TeamName + "," +
                // CoachName = parts[1]
                CoachName + "," +
                TeamLogoImagePath + "," +
                PlayerList.JoinPlayerNamesWithPipe();

            return f;
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
