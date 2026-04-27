using System.IO;

namespace DataDomain
{

    public class Team
    {

        public Team() { }

        public string TeamName { get; set; }
        public string CoachName { get; set; }
        public string TeamLogoImagePath { get; set; }
        public string PlayerNameList { get; set; } // player ingame names like "Donk|Minato|BigPLays"

        public List<Player> PlayerList { get; set; } = new List<Player>();
    }

}
