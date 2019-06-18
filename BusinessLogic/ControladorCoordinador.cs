using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    public class ControladorCoordinador
    {
        CoordinadorDAO coordinadorDAO = new CoordinadorDAO();
        UsuarioDAO usuarioDAO = new UsuarioDAO();



        public AddResult AñadirCoordinador(string nombre, string  númeroPersonal, string carrera, string correo, string contraseña)
        {

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
