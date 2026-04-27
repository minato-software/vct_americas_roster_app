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
        // This remembers if we are currently in edit mode or not
        private bool isEditMode = false;

        public frmTeam(bool editMode = false)
        {
            InitializeComponent();

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
