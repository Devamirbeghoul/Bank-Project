using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class clsRquestsPasswordClients
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;
        public enum enMethod : byte { Email = 0, Phone = 1 };
        public enum enStatus : byte { Pending = 0 , Confirmed = 1 , Canceled =2 }; 

        public int? ChangePasswordID { get; set; }
        public int? ClientID { get; set; }
        public enMethod Method { get; set; }
        public enStatus Status { get; set; }
        public DateTime Time {  get; set; }

        public int? ByUserID { get; set; }

        public clsRquestsPasswordClients()
        {
            _Mode = enMode.AddNew;
            ChangePasswordID = null;
            ClientID = null;
            Method = enMethod.Email;
            Status = enStatus.Pending;
            Time = DateTime.Now;
            ByUserID = null;
        }

        private clsRquestsPasswordClients(int? ChangePasswordID, int? PersonID, enMethod Method, enStatus Status , DateTime Time , int? ByUserID)
        {
            _Mode = enMode.Update;
            this.ChangePasswordID = ChangePasswordID;
            this.ClientID = PersonID;
            this.Method = Method;
            this.Status = Status;
            this.Time = Time;
            this.ByUserID = ByUserID;
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
                    return false;
            }
            return false;
        }

        private bool _AddNew()
        {
            this.ChangePasswordID = clsRequestsPasswordClients.AddNew(this.ClientID, (byte)this.Method, (byte)this.Status , this.Time);
            return ChangePasswordID != -1;
        }

        public static bool Delete(int ChangePasswordID)
            => clsRequestsPasswordClients.Delete(ChangePasswordID);

        public static clsRquestsPasswordClients Find(int? ID)
        {
            int? ClientID = null;
            int? ByUserID = null;
            byte Method = 0;
            byte Status = 0;
            DateTime Time = DateTime.Now;

            if (clsRequestsPasswordClients.GetByID(ID, ref ClientID, ref Method, ref Status, ref Time , ref ByUserID))
                return new clsRquestsPasswordClients(ID, ClientID, (enMethod)Method, (enStatus)Status , Time , ByUserID);

            return null;
        }

        public static bool ExistWith(int? ClientID , enStatus Status)
            => clsRequestsPasswordClients.ExistWith(ClientID, (byte)Status);

        public static int? GetTotalPages(int PageSize)
            => clsRequestsPasswordClients.GetTotalPages(PageSize);

        public static DataTable GetAllPerPages(int CurrentPage, int PageSize)
            => clsRequestsPasswordClients.GetAllPerPages(CurrentPage, PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string Parameter, T Value)
            => clsRequestsPasswordClients.GetTotalPagesBy(PageSize, Parameter, Value);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Parameter, T Value)
            => clsRequestsPasswordClients.GetPerPagesBy(PageNumber, PageSize, Parameter, Value);

        public static bool SetStatus(int ID , enStatus Status , int? UserID)
            => clsRequestsPasswordClients.SetStatus(ID, (byte)Status , UserID);
    }
}
