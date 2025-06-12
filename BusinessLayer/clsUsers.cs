using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUsers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;
        public enum enPermissions : byte { Admin = 0 , Worker = 1 };

        public int? UsrID { get; set; }
        public int? PrsnID { get; set; }
        public string UsrnNm { get; set; }
        public string Psswrd { get; set; }
        public enPermissions Prmssns { get; set; }
        public bool IsActive { get; set; }

        public clsPeople PersonInfo { get; private set; }

        public string Permissions
        {
            get
            {
                return Prmssns.ToString();
            }
        }

        public clsUsers()
        {
            _Mode = enMode.AddNew;
            UsrID = 0;
            PrsnID = 0;
            UsrnNm = "";
            Psswrd = "";
            Prmssns = enPermissions.Admin;
            IsActive = false;
        }

        private clsUsers(int? UsrID, int? PrsnID, string UsrnNm, string Psswrd, enPermissions Prmssns, bool IsActive)
        {
            _Mode = enMode.Update;
            this.UsrID = UsrID;
            this.PrsnID = PrsnID;
            this.UsrnNm = UsrnNm;
            this.Psswrd = Psswrd;
            this.Prmssns = Prmssns;
            this.IsActive = IsActive;
            PersonInfo = clsPeople.Find(PrsnID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            _Mode = enMode.AddNew;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        private bool _AddNew()
        {
            this.UsrID = clsUsersData.AddNew(this.PrsnID, this.UsrnNm, this.Psswrd, (byte)this.Prmssns, this.IsActive);
            return UsrID != -1;
        }

        private bool _Update()
            => clsUsersData.Update(this.UsrID, this.PrsnID, this.UsrnNm, this.Psswrd, (byte)this.Prmssns, this.IsActive);

        public static bool Delete(int UsrID) 
            => clsUsersData.Delete(UsrID);

        public static DataTable GetAllUsers()
            => clsUsersData.GetAllUsers();

        public static clsUsers Find(int? UsrID)
        {
            int? PrsnID = null;
            string UsrnNm = "";
            string Psswrd = "";
            byte? Prmssns = null;
            bool IsActive = false;

            if (clsUsersData.GetByID(UsrID, ref PrsnID, ref UsrnNm, ref Psswrd, ref Prmssns, ref IsActive))
                return new clsUsers(UsrID, PrsnID, UsrnNm, Psswrd, (enPermissions)Prmssns, IsActive);

            return null;
        }

        public static clsUsers Find(string Username)
        {
            int? UsrID = null;
            int? PrsnID = null;
            string Psswrd = "";
            byte? Prmssns = null;
            bool IsActive = false;

            if (clsUsersData.GetByUsername(Username , ref UsrID, ref PrsnID, ref Psswrd, ref Prmssns, ref IsActive))
                return new clsUsers(UsrID, PrsnID, Username, Psswrd, (enPermissions)Prmssns, IsActive);

            return null;
        }

        public static bool IsUserExistByUsername(string Username)
            => clsUsersData.IsUserExistByUsername(Username);

        public static bool IsPersonUser(int? PersonID)
            => clsUsersData.IsUserExistByPersonID(PersonID);

        public static bool IsUserExistByUsernameAndPassword(string Username , string Password)
            => clsUsersData.IsUserExistByUsernameAndPassword(Username , Password);

        public static int? GetTotalPages(int PageSize)
            => clsUsersData.GetTotalPages(PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string Parameter , T Value)
            => clsUsersData.GetTotalPagesBy<T>(PageSize, Parameter, Value);

        public static DataTable GetUserPerPages(int PageNumber , int PageSize)
            => clsUsersData.GetUserPerPages(PageNumber , PageSize);

        public static DataTable GetUserPerPagesBy<T>(int PageNumber, int PageSize, string Parameter, T Value)
            => clsUsersData.GetUserPerPagesBy<T>(PageNumber, PageSize, Parameter, Value);

        public static int GetIDByPersonID(int? PersonID)
            => clsUsersData.GetIDByPersonID(PersonID);

    }
}
