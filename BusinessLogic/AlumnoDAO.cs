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
        private AddResult CheckObjectAlumno(Alumno alumno)
        {
            ValidarCampos validarCampos = new ValidarCampos();
            AddResult result = AddResult.UnknowFail;
            if (alumno.Bloque == String.Empty || alumno.Carrera == String.Empty || alumno.Correo == String.Empty || alumno.Estado == String.Empty || alumno.Matricula == String.Empty || alumno.NombreAlumno == String.Empty || alumno.Seccion == String.Empty || alumno.Visibilidad == String.Empty)
            {
                throw new FormatException("El objeto contiene campos vacios");
            }
            else if (validarCampos.ValidarMatricula(alumno.Matricula) == ValidarCampos.ResultadosValidación.MatriculaInválida)
            {
                throw new FormatException("La matricula ingresada no cumple con los criterios " + alumno.Matricula);
            }
            else if (validarCampos.ValidarCorreo(alumno.Correo) == ValidarCampos.ResultadosValidación.Correoinválido)
            {
                throw new FormatException("El correo no cumple con los criterios: " + alumno.Correo);
            }
            else
            {
                result = AddResult.Success;
            }
            return result;
        }
        public AddResult AddAlumno(Alumno alumno)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectAlumno(alumno);
            }
            catch (ArgumentNullException)
            {
                resultado = AddResult.NullObject;
                return resultado;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
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
                    try
                    {
                        command.ExecuteNonQuery();
                    }catch (SqlException)
                    {
                        resultado = AddResult.SQLFail;
                        return resultado;
                    }
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
            AddResult result = AddResult.UnknowFail;
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
