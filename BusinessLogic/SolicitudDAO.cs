using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataBase;

namespace BusinessLogic
{
    class SolicitudDAO : ISolicitudDAO
    {
        public void AddSolicitud(Solicitud solicitud)
        {
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Solicitud VALUES (@Opcion1, @Opcion2, @opcion3, " +
                    "@FechaSolicitud, @EstadoSolicitud, @Alumno)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@opcion1"))
                }
                connection.Close();
            }
        }
    }
}
