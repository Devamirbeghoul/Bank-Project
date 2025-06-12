using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace DataLayer
{
    public static class  clsPeopleData
    {
        public static bool GetByID(int? PrsnID, ref string CrdID, ref string FrstNm, ref string MddlNm, ref string LstNm, ref DateTime DBrth, ref byte Gndr, ref string Addrs, ref string Phn, ref string Eml, ref int WlID, ref string ImgPth)
        {

            using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetPersonByID", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@Prsn", (object)PrsnID ?? DBNull.Value);

                    try
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                CrdID = Convert.ToString(Reader["CrdID"]);

                                FrstNm = Convert.ToString(Reader["FrstNm"]);

                                MddlNm = Reader["MddlNm"] as string ?? string.Empty;

                                LstNm = Convert.ToString(Reader["LstNm"]);

                                DBrth = Convert.ToDateTime(Reader["DBrth"]);

                                Gndr = Convert.ToByte(Reader["Gndr"]);

                                Addrs = Convert.ToString(Reader["Addrs"]);

                                Phn = Convert.ToString(Reader["Phn"]);

                                Eml = Convert.ToString(Reader["Eml"]);

                                WlID = Convert.ToInt32(Reader["WlID"]);

                                ImgPth = Reader["ImgPth"] as string ?? null;

                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsSettings.LogError(ex);
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool GetByCardID(string CrdID, ref int? PrsnID, ref string FrstNm, ref string MddlNm, ref string LstNm, ref DateTime DBrth, ref byte Gndr, ref string Addrs, ref string Phn, ref string Eml, ref int WlID, ref string ImgPth)
        {
            using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetPersonByCardID", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@CrdID", CrdID);

                    try
                    {
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                PrsnID = Reader["PrsnID"] as int?;

                                FrstNm = Convert.ToString(Reader["FrstNm"]);

                                MddlNm = Reader["MddlNm"] as string ?? string.Empty;

                                LstNm = Convert.ToString(Reader["LstNm"]);

                                DBrth = Convert.ToDateTime(Reader["DBrth"]);

                                Gndr = Convert.ToByte(Reader["Gndr"]);

                                Addrs = Convert.ToString(Reader["Addrs"]);

                                Phn = Convert.ToString(Reader["Phn"]);

                                Eml = Convert.ToString(Reader["Eml"]);

                                WlID = Convert.ToInt32(Reader["WlID"]);

                                ImgPth = Reader["ImgPth"] as string ?? null;

                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsSettings.LogError(ex);
                        return false;
                    }
                }
            }
            return false;
        }

        public static int? GetPersonIDByEmail(string Email)
            => clsGlobalClasses.GetOneByOne<int , string>("People" , "PersonID" , "Email" , Email);

        public static int? GetPersonIDByPhone(string Phone)
            => clsGlobalClasses.GetOneByOne<int, string>("People", "PersonID", "Phone", Phone);

        public static bool Delete(int? PrsnID) 
            => clsGlobalClasses.Delete<int?>("sp_DeletePerson", "PrsnID", PrsnID);

        public static DataTable GetAllPeople() 
            => clsGlobalClasses.GetAll("sp_GetAllPeople");

        public static bool IsPersonExist(int? PrsnID)
            => clsGlobalClasses.Exists <int?> ("sp_CheckIfPersonExistsByID", "PrsnID", PrsnID);

        public static bool IsPersonExistByCardID(string CardID)
            => clsGlobalClasses.Exists<string> ("sp_CheckIfPersonExistsByCardID", "CrdID", CardID);

        public static bool IsPersonExistByEmail(string Email)
            => clsGlobalClasses.Exists<string>("sp_CheckIfPersonExistsByEmail", "Eml", Email);

        public static bool IsPersonExistByPhone(string Phone)
            => clsGlobalClasses.Exists<string>("sp_CheckIfPersonExistsByPhone", "Phn" , Phone);

        public static int? AddNewPerson(string CrdID, string FrstNm, string MddlNm, string LstNm, DateTime DBrth, byte Gndr, string Addrs, string Phn, string Eml, int? WlID, string ImgPth)
        {
            int? PrsnID = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {

                    using (SqlCommand Command = new SqlCommand("sp_AddNewPerson", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@CrdID", CrdID);

                        Command.Parameters.AddWithValue("@FrstNm", FrstNm);

                        Command.Parameters.AddWithValue("@MddlNm", (object)MddlNm ?? DBNull.Value);

                        Command.Parameters.AddWithValue("@LstNm", LstNm);

                        Command.Parameters.AddWithValue("@DBrth", DBrth);

                        Command.Parameters.AddWithValue("@Gndr", Gndr);

                        Command.Parameters.AddWithValue("@Addrs", Addrs);

                        Command.Parameters.AddWithValue("@Phn", Phn);

                        Command.Parameters.AddWithValue("@Eml", Eml);

                        Command.Parameters.AddWithValue("@WlID", WlID);

                        Command.Parameters.AddWithValue("@ImgPth", (object)ImgPth ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@PersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        
                        Command.Parameters.Add(outputIdParam);

                        Connection.Open();

                        Command.ExecuteNonQuery();

                        PrsnID = (int?)outputIdParam.Value;

                    }
                }
            }
            catch (Exception ex)
            {
                clsSettings.LogError(ex);
            }

            return PrsnID;
        }

        public static bool UpdatePerson(int? PrsnID, string CrdID, string FrstNm, string MddlNm, string LstNm, DateTime DBrth, byte Gndr, string Addrs, string Phn, string Eml, int? WlID, string ImgPth)
        {
            int result = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsSettings.GetConnectionString()))
                {
                    using (SqlCommand Command = new SqlCommand("sp_UpdatePerson", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@PrsnID", PrsnID);

                        Command.Parameters.AddWithValue("@CrdID", CrdID);

                        Command.Parameters.AddWithValue("@FrstNm", FrstNm);

                        Command.Parameters.AddWithValue("@MddlNm", (object)MddlNm ?? DBNull.Value);

                        Command.Parameters.AddWithValue("@LstNm", LstNm);

                        Command.Parameters.AddWithValue("@DBrth", DBrth);

                        Command.Parameters.AddWithValue("@Gndr", Gndr);

                        Command.Parameters.AddWithValue("@Addrs", Addrs);

                        Command.Parameters.AddWithValue("@Phn", Phn);

                        Command.Parameters.AddWithValue("@Eml", Eml);

                        Command.Parameters.AddWithValue("@WlID", WlID);

                        Command.Parameters.AddWithValue("@ImgPth", (object)ImgPth ?? DBNull.Value);

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

        public static DataTable GetAllPeoplePerPages(int PageNumber, int PageSize)
            => clsGlobalClasses.GetAllPerPages("sp_GetAllPeoplePerPages", PageNumber, PageSize);

        public static DataTable GetPeoplePerPagesBy<T>(int PageNumber, int PageSize, string Patameter, T Value)
            => clsGlobalClasses.GetAllPerPages($"sp_GetPeoplePerPagesBy{Patameter}", PageNumber, PageSize, Value);

        public static int? GetTotalPages(int PageSize)
            => clsGlobalClasses.GetTotalPages("sp_GetTotalPagesPeople", PageSize);

        public static int? GetTotalPagesPeopleBy<T>(int PageSize, string Patameter, T Value)
            => clsGlobalClasses.GetTotalPages<T>($"sp_GetTotalPagesPeopleBy{Patameter}", PageSize, Value);
    }
}

