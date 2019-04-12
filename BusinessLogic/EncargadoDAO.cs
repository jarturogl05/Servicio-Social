using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EncargadoDAO : IEncargadoDAO
    {
        
        public List<Encargado> GetEncargado()
        {
            List<Encargado> listaEncargado = new List<Encargado>();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Encargado", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Encargado encargado = new Encargado();
                        encargado.IdEncargado = reader["ID_Encargado"].ToString();
                        encargado.NombreEncargado = reader["Nombre"].ToString();
                        encargado.CorreoEncargado = reader["Correo"].ToString();
                        encargado.CargoOrganizacion = reader["CARGO"].ToString();
                        encargado.TelefonoEncargado = reader["TELEFONO"].ToString();
                        encargado.Organizacion.NombreOrganizacion = reader["ORGANIZACION"].ToString();
                        listaEncargado.Add(encargado);
                    }
                }
                connection.Close();
            }

            return listaEncargado;
        }


        public void AddEncargado(Encargado encargado)
        {
           
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Encargado VALUES(@ID_Encargado, @Nombre, @Cargo, @Correo, @Telefono, @Organizacion)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@ID_Encargado", encargado.IdEncargado));
                    command.Parameters.Add(new SqlParameter("@Nombre",encargado.NombreEncargado));
                    command.Parameters.Add(new SqlParameter("@Cargo", encargado.CargoOrganizacion));
                    command.Parameters.Add(new SqlParameter("@Correo", encargado.CorreoEncargado));
                    command.Parameters.Add(new SqlParameter("@Telefono", encargado.TelefonoEncargado));
                    command.Parameters.Add(new SqlParameter("Organizacion", encargado.Organizacion.NombreOrganizacion));
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

      




    }
}
