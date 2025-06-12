using BusinessLayer;
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
    public partial class fmFindPerson : Form
    {
        public fmFindPerson()
        {
            InitializeComponent();
        }

        private void PersonSelected(int? PersonID)
        {
            btnDelete.Enabled = PersonID != null;
            btnEdit.Enabled = PersonID != null;
        }

        private void fmFindPerson_Activated(object sender, EventArgs e)
        {
            ctrPersonInfoWithFilter1.FocusFilter();
        }

        private void fmFindUser_Load(object sender, EventArgs e)
        {
            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

        }

        private void btnClose_Click_1(object sender, EventArgs e)
            => this.Close();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int PersonID = (int)ctrPersonInfoWithFilter1.PersonID;

            if (clsMessages.ConfirmDelete("Person", PersonID))
            {
                if (clsPeople.Delete(PersonID))
                {
                    clsMessages.GeneralSuccessMessage("Deleted Successfuly!");

                    this.Close();

                }
                else
                    clsMessages.GeneralErrorMessage("This Person have another data , remove it first!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int PersonID = (int)ctrPersonInfoWithFilter1.PersonID;

            fmAddEditPerson Edit = new fmAddEditPerson(PersonID);

            Edit.ShowDialog();

            ctrPersonInfoWithFilter1.LoadPersonData(PersonID , true);
        }
    }
}
