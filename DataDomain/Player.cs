using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class Player
    {
        public Player() { }
        public Player(string csvLine)
        {
            
        }

        public string PlayerInGameName { get; set; }
        public string PortraitFilePath { get; set; }

        public string ConvertToCSV()
        {
            string f =
                // TeamName = parts[0]
                PlayerInGameName + "," +
                // CoachName = parts[1]
                PortraitFilePath + ",";
            
            return f;
        }
    }
}
