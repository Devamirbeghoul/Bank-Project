using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.People;
using DesktopLayer.Users.Controls;
using Guna.UI2.WinForms.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.Users
{
    public partial class fmUsersList : Form
    {
        private fmMainAdmin _MainMenue;
        private static int _PageSize = clsDefaultValues.SetPageSize();
        private int _CurrentPage = 1;
        private int _TotalPages;
        private string Filter = null;
        private string Value = null;

        List<string> Headers = new List<string>()
            {
                "ID" , "Person ID" , "Full Name" , "Username" , "Permissions" ,
                "Is Active"
            };

        List<int> Widths = new List<int>()
            {
                110 , 110 , 300 , 200 , 110 , 100
            };

        public fmUsersList(fmMainAdmin MainMenue)
        {
            InitializeComponent();
            _MainMenue = MainMenue;
        }

        private void _RefershUsersList()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsUsers.GetTotalPages(_PageSize) ?? 0;
                dgvUsers.DataSource = clsUsers.GetUserPerPages(_CurrentPage, _PageSize);
            }
                
            else
            { 
                _TotalPages = clsUsers.GetTotalPagesBy(_PageSize, Filter, Value) ?? 0;
                dgvUsers.DataSource = clsUsers.GetUserPerPagesBy<string>(_CurrentPage, _PageSize, Filter, Value);
            }

            lbPages.Text = clsDefaultValues.SetPageStringFormat(_CurrentPage, _TotalPages);

            dgvUsers.Font = clsDefaultValues.GetDefaultFont();

            lbRcords.Text = dgvUsers.RowCount.ToString();

            clsSystem.SetHeadersAndWidthsOfDataGridView(dgvUsers, Headers, Widths);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fmAddEditUser Add = new fmAddEditUser();

            Add.ShowDialog();

            _RefershUsersList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddEditUser Add = new fmAddEditUser();

            Add.ShowDialog();

            _RefershUsersList();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void fmUsersList_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

            cbFilterBy.SelectedIndex = 0;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            fmAddEditUser Edit = new fmAddEditUser(UserID);

            Edit.ShowDialog();

            _RefershUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            if (clsMessages.ConfirmDelete("User" , UserID))
            {
                if (clsUsers.Delete(UserID))
                {
                    clsMessages.GeneralSuccessMessage("Deleted Successfuly!");

                    _RefershUsersList();

                    if (dgvUsers.Rows.Count == 0)
                        btnBack_Click(null, null);
                }
                else
                    clsMessages.GeneralErrorMessage("Can't Delete this User!");
            }
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            fmUserDetails Info = new fmUserDetails(UserID);

            Info.ShowDialog();

            _RefershUsersList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            tbFilterValue.Visible = (cbFilterBy.Text != "None") && (cbFilterBy.Text != "Is Active") && (cbFilterBy.Text != "Permissions");

            if (tbFilterValue.Visible)
            {
                cbChoiceValue.Visible = false;
                tbFilterValue.Clear();
                tbFilterValue.Focus();
                _CurrentPage = 1;
                return;
            }

            cbChoiceValue.Visible = (cbFilterBy.Text != "None");

            if (cbChoiceValue.Visible)
            {
                cbChoiceValue.Items.Clear();
                cbChoiceValue.Items.Add("All");

                if (cbFilterBy.Text == "Permissions")
                {
                    cbChoiceValue.Items.Add("Admin");
                    cbChoiceValue.Items.Add("Worker");
                }

                else
                {
                    cbChoiceValue.Items.Add("Yes");
                    cbChoiceValue.Items.Add("No");
                }

                cbChoiceValue.SelectedIndex = 0;
                _CurrentPage = 1;
                return;
            }
                
            _RefershUsersList() ;
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = cbFilterBy.Text.Trim();

            Filter = (FilterValue == "Full Name") ? "FullName" : FilterValue;

            Value = tbFilterValue.Text.Trim() ?? null;

            _RefershUsersList();
        }

        private void cbChoiceValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter = (cbFilterBy.Text == "Is Active") ? "IsActive" : "Permissions" ;
            Value = cbChoiceValue.Text.Trim();

            _RefershUsersList();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clsSystem.PerformBtnNext(ref _CurrentPage, _TotalPages, _RefershUsersList);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            clsSystem.PerformBtnBack(ref _CurrentPage , _RefershUsersList);
        }

        private void findUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmFindUser Find = new fmFindUser();

            Find.ShowDialog();

            _RefershUsersList();

            if (dgvUsers.Rows.Count == 0)
                btnBack_Click(null, null);
        }

        private void fmUsersList_FormClosed(object sender, FormClosedEventArgs e)
            => _MainMenue.Show();
    }
}
