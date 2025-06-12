using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBalanceOperations
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;

        public enum enOperationType : byte { Desposit = 0, Withdraw = 1 };

        public int? ID { get; set; }
        public int? ClientID { get; set; }
        public decimal? OldAmount { get; set; }
        public decimal? NewAmount { get; set; }
        public enOperationType? OpertaionType { get; set; }
        public DateTime? Time { get; set; }
        public int? ByUserID { get; set; }

        public clsBalanceOperations()
        {
            _Mode = enMode.AddNew;
            ID = null;
            ClientID = null;
            OldAmount = null;
            NewAmount = null;
            OpertaionType = null;
            Time = null;
            ByUserID = null;
        }

        private clsBalanceOperations(int ID, int ClientID, decimal OldAmount, decimal NewAmount, enOperationType OpertaionType, DateTime Time, int ByUserID)
        {
            _Mode = enMode.Update;
            this.ID = ID;
            this.ClientID = ClientID;
            this.OldAmount = OldAmount;
            this.NewAmount = NewAmount;
            this.OpertaionType = OpertaionType;
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
                            _Mode = enMode.Update;
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
            this.ID = clsBalanceOperationsData.AddNew(this.ClientID, this.OldAmount, this.NewAmount, (byte?)this.OpertaionType, this.Time, this.ByUserID);
            return ID != null;
        }

        public static int? GetTotalPages(int PageSize)
           => clsBalanceOperationsData.GetTotalPages(PageSize);

        public static DataTable GetAllPerPages(int CurrentPage, int PageSize)
            => clsBalanceOperationsData.GetAllPerPages(CurrentPage, PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string Parameter, T Value)
            => clsBalanceOperationsData.GetTotalPagesBy(PageSize, Parameter, Value);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Parameter, T Value)
            => clsBalanceOperationsData.GetPerPagesBy(PageNumber, PageSize, Parameter, Value);

        public static int? GetTotalPagesBy<T1 , T2>(int PageSize, string ParameterName1, T1 Value1, string ParameterName2, T2 Value2)
            => clsBalanceOperationsData.GetTotalPagesBy<T1 , T2>(PageSize, ParameterName1, Value1, ParameterName2 , Value2);

        public static DataTable GetPerPagesBy<T1 , T2>(int PageNumber, int PageSize, string ParameterName1, T1 Value1, string ParameterName2, T2 Value2)
            => clsBalanceOperationsData.GetPerPagesBy<T1 , T2>(PageNumber, PageSize, ParameterName1, Value1, ParameterName2 , Value2);
    }
}
