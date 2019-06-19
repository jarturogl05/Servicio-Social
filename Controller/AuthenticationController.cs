using BusinessLogic;
using LoginAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.ValidarCampos;
using static LoginAuth.LoginAuthentication;

namespace Controller
{
    public class LoginData
    {
        public String TipoUsuario { get; set; }
        public validationResult Result { get; set; }

    }

    public class AuthenticationController
    {
        public LoginData UserAuthentication(String user, String pass)
        {
            LoginData loginData = new LoginData();
            LoginAuthentication login = new LoginAuthentication();
            if (login.CredentialsAuthentication(user, pass).Equals(validationResult.Success))
            {
                loginData.TipoUsuario = login.GetUserType(user, pass);
                loginData.Result = validationResult.Success;
            }
            else
            {
                loginData.Result = validationResult.UserOrPasswordIncorrect;
            }
            return loginData;
        }
        public String GetUserName(String user, String pass)
        {
            LoginAuthentication login = new LoginAuthentication();
            return login.GetUserName(user, pass);
            
        }
        public String GetUserType(String user, String pass)
        {
            LoginAuthentication login = new LoginAuthentication();
            return login.GetUserType(user, pass);
        }
        
    }
}
