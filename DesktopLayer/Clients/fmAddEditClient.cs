using BusinessLayer;
using DesktopLayer.GlobalClasses;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DesktopLayer.Clients
{
    public partial class fmAddEditClient : Form
    {
        enum enMode { AddNew, Edit };

        private enMode _Mode = enMode.AddNew;

        private int? _ClientID = null;
        private int? _PersonID = null;

        private clsClients _Client;

        public event Action<int> DataBack;

        public fmAddEditClient()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public fmAddEditClient(int ClientID)
        {
            InitializeComponent();
            _Mode = enMode.Edit;
            _ClientID = ClientID;
        }

        private void fmAddEditClient_Activated(object sender, EventArgs e)
        {
            ctrPersonInfoWithFilter1.FocusFilter();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ctrPersonInfoWithFilter1.FocusFilter();

            _PersonID = ctrPersonInfoWithFilter1.PersonID;

            if (_PersonID == null)
            {
                clsMessages.GeneralErrorMessage("Select a Person First!", "Invalid Informations");
                return;
            }

            if (clsPeople.IsPerson(_PersonID, clsClients.IsPersonClient) && _Mode == enMode.AddNew)
            {
                clsMessages.AlreadyTakenMessage("Person Info", "Client");
                return;
            }

            tcPerformAddEditClient.SelectedIndex = 1;
            btnSave.Enabled = true;
            tbAccountNumber.Focus();
        }

        private void _SetDefaults()
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);
            ctrPersonInfoWithFilter1.btnAddVisible = true;
        }

        private void _PerfromAddScreen()
        {
            this.Text = "Add New Client";
            lbTitle.Text = "Add New Client";
            lbTitleV2.Text = "Add New Client";
            _Client = new clsClients();
        }

        private void _PerfromEditScreen()
        {
            this.Text = "Edit User";
            lbTitle.Text = "Edit User";
            lbTitleV2.Text = "Edit User";

            _Client = clsClients.FindByID(_ClientID);

            if (_Client == null)
            {
                clsMessages.NullObject("Client", $"with Id =  {_ClientID}");
                this.Close();
                return;
            }

            ctrPersonInfoWithFilter1.LoadPersonData((int)_Client.PersonID);

            lbClientID.Text = _ClientID.ToString();
            tbAccountNumber.Text = _Client.AccountNumber;
            tbPassword.Text = clsSystem.SymmetricDecrypt(_Client.PinCode);
            tbConfirmPasword.Text = clsSystem.SymmetricDecrypt(_Client.PinCode);
            tbBalance.Text = _Client.Balance.ToString();

        }

        private void fmAddEditClient_Load(object sender, EventArgs e)
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

            tcPerformAddEditClient.SelectedIndex = 0;

            ctrPersonInfoWithFilter1.FocusFilter();
        }

        private void tbAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            string AccountNumber = tbAccountNumber.Text.Trim();

            bool IsNotValid = clsClients.IsClientExistByAccountNumber(AccountNumber);

            if (_Mode == enMode.Edit)
                IsNotValid = IsNotValid && (_Client.AccountNumber != AccountNumber);

            if (string.IsNullOrEmpty(AccountNumber) || IsNotValid)
            {
                e.Cancel = true;
                epValidate.SetError(tbAccountNumber,
                    (IsNotValid) ? "This Account Number is already used by a Client" : "This field is required!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbAccountNumber, string.Empty);
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
                e.Cancel = false;
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

            _Client.PersonID = _PersonID;
            _Client.AccountNumber = tbAccountNumber.Text.Trim();
            _Client.PinCode = clsSystem.SymmetricEncrypt(tbPassword.Text);
            _Client.Balance = Convert.ToDecimal(tbBalance.Text.Trim());

            if (_Client.Save())
            {
                clsMessages.SuccessSaveData();
                _Mode = enMode.Edit;
                this.Text = "Edit Client";
                lbTitle.Text = "Edit Client";
                lbTitleV2.Text = "Edit Client";
                lbClientID.Text = _Client.ClientID.ToString();
                _ClientID = _Client.ClientID;
                ctrPersonInfoWithFilter1.Filter = false;
                DataBack?.Invoke((int)_ClientID);
            }
            else
                clsMessages.FailedSaveData();
        }

        private void tbBalance_Validating(object sender, CancelEventArgs e)
        {
            string Balance = tbBalance.Text.Trim();

            if (string.IsNullOrEmpty(Balance) || !clsValidate.IsNumber(Balance))
            {
                e.Cancel = true;
                epValidate.SetError(tbBalance, "This field is required Corrected!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbBalance, string.Empty);
            }
        }
    }
}
