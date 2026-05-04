using DataDomain;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Runtime.CompilerServices;

namespace presentationLayer
{
    public partial class frmTeam : Form
    {
        private TeamManager _teamManager = new TeamManager();
        private Team _team = null;

        // Track the original team name to find it in the CSV if the user changes the name
        private string _originalTeamName = null;

        // This remembers if we are currently in edit mode or not
        private bool isEditMode = false;

        public frmTeam(Team team = null, bool editMode = false)
        {
            InitializeComponent();

            LoadTeamLogos();

            if (team == null)
            {
                _team = null;
            }
            else
            {
                LoadTeam(team);
            }

            // this controls if the form opens in readonly mode or edit mode
            setEditMode(editMode);
        }

        private void LoadTeam(Team team)
        {
            _team = team;
            _originalTeamName = _team.TeamName; // Capture the original name


            // set fields
            // TODO: fill more fields
            txtTeamName.Text = _team.TeamName;
            txtCoachName.Text = _team.CoachName;

            if (!string.IsNullOrEmpty(_team.TeamLogoImagePath))
            {
                foreach (TeamLogo item in cboTeamLogo.Items)
                {
                    if (item.FileName == _team.TeamLogoImagePath)
                    {
                        cboTeamLogo.SelectedItem = item;
                        break;
                    }
                }
            }


            if (_team.PlayerList.Count > 0)
            {
                if (_team.PlayerList.Count > 0) txtPlayer1Name.Text = _team.PlayerList[0].PlayerInGameName;
                if (_team.PlayerList.Count > 1) txtPlayer2Name.Text = _team.PlayerList[1].PlayerInGameName;
                if (_team.PlayerList.Count > 2) txtPlayer3Name.Text = _team.PlayerList[2].PlayerInGameName;
                if (_team.PlayerList.Count > 3) txtPlayer4Name.Text = _team.PlayerList[3].PlayerInGameName;
                if (_team.PlayerList.Count > 4) txtPlayer5Name.Text = _team.PlayerList[4].PlayerInGameName;
            }
        }

        // Helper method to load team logos into the combo box
        private void LoadTeamLogos()
        {
            try
            {
                cboTeamLogo.Items.Clear();

                // get the logos from the team manager
                List<TeamLogo> logos = _teamManager.GetTeamLogos();

                //populate the combo box with the logos
                foreach (var logo in logos)
                {
                    logo.FileName = Path.GetFileNameWithoutExtension(logo.FileName);
                }


                cboTeamLogo.DisplayMember = "FileName";
                cboTeamLogo.ValueMember = "FilePath";
                cboTeamLogo.DataSource = logos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading team logos: {ex.Message}");
            }
        }

        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            // toggles edit mode
            setEditMode(true);
        }

        private void btnSaveTeam_Click(object sender, EventArgs e)
        {
            // save data
            // done? TODO: add the rest of the properties - and modify saveTeam logic to overwrite if the team already exists instead of adding duplicates
            if (_team == null)
            {
                _team = new Team();
            }

            _team.TeamName = txtTeamName.Text; // done? TODO: figure out how to handle updating a team name. 
            _team.CoachName = txtCoachName.Text;

            if (!string.IsNullOrWhiteSpace(txtPlayer1Name.Text))
            {
                CheckPlayerExists(0);
                _team.PlayerList[0].PlayerInGameName = txtPlayer1Name.Text;
            }

            if (!string.IsNullOrWhiteSpace(txtPlayer2Name.Text))
            {
                CheckPlayerExists(1);
                _team.PlayerList[1].PlayerInGameName = txtPlayer2Name.Text;
            }

            if (!string.IsNullOrWhiteSpace(txtPlayer3Name.Text))
            {
                CheckPlayerExists(2);
                _team.PlayerList[2].PlayerInGameName = txtPlayer3Name.Text;
            }

            if (!string.IsNullOrWhiteSpace(txtPlayer4Name.Text))
            {
                CheckPlayerExists(3);
                _team.PlayerList[3].PlayerInGameName = txtPlayer4Name.Text;
            }

            if (!string.IsNullOrWhiteSpace(txtPlayer5Name.Text))
            {
                CheckPlayerExists(4);
                _team.PlayerList[4].PlayerInGameName = txtPlayer5Name.Text;
            }

            if (cboTeamLogo.SelectedItem != null)
            {
                TeamLogo selectedLogo = (TeamLogo)cboTeamLogo.SelectedItem;
                _team.TeamLogoImagePath = selectedLogo.FileName;
            }

            // pass original team name to handle overwrites properly
            _teamManager.SaveTeam(_team, _originalTeamName);

            // Update original name in case of multiple edits without closing
            _originalTeamName = _team.TeamName;


            // set form back to readonly mode
            setEditMode(false);
        }

        // Helper method to ensure the player list has enough entries before trying to set a player's name
        private void CheckPlayerExists(int index)
        {
            while (_team.PlayerList.Count <= index)
            {
                _team.PlayerList.Add(new Player
                {
                    PlayerInGameName = string.Empty,
                    //PortraitFilePath = "temp"
                });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_team == null)
            {
                // if team is null, just close the form
                this.Close();
                return;
            }
            // reload data to bring it back to the original state
            LoadTeam(_team);

            // set form back to readonly mode
            setEditMode(false);
        }

        // true means we are going into edit mode
        // false means we are going into readonly mode
        private void setEditMode(bool editMode)
        {
            // update this first
            isEditMode = editMode;

            // set input fields to readonly or editable
            cboTeamLogo.Enabled = editMode;

            txtTeamName.ReadOnly = !editMode;
            txtCoachName.ReadOnly = !editMode;
            txtPlayer1Name.ReadOnly = !editMode;
            txtPlayer2Name.ReadOnly = !editMode;
            txtPlayer3Name.ReadOnly = !editMode;
            txtPlayer4Name.ReadOnly = !editMode;
            txtPlayer5Name.ReadOnly = !editMode;

            btnSaveTeam.Visible = editMode;
            btnCancel.Visible = editMode;
            btnEditTeam.Visible = !editMode;
        }

    }
}
