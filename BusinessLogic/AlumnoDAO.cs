using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    public class AlumnoDAO : IAlumnoDAO
    {
        public AddResult AddAlumno(Alumno alumno)
        {
            AddResult resultado = AddResult.UnknownFail;
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    resultado = AddResult.SQLFail;
                    return resultado;
                }

                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Alumno VALUES(@Matricula, @Seccion, @Correo,@Bloque, @Nombre, @Carrera, @Estado, @Visibilidad)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Matricula", alumno.Matricula));
                    command.Parameters.Add(new SqlParameter("@Seccion", alumno.Seccion));
                    command.Parameters.Add(new SqlParameter("@Correo", alumno.Correo));
                    command.Parameters.Add(new SqlParameter("@Bloque", alumno.Bloque));
                    command.Parameters.Add(new SqlParameter("@Nombre", alumno.NombreAlumno));
                    command.Parameters.Add(new SqlParameter("@Carrera", alumno.Carrera));
                    command.Parameters.Add(new SqlParameter("@Estado", alumno.Estado));
                    command.Parameters.Add(new SqlParameter("@Visibilidad", alumno.Visibilidad));
                    command.ExecuteNonQuery();
                    resultado = AddResult.Success;
                }
                connection.Close();
            }
            return resultado;
        }
        public List<Alumno> GetAlumno()
        {
            List<Alumno> listaAlumno = new List<Alumno>();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Alumno", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Alumno alumno = new Alumno();
                        alumno.Matricula = reader["Matricula"].ToString();
                        alumno.Seccion = reader["Seccion"].ToString();
                        alumno.Correo = reader["Correo"].ToString();
                        alumno.Bloque = reader["Bloque"].ToString();
                        alumno.NombreAlumno = reader["Nombre"].ToString();
                        alumno.Carrera = reader["Carrera"].ToString();
                        alumno.Estado = reader["Estado_Asignacion"].ToString();
                        alumno.Visibilidad = reader["Visibilidad"].ToString();
                        listaAlumno.Add(alumno);
                    }
                }
                connection.Close();
            }
            return listaAlumno;
        }
        public Alumno GetAlumnoByName(String toSearchInBD)
        {
            Alumno alumno = new Alumno();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Alumno WHERE Nombre = @NameToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("NameToSearch", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        alumno.Matricula = reader["Matricula"].ToString();
                        alumno.Seccion = reader["Seccion"].ToString();
                        alumno.Correo = reader["Correo"].ToString();
                        alumno.Bloque = reader["Bloque"].ToString();
                        alumno.NombreAlumno = reader["Nombre"].ToString();
                        alumno.Carrera = reader["Carrera"].ToString();
                        alumno.Estado = reader["Estado_Asignacion"].ToString();
                        alumno.Visibilidad = reader["Visibilidad"].ToString();
                    }
                }
                connection.Close();
            }
            return alumno;
        }
        public Alumno GetAlumnoByMatricula(String toSearchInBD)
        {
            Alumno alumno = new Alumno();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Alumno WHERE Matricula = @MatriculaToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("MatriculaToSearch", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        alumno.Matricula = reader["Matricula"].ToString();
                        alumno.Seccion = reader["Seccion"].ToString();
                        alumno.Correo = reader["Correo"].ToString();
                        alumno.Bloque = reader["Bloque"].ToString();
                        alumno.NombreAlumno = reader["Nombre"].ToString();
                        alumno.Carrera = reader["Carrera"].ToString();
                        alumno.Estado = reader["Estado_Asignacion"].ToString();
                        alumno.Visibilidad = reader["Visibilidad"].ToString();
                    }
                }
                connection.Close();
            }
            return alumno;
        }
        public AddResult DeleteAlumnoByMatricula(String toSearchInBD)
        {
            AddResult result = AddResult.UnknownFail;
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    throw (ex);
                }
                using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Alumno WHERE Matricula = @MatriculaToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("MatriculaToSearch", toSearchInBD));
                    command.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;
        }
    }
}
