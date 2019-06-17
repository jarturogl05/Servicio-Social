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
     public  class SolicitudDAO : ISolicitudDAO
    {
        public AddResult AddSolicitud(Solicitud solicitud)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }catch(SqlException)
                {
                    resultado = AddResult.SQLFail;
                }
                
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Solicitud VALUES(@Alumno, @Opcion1, @Opcion2, @opcion3, " +
                    "@FechaSolicitud, @EstadoSolicitud)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@opcion1", solicitud.Proyectos[0].IDProyecto));
                    command.Parameters.Add(new SqlParameter("@opcion2", solicitud.Proyectos[1].IDProyecto));
                    command.Parameters.Add(new SqlParameter("@opcion3", solicitud.Proyectos[2].IDProyecto));
                    command.Parameters.Add(new SqlParameter("@FechaSolicitud", solicitud.FechaSolicitud));
                    command.Parameters.Add(new SqlParameter("@EstadoSolicitud", solicitud.EstadoSolicitud));
                    command.Parameters.Add(new SqlParameter("@Alumno", solicitud.Alumno.Matricula));
                    try
                    {
                        command.ExecuteNonQuery();
                        resultado = AddResult.Success;
                    }
                    catch (SqlException)
                    {
                        resultado = AddResult.SQLFail;
                    }

                }
                connection.Close();
            }
            return resultado;
        }
    }
}
