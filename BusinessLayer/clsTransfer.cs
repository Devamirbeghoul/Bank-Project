using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTransfer
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;

        public int? ID { get; set; }
        public int? FromID { get; set; }
        public int? ToID { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Time { get; set; }
        public int? ByUserID { get; set; }

        public clsTransfer()
        {
            _Mode = enMode.AddNew;
            ID = null;
            FromID = null;
            ToID = null;
            Amount = null;
            Time = null;
            ByUserID = null;
        }

        private clsTransfer(int? ID, int? FromID, int? ToID, decimal? Amount ,DateTime? Time, int? ByUserID)
        {
            _Mode = enMode.Update;
            this.ID = ID;
            this.FromID = FromID;
            this.ToID = ToID;
            this.Amount = Amount;
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
            this.ID = clsTransferData.AddNew(this.FromID, this.ToID, this.Amount, this.Time, this.ByUserID);
            return ID != null;
        }

        public static int? GetTotalPages(int PageSize)
           => clsTransferData.GetTotalPages(PageSize);

        public static DataTable GetAllPerPages(int CurrentPage, int PageSize)
            => clsTransferData.GetAllPerPages(CurrentPage, PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string Parameter, T Value)
            => clsTransferData.GetTotalPagesBy(PageSize, Parameter, Value);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Parameter, T Value)
            => clsTransferData.GetPerPagesBy(PageNumber, PageSize, Parameter, Value);

        public static int? GetTotalPagesBy<T1, T2>(int PageSize, string ParameterName1, T1 Value1, string ParameterName2, T2 Value2)
            => clsTransferData.GetTotalPagesBy<T1, T2>(PageSize, ParameterName1, Value1, ParameterName2, Value2);

        public static DataTable GetPerPagesBy<T1, T2>(int PageNumber, int PageSize, string ParameterName1, T1 Value1, string ParameterName2, T2 Value2)
            => clsTransferData.GetPerPagesBy<T1, T2>(PageNumber, PageSize, ParameterName1, Value1, ParameterName2, Value2);
    }
}
