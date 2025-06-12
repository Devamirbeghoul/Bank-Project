using BusinessLayer;
using DesktopLayer.GlobalClasses;
using DesktopLayer.Properties;
using Microsoft.VisualBasic.ApplicationServices;
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
using System.Xml.Linq;
using static BusinessLayer.clsPeople;

namespace DesktopLayer.Users.Controls
{
    public partial class ctrUserInfo : UserControl
    {
        clsUsers _User;

        public int? UserID
        {
            get
            {
                return (_User == null) ? null : _User.UsrID;
            }
        }

        public ctrUserInfo()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            ctrPersonInfo1.LoadPersonDataByUserID(_User.PrsnID , false);

            lbUserID.Text = UserID.ToString();
            lbUsername.Text = _User.UsrnNm;
            lbIsActive.Text = (_User.IsActive) ? "Yes" : "No";
            lbPermissions.Text = _User.Permissions;
        }

        public bool LoadUserDataByID(int? UserID)
        {
            _User = clsUsers.Find(UserID);

            if (_User == null)
            {
                clsMessages.NullObject("User", $"with Id = {UserID}");
                _Default();
                return false;
            }

            _LoadData();
            return true;
        }

        private void _Default()
        {
            ctrPersonInfo1.LoadPersonDataByUserID(null , false);

            lbUserID.Text = "[???]";
            lbUsername.Text = "[???]";
            lbIsActive.Text = "[???]";
            lbPermissions.Text = "[???]";
        }

        public bool LoadUserNyUsername(string Username)
        {
            _User = clsUsers.Find(Username);

            if (_User == null)
            {
                clsMessages.NullObject("User", $"with Username = {Username}");
                _Default();
                return false;
            }

            _LoadData();
            return true;
        }
    }
}
