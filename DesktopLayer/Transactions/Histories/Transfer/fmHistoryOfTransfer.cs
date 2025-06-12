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

namespace DesktopLayer.Transactions.Histories.Transfer
{
    public partial class fmHistoryOfTransfer : Form
    {
        public fmHistoryOfTransfer(string Input)
        {
            InitializeComponent();
            this._Input = Input;
            RefreshMethod += _RefreshPersonalList;
        }

        public fmHistoryOfTransfer()
        {
            InitializeComponent();
            cbFilterBy.Items.Add("Username");
            RefreshMethod += _RefershGenralList;
        }

        private string _Input;
        private static int _PageSize = clsDefaultValues.SetPageSize();
        private int _CurrentPage = 1;
        private int _TotalPages;
        private string Filter = null;
        private string Value = null;
        private clsGlobal.enType _Type;

        private Action RefreshMethod;

        List<string> Headers = new List<string>()
            {
                "From Acc" , "To Acc", "Amount" , "Time" , "By User"
            };

        List<int> Widths = new List<int>()
            {
                110 , 110 , 200, 170 , 110
            };

        private void _PerfromUserRefresh()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsTransfer.GetTotalPagesBy<string>(_PageSize, "Username", _Input) ?? 0;
                dgvRegistry.DataSource = clsTransfer.GetPerPagesBy<string>(_CurrentPage, _PageSize, "Username", _Input);
            }

            else
            {
                _TotalPages = clsTransfer.GetTotalPagesBy<string, string>(_PageSize, "Username", _Input, Filter, Value) ?? 0;
                dgvRegistry.DataSource = clsTransfer.GetPerPagesBy<string, string>(_CurrentPage, _PageSize, "Username", _Input, Filter, Value);
            }
        }

        private void _PerfromClientRefersh()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsTransfer.GetTotalPagesBy<string>(_PageSize, "AccountNumber", _Input) ?? 0;
                dgvRegistry.DataSource = clsTransfer.GetPerPagesBy<string>(_CurrentPage, _PageSize, "AccountNumber", _Input);
            }

            else
            {
                _TotalPages = clsTransfer.GetTotalPagesBy<string, string>(_PageSize, "AccountNumber", _Input, Filter, Value) ?? 0;
                dgvRegistry.DataSource = clsTransfer.GetPerPagesBy<string, string>(_CurrentPage, _PageSize, "AccountNumber", _Input, Filter, Value);
            }
        }

        private void _RefershList()
        {
            RefreshMethod();

            dgvRegistry.Font = clsDefaultValues.GetDefaultFont();

            lbRcords.Text = dgvRegistry.RowCount.ToString();

            lbPages.Text = clsDefaultValues.SetPageStringFormat(_CurrentPage, _TotalPages);

            clsSystem.SetHeadersAndWidthsOfDataGridView(dgvRegistry, Headers, Widths);
        }

        private void _RefershGenralList()
        {
            if (cbFilterBy.Text == "None" || Value == null)
            {
                _TotalPages = clsTransfer.GetTotalPages(_PageSize) ?? 0;
                dgvRegistry.DataSource = clsTransfer.GetAllPerPages(_CurrentPage, _PageSize);
            }

            else
            {
                _TotalPages = clsTransfer.GetTotalPagesBy<string>(_PageSize, Filter, Value) ?? 0;
                dgvRegistry.DataSource = clsTransfer.GetPerPagesBy<string>(_CurrentPage, _PageSize, Filter, Value);
            }
        }

        private void _RefreshPersonalList()
        {
            if (_Type == clsGlobal.enType.User)
                _PerfromUserRefresh();
            else
                _PerfromClientRefersh();
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void fmPersonal_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

            _Type = clsGlobal.LoginType;
            dtpTime.MaxDate = DateTime.Now;

            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentPage = 1;
            tbFilterValue.Visible = (cbFilterBy.Text != "None") && (cbFilterBy.Text != "Time");

            if (tbFilterValue.Visible)
            {
                tbFilterValue.Clear();
                tbFilterValue.Focus();
                dtpTime.Visible = false;
                return;
            }

            dtpTime.Visible = (cbFilterBy.Text != "None");


            if (dtpTime.Visible)
            {
                dtpTime.Value = dtpTime.MaxDate;
                return;
            }

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

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            Filter = cbFilterBy.Text;

            string FilterValue = tbFilterValue.Text.Trim();

            Value = (FilterValue == "") ? null : FilterValue;

            _RefershList();
        }
    }
}
