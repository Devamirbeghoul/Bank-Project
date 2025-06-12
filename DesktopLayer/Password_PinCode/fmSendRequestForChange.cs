using BusinessLayer;
using DesktopLayer.GlobalClasses;
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

namespace DesktopLayer.Password_PinCode
{
    public partial class fmSendRequestForChange : Form
    {
        public fmSendRequestForChange()
        {
            InitializeComponent();
        }

        private void cbBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbInput1.Text = cbBy.Text.Trim() + ":";
            tbInput1.Clear();
            tbInput1.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void fmSendRequestForChange_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);
        }

        private void tbInput1_Validating(object sender, CancelEventArgs e)
        {
            string Input = tbInput1.Text.Trim();

            if (string.IsNullOrEmpty(Input))
            {
                e.Cancel = true;
                epValidate.SetError(tbInput1, "This field is required!");
            }

            else if (cbBy.Text == "Email" && !clsValidate.ValidateEmail(Input))
            {
                e.Cancel = true;
                epValidate.SetError(tbInput1, "Invalid Email");
            }

            else if (cbBy.Text == "Phone" && Input.Length != 9)
            {
                e.Cancel = true;
                epValidate.SetError(tbInput1, "Invalid Phone");
            }

            else
            {
                e.Cancel = false;
                epValidate.SetError(tbInput1, "");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessages.NullOrEmptyFieldsMessage(true);
                return;
            }

            string Input = tbInput1.Text.Trim();
            string By = cbBy.Text.Trim();
            int? PersonID;

            if (By == "Email")
                PersonID = clsPeople.GetIDByEmail(Input);
            else
                PersonID = clsPeople.GetIDByPhone(Input);

            if (PersonID == null)
            {
                clsMessages.NullObject("Person", $"With {By} = {Input}");
                return;
            }

            if (cbType.Text == "Client")
                SendClientRequest(PersonID);
            else
                SendUserRequest(PersonID);
        }

        private void SendClientRequest(int? PersonID)
        {
            int ClientID = clsClients.GetIDByPersonID(PersonID);

            if (clsRquestsPasswordClients.ExistWith(ClientID, clsRquestsPasswordClients.enStatus.Pending))
            {
                clsMessages.GeneralErrorMessage("There's already a pending request for this account, please be patient and wait :)");
                return;
            }

            clsRquestsPasswordClients Request = new clsRquestsPasswordClients();

            Request.Status = clsRquestsPasswordClients.enStatus.Pending;
            Request.Method = (clsRquestsPasswordClients.enMethod)cbBy.SelectedIndex;
            Request.Time = DateTime.Now;
            Request.ClientID = ClientID;

            if (Request.Save())
            {
                clsMessages.GeneralSuccessMessage("Request Send it Succesfuly!");
                this.Close();
            }
            else
                clsMessages.GeneralErrorMessage("Request Failed!");
        }

        private void SendUserRequest(int? PersonID)
        {
            int UserID = clsUsers.GetIDByPersonID(PersonID);

            if (clsRquestsPasswordUsers.ExistWith(UserID, clsRquestsPasswordUsers.enStatus.Pending))
            {
                clsMessages.GeneralErrorMessage("There's already a pending request for this account, please be patient and wait :)");
                return;
            }

            clsRquestsPasswordUsers Request = new clsRquestsPasswordUsers();

            Request.Status = clsRquestsPasswordUsers.enStatus.Pending;
            Request.Method = (clsRquestsPasswordUsers.enMethod)cbBy.SelectedIndex;
            Request.Time = DateTime.Now;
            Request.UserID = UserID;

            if (Request.Save())
            {
                clsMessages.GeneralSuccessMessage("Request Send it Succesfuly!");
                this.Close();
            }
            else
                clsMessages.GeneralErrorMessage("Request Failed!");
        }    

        private void tbInput1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbBy.Text == "Phone")
                e.Handled = clsValidate.AllowNumbersOnly(e.KeyChar);
        }

        private void fmSendRequestForChange_Activated(object sender, EventArgs e)
        {
            tbInput1.Focus();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInput1.Focus();
        }
    }
}
