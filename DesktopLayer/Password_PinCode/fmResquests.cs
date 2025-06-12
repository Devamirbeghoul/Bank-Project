using BusinessLayer;
using DesktopLayer.Clients;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Main;
using DesktopLayer.People;
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

namespace DesktopLayer.Password_PinCode
{
    public partial class fmResquests : Form
    {
        public fmResquests()
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
                "ID" , "UserID", "Full Name" , "Time" , "Send By" , "Status"
            };

        List<int> Widths = new List<int>()
            {
                110 , 110 , 300 , 170 , 100 , 110
            };
        
        private void _PerfromAdminRefresh()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsRquestsPasswordUsers.GetTotalPages(_PageSize) ?? 0;
                dgvRequests.DataSource = clsRquestsPasswordUsers.GetAllPerPages(_CurrentPage, _PageSize);
            }

            else
            {
                _TotalPages = clsRquestsPasswordUsers.GetTotalPagesBy(_PageSize, Filter, Value) ?? 0;
               dgvRequests.DataSource = clsRquestsPasswordUsers.GetPerPagesBy<string>(_CurrentPage, _PageSize, Filter, Value);
            }
        }

        private void _PerfromWorkerRefersh()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsRquestsPasswordClients.GetTotalPages(_PageSize) ?? 0;
                dgvRequests.DataSource = clsRquestsPasswordClients.GetAllPerPages(_CurrentPage, _PageSize);
            }

            else
            {
                _TotalPages = clsRquestsPasswordClients.GetTotalPagesBy(_PageSize, Filter, Value) ?? 0;
                dgvRequests.DataSource = clsRquestsPasswordClients.GetPerPagesBy<string>(_CurrentPage, _PageSize, Filter, Value);
            }
        }

        private void _RefershChangePasswordList()
        {
            if (Permission == "Admin")
                _PerfromAdminRefresh();
            else
                _PerfromWorkerRefersh();

            dgvRequests.Font = clsDefaultValues.GetDefaultFont();

            lbRcords.Text = dgvRequests.RowCount.ToString();

            lbPages.Text = clsDefaultValues.SetPageStringFormat(_CurrentPage, _TotalPages);

            clsSystem.SetHeadersAndWidthsOfDataGridView(dgvRequests, Headers, Widths);
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void fmChangePasswordList_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

            Permission = clsGlobal.Permissions;

            if (Permission == "Admin")
                Headers[1] = "UserID";
            else
                Headers[1] = "ClientID";

            cbFilterBy.SelectedIndex = 0;
        }

        private void DataBack()
        {
            int ID = (int)dgvRequests.CurrentRow.Cells[0].Value;

            if (Permission == "Admin")
                clsRquestsPasswordUsers.SetStatus(ID, clsRquestsPasswordUsers.enStatus.Confirmed, clsGlobal.ID);
            else
                clsRquestsPasswordClients.SetStatus(ID, clsRquestsPasswordClients.enStatus.Confirmed, clsGlobal.ID);

        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvRequests.CurrentRow.Cells[1].Value;

            if (Permission == "Admin")
            {
                fmChangePasswordUsers ChangePassword = new fmChangePasswordUsers(ID);

                ChangePassword.DataBack += DataBack;

                ChangePassword.ShowDialog();
            }
              
            else
            {
                fmChangePinCode ChangePassword = new fmChangePinCode(ID , false);

                ChangePassword.DataBack += DataBack;

                ChangePassword.ShowDialog();
            }


            _RefershChangePasswordList();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvRequests.CurrentRow.Cells[1].Value;

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

                

            _RefershChangePasswordList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Visible = (cbFilterBy.Text != "None") && (cbFilterBy.Text != "Status");

            if (tbFilterValue.Visible)
            {
                tbFilterValue.Clear();
                tbFilterValue.Focus();
                _CurrentPage = 1;
                cbStatusValue.Visible = false;
                return;
            }

            cbStatusValue.Visible = (cbFilterBy.Text != "None");

            if (cbStatusValue.Visible)
            {
                cbStatusValue.SelectedIndex = 0;
                _CurrentPage = 1;
                return;
            }

            _RefershChangePasswordList();

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

        private void cbStatusValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            string V = cbStatusValue.Text.Trim();

            Filter = cbFilterBy.Text;
            Value = (V == "All") ? null : V;

            _RefershChangePasswordList();
        }

        private void cmsMainMenue_Opening(object sender, CancelEventArgs e)
        {
            int ID = (int)dgvRequests.CurrentRow.Cells[0].Value;

            if (Permission == "Admin")
            {
                clsRquestsPasswordUsers Change = clsRquestsPasswordUsers.Find(ID);

                if (Change != null)
                {
                    editToolStripMenuItem.Enabled = Change.Status == clsRquestsPasswordUsers.enStatus.Pending;
                    toolStripMenuItem1.Enabled = Change.Status == clsRquestsPasswordUsers.enStatus.Pending;
                    byToolStripMenuItem.Enabled = Change.Status != clsRquestsPasswordUsers.enStatus.Pending;
                }
            }
            else
            {
                clsRquestsPasswordClients Change = clsRquestsPasswordClients.Find(ID);

                if (Change != null)
                {
                    editToolStripMenuItem.Enabled = Change.Status == clsRquestsPasswordClients.enStatus.Pending;
                    toolStripMenuItem1.Enabled = Change.Status == clsRquestsPasswordClients.enStatus.Pending;
                    byToolStripMenuItem.Enabled = Change.Status != clsRquestsPasswordClients.enStatus.Pending;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (clsMessages.Confirm("Cancel"))
            {
                int ID = (int)dgvRequests.CurrentRow.Cells[0].Value;

                if (Permission == "Admin")
                    clsRquestsPasswordUsers.SetStatus(ID, clsRquestsPasswordUsers.enStatus.Canceled, clsGlobal.ID);
                else
                    clsRquestsPasswordClients.SetStatus(ID, clsRquestsPasswordClients.enStatus.Canceled, clsGlobal.ID);

                clsMessages.GeneralSuccessMessage("Cancel is done!");

                _RefershChangePasswordList();
            }
            
        }

        private void byToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? UserID;
            int? ID  = (int)dgvRequests.CurrentRow.Cells[0].Value;

            if (Permission == "Admin")
                UserID = (int)clsRquestsPasswordUsers.Find(ID).ByUserID;
            else
                UserID = (int)clsRquestsPasswordClients.Find(ID).ByUserID;


            fmUserDetails User = new fmUserDetails(UserID);

            User.ShowDialog();
        }
    }
}
