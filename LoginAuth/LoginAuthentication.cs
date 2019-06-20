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
