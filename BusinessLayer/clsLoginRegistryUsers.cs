using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLoginRegistryUsers
    {
        public int? ID {  get; set; }

        public int? UserID { get; set; }

        public DateTime Time { get; set; }

        public clsLoginRegistryUsers()
        {
            this.ID = null;
            this.UserID = null;
            this.Time = DateTime.Now;
        }

        private bool _AddNew()
        {
            this.ID = clsLoginRegistryUsersData.AddNew(this.UserID , this.Time);

            return this.ID != null;
        }

        public bool Save()
            => this._AddNew();

        public static int? GetTotalPages(int PageSize)
           => clsLoginRegistryUsersData.GetTotalPages(PageSize);

        public static DataTable GetAllPerPages(int CurrentPage, int PageSize)
            => clsLoginRegistryUsersData.GetAllPerPages(CurrentPage, PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string Parameter, T Value)
            => clsLoginRegistryUsersData.GetTotalPagesBy(PageSize, Parameter, Value);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Parameter, T Value)
            => clsLoginRegistryUsersData.GetPerPagesBy(PageNumber, PageSize, Parameter, Value);

        public static int? GetTotalPages(int PageSize , int? ID)
           => GetTotalPagesBy<int?>(PageSize , "UserID" , ID);

        public static DataTable GetAllPerPages(int CurrentPage, int PageSize , int? ID)
            => GetPerPagesBy<int?>(CurrentPage , PageSize , "UserID" , ID);

        public static int? GetTotalPagesBy<T>(int PageSize, string Parameter, T Value , int? ID)
            => clsLoginRegistryUsersData.GetTotalPagesBy(PageSize, Parameter, Value , ID);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Parameter, T Value, int? ID)
            => clsLoginRegistryUsersData.GetPerPagesBy(PageNumber, PageSize, Parameter, Value , ID);

    }
}
