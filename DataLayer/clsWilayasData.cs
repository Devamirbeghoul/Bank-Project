using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace DataLayer
{
    public static class  clsWilayasData
    {
        public static bool GetByID(int? WlID, ref string Nm)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand("sp_GetWilayaByID", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@WlID", (object)WlID ?? DBNull.Value);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                Nm = Convert.ToString(Reader["Nm"]);

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

        public static bool GetByName(string Nm , ref int? WlID)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {

                    using (SqlCommand Command = new SqlCommand("sp_GetWilayaByName", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@Nm", Nm);
                        Connection.Open();
                        

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                WlID = Reader["WlID"] as int?;

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

        public static bool Delete(int? WlID)
            => clsGlobalClasses.Delete<int?>("sp_DeleteWilaya", "WlID", WlID);

        public static DataTable GetAllWilayas()
            => clsGlobalClasses.GetAll("sp_GetAllWilayas");
            
        public static int? AddNew(string Nm)
        {
            int? ID = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_AddNewWilaya", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@Nm", Nm);

                        SqlParameter outputIdParam = new SqlParameter("@PersonID", SqlDbType.Int)
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

        public static bool Update(int? WlID, string Nm)
        {
            int result = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_UpdateWilaya", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@WlID", WlID);

                        Command.Parameters.AddWithValue("@Nm", Nm);

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


    }
}

