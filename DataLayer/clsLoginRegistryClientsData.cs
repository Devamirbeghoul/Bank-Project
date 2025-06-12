﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsLoginRegistryClientsData
    {
        public static int? AddNew(int? UserID , DateTime Time)
        {
            int? ID = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_AddNewLoginOfClient", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@UserID", UserID);

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
           => clsGlobalClasses.GetTotalPages("sp_GetTotalPagesLoginClients", PageSize);

        public static DataTable GetAllPerPages(int PageNumber, int PageSize)
            => clsGlobalClasses.GetAllPerPages("sp_GetAllLoginClientsPerPages", PageNumber, PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string ParameterName, T Value)
            => clsGlobalClasses.GetTotalPages($"sp_GetTotalPagesLoginClientsBy{ParameterName}", PageSize, Value);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Patameter, T Value)
            => clsGlobalClasses.GetAllPerPages($"sp_GetLoginClientsPerPagesBy{Patameter}", PageNumber, PageSize, Value);

        public static int? GetTotalPagesBy<T>(int PageSize, string ParameterName, T Value, int? ID)
            => clsGlobalClasses.GetTotalPages<int?, T>($"sp_GetTotalPagesLoginClientsByClientIDBy{ParameterName}", PageSize, ID, Value);

        public static DataTable GetPerPagesBy<T>(int PageNumber, int PageSize, string Patameter, T Value, int? ID)
            => clsGlobalClasses.GetAllPerPages<int?, T>($"sp_GetLoginClientsPerPagesByClientIDBy{Patameter}", PageNumber, PageSize, ID, Value);
    }
}
