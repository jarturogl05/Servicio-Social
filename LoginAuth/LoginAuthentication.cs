using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginAuth
{

    /// <summary>Autentica al usuario conforme a los datos en la base de datos</summary>
    public class LoginAuthentication
    {
        
        public enum validationResult
        {
            Success,
            UnknownFail,
            UserOrPasswordIncorrect,
            UserIncorrect,
            PasswordIncorrect
        }

        /// <summary>Hashea un parametro ingresado.</summary>
        /// <param name="data">El parametro.</param>
        /// <returns>El parametro en SHA1</returns>
        private String PassHash(String data)
        {
            SHA1 sha = SHA1.Create();
            byte[] hashData = sha.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder stringBuilderValue = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                stringBuilderValue.Append(hashData[i].ToString());
            }
            return stringBuilderValue.ToString();
        }

        /// <summary>Compara los datos ingresados con la base de datos para buscar coincidencias.</summary>
        /// <param name="user">El usuario.</param>
        /// <param name="pass">La contraseña.</param>
        /// <returns>El resultado de la autenticacion</returns>
        public validationResult CredentialsAuthentication(String user, String pass)
        {
            validationResult result = validationResult.UnknownFail;
            DbConnection dbConnection = new DbConnection();
            String tipoString = "";
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT [Tipo_Usuario] FROM [dbo].[Usuarios] WHERE Usuario = @usuario AND Contraseña = @password", connection))
                {
                    command.Parameters.Add(new SqlParameter("@usuario", user));
                    command.Parameters.Add(new SqlParameter("@password", PassHash(pass)));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tipoString = reader["Tipo_Usuario"].ToString();
                    }

                    if (String.IsNullOrEmpty(tipoString))
                    {
                        result = validationResult.UserOrPasswordIncorrect;
                    }
                    else
                    {
                        result = validationResult.Success;
                    }

                }

            }
            return result;
        }

        /// <summary>Obtiene el tipo de usuario.</summary>
        /// <param name="user">El usuario.</param>
        /// <param name="pass">La contraseña.</param>
        /// <returns>El tipo de usuario</returns>
        public String GetUserType(String user, String pass)
        {
            String result = "";
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT [Tipo_Usuario] FROM [dbo].[Usuarios] WHERE Usuario = @usuario AND Contraseña = @password", connection))
                {
                    command.Parameters.Add(new SqlParameter("@usuario", user));
                    command.Parameters.Add(new SqlParameter("@password", PassHash(pass)));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result = reader["Tipo_Usuario"].ToString();
                    }

                }

            }
            return result;
        }

        /// <summary>Obtiene el nombre de usuario.</summary>
        /// <param name="user">El usuario.</param>
        /// <param name="pass">La contraseña.</param>
        /// <returns>El nombre de usuario</returns>
        public String GetUserName(String user, String pass)
        {
            String result = "";
            DbConnection dbConnection = new DbConnection();
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT [Usuario] FROM [dbo].[Usuarios] WHERE Usuario = @usuario AND Contraseña = @password", connection))
                {
                    command.Parameters.Add(new SqlParameter("@usuario", user));
                    command.Parameters.Add(new SqlParameter("@password", PassHash(pass)));
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result = reader["Usuario"].ToString();
                    }

                }
            }
            return result;
        }
    }
}
