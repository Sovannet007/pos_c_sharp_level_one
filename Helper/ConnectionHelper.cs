using System;
using System.Data.SqlClient;

namespace POS_LEVEL_01.Helper
{
    public class ConnectionHelper
    {
        // Connection string
        private static SqlConnection con = new SqlConnection(
            "Data Source=NOV-SOVANNET\\SQLEXPRESS;Initial Catalog=BikeStores;User ID=pos_net_level_1;Password=admin@12345;TrustServerCertificate=True;"
        );

        // Function to get an open connection
        public static SqlConnection GetConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed || con.State == System.Data.ConnectionState.Broken)
            {
                con.Open(); 
            }

            return con;
        }

        // Function to close connection
        public static void CloseConnection()
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
