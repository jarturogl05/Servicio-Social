using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataBase;

namespace BusinessLogic
{
    public class CoordinadorDAO : ICoordinadorDAO
    {

        public void AddCoordinador(Coordinador coordinador)
        {
            
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Coordinador VALUES (@Numero_Personal, @Nombre, @Carrera)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Numero_Personal", coordinador.NumeroPersonal));
                    command.Parameters.Add(new SqlParameter("@Nombre", coordinador.NombreCoordinador));
                    command.Parameters.Add(new SqlParameter("@Carrera", coordinador.Carrera));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

   
    }
}
