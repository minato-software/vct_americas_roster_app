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

            RefreshTeamPanel();

            Teams = _teamManager.GetTeamList();

        }

        private void RefreshTeamPanel()
        {
            flowLayoutPanel1.Controls.Clear();

            Teams = _teamManager.GetTeamList();

            // Dynamically add teams to teams box
            foreach (var team in Teams)
            {
                var newPictureBox = new PictureBox();
                newPictureBox.Name = team.TeamName;
                newPictureBox.ImageLocation = team.TeamLogoImagePath;

                newPictureBox.Size = new Size(100, 100);
                newPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // first tried centerImage, maybe zoom better
                newPictureBox.Padding = new Padding(5);

                // cursor change to show users it's clickable
                newPictureBox.Cursor = Cursors.Hand;

                // click event to set the selected team
                newPictureBox.Click += (sender, e) =>
                {
                    selectedTeam = Teams.FirstOrDefault(team => team.TeamName == newPictureBox.Name);

                    if (selectedTeam != null)
                    {
                        label2.Text = selectedTeam.TeamName;
                    }
                };


                flowLayoutPanel1.Controls.Add(newPictureBox);
            }
        }

        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            frmTeam frmTeam = new frmTeam(null, true);
            frmTeam.ShowDialog();

            RefreshTeamPanel();
        }

        private void btnViewTeam_Click(object sender, EventArgs e)
        {
            if (selectedTeam == null)
            {
                MessageBox.Show("Please select a team to view first.");
            }

            frmTeam frmTeam = new frmTeam(selectedTeam, false);
            frmTeam.ShowDialog();

            RefreshTeamPanel();
        }

        private void btnUpdateTeam_Click(object sender, EventArgs e)
        {
            if (selectedTeam == null)
            {
                MessageBox.Show("Please select a team to update first.");
                return;
            }

            // open directly into edit mode
            frmTeam frmTeam = new frmTeam(selectedTeam, true);
            frmTeam.ShowDialog();

            RefreshTeamPanel();
        }

        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            if (selectedTeam == null)
            {
                MessageBox.Show("Please select a team to delete first.");
                return;
            }

            // Confirm deletion
            var result = MessageBox.Show($"Are you sure you want to delete the team '{selectedTeam.TeamName}'?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (_teamManager.DeleteTeam(selectedTeam))
                {
                    selectedTeam = null;
                    RefreshTeamPanel();
                }
                else
                {
                    MessageBox.Show("Failed to delete the team.");
                }
            }
        }
    }
}
