using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using System.Data.SqlClient;

namespace BusinessLogic
{
    class OrganizacionDAO : IOrganizacionDAO
    {
        public bool AddOrganizacion(Organizacion organizacion)
        {
            bool resultado = false;
            DbConnection dbConnection = new DbConnection();
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
                    command.ExecuteNonQuery();
                    resultado = true;
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
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Organizacion", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Organizacion organizacion = new Organizacion();
                        organizacion.rfc = reader["RFC"].ToString();
                        organizacion.NombreOrganizacion = reader["Nombre"].ToString();
                        organizacion.NombreOrganizacion = reader["Direccion"].ToString();
                        organizacion.Sector = reader["Sector"].ToString();
                        organizacion.TelefonoOrganizacion = reader.ToString();
                        organizacion.CorreoOrganizacion = reader.ToString();
                    }
                }
                connection.Close();
            }
            return listaOrganizacion;
        }
        public Organizacion GetOrganizacionByID(String toSearchInBD)
        {
            Organizacion organizacion = new Organizacion();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Organizacion WHERE RFC = @rfcToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("rfcToSearch", toSearchInBD));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        organizacion.rfc = reader["RFC"].ToString();
                        organizacion.NombreOrganizacion = reader["Nombre"].ToString();
                        organizacion.NombreOrganizacion = reader["Direccion"].ToString();
                        organizacion.Sector = reader["Sector"].ToString();
                        organizacion.TelefonoOrganizacion = reader.ToString();
                        organizacion.CorreoOrganizacion = reader.ToString();
                    }
                }
                connection.Close();
            }
            return organizacion;
        }
    }
}
