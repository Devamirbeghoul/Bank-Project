using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Main;
using DesktopLayer.Password_PinCode;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.Login
{
    public partial class fmLogin : Form
    {
        private static short Default = 2;
        private short Counter = Default;
        private int TimeForNextLogin = 30;

        public fmLogin()
        {
            InitializeComponent();
        }

        private void fmLogin_Load(object sender, EventArgs e)
        {
            string Username = string.Empty;
            string Password = string.Empty;
            string Type = string.Empty;

            if (clsSystem.BackupLoginInformation(ref Username, ref Password , ref Type))
            {
                cbType.SelectedIndex = Convert.ToInt32(Type);
                tbUsername.Text = Username;
                tbPassword.Text = Password;
                cbRememberMe.Checked = true;
            }
            else
                cbRememberMe.Checked = false;

        }

        private void NoNullOrEmpty_Validating(object sender, CancelEventArgs e)
        {
            Guna2TextBox tb = sender as Guna2TextBox;

            if (string.IsNullOrEmpty(tb.Text))
            {
                e.Cancel = true;
                epValidate.SetError(tb, "This Field is required!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tb, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void _PerformUserLogin()
        {
            string Username = tbUsername.Text.Trim();
            string Password = clsSystem.SymmetricEncrypt(tbPassword.Text.Trim());

            if (!clsUsers.IsUserExistByUsernameAndPassword(Username, Password))
            {
                clsMessages.GeneralErrorMessage("Wrong Username/Password!", "Wrong Informations");
                tbUsername.Focus();
                return;
            }

            clsGlobal.SetCurrentPersonLogin(clsGlobal.enType.User, Username);

            if (!clsGlobal.IsActive)
            {
                clsMessages.GeneralErrorMessage("This User Account isn't Active", "No Longer Active");
                return;
            }

            if (cbRememberMe.Checked)
                clsSystem.SaveLoginInforamtion(Username, Password, cbType.SelectedIndex);
            else
                clsSystem.RemoveStoredInformation();

            clsGlobal.SetCurrentPersonLogin(clsGlobal.enType.User, Username);

            clsLoginRegistryUsers NewLogin = new clsLoginRegistryUsers();

            NewLogin.UserID = clsGlobal.ID;
            NewLogin.Time = DateTime.Now;

            NewLogin.Save();

            Form Main;

            if (clsGlobal.Permissions == "Admin")
                Main = new fmMainAdmin(this);

            else
                Main = new fmMainWorker(this);

            Counter = Default;

            this.Hide();

            Main.ShowDialog();
        }

        private void _PerformClientLogin()
        {
            string AccountNumber = tbUsername.Text.Trim();
            string PinCode = clsSystem.SymmetricEncrypt(tbPassword.Text.Trim());

            if (!clsClients.IsClientExistByAccountNumberAndPinCode(AccountNumber, PinCode))
            {
                clsMessages.GeneralErrorMessage("Wrong AccountNumber/PinCode!", "Wrong Informations");
                tbUsername.Focus();
                return;
            }

            clsGlobal.SetCurrentPersonLogin(clsGlobal.enType.Client, AccountNumber);


            if (cbRememberMe.Checked)
                clsSystem.SaveLoginInforamtion(AccountNumber, PinCode, cbType.SelectedIndex);
            else
                clsSystem.RemoveStoredInformation();

            clsGlobal.SetCurrentPersonLogin(clsGlobal.enType.Client, AccountNumber);

            clsLoginRegistryClients NewLogin = new clsLoginRegistryClients();

            NewLogin.ClientID = clsGlobal.ID;
            NewLogin.Time = DateTime.Now;

            NewLogin.Save();

            fmMainClients Main = new fmMainClients(this);

            Counter = Default;

            this.Hide();

            Main.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Counter == 0)
            {
                btnGo.Enabled = false;
                btnGo.Text = TimeForNextLogin.ToString();
                clsMessages.GeneralErrorMessage($"Your 3 Chances End, Try Again After {TimeForNextLogin} s");
                NextLogin.Start();
                return;
            }
            else
                Counter--;

            if (!this.ValidateChildren())
            {
                clsMessages.NullOrEmptyFieldsMessage(false);
                return;
            }

            switch (cbType.Text)
            {
                case "User":
                    {
                        _PerformUserLogin();
                        break;
                    }
                case "Client":
                    {
                        _PerformClientLogin();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void _PerformUserUi()
            => _PerformUi("Username:", "Password:" , 170, 226);

        private void _PerformClientUi()
            => _PerformUi("Account Number:", "Pin Code:" , 246, 302);

        private void _PerformUi(string Title1 , string Title2 , int x1 , int x2)
        {
            lbInput1.Text = Title1;
            lbInput2.Text = Title2;
            tbUsername.Location = new Point(x1, 143);

            tbPassword.Location = new Point(x1, 200);

            cbRememberMe.Location = new Point(x2, 246);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Guna2TextBox tb in gbLogin.Controls.OfType<Guna2TextBox>())
                tb.Clear();
                

            switch(cbType.Text)
            {
                case "User":
                    {
                        _PerformUserUi();
                        break;
                    }
                case "Client":
                    {
                        _PerformClientUi();
                        break;
                    }
                default:
                    {
                        _PerformClientUi();
                        break;
                    }
            }

            tbUsername.Focus();
        }

        private void NextLogin_Tick(object sender, EventArgs e)
        {
            TimeForNextLogin--;

            if (TimeForNextLogin == 0)
            {
                btnGo.Enabled = true;
                btnGo.Text = "Go";
                TimeForNextLogin = 30;
                Counter = Default;
                NextLogin.Stop();
            }
            else
                btnGo.Text = TimeForNextLogin.ToString();
        }

        private void llbForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmSendRequestForChange Send = new fmSendRequestForChange();

            Send.ShowDialog();
        }
    }
}
