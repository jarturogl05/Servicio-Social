using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Controller.OrganizacionController;

namespace Controller
{
    public class UsuarioController
    {
        public OperationResult AddUsuario(String nombre, String correo, String tipoUsuario, String usuario, String contraseña)
        {
            OperationResult operation = OperationResult.UnknowFail;
            if (GetUsuarioByUsername(usuario).UserName == null)
            {
                Usuario user = new Usuario();
                user.Name = nombre;
                user.Email = correo;
                user.UserType = tipoUsuario;
                user.UserName = usuario;
                user.Password = contraseña;
                user.RegisterDate = DateTime.Today;
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                operation = (OperationResult)usuarioDAO.AddUsuario(user);
            }
            else
            {
                operation = OperationResult.ExistingRecord;
            }

            return operation;
        }
        public Usuario GetUsuarioByUsername(String username)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            return usuarioDAO.GetUsuarioByUsername(username);
        }

    }
}
