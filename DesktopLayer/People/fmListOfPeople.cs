using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Login;
using DesktopLayer.Main;
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

namespace DesktopLayer.People
{
    public partial class fmListOfPeople : Form
    {
        private Form _MainMenue;
        private static int _PageSize = clsDefaultValues.SetPageSize();
        private int _CurrentPage = 1;
        private int _TotalPages;
        private string Filter = null;
        private string Value = null;

        List<string> Headers = new List<string>()
            {
                "ID" , "Card ID" , "Full Name" , "Date Of Birth" , "Gender" ,
                "Address" , "Wilaya" , "Phone" , "Email"
            };

        List<int> Widths = new List<int>()
            {
                110 , 110 , 300 , 140 , 70 , 270 , 110 , 100 , 200
            };

        public fmListOfPeople(Form MainMenue)
        {
            InitializeComponent();
            _MainMenue = MainMenue;
        }

        private void _RefershPeopleList()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsPeople.GetTotalPages(_PageSize) ?? 0;
                dgvPeople.DataSource = clsPeople.GetAllPeoplePerPages(_CurrentPage, _PageSize);
            }

            else
            {
                _TotalPages = clsPeople.GetTotalPagesBy(_PageSize, Filter, Value) ?? 0;
                dgvPeople.DataSource = clsPeople.GetPeoplePerPagesBy<string>(_CurrentPage, _PageSize, Filter, Value);
            }


            dgvPeople.Font = clsDefaultValues.GetDefaultFont();

            lbRcords.Text = dgvPeople.RowCount.ToString();

            lbPages.Text = clsDefaultValues.SetPageStringFormat(_CurrentPage, _TotalPages);

            clsSystem.SetHeadersAndWidthsOfDataGridView(dgvPeople, Headers, Widths);
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fmAddEditPerson Add = new fmAddEditPerson();

            Add.ShowDialog();

            _RefershPeopleList();

        }

        private void fmListOfPeople_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

            cbFilterBy.SelectedIndex = 0;
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddEditPerson Add = new fmAddEditPerson();

            Add.ShowDialog();

            _RefershPeopleList();
                
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            fmAddEditPerson Edit = new fmAddEditPerson(PersonID);

            Edit.ShowDialog();

            _RefershPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            if (clsMessages.ConfirmDelete("Person" , PersonID))
            {
                if (clsPeople.Delete(PersonID))
                {
                    clsMessages.GeneralSuccessMessage("Deleted Successfuly!");

                    _RefershPeopleList();

                    if (dgvPeople.Rows.Count == 0)
                        btnBack_Click(null, null);

                }
                else
                    clsMessages.GeneralErrorMessage("This Person have another data , remove it first!");
            }
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;

            fmPersonInfo Info = new fmPersonInfo(PersonID);

            Info.ShowDialog();

            _RefershPeopleList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Visible = (cbFilterBy.Text != "None") && (cbFilterBy.Text != "Gender");

            if (tbFilterValue.Visible)
            {
                tbFilterValue.Clear();
                tbFilterValue.Focus();
                cbGenderValue.Visible = false;
                _CurrentPage = 1;
                return;
            }

            cbGenderValue.Visible = (cbFilterBy.Text != "None");

            if (cbGenderValue.Visible)
            {
                cbGenderValue.SelectedIndex = 0;
                _CurrentPage = 1;
                return;
            }

            _RefershPeopleList();
                
        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "ID" || cbFilterBy.Text == "Card ID")
                e.Handled = clsValidate.AllowNumbersOnly(e.KeyChar);
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = cbFilterBy.Text.Trim();

            Filter = (FilterValue == "Full Name") ? "FullName" : FilterValue;

            Value = tbFilterValue.Text.Trim() ?? null;

            _RefershPeopleList();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clsSystem.PerformBtnNext(ref _CurrentPage, _TotalPages, _RefershPeopleList);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            clsSystem.PerformBtnBack(ref _CurrentPage, _RefershPeopleList);
        }

        private void findPerosnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmFindPerson Find = new fmFindPerson();

            Find.ShowDialog();

            _RefershPeopleList();

            if (dgvPeople.RowCount == 0)
                btnBack_Click(null, null);
        }

        private void fmListOfPeople_FormClosed(object sender, FormClosedEventArgs e)
            => _MainMenue.Show();

        private void cbGenderValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            string V = cbGenderValue.Text.Trim();

            Filter = cbFilterBy.Text;
            Value = (V == "All") ? null : V;

            _RefershPeopleList();
        }
    }
}
