using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class DbConnection
    {
        private SqlConnection connection;
        private string connectionString;

        public DbConnection()


        {
            connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

            connection = new SqlConnection(connectionString);

        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public void CloseConnection()
        {
            if (connection != null)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
