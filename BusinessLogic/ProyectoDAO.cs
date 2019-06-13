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

        }

        public AddResult AddProyecto(Proyecto proyecto)
        {
            AddResult resultado = AddResult.UnknownFail;
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Proyecto VALUES (@IDProyecto, @Nombre, @NumeroDeAlumnos," +
                    " @EstadoProyecto, @Horario, @Lugar, @Actividades, @Requisitos, @Coordinador, @Encargado)", connection)) 
                {
                    command.Parameters.Add(new SqlParameter("@IDProyecto", proyecto.IDProyecto));
                    command.Parameters.Add(new SqlParameter("@Nombre",proyecto.NombreProyecto));
                    command.Parameters.Add(new SqlParameter("@NumeroDeAlumnos", proyecto.NumeroAlumnos));
                    command.Parameters.Add(new SqlParameter("@EstadoProyecto", proyecto.EstadoProyecto));
                    command.Parameters.Add(new SqlParameter("@Horario", proyecto.Horario));
                    command.Parameters.Add(new SqlParameter("@Lugar", proyecto.Lugar));
                    command.Parameters.Add(new SqlParameter("@Actividades", proyecto.Actividades));
                    command.Parameters.Add(new SqlParameter("@Requisitos", proyecto.Requisitos));
                    command.Parameters.Add(new SqlParameter("@Coordinador", proyecto.Coordinador.NombreCoordinador));
                    command.Parameters.Add(new SqlParameter("@Encargado", proyecto.Encargado.NombreEncargado));
                    command.ExecuteNonQuery();
                    resultado = AddResult.Success;
                    
                }
                connection.Close();
            }
            return resultado;
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
                        Coordinador coordinador = new Coordinador();
                        Encargado encargado = new Encargado();
                        proyecto.Encargado = encargado;
                        proyecto.Coordinador = coordinador;

                        proyecto.IDProyecto = Convert.ToInt32(reader["ID_proyecto"].ToString());
                        proyecto.NombreProyecto = reader["Nombre"].ToString();
                        proyecto.NumeroAlumnos = Convert.ToInt32(reader["Número_Alumnos"].ToString());
                        proyecto.EstadoProyecto = reader["Estado_Proyecto"].ToString();
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
