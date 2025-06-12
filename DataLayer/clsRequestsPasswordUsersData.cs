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
    public class clsRequestsPasswordUsersData
    {
        public static bool GetByID(int? ChangePasswordID, ref int? UserID, ref byte Method, ref byte Status , ref DateTime Time , ref int? ByUserID)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_GetRequestPasswordUsersByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@ID", ChangePasswordID);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                UserID = Convert.ToInt32(Reader["UserID"]);

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
                    using (SqlCommand Command = new SqlCommand("sp_UpdateRequestPasswordUsersStatusByID", Connection))
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

        public static bool ExistWith(int? UserID  , byte Status)
            => clsGlobalClasses.Exists<int? , byte>("sp_CheckIfRequestExistsByUserIDAndStatus", "UserID" ,  UserID , "Status" , Status);

        public static bool Delete(int? ID)
            => clsGlobalClasses.Delete<int?>("sp_DeleteRequestsPasswordUsers", "ID", ID);

        public static int? AddNew(int? UserID, byte Method, byte Status , DateTime Time)
        {
            int? ID = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_AddRequestUser", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@UserID", UserID);

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
            => clsGlobalClasses.GetTotalPages("sp_GetTotalPagesRequestsUsers", PageSize);

        public static DataTable GetAllPerPages(int PageNumber , int PageSize)
            => clsGlobalClasses.GetAllPerPages("sp_GetRequestsUsersPerPages", PageNumber , PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string ParameterName, T Value)
            => clsGlobalClasses.GetTotalPages($"sp_GetTotalPagesRequestUsersBy{ParameterName}", PageSize, Value);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Patameter, T Value)
            => clsGlobalClasses.GetAllPerPages($"sp_GetRequestsUsersPerPagesBy{Patameter}", PageNumber, PageSize, Value);
    }
}
