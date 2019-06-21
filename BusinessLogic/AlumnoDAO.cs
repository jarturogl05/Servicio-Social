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

    /// <summary>Clase que contiene todos los metodos para guardar, consultar y borrar alumno</summary>
    /// <seealso cref="BusinessLogic.IAlumnoDAO" />
    public class AlumnoDAO : IAlumnoDAO
    {

        /// <summary>Revisa el objeto alumno en busca de inconsistencias.</summary>
        /// <param name="alumno">El alumno.</param>
        /// <returns>El resultado de la validacion</returns>
        /// <exception cref="FormatException">
        /// El objeto contiene campos vacios
        /// or
        /// La matricula ingresada no cumple con los criterios " + alumno.Matricula
        /// or
        /// El correo no cumple con los criterios: " + alumno.Correo
        /// </exception>
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

        /// <summary>Añade el alumno.</summary>
        /// <param name="alumno">El alumno.</param>
        /// <returns>El resultado de la operacion</returns>
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
        /// <summary>Obtiene la lista de alumno de la base de datos.</summary>
        /// <returns>Una lista de Alumno</returns>
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

        /// <summary>Obtiene un alumno por su nombre.</summary>
        /// <param name="toSearchInBD">El nombre a buscar en la base de datos.</param>
        /// <returns>Un Alumno</returns>
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

        /// <summary>Obtiene un alumno por su matricula.</summary>
        /// <param name="toSearchInBD">La matricula a buscar en la base de datos.</param>
        /// <returns>Un Alumno</returns>
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

        /// <summary>Borra al alumno por su matricula.</summary>
        /// <param name="toSearchInBD">La matricula a borrar en el sistema.</param>
        /// <returns>El resultado de la operacion</returns>
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
