using System;
using System.Diagnostics;
using System.Configuration;

namespace DataLayer
{
    public static class  clsSettings
    {
        public static void LogError(Exception ex)
        {
            try
            {
                if (!EventLog.SourceExists("BankApp"))
                    EventLog.CreateEventSource("BankApp", "Application");

                EventLog.WriteEntry("MyApp", $"Error: {ex.Message}\nStackTrace: {ex.StackTrace}", EventLogEntryType.Error);
            }
            catch (Exception)
            {
            }
        }

        public static string GetConnectionString()
         {
            return "Server=.;Database=BankDB;User Id=sa;Password=sa123456";
         }
    }
}

