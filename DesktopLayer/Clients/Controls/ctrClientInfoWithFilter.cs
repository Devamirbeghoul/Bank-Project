using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Users;
using DesktopLayer.Users.Controls;
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
    public partial class ctrClientInfoWithFilter : UserControl
    {
        public ctrClientInfoWithFilter()
        {
            InitializeComponent();
        }

        public event Action<int?> ClientSelected;

        public void FocusFilter() => tbFilterValue.Focus();

        public bool Filter
        {
            get
            {
                return gbFilter.Enabled;
            }

            set
            {
                gbFilter.Enabled = value;
            }
        }

        public bool btnAddVisible
        {
            get
            {
                return btnAdd.Visible;
            }

            set
            {
                btnAdd.Visible = value;
            }
        }

        public int? ClientID
        {
            get
            {
                return ctrClientInfo1.ClientID;
            }
        }

        public clsClients ClientInfo => ctrClientInfo1.ClientInfo;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessages.GeneralErrorMessage("Enter Informations First!");
                return;
            }

            bool IsFind = false;
            string Input = tbFilterValue.Text.Trim();

            if (cbFilterBy.Text == "Client ID")
                IsFind = ctrClientInfo1.LoadClientDataByID(Convert.ToInt32(Input));
            else
                IsFind = ctrClientInfo1.LoadClientDataByAccountNumber(Input);

            if (!IsFind)
            {
                tbFilterValue.Clear();
                FocusFilter();
            }

            if (ClientSelected != null)
                ClientSelected(ClientID);
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
                return;
            }

            if (cbFilterBy.Text == "Client ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void ctrClientInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void DataBack(int ClientID)
        {
            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Text = ClientID.ToString();
            btnSearch.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fmAddEditClient Add = new fmAddEditClient();
            Add.DataBack += DataBack;
            Add.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Clear();
            tbFilterValue.Focus();
        }

        private void tbFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilterValue.Text))
            {
                e.Cancel = true;
                epValidate.SetError(tbFilterValue, "This filed is required!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbFilterValue, "");
            }
        }

        public void LoadClientData(int? ClientID, bool FilterValue = false)
        {
            Filter = FilterValue;

            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Text = ClientID.ToString();

            ctrClientInfo1.LoadClientDataByID(ClientID);

        }
    }
}
