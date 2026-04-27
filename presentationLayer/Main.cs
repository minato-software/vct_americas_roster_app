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
            frmTeam frmTeam = new frmTeam(true);
            frmTeam.ShowDialog();
        }

        private void btnViewTeam_Click(object sender, EventArgs e)
        {
            frmTeam frmTeam = new frmTeam(false);
            frmTeam.ShowDialog();
        }
    }
}
