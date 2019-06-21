using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using System.Data.SqlClient;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{

    /// <summary>Clase con los métodos para añadir, consultar y eliminar organizaciones de la base de datos</summary>
    /// <seealso cref="BusinessLogic.IOrganizacionDAO" />
    public class OrganizacionDAO : IOrganizacionDAO
    {

        /// <summary>Checa un objeto organizacion.</summary>
        /// <param name="organizacion">La organizacion.</param>
        /// <returns></returns>
        /// <exception cref="FormatException">
        /// El objeto contiene campos vacios
        /// or
        /// El RFC ingresado no cumple con los criterios" + organizacion.rfc
        /// or
        /// El telefono contiene caracteres no permitidos" + organizacion.TelefonoOrganizacion
        /// or
        /// El correo no cumple con los criterios: " + organizacion.CorreoOrganizacion
        /// </exception>
        private AddResult CheckObjectOrganizacion(Organizacion organizacion)
        {
            ValidarCampos validarCampos = new ValidarCampos();
            AddResult result = AddResult.UnknowFail;
            if (organizacion.rfc == String.Empty || organizacion.NombreOrganizacion == String.Empty || organizacion.DireccionOrganizacion == String.Empty || organizacion.Sector == String.Empty || organizacion.TelefonoOrganizacion== String.Empty || organizacion.CorreoOrganizacion == String.Empty)
            {
                throw new FormatException("El objeto contiene campos vacios");
            }else if(validarCampos.ValidarRFC(organizacion.rfc) == ValidarCampos.ResultadosValidación.RfcInválido)
            {
                throw new FormatException("El RFC ingresado no cumple con los criterios" + organizacion.rfc);
            }else if(validarCampos.ValidarNúmero(organizacion.TelefonoOrganizacion) == ValidarCampos.ResultadosValidación.TeléfonoInválido)
            {
                throw new FormatException("El telefono contiene caracteres no permitidos" + organizacion.TelefonoOrganizacion);
            }else if (validarCampos.ValidarCorreo(organizacion.CorreoOrganizacion) == ValidarCampos.ResultadosValidación.Correoinválido)
            {
                throw new FormatException("El correo no cumple con los criterios: " + organizacion.CorreoOrganizacion);
            }
            else
            {
                result = AddResult.Success;
            }
            return result;
        }

        /// <summary>Añade la organizacion.</summary>
        /// <param name="organizacion">La organizacion.</param>
        /// <returns></returns>
        public AddResult AddOrganizacion(Organizacion organizacion)
        {
            AddResult resultado = AddResult.UnknowFail;
            DbConnection dbConnection = new DbConnection();
            AddResult checkForEmpty = AddResult.UnknowFail;
            try
            {
                checkForEmpty = CheckObjectOrganizacion(organizacion);
            }
            catch (ArgumentNullException)
            {
                resultado = AddResult.NullObject;
                return resultado;
            }catch(FormatException ex)
            {
                throw ex;
            }
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Organizacion VALUES(@rfc, @nombre, @direccion,@sector, @telefono, @correo)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@rfc", organizacion.rfc));
                    command.Parameters.Add(new SqlParameter("@nombre", organizacion.NombreOrganizacion));
                    command.Parameters.Add(new SqlParameter("@direccion", organizacion.DireccionOrganizacion));
                    command.Parameters.Add(new SqlParameter("@Sector", organizacion.Sector));
                    command.Parameters.Add(new SqlParameter("@Telefono", organizacion.TelefonoOrganizacion));
                    command.Parameters.Add(new SqlParameter("@correo", organizacion.CorreoOrganizacion));
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
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

        /// <summary>Obtiene la lista de las organizacion en la base de datos.</summary>
        /// <returns>Lista de Organizacion</returns>
        public List<Organizacion> GetOrganizacion()
        {
            List<Organizacion> listaOrganizacion = new List<Organizacion>();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    return listaOrganizacion;
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Organizacion", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Organizacion organizacion = new Organizacion();
                        organizacion.rfc = reader["RFC"].ToString();
                        organizacion.NombreOrganizacion = reader["Nombre"].ToString();
                        organizacion.DireccionOrganizacion = reader["Direccion"].ToString();
                        organizacion.Sector = reader["Sector"].ToString();
                        organizacion.TelefonoOrganizacion = reader["Telefono"].ToString();
                        organizacion.CorreoOrganizacion = reader["Correo"].ToString();
                        listaOrganizacion.Add(organizacion);
                    }
                }
                connection.Close();
            }
            return listaOrganizacion;
        }

        /// <summary>Obtiene la organizacion por el RFC.</summary>
        /// <param name="toSearchInBD">El RFC a buscar en la base de datos.</param>
        /// <returns>Una Organizacion</returns>
        public Organizacion GetOrganizacionByName(String toSearchInBD)
        {
            Organizacion organizacion = new Organizacion();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Organizacion WHERE Nombre = @NameToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("NameToSearch", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        organizacion.rfc = reader["RFC"].ToString();
                        organizacion.NombreOrganizacion = reader["Nombre"].ToString();
                        organizacion.DireccionOrganizacion = reader["Direccion"].ToString();
                        organizacion.Sector = reader["Sector"].ToString();
                        organizacion.TelefonoOrganizacion = reader["Telefono"].ToString();
                        organizacion.CorreoOrganizacion = reader["Correo"].ToString();
                    }
                }
                connection.Close();
            }
            return organizacion;
        }

        /// <summary>Obtiene la organizacion por el RFC.</summary>
        /// <param name="toSearchInBD">El RFC a buscar en la base de datos.</param>
        /// <returns>Una Organizacion</returns>
        public Organizacion GetOrganizacionByRFC(String toSearchInBD)
        {
            Organizacion organizacion = new Organizacion();
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Organizacion WHERE RFC = @RFCToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("RFCToSearch", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        organizacion.rfc = reader["RFC"].ToString();
                        organizacion.NombreOrganizacion = reader["Nombre"].ToString();
                        organizacion.DireccionOrganizacion = reader["Direccion"].ToString();
                        organizacion.Sector = reader["Sector"].ToString();
                        organizacion.TelefonoOrganizacion = reader["Telefono"].ToString();
                        organizacion.CorreoOrganizacion = reader["Correo"].ToString();
                    }
                }
                connection.Close();
            }
            return organizacion;
        }

        /// <summary>Borra la organizacion por el RFC.</summary>
        /// <param name="toDeleteInDB">El RFC a borrar en la base de datos.</param>
        /// <returns>El resultado de la operacion</returns>
        public AddResult DeleteOrganizacionByRFC(String toDeleteInDB)
        {
            DbConnection dbconnection = new DbConnection();
            AddResult result = AddResult.UnknowFail;
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
                using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Organizacion WHERE RFC = @RFCToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("RFCToSearch", toDeleteInDB));
                    command.ExecuteNonQuery();
                    result = AddResult.Success;
                }
                connection.Close();
            }
            return result;

        }

        /// <summary>Obtiene una organizacion por encargado.</summary>
        /// <param name="IDEncargado">El ID de encargado.</param>
        /// <returns>Una Organizacion</returns>
        public Organizacion GetOrganizacionByEncargado(string IDEncargado)
        {
            Organizacion organizacion = new Organizacion();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    return organizacion;
                }
                using (SqlCommand command = new SqlCommand("Select Organizacion.Nombre From Organizacion, Encargado where Organizacion.RFC = Encargado.Organización and ID_Encargado = @IDEncargado", connection))
                {
                    command.Parameters.Add(new SqlParameter("IDEncargado", IDEncargado));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        organizacion.NombreOrganizacion = reader["Nombre"].ToString();


                    }
                }
                connection.Close();
            }
            return organizacion;
        }


    }
}
