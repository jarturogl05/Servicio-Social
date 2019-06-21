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
    public class ControladorEncargado
    {

        /// <summary>  Crea un objeto encargado y lo comunica con el DAO correspondiente</summary>
        /// <param name="nombre"> nombre.</param>
        /// <param name="cargo"> Cargo.</param>
        /// <param name="teléfono">teléfono.</param>
        /// <param name="correo"> correo.</param>
        /// <param name="organizacionSelected">organizacion seleccionada.</param>
        /// <returns>Resultado de la operación</returns>
        public AddResult AñadirEncargado(string nombre, string cargo, string teléfono, string correo, Object organizacionSelected)
        {
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            Encargado encargado = new Encargado(nombre, cargo, correo, teléfono, (Organizacion)organizacionSelected);
            return encargadoDAO.AddEncargado(encargado);
        }

        /// <summary>Manda la organización seleccionada al DAO de encargados para regresar los encargados de la empresa</summary>
        /// <param name="organización">organización.</param>
        /// <returns>Una lista de encargados</returns>
        public List<Encargado> GetEncargados(Object organización)
        {
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            return encargadoDAO.GetEncargadoByOrganización((Organizacion) organización);
        }

        /// <summary>  Obtiene encargado por id</summary>
        /// <param name="idEncarado">El id del encargado</param>
        /// <returns>Nombre del encargado</returns>
        public string GetEncargado(string idEncarado)
        {
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            Encargado encargado = encargadoDAO.GetEncargadoByID(idEncarado);
            return encargado.NombreEncargado;

        }
    }
}
