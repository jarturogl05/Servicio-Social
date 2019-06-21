using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{

    /// <summary>Clase que controla la conexión a la base de datos</summary>
    public class DbConnection
    {
        private SqlConnection connection;
        private string connectionString;

        public DbConnection()

        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionToSQL"].ConnectionString;

            connection = new SqlConnection(connectionString);

        }

        /// <summary>Obtiene la coneccion.</summary>
        /// <returns>La coneccion</returns>
        public SqlConnection GetConnection()
        {
            return connection;
        }

        /// <summary>Cierra la coneccion.</summary>
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
