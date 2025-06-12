using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsGlobalClasses
    {
        public static DataTable GetAll(string StoredProcedure)
        {
            DataTable Records = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
            {
                using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                                Records.Load(Reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsSettings.LogError(ex);
                    }
                }
            }
            return Records;
        }

        public static T1 GetOneByOne<T1, T2>(string Table , string OutputParameter , string ParameterName , T2 Value)
        {
            T1 Output = default(T1);

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {

                    using (SqlCommand Command = new SqlCommand($"sp_Get{Table}{OutputParameter}By{ParameterName}", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue($"@{ParameterName}", Value);

                        SqlParameter outputIdParam = new SqlParameter("@Value", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        Command.Parameters.Add(outputIdParam);

                        Connection.Open();

                        Command.ExecuteNonQuery();

                        Output = (T1)Convert.ChangeType(outputIdParam.Value, typeof(T1));

                    }
                }
            }
            catch (Exception ex)
            {
                clsSettings.LogError(ex);
            }

            return Output;
        }

        public static bool Delete<T>(string StoredProcedure , string ParameterName , T Value)
        {
            int result = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue($"@{ParameterName}", (object)Value ?? DBNull.Value);

                        Connection.Open();

                        result = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsSettings.LogError(ex);
                return false;
            }
            return result > 0;
        }

        public static bool Exists<T>(string StoredProcedure, string ParameterName, T Value)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue($"@{ParameterName}", (object)Value ?? DBNull.Value);

                        SqlParameter existsParam = new SqlParameter("@Exists", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(existsParam);

                        Connection.Open();

                        Command.ExecuteNonQuery();

                        IsFound = (bool)existsParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsSettings.LogError(ex);
                return false;
            }
            return IsFound;
        }

        public static bool Exists<T1 , T2>(string StoredProcedure, string ParameterName1, T1 Value1, string ParameterName2, T2 Value2)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue($"@{ParameterName1}", Value1);
                        Command.Parameters.AddWithValue($"@{ParameterName2}", Value2);

                        SqlParameter existsParam = new SqlParameter("@Exists", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(existsParam);

                        Connection.Open();

                        Command.ExecuteNonQuery();

                        IsFound = (bool)existsParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsSettings.LogError(ex);
                return false;
            }
            return IsFound;
        }

        public static bool Exists<T1, T2 , T3>(string StoredProcedure, string ParameterName1, T1 Value1, string ParameterName2, T2 Value2 , string ParameterName3, T3 Value3)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue($"@{ParameterName1}", Value1);
                        Command.Parameters.AddWithValue($"@{ParameterName2}", Value2);
                        Command.Parameters.AddWithValue($"@{ParameterName3}", Value3);

                        SqlParameter existsParam = new SqlParameter("@Exists", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(existsParam);

                        Connection.Open();

                        Command.ExecuteNonQuery();

                        IsFound = (bool)existsParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsSettings.LogError(ex);
                return false;
            }
            return IsFound;
        }

        public static DataTable GetAllPerPages(string StoredProcedure , int PageNumber , int PageSize)
        {
            DataTable Records = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
            {
                using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue($"@PageNumber", PageNumber);
                    Command.Parameters.AddWithValue($"@PageSize", @PageSize);

                    try
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                                Records.Load(Reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsSettings.LogError(ex);
                    }
                }
            }
            return Records;
        }

        public static DataTable GetAllPerPages<T1 , T2>(string StoredProcedure, int PageNumber, int PageSize, T1 Value1 , T2 Value2)
        {
            DataTable Records = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
            {
                using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue($"@PageNumber", PageNumber);
                    Command.Parameters.AddWithValue($"@PageSize", PageSize);
                    Command.Parameters.AddWithValue($"@Value1", Value1);
                    Command.Parameters.AddWithValue($"@Value2", Value2);

                    try
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                                Records.Load(Reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsSettings.LogError(ex);
                    }
                }
            }
            return Records;
        }

        public static DataTable GetAllPerPages<T>(string StoredProcedure, int PageNumber, int PageSize , T Value)
        {
            DataTable Records = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
            {
                using (SqlCommand Command = new SqlCommand(StoredProcedure, Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue($"@PageNumber", PageNumber);
                    Command.Parameters.AddWithValue($"@PageSize", PageSize);
                    Command.Parameters.AddWithValue($"@Value", Value);

                    try
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                                Records.Load(Reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsSettings.LogError(ex);
                    }
                }
            }
            return Records;
        }

        public static int? GetTotalPages(string StoredProcedure, int PageSize)
        {
            int? TotalPages = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PageSize", PageSize);

                        SqlParameter totalPagesParam = new SqlParameter("@TotalPages", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(totalPagesParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        
                        TotalPages = (int)totalPagesParam.Value;
                    }


                }
            }
            catch (Exception ex)
            {
                clsSettings.LogError(ex);
                return null;
            }

            return TotalPages;
        }

        public static int? GetTotalPages<T>(string StoredProcedure , int PageSize, T Value)
        {
            int? TotalPages = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PageSize", PageSize);
                        cmd.Parameters.AddWithValue($"@Value", (object)Value ?? DBNull.Value);

                        SqlParameter totalPagesParam = new SqlParameter("@TotalPages", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(totalPagesParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        TotalPages = (int)totalPagesParam.Value;
                    }


                }
            }
            catch (Exception ex)
            {
                clsSettings.LogError(ex);
                return null;
            }

            return TotalPages;
        }

        public static int? GetTotalPages<T1 , T2>(string StoredProcedure, int PageSize, T1 Value1 , T2 Value2)
        {
            int? TotalPages = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PageSize", PageSize);
                        cmd.Parameters.AddWithValue($"@Value1", (object)Value1 ?? DBNull.Value);
                        cmd.Parameters.AddWithValue($"@Value2", (object)Value2 ?? DBNull.Value);

                        SqlParameter totalPagesParam = new SqlParameter("@TotalPages", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(totalPagesParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        TotalPages = (int)totalPagesParam.Value;
                    }


                }
            }
            catch (Exception ex)
            {
                clsSettings.LogError(ex);
                return null;
            }

            return TotalPages;
        }

    }
}
