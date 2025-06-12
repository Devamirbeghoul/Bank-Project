using DesktopLayer.GlobalClasses;
using DesktopLayer.Login;
using DesktopLayer.Login.Register;
using DesktopLayer.Password_PinCode;
using DesktopLayer.People;
using DesktopLayer.Transactions;
using DesktopLayer.Transactions.Histories.BalanceOperations;
using DesktopLayer.Transactions.Histories.Transfer;
using DesktopLayer.Users;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer
{
    public partial class fmMainAdmin : Form
    {
        private fmLogin _Login;

        public fmMainAdmin(fmLogin Login)
        {
            InitializeComponent();
            _Login = Login;
        }

        void ResetBtns()
        {
            foreach (Guna2Button btn in splitContainer1.Panel1.Controls)
                btn.Checked = false;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ResetBtns();

            Guna2Button btn = sender as Guna2Button;

            btn.Checked = true;

            tcScreens.SelectedIndex = Convert.ToInt32(btn.Tag);
        }

        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
            => _Login.Show();

        private void splitContainer1_Panel1_Click(object sender, EventArgs e)
        {
            ResetBtns();

            tcScreens.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        #region Account Btns
        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            fmUserDetails User = new fmUserDetails(clsGlobal.ID);

            User.ShowDialog();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            fmChangePasswordUsers Password = new fmChangePasswordUsers();

            Password.ShowDialog();
        }

        private void btnPersonalLoginHistory_Click(object sender, EventArgs e)
        {
            fmPersonalLogin Personal = new fmPersonalLogin(clsGlobal.ID);

            Personal.ShowDialog();
        }

        #endregion

        #region Users Btns
        private void btnBasic_Click(object sender, EventArgs e)
        {
            fmListOfPeople All = new fmListOfPeople(this);

            this.Hide();

            All.ShowDialog();
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            fmUsersList User = new fmUsersList(this);

            this.Hide();

            User.ShowDialog();
        }


        #endregion

        #region Password Requests
        private void btnPasswordRequests_Click(object sender, EventArgs e)
        {
            ResetBtns();

            btnPasswordRequests.Checked = true;

            fmResquests Request = new fmResquests();

            Request.ShowDialog();

            btnPasswordRequests.Checked = false;
        }

        #endregion

        #region Registry
        private void btnRegistry_Click(object sender, EventArgs e)
        {
            fmLoginRegister Registry = new fmLoginRegister();

            Registry.ShowDialog();
        }


        #endregion

        #region Transactions
        private void btnBasicHistory_Click(object sender, EventArgs e)
        {
            fmHistroyOfOperations History = new fmHistroyOfOperations();

            History.ShowDialog();
        }

        private void btnTransferHistory_Click(object sender, EventArgs e)
        {
            fmHistoryOfTransfer transfer = new fmHistoryOfTransfer();

            transfer.ShowDialog();
        }


        #endregion Transactions

    }
}
