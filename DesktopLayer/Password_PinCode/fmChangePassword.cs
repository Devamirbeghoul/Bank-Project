using BusinessLayer;
using DesktopLayer.GlobalClasses;
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
    public partial class fmChangePasswordUsers : Form
    {
        private clsUsers _User;

        public Action DataBack;

        public fmChangePasswordUsers()
        {
            InitializeComponent();
            ctrUserInfo1.LoadUserDataByID(clsGlobal.ID);
            _User = clsUsers.Find(clsGlobal.ID);

            if (_User.Permissions == "Admin")
            {
                tbCurrentPassword.Visible = false;
                lbCurrentPassword.Visible = false;
                tbCurrentPassword.Validating -= tbCurrentPassword_Validating;
            }

            else
            {
                llbForgetPassword.Visible = true;
            }

        }

        public fmChangePasswordUsers(int? UserID)
        {
            InitializeComponent();
            ctrUserInfo1.LoadUserDataByID(UserID);
            _User = clsUsers.Find(UserID);
            tbCurrentPassword.Visible = false;
            lbCurrentPassword.Visible = false;
            tbCurrentPassword.Validating -= tbCurrentPassword_Validating;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbCurrentPassword.Text != clsSystem.SymmetricDecrypt(_User.Psswrd))
            {
                e.Cancel = true;
                epValidate.SetError(tbCurrentPassword, "Wrong Password!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbCurrentPassword, "");
            }
        }

        private void fmChangePasswordUsers_Activated(object sender, EventArgs e)
        {
            if (_User.Permissions == "Admin")
                tbNewPassword.Focus();
            else
                tbCurrentPassword.Focus();
        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            string Password = tbNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(Password) || !clsValidate.ValidatePassword(Password))
            {
                e.Cancel = true;
                epValidate.SetError(tbNewPassword, "Invalid Password!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbNewPassword, "");
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbConfirmPassword.Text != tbNewPassword.Text)
            {
                e.Cancel = true;
                epValidate.SetError(tbConfirmPassword, "Not The Same Password!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbConfirmPassword, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessages.NullOrEmptyFieldsMessage(true);
                return;
            }

            _User.Psswrd = clsSystem.SymmetricEncrypt(tbConfirmPassword.Text.Trim());

            if (_User.Save())
            {
                clsMessages.SuccessSaveData();
                clsGlobal.SetCurrentPersonLogin(clsGlobal.enType.User, _User.UsrnNm);
                DataBack?.Invoke();
                this.Close();
            }
            else
                clsMessages.FailedSaveData();
        }

        private void fmChangePasswordUsers_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

            

        }

        private void llbForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmSendRequestForChange Send = new fmSendRequestForChange();

            Send.ShowDialog();
        }
    }
}
