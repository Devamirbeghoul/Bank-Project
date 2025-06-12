using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Main;
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

namespace DesktopLayer.Clients
{
    public partial class fmClientsList : Form
    {
        private fmMainWorker _MainMenue;
        private static int _PageSize = clsDefaultValues.SetPageSize();
        private int _CurrentPage = 1;
        private int _TotalPages;
        private string Filter = null;
        private string Value = null;

        List<string> Headers = new List<string>()
            {
                "ID" , "Person ID" , "Full Name" , "Acc.Number" , "Balance"
            };

        List<int> Widths = new List<int>()
            {
                110 , 110 , 300 , 110 ,200
            };

        public fmClientsList(fmMainWorker MainMenue)
        {
            InitializeComponent();
            _MainMenue = MainMenue;
        }

        private void _RefershClientsList()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsClients.GetTotalPages(_PageSize) ?? 0;
                dgvClients.DataSource = clsClients.GetClientsPerPages(_CurrentPage, _PageSize);
            }

            else
            {
                _TotalPages = clsClients.GetTotalPagesBy(_PageSize, Filter, Value) ?? 0;
                dgvClients.DataSource = clsClients.GetClientsPerPagesBy<string>(_CurrentPage, _PageSize, Filter, (string)Value);
            }

            lbPages.Text = clsDefaultValues.SetPageStringFormat(_CurrentPage, _TotalPages);

            dgvClients.Font = clsDefaultValues.GetDefaultFont();

            lbRcords.Text = dgvClients.RowCount.ToString();

            clsSystem.SetHeadersAndWidthsOfDataGridView(dgvClients, Headers, Widths);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fmAddEditClient Add = new fmAddEditClient();

            Add.ShowDialog();

            _RefershClientsList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddEditClient Add = new fmAddEditClient();

            Add.ShowDialog();

            _RefershClientsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void fmClientsList_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

            cbFilterBy.SelectedIndex = 0;

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;

            fmAddEditClient Edit = new fmAddEditClient(ClientID);

            Edit.ShowDialog();

            _RefershClientsList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;

            if (clsMessages.ConfirmDelete("Client", ClientID))
            {
                if (clsClients.Delete(ClientID))
                {
                    clsMessages.GeneralSuccessMessage("Deleted Successfuly!");

                    _RefershClientsList();

                    if (dgvClients.Rows.Count == 0)
                        btnBack_Click(null, null);
                }
                else
                    clsMessages.GeneralErrorMessage("Can't Delete this User!");
            }
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;

            fmClientDetails Info = new fmClientDetails(ClientID);

            Info.ShowDialog();

            _RefershClientsList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            tbFilterValue.Visible = (cbFilterBy.Text != "None");

            if (tbFilterValue.Visible)
            {
                tbFilterValue.Clear();
                tbFilterValue.Focus();
                _CurrentPage = 1;
                return;
            }

            _RefershClientsList();
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            switch (cbFilterBy.Text)
            {
                case "Full Name":
                    {
                        Filter = "FullName";
                        break;
                    }
                case "Account Number":
                    {
                        Filter = "AccountNumber";
                        break;
                    }

                default:
                    {
                        Filter = string.Empty;
                        break;
                    }
            }

            Value = cbFilterBy.Text.Trim() ?? null;

            _RefershClientsList();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clsSystem.PerformBtnNext(ref _CurrentPage, _TotalPages, _RefershClientsList);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            clsSystem.PerformBtnBack(ref _CurrentPage, _RefershClientsList);
        }

        private void findUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmFindClient Find = new fmFindClient();

            Find.ShowDialog();

            _RefershClientsList();

            if (dgvClients.Rows.Count == 0)
                btnBack_Click(null, null);
        }

        private void fmClientsList_FormClosed(object sender, FormClosedEventArgs e)
            => _MainMenue.Show();
    }
}
