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

namespace DesktopLayer.People.Controls
{
    public partial class ctrPersonInfoWithFilter : UserControl
    {
        public ctrPersonInfoWithFilter()
        {
            InitializeComponent();
        }

        public event Action<int?> PersonSelected;

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

        public int? PersonID
        {
            get
            {
                return ctrPersonInfo1.PersonID;
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

            if (cbFilterBy.Text == "Person ID")
                IsFind = ctrPersonInfo1.LoadPersonDataByUserID(Convert.ToInt32(Input));
            else
                IsFind = ctrPersonInfo1.LoadPersonDataByCardID(Input);

            if (!IsFind)
            {
                tbFilterValue.Clear();
                FocusFilter();
            }

            if (PersonSelected != null)
                PersonSelected(PersonID);
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
                return;
            }

            e.Handled = clsValidate.AllowNumbersOnly(e.KeyChar);

        }

        private void ctrPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void DataBack(int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Text = PersonID.ToString();
            btnSearch.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fmAddEditPerson Add = new fmAddEditPerson();
            Add.DataBack += DataBack;
            Add.ShowDialog();
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

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tbFilterValue.Clear();
            tbFilterValue.Focus() ;
        }

        public void LoadPersonData(int PersonID , bool FilterValue = false)
        {
            Filter = FilterValue;

            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Text = PersonID.ToString() ;

            ctrPersonInfo1.LoadPersonDataByUserID(PersonID);

        }
    }
}
