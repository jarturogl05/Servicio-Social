using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataBase;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    public class CoordinadorDAO : ICoordinadorDAO
    {

        public AddResult AddCoordinador(Coordinador coordinador)
        {
            AddResult resultado = AddResult.UnknownFail;
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch(SqlException)
                {
                    resultado = AddResult.SQLFail;

                }

                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Coordinador VALUES (@Numero_Personal, @Nombre, @Carrera)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Numero_Personal", coordinador.NumeroPersonal));
                    command.Parameters.Add(new SqlParameter("@Nombre", coordinador.NombreCoordinador));
                    command.Parameters.Add(new SqlParameter("@Carrera", coordinador.Carrera));
                    try
                    {
                        command.ExecuteNonQuery();
                        resultado = AddResult.Success;
                    }
                    catch(InvalidOperationException){
                        resultado = AddResult.UnknownFail;
                    }
                   
                    
                }
                connection.Close();
            }
            return resultado;
        }

   
    }
}
