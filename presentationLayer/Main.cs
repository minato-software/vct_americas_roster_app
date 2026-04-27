namespace presentationLayer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            frmTeam frmTeam = new frmTeam();
            frmTeam.ShowDialog();
        }

        private void btnViewTeam_Click(object sender, EventArgs e)
        {
            frmTeam frmTeam = new frmTeam();
            frmTeam.ShowDialog();
        }
    }
}
