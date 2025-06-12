using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Users;
using DesktopLayer.Users.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.Clients
{
    public partial class fmFindClient : Form
    {
        public fmFindClient()
        {
            InitializeComponent();
        }

        private void ClientSelected(int? ClientID)
        {
            btnDelete.Enabled = ClientID != null;
            btnEdit.Enabled = ClientID != null;
        }

        private void fmFindClient_Activated(object sender, EventArgs e)
        {
            ctrClientInfoWithFilter1.FocusFilter();
        }

        private void fmFindClient_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

        }

        private void btnClose_Click_1(object sender, EventArgs e)
            => this.Close();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ClientID = (int)ctrClientInfoWithFilter1.ClientID;

            if (clsMessages.ConfirmDelete("Client", ClientID))
            {
                if (clsUsers.Delete(ClientID))
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
            int ClientID = (int)ctrClientInfoWithFilter1.ClientID;

            fmAddEditClient Edit = new fmAddEditClient(ClientID);

            Edit.ShowDialog();

            ctrClientInfoWithFilter1.LoadClientData(ClientID, true);
        }
    }
}
