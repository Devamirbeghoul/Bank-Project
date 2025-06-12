using DesktopLayer.Clients;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Login;
using DesktopLayer.Login.Register;
using DesktopLayer.Password_PinCode;
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

namespace DesktopLayer.Main
{
    public partial class fmMainClients : Form
    {
        private fmLogin _Login;

        public fmMainClients(fmLogin Login)
        {
            InitializeComponent();
            _Login = Login;
        }

        void ResetBtns()
        {
            foreach (Guna2Button btn in splitContainer1.Panel1.Controls)
                btn.Checked = false;
        }

        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
            => _Login.Show();

        private void btn_Click(object sender, EventArgs e)
        {
            ResetBtns();

            Guna2Button btn = sender as Guna2Button;

            btn.Checked = true;

            tcScreens.SelectedIndex = Convert.ToInt32(btn.Tag);
        }

        private void splitContainer1_Panel1_Click(object sender, EventArgs e)
        {
            ResetBtns();

            tcScreens.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        #region Account
        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            fmClientDetails Client = new fmClientDetails(clsGlobal.ID);

            Client.ShowDialog();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            fmChangePinCode Password = new fmChangePinCode(clsGlobal.ID);

            Password.ShowDialog();
        }

        private void btnPersonalLoginHistory_Click(object sender, EventArgs e)
        {
            fmPersonalLogin Personal = new fmPersonalLogin(clsGlobal.ID);

            Personal.ShowDialog();
        }

        private void btnBasicHistory_Click(object sender, EventArgs e)
        {
            fmHistroyOfOperations New = new fmHistroyOfOperations(clsGlobal.GetIdentifier);

            New.ShowDialog();
        }

        private void btnTransferHistory_Click(object sender, EventArgs e)
        {
            fmHistoryOfTransfer transfer = new fmHistoryOfTransfer(clsGlobal.GetIdentifier);

            transfer.ShowDialog();
        }

        #endregion


    }
}
