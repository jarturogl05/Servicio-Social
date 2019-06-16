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
    public class UsuarioDAO : IUsuarioDAO
    {
        public AddResult AddUsuario(Usuario usuario)
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
                    return resultado;
                }

                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Usuarios VALUES(@nombre, @correo, @registro, @tipo, @estatus, @usuario, @contraseña)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@nombre", usuario.Name));
                    command.Parameters.Add(new SqlParameter("@correo", usuario.Email));
                    command.Parameters.Add(new SqlParameter("@registro", usuario.RegisterDate));
                    command.Parameters.Add(new SqlParameter("@tipo", usuario.UserType));
                    command.Parameters.Add(new SqlParameter("@estatus", ""));
                    command.Parameters.Add(new SqlParameter("@usuario", usuario.UserName));
                    command.Parameters.Add(new SqlParameter("@contraseña", usuario.Password));
                    command.ExecuteNonQuery();
                    resultado = AddResult.Success;
                }
                connection.Close();
            }
            return resultado;
        }
    }
}
