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
                        encargado.TelefonoEncargado = reader["Tel�fono"].ToString();

                    }
                }
                connection.Close();
            }

            return encargado;
        }

        public Encargado GetEncargadoByNombre(string nombre)
        {
            Encargado encargado = new Encargado();
            Organizacion organizacion = new Organizacion();
            DbConnection dbconnection = new DbConnection();
            using (SqlConnection connection = dbconnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Encargado WHERE Nombre = @nombre", connection))
                {
                    command.Parameters.Add(new SqlParameter("Nombre", nombre));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        encargado.IdEncargado = reader["ID_Encargado"].ToString();
                        encargado.NombreEncargado = reader["Nombre"].ToString();
                        encargado.CorreoEncargado = reader["Correo"].ToString();
                        encargado.CargoOrganizacion = reader["Cargo"].ToString();
                        encargado.TelefonoEncargado = reader["Tel�fono"].ToString();
                        organizacion.rfc = reader["Organizaci�n"].ToString();
                    }
                }
                connection.Close();
            }
            encargado.Organizacion = organizacion; 
            return encargado;
        }


        public List<Encargado> GetEncargadoByOrganizaci�n(Organizacion organizaci�n)
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Encargado WHERE Organizaci�n = @organizacion", connection))
                {
                    command.Parameters.Add(new SqlParameter("@organizacion", organizaci�n.rfc));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Encargado encargado = new Encargado();
                            encargado.IdEncargado = reader["ID_Encargado"].ToString();
                            encargado.NombreEncargado = reader["Nombre"].ToString();
                            encargado.CorreoEncargado = reader["Correo"].ToString();
                            encargado.CargoOrganizacion = reader["CARGO"].ToString();
                            encargado.TelefonoEncargado = reader["Tel�fono"].ToString();


                            listaEncargados.Add(encargado);
                        }
                    }
                }
                connection.Close();
            }

            return listaEncargados;
        }



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
                        encargado.TelefonoEncargado = reader["tel�fono"].ToString();
                        encargado.Organizacion.NombreOrganizacion = reader["Organizaci�n"].ToString();
                        listaEncargado.Add(encargado);
                    }
                }
                connection.Close();
            }

            return listaEncargado;
        }


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
                    catch (InvalidOperationException)
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
