using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsUsersData
    {
        public static bool GetByID(int? UsrID, ref int? PrsnID, ref string UsrnNm, ref string Psswrd, ref byte? Prmssns, ref bool IsActive)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_GetUserByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@UsrID", UsrID);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                PrsnID = Convert.ToInt32(Reader["PrsnID"]);

                                UsrnNm = Convert.ToString(Reader["UsrnNm"]);

                                Psswrd = Convert.ToString(Reader["Psswrd"]);

                                Prmssns = Convert.ToByte(Reader["Prmssns"]);

                                IsActive = Convert.ToBoolean(Reader["IsActive"]);

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

        public static bool GetByUsername(string Username , ref int? UsrID, ref int? PrsnID, ref string Psswrd, ref byte? Prmssns, ref bool IsActive)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_GetUserByUsername", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@UsrNm", Username);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {

                                UsrID = Convert.ToInt32(Reader["UsrID"]);

                                PrsnID = Convert.ToInt32(Reader["PrsnID"]);

                                Psswrd = Convert.ToString(Reader["Psswrd"]);

                                Prmssns = Convert.ToByte(Reader["Prmssns"]);

                                IsActive = Convert.ToBoolean(Reader["IsActive"]);

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

        public static int GetIDByPersonID(int? PersonID)
            => clsGlobalClasses.GetOneByOne<int , int?>("Users", "ID", "PersonID", PersonID);

        public static bool Delete(int UsrID)
            => clsGlobalClasses.Delete<int>("sp_DeleteUser", "UsrID" , UsrID);

        public static DataTable GetAllUsers()
            => clsGlobalClasses.GetAll("sp_GetAllUsers");

        public static int? AddNew(int? PrsnID, string UsrnNm, string Psswrd, byte? Prmssns, bool IsActive)
        {
            int? ID = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_AddNewUser", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PrsnID", PrsnID);

                        Command.Parameters.AddWithValue("@UsrnNm", UsrnNm);

                        Command.Parameters.AddWithValue("@Psswrd", Psswrd);

                        Command.Parameters.AddWithValue("@Prmssns", Prmssns);

                        Command.Parameters.AddWithValue("@IsActive", IsActive);

                        SqlParameter outputIdParam = new SqlParameter("@UsrID", SqlDbType.Int)
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

        public static bool Update(int? UsrID, int? PrsnID, string UsrnNm, string Psswrd, byte? Prmssns, bool IsActive)
        {
            int result = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_UpdateUser", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@UsrID", UsrID);

                        Command.Parameters.AddWithValue("@PrsnID", PrsnID);

                        Command.Parameters.AddWithValue("@UsrnNm", UsrnNm);

                        Command.Parameters.AddWithValue("@Psswrd", Psswrd);

                        Command.Parameters.AddWithValue("@Prmssns", Prmssns);

                        Command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool IsUserExistByID(int? UserID)
            => clsGlobalClasses.Exists<int?>("sp_CheckIfUserExistsByID", "UsrID", UserID);

        public static bool IsUserExistByPersonID(int? PersonID)
            => clsGlobalClasses.Exists<int?>("sp_CheckIfUserExistsByPersonID", "PrsnID", PersonID);

        public static bool IsUserExistByUsername(string Username)
            => clsGlobalClasses.Exists<string>("sp_CheckIfUserExistsByUsername", "UsrnNm", Username);

        public static bool IsUserExistByUsernameAndPassword(string Username , string Password)
            => clsGlobalClasses.Exists<string , string >("sp_CheckIfUserExistsByUsernameAndPassword", "UsrnNm", Username , "Psswrd" , Password);

        public static int? GetTotalPages(int PageSize)
            => clsGlobalClasses.GetTotalPages("sp_GetTotalPagesUsers", PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize , string Patameter , T Value)
            => clsGlobalClasses.GetTotalPages<T>($"sp_GetTotalPagesUsersBy{Patameter}", PageSize , Value);

        public static DataTable GetUserPerPages(int PageNumber, int PageSize)
            => clsGlobalClasses.GetAllPerPages("sp_GetAllUserPerPages", PageNumber, PageSize);

        public static DataTable GetUserPerPagesBy<T>(int PageNumber, int PageSize , string Patameter, T Value)
            => clsGlobalClasses.GetAllPerPages($"sp_GetUsersPerPagesBy{Patameter}", PageNumber, PageSize , Value);

        
    }
}
