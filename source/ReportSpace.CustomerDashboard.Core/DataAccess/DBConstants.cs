using System;
using System.Data.Common;

namespace ReportSpace.CustomerDashboard.Core.DataAccess
{
    public static class DBConstants
    {
        public static String DataBaseName = "ReportSpace";

        public static String ProviderName = "System.Data.SqlClient";

        public static String GetConnectionString(string databasename = "")
        {
            string connectionString = "Data Source=(local);Initial Catalog=" + ((String.IsNullOrEmpty(databasename)) ? DataBaseName : databasename) + ";Integrated Security=True";
            return connectionString;
        }
        
        public static DbConnection GetDBConnection(string databasename = "")
        {
            var conn = DbProviderFactories.GetFactory(ProviderName).CreateConnection();
            conn.ConnectionString = GetConnectionString(databasename);
            return conn;
        }

    }

    
}