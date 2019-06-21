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


    /// <summary>Clase con los métodos para añadir y consultar coordinadores de la base de datos</summary>
    /// <seealso cref="BusinessLogic.ICoordinadorDAO" />
    public class CoordinadorDAO : ICoordinadorDAO
    {


        /// <summary>Añade un coordinador a la base de datos</summary>
        /// <param name="coordinador">El coordinador a ñadir</param>
        /// <returns>el resultado de la operación</returns>
        /// <exception cref="SqlException">En caso de que ocurra un error en la base de datos</exception>
        public AddResult AddCoordinador(Coordinador coordinador)
        {
            AddResult resultado = AddResult.UnknowFail;
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
                    catch(SqlException){
                        resultado = AddResult.UnknowFail;
                    }
                   
                    
                }
                connection.Close();
            }
            return resultado;
        }

   
    }
}
