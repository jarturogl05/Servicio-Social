using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;
using BusinessLogic;

namespace Controller
{
    /// <summary>Clase para comunicar la capa de UI con la de BusinessLogic</summary>
    public class ControladorCoordinador
    {
        /// <summary>Crea objetos coordinador y usuario para comunicarlos con los dao</summary>
        /// <param name="nombre"> Nombre.</param>
        /// <param name="númeroPersonal">número personal.</param>
        /// <param name="carrera"> carrera.</param>
        /// <param name="correo">correo.</param>
        /// <param name="contraseña"> contraseña.</param>
        /// <returns>Resultado de la operación</returns>
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
