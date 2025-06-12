using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Properties;
using Guna.UI2.HtmlRenderer.Adapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.Users
{
    public partial class fmAddEditUser : Form
    {
        enum enMode { AddNew , Edit};

        private enMode _Mode = enMode.AddNew;

        private int? _UserID = null;
        private int? PersonID = null;

        private clsUsers _User;

        public event Action<int> DataBack;

        public fmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }

        public fmAddEditUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Edit;
            _UserID = UserID;
        }

        private void fmAddEditUser_Activated(object sender, EventArgs e)
        {
            ctrPersonInfoWithFilter1.FocusFilter();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ctrPersonInfoWithFilter1.FocusFilter();

            PersonID = ctrPersonInfoWithFilter1.PersonID;

            if (PersonID == null)
            {
                clsMessages.GeneralErrorMessage("Select a Person First!", "Invalid Informations");
                return;
            }

            if (clsPeople.IsPerson(PersonID , clsUsers.IsPersonUser) && _Mode == enMode.AddNew)
            {
                clsMessages.AlreadyTakenMessage("Person Info", "User");
                return;
            }

            tcPerformAddEditUser.SelectedIndex = 1;
            btnSave.Enabled = true;
            tbUserName.Focus();
        }

        private void _SetDefaults()
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);
            ctrPersonInfoWithFilter1.btnAddVisible = true;
        }

        private void _PerfromAddScreen()
        {
            this.Text = "Add New User";
            lbTitle.Text = "Add New User";
            lbTitleV2.Text = "Add New User";
            _User = new clsUsers();
        }

        private void _PerfromEditScreen()
        {
            this.Text = "Edit User";
            lbTitle.Text = "Edit User";
            lbTitleV2.Text = "Edit User";

            _User = clsUsers.Find(_UserID);

            if (_User == null)
            {
                clsMessages.NullObject("User", $"with Id =  {_UserID}");
                this.Close();
                return;
            }

            ctrPersonInfoWithFilter1.LoadPersonData((int)_User.PrsnID);

            lbUserID.Text = _UserID.ToString();
            tbUserName.Text = _User.UsrnNm;
            tbPassword.Text = clsSystem.SymmetricDecrypt(_User.Psswrd);
            tbConfirmPasword.Text = clsSystem.SymmetricDecrypt(_User.Psswrd);
            cbIsActive.Checked = _User.IsActive;

            if (_User.Prmssns == clsUsers.enPermissions.Admin)
                rbAdmin.Checked = true;
            else
                rbWorker.Checked = true;

        }

        private void fmAddEditUser_Load(object sender, EventArgs e)
        {
            _SetDefaults();

            if (_Mode == enMode.AddNew)
                _PerfromAddScreen();
            else
                _PerfromEditScreen();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            tcPerformAddEditUser.SelectedIndex = 0;

            ctrPersonInfoWithFilter1.FocusFilter();
        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            string Username = tbUserName.Text.Trim();

            bool IsNotValid = clsUsers.IsUserExistByUsername(Username);

            if (_Mode == enMode.Edit)
                IsNotValid = IsNotValid && (_User.UsrnNm != Username);

            if (string.IsNullOrEmpty(Username) || IsNotValid)
            {
                e.Cancel = true;
                epValidate.SetError(tbUserName,
                    (IsNotValid) ? "This Username is already used by a User" : "This field is required!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbUserName, string.Empty);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            string Password = tbPassword.Text.Trim();
            bool IsNullOrEmpty = string.IsNullOrEmpty(Password);

            if (IsNullOrEmpty || !clsValidate.ValidatePassword(Password))
            {
                e.Cancel = true;

                epValidate.SetError(tbPassword,
                    (IsNullOrEmpty) ? "This field is required!" : "Weak Password!"); ;
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbPassword, "");
            }
        }

        private void tbConfirmPasword_Validating(object sender, CancelEventArgs e)
        {
            if (tbConfirmPasword.Text != tbPassword.Text)
            {
                e.Cancel = true;
                epValidate.SetError(tbConfirmPasword, "Not The Same Password!");
            }
            else
            {
                e.Cancel= false;
                epValidate.SetError(tbConfirmPasword, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessages.NullOrEmptyFieldsMessage(true);
                return;
            }

            _User.PrsnID = PersonID;
            _User.UsrnNm = tbUserName.Text.Trim();
            _User.Psswrd = clsSystem.SymmetricEncrypt(tbPassword.Text);
            _User.Prmssns = 
                (rbAdmin.Checked) ? clsUsers.enPermissions.Admin : clsUsers.enPermissions.Worker;
            _User.IsActive = cbIsActive.Checked;

            if (_User.Save())
            {
                clsMessages.SuccessSaveData();
                _Mode = enMode.Edit;
                this.Text = "Edit User";
                lbTitle.Text = "Edit User";
                lbTitleV2.Text = "Edit User";
                lbUserID.Text = _User.UsrID.ToString();
                _UserID = _User.UsrID;
                ctrPersonInfoWithFilter1.Filter = false;
                DataBack?.Invoke((int)_UserID);
            }
            else
                clsMessages.FailedSaveData();
        }
    }
}
