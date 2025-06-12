using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLoginRegistryClients
    {
        public int? ID {  get; set; }

        public int? ClientID { get; set; }

        public DateTime Time { get; set; }

        public clsLoginRegistryClients()
        {
            this.ID = null;
            this.ClientID = null;
            this.Time = DateTime.Now;
        }

        private bool _AddNew()
        {
            this.ID = clsLoginRegistryClientsData.AddNew(this.ClientID , this.Time);

            return this.ID != null;
        }

        public bool Save()
            => this._AddNew();

        public static int? GetTotalPages(int PageSize)
           => clsLoginRegistryClientsData.GetTotalPages(PageSize);

        public static DataTable GetAllPerPages(int CurrentPage, int PageSize)
            => clsLoginRegistryClientsData.GetAllPerPages(CurrentPage, PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string Parameter, T Value)
            => clsLoginRegistryClientsData.GetTotalPagesBy(PageSize, Parameter, Value);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Parameter, T Value)
            => clsLoginRegistryClientsData.GetPerPagesBy(PageNumber, PageSize, Parameter, Value);

        public static int? GetTotalPages(int PageSize, int? ID)
           => GetTotalPagesBy<int?>(PageSize, "ClientID", ID);

        public static DataTable GetAllPerPages(int CurrentPage, int PageSize, int? ID)
            => GetPerPagesBy<int?>(CurrentPage, PageSize, "ClientID", ID);

        public static int? GetTotalPagesBy<T>(int PageSize, string Parameter, T Value, int? ID)
            => clsLoginRegistryClientsData.GetTotalPagesBy(PageSize, Parameter, Value, ID);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Parameter, T Value, int? ID)
            => clsLoginRegistryClientsData.GetPerPagesBy(PageNumber, PageSize, Parameter, Value, ID);

    }
}
