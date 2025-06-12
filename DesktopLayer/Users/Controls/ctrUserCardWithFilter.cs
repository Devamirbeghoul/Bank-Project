using DesktopLayer.GlobalClasses;
using DesktopLayer.People;
using DesktopLayer.People.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.Users.Controls
{
    public partial class ctrUserCardWithFilter : UserControl
    {
        public ctrUserCardWithFilter()
        {
            InitializeComponent();
        }

        public event Action<int?> UserSelected;

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

        public int? UserID
        {
            get
            {
                return ctrUserInfo1.UserID;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessages.GeneralErrorMessage("Enter Informations First!");
                return;
            }

            bool IsFind = false;
            string Input = tbFilterValue.Text.Trim();

            if (cbFilterBy.Text == "User ID")
                IsFind = ctrUserInfo1.LoadUserDataByID(Convert.ToInt32(Input));
            else
                IsFind = ctrUserInfo1.LoadUserNyUsername(Input);

            if (!IsFind)
            {
                tbFilterValue.Clear();
                FocusFilter();
            }

            if (UserSelected != null)
                UserSelected(UserID);
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
                return;
            }

            if (cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void ctrUserInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void DataBack(int UserID)
        {
            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Text = UserID.ToString();
            btnSearch.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fmAddEditUser Add = new fmAddEditUser();
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

        public void LoadUserData(int UserID , bool FilterValue = false)
        {
            Filter = FilterValue;

            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Text = UserID.ToString();

            ctrUserInfo1.LoadUserDataByID(UserID);

        }
    }
}
