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
    public partial class fmBalanceOperations : Form
    {
        private clsBalanceOperations.enOperationType _Type;
        public fmBalanceOperations(clsBalanceOperations.enOperationType Type)
        {
            InitializeComponent();
            _Type = Type;
        }

        private void BalanceOperations_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

            string TypeText = _Type.ToString();

            btnSend.Text = TypeText;
            this.Text = TypeText;
        }

        private void BalanceOperations_Activated(object sender, EventArgs e)
        {
            ctrClientInfoWithFilter1.FocusFilter();
        }

        private void OnClientSelected(int? ClientID)
        {
            if (ClientID != null)
                tbAmount.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (clsMessages.Confirm(_Type.ToString())) 
            {
                if (!this.ValidateChildren())
                {
                    clsMessages.NullOrEmptyFieldsMessage(true);
                    return;
                }

                clsBalanceOperations New = new clsBalanceOperations();

                decimal OldAmount = ctrClientInfoWithFilter1.ClientInfo.Balance;
                decimal Amount = Convert.ToDecimal(tbAmount.Text);
                int? ClientID = ctrClientInfoWithFilter1.ClientID;

                New.OpertaionType = _Type;
                New.ClientID = ClientID;
                New.OldAmount = OldAmount;
                New.ByUserID = clsGlobal.ID;
                New.Time = DateTime.Now;

                if (_Type == clsBalanceOperations.enOperationType.Desposit)
                    New.NewAmount = OldAmount + Amount;
                else
                {
                    if (Amount > OldAmount)
                    {
                        clsMessages.GeneralErrorMessage("You can Withdraw only " + OldAmount);
                        return;
                    }

                    New.NewAmount = OldAmount - Amount;
                }

                if (New.Save())
                {
                    clsMessages.SuccessSaveData();
                    ctrClientInfoWithFilter1.LoadClientData(ClientID, true);
                    ctrClientInfoWithFilter1.FocusFilter();
                }
                else
                    clsMessages.FailedSaveData();
            }
        }
    }
}
