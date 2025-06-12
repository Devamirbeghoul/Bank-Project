using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsRequestsPasswordClients
    {
        public static bool GetByID(int? ChangePasswordID, ref int? ClientID, ref byte Method, ref byte Status , ref DateTime Time , ref int? ByUserID)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_GetRequestPasswordClientByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@ID", ChangePasswordID);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                ClientID = Convert.ToInt32(Reader["ClientID"]);

                                Method = Convert.ToByte(Reader["Method"]);

                                Status = Convert.ToByte(Reader["Status"]);

                                Time = Convert.ToDateTime(Reader["Time"]);

                                ByUserID = Reader["ByUserID"] as int?;


                                return true;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                clsSettings.LogError(ex);
                return false;
            }
            return false;
        }

        public static bool SetStatus(int ID , byte Status , int? ByUserID)
        {
            int result = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_UpdateRequestPasswordClientStatusByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@ID", ID);

                        Command.Parameters.AddWithValue("@Status", Status);
                        Command.Parameters.AddWithValue("@ByUserID", ByUserID);

                        Connection.Open();

                        result = Command.ExecuteNonQuery();

                    }
                }
            }

            catch (Exception ex)
            {
                clsSettings.LogError(ex);
            }
            return result > 0;
        }

        public static bool ExistWith(int? ClientID  , byte Status)
            => clsGlobalClasses.Exists<int? , byte>("sp_CheckIfRequestExistsByClientIDAndStatus", "ClientID" ,  ClientID , "Status" , Status);

        public static bool Delete(int? ID)
            => clsGlobalClasses.Delete<int?>("sp_DeleteRequestsPasswordClients", "ID", ID);

        public static int? AddNew(int? ClientID, byte Method, byte Status , DateTime Time)
        {
            int? ID = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_AddRequestClient", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@ClientID", ClientID);

                        Command.Parameters.AddWithValue("@Method", Method);

                        Command.Parameters.AddWithValue("@Status", Status);

                        Command.Parameters.AddWithValue("@Time", Time);

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
            => clsGlobalClasses.GetTotalPages("sp_GetTotalPagesRequestsClients", PageSize);

        public static DataTable GetAllPerPages(int PageNumber , int PageSize)
            => clsGlobalClasses.GetAllPerPages("sp_GetRequestsClientsPerPages", PageNumber , PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string ParameterName, T Value)
            => clsGlobalClasses.GetTotalPages($"sp_GetTotalPagesRequestClientsBy{ParameterName}", PageSize, Value);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Patameter, T Value)
            => clsGlobalClasses.GetAllPerPages($"sp_GetRequestsClientsPerPagesBy{Patameter}", PageNumber, PageSize, Value);
    }
}
