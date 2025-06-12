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

namespace DesktopLayer.Clients.Controls
{
    public partial class ctrClientInfo : UserControl
    {
        public clsClients ClientInfo;

        public ctrClientInfo()
        {
            InitializeComponent();
        }

        public int? ClientID
        {
            get
            {
                return (ClientInfo == null) ? null : ClientInfo.ClientID;
            }
        }

        private void _LoadData()
        {
            ctrPersonInfo1.LoadPersonDataByUserID(ClientInfo.PersonID, false);

            lbClientID.Text = ClientID.ToString();
            lbAccountNumber.Text = ClientInfo.AccountNumber;
            lbBalance.Text = ClientInfo.Balance.ToString();
        }

        public bool LoadClientDataByID(int? ClientID)
        {
            ClientInfo = clsClients.FindByID(ClientID);

            if (ClientInfo == null)
            {
                clsMessages.NullObject("Client", $"with Id = {ClientID}");
                _Default();
                return false;
            }

            _LoadData();
            return true;
        }

        private void _Default()
        {
            ctrPersonInfo1.LoadPersonDataByUserID(null, false);

            lbClientID.Text = "[???]";
            lbAccountNumber.Text = "[???]";
            lbBalance.Text = "[???]";
        }

        public bool LoadClientDataByAccountNumber(string AccountNumber)
        {
            ClientInfo = clsClients.FindByAccountNumber(AccountNumber);

            if (ClientInfo == null)
            {
                clsMessages.NullObject("User", $"with Account Number = {AccountNumber}");
                _Default();
                return false;
            }

            _LoadData();
            return true;
        }
    }
}
