using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ProyectoDAO : IProyectoDAO
    {

        public Proyecto GetProyectoByID(String toSearch)
        {
            Proyecto proyecto = new Proyecto();
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Proyecto WHERE ID_Proyecto=@idToSearch", connection))
                {
                    command.Parameters.Add(new SqlParameter("@idToSearch", toSearch));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        proyecto.Actividades = reader["Actividades"].ToString();
                        proyecto.NombreProyecto = reader["Nombre"].ToString();
                        proyecto.NumeroAlumnos = Convert.ToInt32(reader["Numero_Alumnos"].ToString());
                        proyecto.Horario = reader["Horario"].ToString();
                        proyecto.Lugar = reader["Lugar"].ToString();
                        proyecto.Requisitos = reader["Requisitos"].ToString();
                    }

                }
                connection.Close();
            }
            return proyecto;


        public void AddProyecto(Proyecto proyecto)
        {
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Proyecto VALUES (@Nombre, @NumeroDeAlumnos," +
                    " @EstadoProyecto, @Horario, @Lugar, @Actividades, @Requisitos, @Coordinador, @Encargado)", connection)) 
                {
                    command.Parameters.Add(new SqlParameter("@Nombre",proyecto.NombreProyecto));
                    command.Parameters.Add(new SqlParameter("@NumeroDelAlumnos", proyecto.NumeroAlumnos));
                    command.Parameters.Add(new SqlParameter("@EstadoProyecto", proyecto.EstadoProyetcto));
                    command.Parameters.Add(new SqlParameter("@Horario", proyecto.Horario));
                    command.Parameters.Add(new SqlParameter("@Lugar", proyecto.Lugar));
                    command.Parameters.Add(new SqlParameter("@Actividades", proyecto.Actividades));
                    command.Parameters.Add(new SqlParameter("@Requisitos", proyecto.Requisitos));
                    command.Parameters.Add(new SqlParameter("@Coordinador", proyecto.Coordinador.NombreCoordinador));
                    command.Parameters.Add(new SqlParameter("@Encargado", proyecto.Encargado.NombreEncargado));
                    command.ExecuteNonQuery();
                    
                }
                connection.Close();

            }


        }

        public List<Proyecto> GetProyectos()
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            DbConnection dbConnection = new DbConnection();
            using(SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SELECT * FROM PROYECTO", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Proyecto proyecto = new Proyecto();
                        proyecto.NombreProyecto = reader["Nombre"].ToString();
                        proyecto.NumeroAlumnos = Convert.ToInt32(reader["Número De alumnos"].ToString());
                        proyecto.EstadoProyetcto = reader["Proyecto"].ToString();
                        proyecto.Horario = reader["Horario"].ToString();
                        proyecto.Lugar = reader["lugar"].ToString();
                        proyecto.Actividades = reader["Actividades"].ToString();
                        proyecto.Requisitos = reader["Requisitos"].ToString();
                        proyecto.Coordinador.NombreCoordinador = reader["Coordinador"].ToString();
                        proyecto.Encargado.NombreEncargado = reader["Encargado"].ToString();
                        proyectos.Add(proyecto);
                            
                    }
                }
                connection.Close();
            }
            return proyectos;
        }
    }
}
