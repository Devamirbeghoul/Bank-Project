using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsTransferData
    {
        public static int? AddNew(int? FromID, int? ToID, decimal? Amount, DateTime? Time, int? ByUserID)
        {
            int? ID = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_PerformTransfer", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@FromID", FromID);

                        Command.Parameters.AddWithValue("@ToID", ToID);

                        Command.Parameters.AddWithValue("@Amount", Amount);

                        Command.Parameters.AddWithValue("@Time", Time);

                        Command.Parameters.AddWithValue("@ByUserID", ByUserID);

                        SqlParameter outputIdParam = new SqlParameter("@ID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        Command.Parameters.Add(outputIdParam);

                        Connection.Open();

                        Command.ExecuteNonQuery();

                        ID = (int?)outputIdParam.Value;
                    }
                }
            }

            catch (Exception ex)
            {
                clsSettings.LogError(ex);
            }
            return ID;
        }

        public static int? GetTotalPages(int PageSize)
           => clsGlobalClasses.GetTotalPages("sp_GetTotalPagesTransfers", PageSize);

        public static DataTable GetAllPerPages(int PageNumber, int PageSize)
            => clsGlobalClasses.GetAllPerPages("sp_GetAllTransfersPerPages", PageNumber, PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string ParameterName, T Value)
            => clsGlobalClasses.GetTotalPages($"sp_GetTotalPagesTransfersBy{ParameterName}", PageSize, Value);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Patameter, T Value)
            => clsGlobalClasses.GetAllPerPages($"sp_GetTransfersPerPagesBy{Patameter}", PageNumber, PageSize, Value);

        public static int? GetTotalPagesBy<T1, T2>(int PageSize, string ParameterName1, T1 Value1, string ParameterName2, T2 Value2)
            => clsGlobalClasses.GetTotalPages<T1, T2>($"sp_GetTotalPagesTransfersBy{ParameterName1}By{ParameterName2}", PageSize, Value1, Value2);

        public static DataTable GetPerPagesBy<T1, T2>(int PageNumber, int PageSize, string ParameterName1, T1 Value1, string ParameterName2, T2 Value2)
            => clsGlobalClasses.GetAllPerPages<T1, T2>($"sp_GetTransfersPerPagesBy{ParameterName1}By{ParameterName2}", PageNumber, PageSize, Value1, Value2);

    }
}
