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
    
    public class OrganizacionDAO : IOrganizacionDAO
    {
        public AddResult AddOrganizacion(Organizacion organizacion)
        {
            AddResult resultado = AddResult.UnknownFail;
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                }catch(SqlException)
                {
                    resultado = AddResult.SQLFail;
                    return resultado;
                }

                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Organizacion VALUES(@rfc, @nombre, @direccion,@sector, @telefono, @correo)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@rfc", organizacion.rfc));
                    command.Parameters.Add(new SqlParameter("@nombre", organizacion.NombreOrganizacion));
                    command.Parameters.Add(new SqlParameter("@direccion", organizacion.DireccionOrganizacion));
                    command.Parameters.Add(new SqlParameter("@Sector", organizacion.Sector));
                    command.Parameters.Add(new SqlParameter("@Telefono", organizacion.TelefonoOrganizacion));
                    command.Parameters.Add(new SqlParameter("@correo", organizacion.CorreoOrganizacion));
                    command.ExecuteNonQuery();
                    resultado = AddResult.Success;
                }
                connection.Close();
            }
            return resultado;
        }
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
                catch (SqlException ex)
                {
                    throw (ex);
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
        public AddResult DeleteOrganizacionByRFC(String toDeleteInDB)
        {
            DbConnection dbconnection = new DbConnection();
            AddResult result = AddResult.UnknownFail;
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
    }
}
