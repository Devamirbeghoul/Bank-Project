using BusinessLayer;
using DesktopLayer.Clients;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.Login.Register
{
    public partial class fmPersonalLogin : Form
    {
        public fmPersonalLogin(int? ID)
        {
            InitializeComponent();
            this._ID = ID;
        }

        private int? _ID = null;
        private static int _PageSize = clsDefaultValues.SetPageSize();
        private int _CurrentPage = 1;
        private int _TotalPages;
        private string Filter = null;
        private string Value = null;
        private clsGlobal.enType _Type;

        List<string> Headers = new List<string>()
            {
                "UserID" , "Username", "Full Name" , "Time"
            };

        List<int> Widths = new List<int>()
            {
                110 , 110 , 300 , 170
            };

        private void _PerfromUserRefresh()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsLoginRegistryUsers.GetTotalPages(_PageSize , _ID) ?? 0;
                dgvRegistry.DataSource = clsLoginRegistryUsers.GetAllPerPages(_CurrentPage, _PageSize , _ID);
            }

            else
            {
                _TotalPages = clsLoginRegistryUsers.GetTotalPagesBy(_PageSize, Filter, Value , _ID) ?? 0;
                dgvRegistry.DataSource = clsLoginRegistryUsers.GetPerPagesBy<string>(_CurrentPage, _PageSize, Filter, Value , _ID);
            }
        }

        private void _PerfromClientRefersh()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsLoginRegistryClients.GetTotalPages(_PageSize , _ID) ?? 0;
                dgvRegistry.DataSource = clsLoginRegistryClients.GetAllPerPages(_CurrentPage, _PageSize , _ID);
            }

            else
            {
                _TotalPages = clsLoginRegistryClients.GetTotalPagesBy(_PageSize, Filter, Value , _ID) ?? 0;
                dgvRegistry.DataSource = clsLoginRegistryClients.GetPerPagesBy<string>(_CurrentPage, _PageSize, Filter, Value , _ID);
            }
        }

        private void _RefershChangePasswordList()
        {
            if (_Type == clsGlobal.enType.User)
                _PerfromUserRefresh();
            else
                _PerfromClientRefersh();

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

            _Type = clsGlobal.LoginType;
            dtpTime.MaxDate = DateTime.Now;

            if (_Type == clsGlobal.enType.User)
            {
                Headers[0] = "UserID";
                Headers[1] = "Username";
            }

            else
            {
                Headers[0] = "ClientID";
                Headers[1] = "Acc.Number";
            }


            cbFilterBy.SelectedIndex = 0;
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvRegistry.CurrentRow.Cells[0].Value;

            if (_Type == clsGlobal.enType.User)
            {

                fmUserDetails Info = new fmUserDetails(ID);

                Info.ShowDialog();
            }

            else
            {
                fmClientDetails Info = new fmClientDetails(ID);

                Info.ShowDialog();
            }



            _RefershChangePasswordList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpTime.Visible = (cbFilterBy.Text != "None");
            _CurrentPage = 1;

            if (dtpTime.Visible)
            {
                dtpTime.Value = dtpTime.MaxDate;
                return;
            }

            _RefershChangePasswordList();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clsSystem.PerformBtnNext(ref _CurrentPage, _TotalPages, _RefershChangePasswordList);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            clsSystem.PerformBtnBack(ref _CurrentPage, _RefershChangePasswordList);
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            Filter = "Time";
            Value = dtpTime.Value.ToString("dd/MM/yyyy");
            _RefershChangePasswordList();
        }
    }
}
