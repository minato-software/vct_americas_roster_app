using DataDomain;
using LogicLayer;

namespace presentationLayer
{
    public partial class Main : Form
    {
        private TeamManager _teamManager = new TeamManager();
        
        List<Team> Teams = new List<Team>();
        Team selectedTeam = null;

        public Main()
        {
            InitializeComponent();

            Teams = _teamManager.GetTeamList();

            // Dynamically add teams to teams box
            foreach (var team in Teams)
            {
                var newPictureBox = new PictureBox();
                newPictureBox.Name = team.TeamName;
                newPictureBox.ImageLocation = team.TeamLogoImagePath;
                newPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                newPictureBox.Click += (sender, e) =>
                {
                    selectedTeam = Teams.FirstOrDefault(x => x.TeamName == newPictureBox.Name);
                    label2.Text = selectedTeam.TeamName;
                };

                flowLayoutPanel1.Controls.Add(newPictureBox);
            }

        }

        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            frmTeam frmTeam = new frmTeam(null, true);
            frmTeam.ShowDialog();
        }

        private void btnViewTeam_Click(object sender, EventArgs e)
        {
            frmTeam frmTeam = new frmTeam(selectedTeam, false);
            frmTeam.ShowDialog();
        }

        private void btnUpdateTeam_Click(object sender, EventArgs e)
        {

        }
    }
}
