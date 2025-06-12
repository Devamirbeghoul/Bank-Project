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

namespace DesktopLayer.People
{
    public partial class fmPersonInfo : Form
    {
        public fmPersonInfo(int PersonID)
        {
            InitializeComponent();
            ctrPersonInfo1.LoadPersonDataByUserID(PersonID);
        }

        public fmPersonInfo(string CardID)
        {
            InitializeComponent();
            ctrPersonInfo1.LoadPersonDataByCardID(CardID);
        }

        private void fmPersonInfo_Load(object sender, EventArgs e)
            => clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);
            

        private void btnClose_Click(object sender, EventArgs e) 
            => this.Close();
    }
}
