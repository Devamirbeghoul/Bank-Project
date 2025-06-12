using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.People
{
    public partial class fmAddEditPerson : Form
    {
        enum enMode { AddNew = 1 , Edit = 2 };

        private enMode _Mode = enMode.AddNew;

        private int? _PersonID = null;

        private clsPeople _Person;

        public event Action<int> DataBack;

        public fmAddEditPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public fmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Edit;
            _PersonID = PersonID;
        }

        private void fmAddEditPerson_Activated(object sender, EventArgs e)
        {
            tbFirst.Focus();
        }

        private void OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e) 
            => e.Handled = clsValidate.AllowNumbersOnly(e.KeyChar);

        private void NoNullValueValidating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (string.IsNullOrEmpty(tb.Text))
            {
                e.Cancel = true;
                epValidate.SetError(tb, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tb, string.Empty);
            }
                
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email = tbEmail.Text.Trim();
            bool IsNotValid = clsPeople.IsPersonExistByEmail(Email);

            if (_Mode == enMode.Edit)
                IsNotValid = IsNotValid && (_Person.Eml != Email);

            if (!clsValidate.ValidateEmail(tbEmail.Text) || IsNotValid)
            {
                e.Cancel = true;
                epValidate.SetError(tbEmail, (IsNotValid) ? "This Email Already Taken!" : "Invalid Email!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbEmail, string.Empty);
            }
        }

        private void _FillWilayas()
        {
            clsSystem.FillComboBox(cbCountries , clsWilayas.GetAllWilayas() , "Mila");
        }

        private void _SetDefaults()
        {
            _FillWilayas();

            clsSystem.CustomWindow(Color.FromArgb(10, 157, 96), Color.Black, Color.FromArgb(10, 157, 96), Handle);

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            rbMale.Checked = true;
            pbImage.Image = Resources.man;

            llbRemove.Visible = false;

            foreach (TextBox tb in gbInfo.Controls.OfType<TextBox>())
                tb.Clear();
        }

        private void _PerfromAddScreen()
        {
            this.Text = "Add New Person";
            lbTitle.Text = "Add New Person";
            _Person = new clsPeople();
        }

        private void _PerfromEditScreen()
        {
            this.Text = "Edit Person";
            lbTitle.Text = "Edit Person";

            _Person = clsPeople.Find(_PersonID);

            if (_Person == null)
            {
                clsMessages.NullObject("Person", $"with Id = {_PersonID}");
                this.Close();
                return;
            }

            lbPersonID.Text = _PersonID.ToString();

            tbFirst.Text = _Person.FrstNm;
            tbSecond.Text = _Person.MddlNm;
            tbLast.Text = _Person.LstNm;
            tbCardID.Text = _Person.CrdID;

            if (_Person.Gndr == 0)
                rbMale.PerformClick();
            else
                rbFemale.PerformClick();

            tbPhone.Text = _Person.Phn;
            tbEmail.Text = _Person.Eml;
            tbAddress.Text = _Person.Addrs;

            if (_Person.ImgPth != null)
            {
                pbImage.ImageLocation = _Person.ImgPth;
                llbRemove.Visible = true;
            }

            cbCountries.Text = _Person.WilayaInfo.Nm;

        }

        private void btnClose_Click(object sender, EventArgs e) 
            => this.Close();

        private void llbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdSelectImg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdSelectImg.FilterIndex = 1;
            ofdSelectImg.RestoreDirectory = true;

            if (ofdSelectImg.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = ofdSelectImg.FileName;
                llbRemove.Visible = true;
            }
        }

        private void llbRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            pbImage.Image = (rbMale.Checked) ? Resources.man : Resources.woman;
            llbRemove.Visible = false;
        }

        private bool _HundleImgSaving()
        {
            if (_Person.ImgPth != null)
            {
                if (pbImage.ImageLocation != _Person.ImgPth)
                {
                    try
                    {
                        File.Delete(_Person.ImgPth);
                    }
                    catch (IOException)
                    {
                        return false;
                    }
                }
            }

            if (pbImage.ImageLocation != null)
            {
                string Source = pbImage.ImageLocation.ToString();

                if (clsSystem.CopyImgToFolder(ref Source))
                {
                    _Person.ImgPth = Source;
                    return true;
                }
                else
                    return false;
            }

            _Person.ImgPth = null;

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                clsMessages.NullOrEmptyFieldsMessage(true);
                return;
            }

            if (!_HundleImgSaving())
            {
                clsMessages.GeneralErrorMessage("Can't Save Image!");
                return;
            }

            _Person.FrstNm = tbFirst.Text.Trim();
            _Person.MddlNm = tbSecond.Text.Trim();
            _Person.LstNm = tbLast.Text.Trim();
            _Person.CrdID = tbCardID.Text.Trim();
            _Person.Gndr = (rbMale.Checked) ? clsPeople.enGender.Male : clsPeople.enGender.Female;
            _Person.Phn = tbPhone.Text.Trim();
            _Person.Eml = tbEmail.Text.Trim();
            _Person.Addrs = tbAddress.Text.Trim();
            _Person.WlID = clsWilayas.Find(cbCountries.Text).WlID;

            if (_Person.Save())
            {
                clsMessages.GeneralSuccessMessage("Data Saved Successfuly!!");
                _Mode = enMode.Edit;
                this.Text = "Edit Person";
                lbTitle.Text = "Edit Person";
                lbPersonID.Text = _Person.PrsnID.ToString();
                _PersonID = _Person.PrsnID;

                DataBack?.Invoke((int)_PersonID);
            }
            else
                clsMessages.GeneralErrorMessage("Error: Date Doesn't Save");

        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            string Phone = tbPhone.Text.Trim();
            bool IsNotValid = clsPeople.IsPersonExistByPhone(Phone);

            if (_Mode == enMode.Edit)
                IsNotValid = IsNotValid && (_Person.Phn != Phone);

            if (Phone.Length != 9 || IsNotValid)
            {
                e.Cancel = true;
                epValidate.SetError(tbPhone, (IsNotValid) ? "This Phone Number Already Taken!" : "Invalid Phone Number!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbPhone, string.Empty);
            }
        }

        private void fmAddEditPerson_Load(object sender, EventArgs e)
        {
            _SetDefaults();

            if (_Mode == enMode.AddNew)
                _PerfromAddScreen();
            else
                _PerfromEditScreen();
        }

        private void Gender_Click(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image =
                    (sender == rbMale) ? Resources.man : Resources.woman;
                
        }

        private void tbCardID_Validating(object sender, CancelEventArgs e)
        {
            string CardID = tbCardID.Text.Trim();

            bool IsValid;

            if (_Mode == enMode.AddNew)
                IsValid = clsPeople.IsPersonExistByCardID(CardID);
            else
                IsValid = _Person.CrdID != CardID;


            if (string.IsNullOrEmpty(CardID) || IsValid)
            {
                e.Cancel = true;
                epValidate.SetError(tbCardID,
                    (IsValid) ? "This Card ID is already used by a Person" : "This field is required!");
            }
            else
            {
                e.Cancel = false;
                epValidate.SetError(tbCardID, string.Empty);
            }
        }
    }
}
