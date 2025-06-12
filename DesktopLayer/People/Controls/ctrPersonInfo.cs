using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Properties;
using Guna.UI2.HtmlRenderer.Adapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.People.Controls
{
    public partial class ctrPersonInfo : UserControl
    {
        clsPeople _Person;

        public int? PersonID
        {
            get
            {
                return (_Person == null) ? null : _Person.PrsnID;
            }
        }

        public ctrPersonInfo()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            llbEditPersonInfo.Enabled = true;

            lbPersonID.Text = _Person.PrsnID.ToString();

            lbName.Text = _Person.FullName;

            lbCardID.Text = _Person.CrdID;

            lbGender.Text = _Person.Gender;

            lbPhone.Text = _Person.Phn;
            lbEmail.Text = _Person.Eml;
            lbAddress.Text = _Person.Addrs;

            lbDateOfBirth.Text = clsFormat.DefaultDate(_Person.DBrth);
            lbCountry.Text = _Person.WilayaInfo.Nm;

            if (_Person.ImgPth != null)
                pbImage.ImageLocation = _Person.ImgPth;
            else
                pbImage.Image =
                    (_Person.Gndr == clsPeople.enGender.Male) ? Resources.man : Resources.woman;
        }

        private void _Default()
        {
            llbEditPersonInfo.Enabled = false;

            lbPersonID.Text = "[???]";

            lbName.Text = "[???]";

            lbCardID.Text = "[???]";

            lbGender.Text = "[???]";

            lbPhone.Text = "[???]";
            lbEmail.Text = "[???]";
            lbAddress.Text = "[???]";

            lbDateOfBirth.Text = "[???]";
            lbCountry.Text = "[???]";

            pbImage.Image = Resources.man;
        }

        public bool LoadPersonDataByUserID(int? PersonID , bool Display = true)
        {
            _Person = clsPeople.Find(PersonID);

            if (_Person == null)
            {
                if (Display)
                    clsMessages.NullObject("Person", $"with Id = {PersonID}");
                _Default();
                return false;
            }

            _LoadData();
            return true;
        }

        public bool LoadPersonDataByCardID(string CardID)
        {
            _Person = clsPeople.Find(CardID);

            if (_Person == null)
            {
                clsMessages.NullObject("Person", $"with Card ID = {CardID}");
                _Default();
                return false;
            }

            _LoadData();
            return true;
        }

        private void llbEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = (int)_Person.PrsnID;

            fmAddEditPerson Edit = new fmAddEditPerson(PersonID);

            Edit.ShowDialog();

            LoadPersonDataByUserID(PersonID);
        }
    }
}
