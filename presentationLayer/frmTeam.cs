using DataDomain;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentationLayer
{
    public partial class frmTeam : Form
    {
        private TeamManager _teamManager = new TeamManager();
        private Team _team = null;

        // This remembers if we are currently in edit mode or not
        private bool isEditMode = false;

        public frmTeam(Team team = null, bool editMode = false)
        {
            InitializeComponent();


            if (team == null)
            {
                _team = new Team();
            }
            else
            {
                _team = team;
            }

            // this controls if the form opens in readonly mode or edit mode
            setEditMode(editMode);
        }

        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            // toggles edit mode
            setEditMode(true);
        }

        private void btnSaveTeam_Click(object sender, EventArgs e)
        {
            // save data
            // TODO: add the rest of the properties - and modify saveTeam logic to overwrite if the team already exists instead of adding duplicates
            _team.TeamName = txtTeamName.Text;
            _team.CoachName = txtCoachName.Text;

            // this will look better when a combo box is used
            if (txtPlayer1Name.Text.Length > 0)
            {
                if (_team.PlayerList.Count > 0 && _team.PlayerList[0] != null)
                {
                    // Updates player slot
                    _team.PlayerList[0].PlayerInGameName = txtPlayer1Name.Text;
                }
                else
                {
                    // creates new player/slot
                    _team.PlayerList.Add(new Player
                    {
                        PlayerInGameName = txtPlayer1Name.Text,
                        PortraitFilePath = "temp"
                    });
                }

                if (_team.PlayerList.Count > 0 && _team.PlayerList[1] != null)
                {
                    // Updates player slot
                    _team.PlayerList[1].PlayerInGameName = txtPlayer2Name.Text;
                }
                else
                {
                    // creates new player/slot
                    _team.PlayerList.Add(new Player
                    {
                        PlayerInGameName = txtPlayer2Name.Text,
                        PortraitFilePath = "temp"
                    });
                }
            }

            _teamManager.SaveTeam(_team);

            // set form back to readonly mode
            setEditMode(false);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // reload data to bring it back to the original state

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
            // TODO: add the rest of the fields here
            txtTeamName.ReadOnly = !editMode;
            txtCoachName.ReadOnly = !editMode;
            txtPlayer1Name.ReadOnly = !editMode;

            btnSaveTeam.Visible = editMode;
            btnCancel.Visible = editMode;
            btnEditTeam.Visible = !editMode;
        }

    }
}
