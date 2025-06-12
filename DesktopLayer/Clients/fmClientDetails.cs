using DesktopLayer.GlobalClasses;
using DesktopLayer.Users.Controls;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class fmClientDetails : Form
    {
        public fmClientDetails(int? ClientID)
        {
            InitializeComponent();
            ctrClientInfo1.LoadClientDataByID(ClientID);
        }

        private void btnClose_Click(object sender, EventArgs e)
            => this.Close();

        private void fmUserDetails_Load(object sender, EventArgs e)
             => clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);
    }
}
