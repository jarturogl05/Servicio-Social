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
    public class EncargadoDAO : IEncargadoDAO
    {

        public Encargado GetEncargadoByID(string toSearch)
        {
            Encargado encargado = new Encargado();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Encargado WHERE ID_Encargado = @idToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("idToSearch", toSearch));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        encargado.IdEncargado = reader["ID_Encargado"].ToString();
                        encargado.NombreEncargado = reader["Nombre"].ToString();
                        encargado.CorreoEncargado = reader["Correo"].ToString();
                        encargado.CargoOrganizacion = reader["CARGO"].ToString();
                        encargado.TelefonoEncargado = reader["TELEFONO"].ToString();
                        encargado.Organizacion.NombreOrganizacion = reader["ORGANIZACION"].ToString();
                    }
                }
                connection.Close();
            }

            return encargado;
        }        
        
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


        public AddResult AddEncargado(Encargado encargado)
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
                }
                
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Encargado VALUES(@ID_Encargado, @Nombre, @Cargo, @Correo, @Telefono, @Organizacion)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@ID_Encargado", encargado.IdEncargado));
                    command.Parameters.Add(new SqlParameter("@Nombre",encargado.NombreEncargado));
                    command.Parameters.Add(new SqlParameter("@Cargo", encargado.CargoOrganizacion));
                    command.Parameters.Add(new SqlParameter("@Correo", encargado.CorreoEncargado));
                    command.Parameters.Add(new SqlParameter("@Telefono", encargado.TelefonoEncargado));
                    command.Parameters.Add(new SqlParameter("Organizacion", encargado.Organizacion.NombreOrganizacion));
                    command.ExecuteNonQuery();
                    resultado = AddResult.Success;
                }
                connection.Close();
            }
            return resultado;
        }


       





    }
}
