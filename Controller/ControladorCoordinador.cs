using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;
using BusinessLogic;

namespace Controller
{
    public class ControladorCoordinador
    {



        public AddResult AñadirCoordinador(string nombre, string  númeroPersonal, string carrera, string correo, string contraseña)
        {
            CoordinadorDAO coordinadorDAO = new CoordinadorDAO();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Coordinador coordinador = new Coordinador(nombre, carrera, Convert.ToInt32(númeroPersonal));
            DateTime dateTime = DateTime.Now;
            Usuario usuario = new Usuario(númeroPersonal, contraseña, "Coordinador", dateTime, nombre, correo);
            if(coordinadorDAO.AddCoordinador(coordinador) == AddResult.Success && usuarioDAO.AddUsuario(usuario) == AddResult.Success)
            {
                return AddResult.Success;
            }
            return AddResult.UnknowFail;

        }


    }
}
