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

    /// <summary>
    /// Contiene métodos para realizar consultas sobre el objeto ENCARGADO en la base de datos
    /// </summary>
    public class EncargadoDAO : IEncargadoDAO
    {

        /// <summary>obtiene un encargado por su ID.</summary>
        /// <param name="toSearch">ID a buscar.</param>
        /// <returns>un encargado</returns>
        /// <exception cref=" SqlException"> En caso de ocurrir un error en la base de datos</exception>
        public Encargado GetEncargadoByID(string toSearch)
        {
            Encargado encargado = new Encargado();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    return encargado;
                }
                
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Encargado WHERE ID_Encargado = @idToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("idToSearch", toSearch));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        encargado.NombreEncargado = reader["Nombre"].ToString();
                        encargado.CorreoEncargado = reader["Correo"].ToString();
                        encargado.CargoOrganizacion = reader["Cargo"].ToString();
                        encargado.TelefonoEncargado = reader["Teléfono"].ToString();

                    }
                }
                connection.Close();
            }

            return encargado;
        }

        /// <summary>Obtiene encargados por su organización.</summary>
        /// <param name="organización">la organización del encargado.</param>
        /// <returns>Lista de encargados </returns>
        /// <exception cref=" SqlException"> en caso de que ocurra un error en la base de datos</exception>
        public List<Encargado> GetEncargadoByOrganización(Organizacion organización)
        {
            List<Encargado> listaEncargados = new List<Encargado>();
            
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    return listaEncargados;
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Encargado WHERE Organización = @organizacion", connection))
                {
                    command.Parameters.Add(new SqlParameter("@organizacion", organización.rfc));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Encargado encargado = new Encargado();
                            encargado.IdEncargado = reader["ID_Encargado"].ToString();
                            encargado.NombreEncargado = reader["Nombre"].ToString();
                            encargado.CorreoEncargado = reader["Correo"].ToString();
                            encargado.CargoOrganizacion = reader["CARGO"].ToString();
                            encargado.TelefonoEncargado = reader["Teléfono"].ToString();


                            listaEncargados.Add(encargado);
                        }
                    }
                }
                connection.Close();
            }

            return listaEncargados;
        }

        /// <summary>Obtiene todos los encargados de la base de datos.</summary>
        /// <returns>lista de encargados</returns>
        /// <exception cref="SqlException"> en caso de error en la base de datos</exception>
        public List<Encargado> GetEncargado()
        {
            List<Encargado> listaEncargado = new List<Encargado>();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                 connection.Open();
                }
                catch (SqlException)
                {
                    return listaEncargado;
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Encargado", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Encargado encargado = new Encargado();
                        Organizacion organizacion = new Organizacion();
                        encargado.Organizacion = organizacion;
                        encargado.IdEncargado = reader["ID_Encargado"].ToString();
                        encargado.NombreEncargado = reader["Nombre"].ToString();
                        encargado.CorreoEncargado = reader["Correo"].ToString();
                        encargado.CargoOrganizacion = reader["CARGO"].ToString();
                        encargado.TelefonoEncargado = reader["teléfono"].ToString();
                        encargado.Organizacion.NombreOrganizacion = reader["Organización"].ToString();
                        listaEncargado.Add(encargado);
                    }
                }
                connection.Close();
            }

            return listaEncargado;
        }

        /// <summary>Añade un encargado a la base de datos.</summary>
        /// <param name="encargado">El encargado.</param>
        /// <returns>Resultado de la operación</returns>
        /// <exception cref=" SqlException">En caso de que ocurra un error al agregar el Encargado</exception>
        public AddResult AddEncargado(Encargado encargado)
        {
            AddResult resultado = AddResult.UnknowFail;
            
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
                }
                
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Encargado VALUES(@Nombre, @Correo, @Cargo, @Telefono, @Organizacion)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Nombre",encargado.NombreEncargado));
                    command.Parameters.Add(new SqlParameter("@Cargo", encargado.CargoOrganizacion));
                    command.Parameters.Add(new SqlParameter("@Correo", encargado.CorreoEncargado));
                    command.Parameters.Add(new SqlParameter("@Telefono", encargado.TelefonoEncargado));
                    command.Parameters.Add(new SqlParameter("@Organizacion", encargado.Organizacion.rfc));
                    try
                    {
                        command.ExecuteNonQuery();
                        resultado = AddResult.Success;
                    }
                    catch (SqlException)
                    {
                        resultado = AddResult.UnknowFail;
                    }

                }
                connection.Close();
            }
            return resultado;
        }

    }
}
