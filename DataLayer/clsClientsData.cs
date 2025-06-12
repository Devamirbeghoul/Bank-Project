using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsClientsData
    {
        public static bool GetByID(int? ClientID, ref int? PersonID, ref string AccountNumber, ref string PinCode, ref decimal Balance)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_GetClientByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@ClientID", ClientID);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                PersonID = Convert.ToInt32(Reader["PersonID"]);

                                AccountNumber = Convert.ToString(Reader["AccountNumber"]);

                                PinCode = Convert.ToString(Reader["PinCode"]);

                                Balance = Convert.ToDecimal(Reader["Balance"]);

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

        public static bool GetByAccountNumber(string AccountNumber , ref int? ClientID, ref int? PersonID, ref string PinCode, ref decimal Balance)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_GetClientByAccountNumber", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                ClientID = Convert.ToInt32(Reader["ClientID"]);

                                PersonID = Convert.ToInt32(Reader["PersonID"]);

                                PinCode = Convert.ToString(Reader["PinCode"]);

                                Balance = Convert.ToDecimal(Reader["Balance"]);

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
            => clsGlobalClasses.GetOneByOne<int , int?>("Clients", "ID", "PersonID", PersonID);

        public static decimal GetBalanceByID(int? ID)
            => clsGlobalClasses.GetOneByOne<decimal, int?>("Clients", "Balance", "ID", ID);

        public static bool Delete(int ClientID)
            => clsGlobalClasses.Delete<int>("sp_DeleteClient", "ClientID", ClientID);

        public static DataTable GetAllClients()
            => clsGlobalClasses.GetAll("sp_GetAllClients");

        public static int? AddNew(int? PersonID, string AccountNumber, string PinCode, decimal Balance)
        {
            int? ID = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_AddNewClient", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PersonID", PersonID);

                        Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

                        Command.Parameters.AddWithValue("@PinCode", PinCode);

                        Command.Parameters.AddWithValue("@Balance", Balance);

                        SqlParameter outputIdParam = new SqlParameter("@ClientID", SqlDbType.Int)
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

        public static bool Update(int? ClientID, int? PersonID, string AccountNumber, string PinCode, decimal Balance)
        {
            int result = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_UpdateClient", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@ClientID", ClientID);

                        Command.Parameters.AddWithValue("@PersonID", PersonID);

                        Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

                        Command.Parameters.AddWithValue("@PinCode", PinCode);

                        Command.Parameters.AddWithValue("@Balance", Balance);

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

        public static bool IsClientExistByPersonID(int? PersonID)
            => clsGlobalClasses.Exists<int?>("sp_CheckIfClientExistsByPersonID", "PersonID", PersonID);

        public static bool IsClientExistByAccountNumber(string AccountNumber)
            => clsGlobalClasses.Exists<string>("sp_CheckIfClientExistsByAccountNumber", "AccountNumber", AccountNumber);

        public static bool IsClientExistByAccountNumberAndPinCode(string AccountNumber, string PinCode)
            => clsGlobalClasses.Exists<string, string>("sp_CheckIfClientExistsByAccountNumberAndPinCode", "AccountNumber", AccountNumber, "PinCode", PinCode);

        public static int? GetTotalPages(int PageSize)
            => clsGlobalClasses.GetTotalPages("sp_GetTotalPagesClients", PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string Patameter, T Value)
            => clsGlobalClasses.GetTotalPages<T>($"sp_GetTotalPagesClientsBy{Patameter}", PageSize, Value);

        public static DataTable GetClientsPerPages(int CurrentPage , int PageSize)
            => clsGlobalClasses.GetAllPerPages("sp_GetAllClientsPerPages", CurrentPage, PageSize);

        public static DataTable GetClientsPerPagesBy<T>(int PageNumber, int PageSize, string Patameter, T Value)
            => clsGlobalClasses.GetAllPerPages($"sp_GetClientsPerPagesBy{Patameter}", PageNumber, PageSize, Value);
    }
}
