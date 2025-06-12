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

namespace DesktopLayer.Transactions
{
    public partial class fmTransfer : Form
    {
        public fmTransfer()
        {
            InitializeComponent();
        }

        private void tbAmount_Validating(object sender, CancelEventArgs e)
        {
            string Amount = tbAmount.Text.Trim();

            if (!clsValidate.IsNumber(Amount))
            {
                e.Cancel = true;
                epValidate.SetError(tbAmount, "Invalid Amount!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbAmount, "");
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClientSelected(int? ClientID)
        {
            if (ClientID == null)
                return;

            if (btnNextBack.Text == "Next")
                lbFrom.Text = ClientID.ToString();
            else
                lbTo.Text = ClientID.ToString();
        }

        private void btnNextBack_Click(object sender, EventArgs e)
        {
            if (btnNextBack.Text == "Next")
            {
                btnNextBack.Text = "Back";
                tbAmount.Enabled = true;
                btnPerform.Enabled = true;
                ctrClientInfoWithFilter1.FocusFilter();
            }
                
            else
            {
                btnNextBack.Text = "Next";
                tbAmount.Enabled = false;
                btnPerform.Enabled = false;
            }
                
        }

        private void lbFrom_Validating(object sender, CancelEventArgs e)
        {
            Label lb = sender as Label;

            e.Cancel = lb.Text == "[???]";
        }

        private void btnPerform_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessages.NullOrEmptyFieldsMessage(true);
                return;
            }

            int FromID = Convert.ToInt32(lbFrom.Text);
            int ToID = Convert.ToInt32(lbTo.Text);
            decimal Amount = Convert.ToDecimal(tbAmount.Text);
            decimal FromBalance = clsClients.GetBalanceByID(FromID);

            if (FromID == ToID)
            {
                clsMessages.GeneralErrorMessage("You can't send to the same account!");
                return;
            }

            if (FromBalance < Amount)
            {
                clsMessages.GeneralErrorMessage("You can Withdraw only " + FromBalance + " From First Client");
                return;
            }

            clsTransfer NewTransfer = new clsTransfer();

            NewTransfer.FromID = FromID;
            NewTransfer.ToID = ToID;
            NewTransfer.Amount = Amount;
            NewTransfer.Time = DateTime.Now;
            NewTransfer.ByUserID = clsGlobal.ID;

            if (NewTransfer.Save())
            {
                clsMessages.SuccessSaveData();
                this.Close();
            }
            else
                clsMessages.FailedSaveData();
        }

        private void fmTransfer_Activated(object sender, EventArgs e)
        {
            ctrClientInfoWithFilter1.FocusFilter();
        }

        private void fmTransfer_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

        }
    }
}
