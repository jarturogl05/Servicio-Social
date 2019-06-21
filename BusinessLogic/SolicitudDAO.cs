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
    /// <summary>Clase con métodos para añadir y consultar solicitudes en la base de datos</summary>
    /// <seealso cref="BusinessLogic.ISolicitudDAO" />
    public class SolicitudDAO : ISolicitudDAO
    {
        /// <summary>  Añade una solicitud a la base de datos</summary>
        /// <param name="solicitud"> Una solicitud</param>
        /// <returns>El resultado de la operación</returns>
        /// <exception cref="SqlException">En caso de error en la base de datos</exception>
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

        /// <summary>Obtiene la solicitud de un alumno</summary>
        /// <param name="alumno">El alumno</param>
        /// <returns>Una solicitud</returns>
        /// <exception cref="SqlException">En caso de un error en la base de datos</exception>
        public Solicitud GetSolicitudByAlumno(Alumno alumno)
        {
            Solicitud solicitud = new Solicitud();
            Alumno alumnoAuxiliar = new Alumno();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException )
                {
                    return solicitud;
                }
                using (SqlCommand command = new SqlCommand("SELECT Alumno FROM dbo.Solicitud WHERE Alumno = @AlumnoToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("AlumnoToSearch", alumno.Matricula));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        alumnoAuxiliar.Matricula = reader["Alumno"].ToString();
                    }
                }
                connection.Close();
            }
            solicitud.Alumno = alumnoAuxiliar;
            return solicitud;
        }
    }
}
