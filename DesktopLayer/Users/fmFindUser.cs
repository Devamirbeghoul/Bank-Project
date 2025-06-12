using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.People;
using DesktopLayer.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.Users.Controls
{
    public partial class fmFindUser : Form
    {
        public fmFindUser()
        {
            InitializeComponent();
        }

        private void UserSelected(int? UserID)
        {
            btnDelete.Enabled = UserID != null;
            btnEdit.Enabled = UserID != null;
        }

        private void fmFindUser_Activated(object sender, EventArgs e)
        {
            ctrUserCardWithFilter1.FocusFilter();
        }

        private void fmFindUser_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

        }

        private void btnClose_Click_1(object sender, EventArgs e)
            => this.Close();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int UserID = (int)ctrUserCardWithFilter1.UserID;

            if (clsMessages.ConfirmDelete("User", UserID))
            {
                if (clsUsers.Delete(UserID))
                {
                    clsMessages.GeneralSuccessMessage("Deleted Successfuly!");

                    this.Close();

                }
                else
                    clsMessages.GeneralErrorMessage("Can't Delete this User!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int UserID = (int)ctrUserCardWithFilter1.UserID;

            fmAddEditUser Edit = new fmAddEditUser(UserID);

            Edit.ShowDialog();

            ctrUserCardWithFilter1.LoadUserData(UserID , true);
        }
    }
}
