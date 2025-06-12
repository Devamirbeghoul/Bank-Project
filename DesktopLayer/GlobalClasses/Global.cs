using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesktopLayer.GlobalClasses
{
    public class clsGlobal
    {
        public enum enType {User = 0 , Client = 1};

        public static enType LoginType { get; set; } = enType.User;

        private static clsUsers _User;

        private static clsClients _Client;

        public static clsPeople PersonInfo;

        public static int? ID
        {
            get
            {
                return( LoginType == enType.User) ? _User.UsrID : _Client.ClientID;
            }
        }

        public static string GetIdentifier
        {
            get
            {
                return (LoginType == enType.User) ? _User.UsrnNm : _Client.AccountNumber;
            }
        }

        public static string Permissions
        {
            get
            {
                return _User.Permissions;
            }
        }

        public static void SetCurrentPersonLogin(enType Type , string Item)
        {
            if (Type == enType.User)
            {
                _User = clsUsers.Find(Item);
                PersonInfo = _User.PersonInfo;
            }

            else
            {
                _Client = clsClients.FindByAccountNumber(Item);
                PersonInfo = _Client.PersonInfo;
            }

                LoginType = Type;
        }

        public static bool IsActive
        {
            get
            {
                return _User.IsActive;
            }
        }


    }
}
