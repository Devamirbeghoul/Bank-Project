using BusinessLayer;
using DesktopLayer.Clients;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Password_PinCode;
using DesktopLayer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.Login.Register
{
    public partial class fmLoginRegister : Form
    {
        public fmLoginRegister()
        {
            InitializeComponent();
        }

        private static int _PageSize = clsDefaultValues.SetPageSize();
        private int _CurrentPage = 1;
        private int _TotalPages;
        private string Filter = null;
        private string Value = null;
        private string Permission;

        List<string> Headers = new List<string>()
            {
                "UserID" , "Username", "Full Name" , "Time"
            };

        List<int> Widths = new List<int>()
            {
                110 , 110 , 300 , 170
            };

        private void _PerfromAdminRefresh()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsLoginRegistryUsers.GetTotalPages(_PageSize) ?? 0;
                dgvRegistry.DataSource = clsLoginRegistryUsers.GetAllPerPages(_CurrentPage, _PageSize);
            }

            else
            {
                _TotalPages = clsLoginRegistryUsers.GetTotalPagesBy(_PageSize, Filter, Value) ?? 0;
                dgvRegistry.DataSource = clsLoginRegistryUsers.GetPerPagesBy<string>(_CurrentPage, _PageSize, Filter, Value);
            }
        }

        private void _PerfromWorkerRefersh()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsLoginRegistryClients.GetTotalPages(_PageSize) ?? 0;
                dgvRegistry.DataSource = clsLoginRegistryClients.GetAllPerPages(_CurrentPage, _PageSize);
            }

            else
            {
                _TotalPages = clsLoginRegistryClients.GetTotalPagesBy(_PageSize, Filter, Value) ?? 0;
                dgvRegistry.DataSource = clsLoginRegistryClients.GetPerPagesBy<string>(_CurrentPage, _PageSize, Filter, Value);
            }
        }

        private void _RefershList()
        {
            if (Permission == "Admin")
                _PerfromAdminRefresh();
            else
                _PerfromWorkerRefersh();

            dgvRegistry.Font = clsDefaultValues.GetDefaultFont();

            lbRcords.Text = dgvRegistry.RowCount.ToString();

            lbPages.Text = clsDefaultValues.SetPageStringFormat(_CurrentPage, _TotalPages);

            clsSystem.SetHeadersAndWidthsOfDataGridView(dgvRegistry, Headers, Widths);
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void fmChangePasswordList_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

            Permission = clsGlobal.Permissions;
            dtpTime.MaxDate = DateTime.Now;

            if (Permission == "Admin")
            {
                Headers[0] = "UserID";
                Headers[1] = "Username";
                cbFilterBy.Items[1] = "UserID";
                cbFilterBy.Items[3] = "Username";
            }
                
            else
            {
                Headers[0] = "ClientID";
                Headers[1] = "Acc.Number";
                cbFilterBy.Items[1] = "ClientID";
                cbFilterBy.Items[3] = "AccountNumber";
            }
                
            
            cbFilterBy.SelectedIndex = 0;
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvRegistry.CurrentRow.Cells[0].Value;

            if (Permission == "Admin")
            {

                fmUserDetails Info = new fmUserDetails(ID);

                Info.ShowDialog();
            }

            else
            {
                fmClientDetails Info = new fmClientDetails(ID);

                Info.ShowDialog();
            }



            _RefershList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Visible = (cbFilterBy.Text != "None") && (cbFilterBy.Text != "Time");

            if (tbFilterValue.Visible)
            {
                tbFilterValue.Clear();
                tbFilterValue.Focus();
                _CurrentPage = 1;
                dtpTime.Visible = false;
                return;
            }

            dtpTime.Visible = (cbFilterBy.Text != "None");

            if (dtpTime.Visible)
            {
                dtpTime.Value = dtpTime.MaxDate;
                _CurrentPage = 1;
                return;
            }

            _RefershList();

        }

        private void tbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text.Contains("ID"))
                e.Handled = clsValidate.AllowNumbersOnly(e.KeyChar);
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = cbFilterBy.Text.Trim();

            Filter = (FilterValue == "Full Name") ? "FullName" : FilterValue;

            FilterValue = tbFilterValue.Text.Trim();

            Value = (FilterValue == "") ? null : FilterValue;

            _RefershList();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clsSystem.PerformBtnNext(ref _CurrentPage, _TotalPages, _RefershList);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            clsSystem.PerformBtnBack(ref _CurrentPage, _RefershList);
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            Filter = "Time";
            Value = dtpTime.Value.ToString("dd/MM/yyyy");
            _RefershList();
        }
    }
}
