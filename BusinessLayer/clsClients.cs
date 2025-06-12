using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsClients
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;

        public int? ClientID { get; set; }
        public int? PersonID { get; set; }
        public string AccountNumber { get; set; }
        public string PinCode { get; set; }
        public decimal Balance { get; set; }

        public clsPeople PersonInfo { get; private set; }

        public clsClients()
        {
            _Mode = enMode.AddNew;
            ClientID = null;
            PersonID = null;
            AccountNumber = "";
            PinCode = "";
            Balance = 0;
        }

        private clsClients(int? ClientID, int? PersonID, string AccountNumber, string PinCode, decimal Balance)
        {
            _Mode = enMode.Update;
            this.ClientID = ClientID;
            this.PersonID = PersonID;
            this.AccountNumber = AccountNumber;
            this.PinCode = PinCode;
            this.Balance = Balance;

            PersonInfo = clsPeople.Find(PersonID);
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
            this.ClientID = clsClientsData.AddNew(this.PersonID, this.AccountNumber, this.PinCode, this.Balance);
            return ClientID != null;
        }

        private bool _Update()
            => clsClientsData.Update(this.ClientID, this.PersonID, this.AccountNumber, this.PinCode, this.Balance);

        public static bool Delete(int ClientID)
            => clsClientsData.Delete(ClientID);

        public static DataTable GetAllClients()
            => clsClientsData.GetAllClients();

        public static clsClients FindByID(int? ClientID)
        {
            int? PersonID = null;
            string AccountNumber = "";
            string PinCode = "";
            decimal Balance = 0;

            if (clsClientsData.GetByID(ClientID, ref PersonID, ref AccountNumber, ref PinCode, ref Balance))
                return new clsClients(ClientID, PersonID, AccountNumber, PinCode, Balance);

            return null;
        }

        public static clsClients FindByAccountNumber(string AccountNumber)
        {
            int? ClientID = null;
            int? PersonID = null;
            string PinCode = "";
            decimal Balance = 0;

            if (clsClientsData.GetByAccountNumber(AccountNumber , ref ClientID, ref PersonID, ref PinCode, ref Balance))
                return new clsClients(ClientID, PersonID, AccountNumber, PinCode, Balance);

            return null;
        }

        public static bool IsPersonClient(int? PersonID)
            => clsClientsData.IsClientExistByPersonID(PersonID);

        public static bool IsClientExistByAccountNumber(string AccountNumber)
            => clsClientsData.IsClientExistByAccountNumber(AccountNumber);

        public static bool IsClientExistByAccountNumberAndPinCode(string AccountNumber, string PinCode)
            => clsClientsData.IsClientExistByAccountNumberAndPinCode(AccountNumber, PinCode);

        public static int? GetTotalPages(int PageSize)
            => clsClientsData.GetTotalPages(PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string Parameter, T Value)
            => clsClientsData.GetTotalPagesBy<T>(PageSize, Parameter, Value);

        public static DataTable GetClientsPerPages(int CurrentPage ,  int PageSize)
            => clsClientsData.GetClientsPerPages(CurrentPage, PageSize);

        public static DataTable GetClientsPerPagesBy<T>(int PageNumber, int PageSize, string Parameter, T Value)
            => clsClientsData.GetClientsPerPagesBy<T>(PageNumber, PageSize, Parameter, Value);

        public static int GetIDByPersonID(int? PersonID)
            => clsClientsData.GetIDByPersonID(PersonID);

        public static decimal GetBalanceByID(int? ID)
            => clsClientsData.GetBalanceByID(ID);

    }
}
