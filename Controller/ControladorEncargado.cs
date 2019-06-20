using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;
using BusinessLogic;

namespace Controller
{
    public class ControladorEncargado
    {

        public AddResult AñadirEncargado(string nombre, string cargo, string teléfono, string correo, Object organizacionSelected)
        {
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            Encargado encargado = new Encargado(nombre, cargo, correo, teléfono, (Organizacion)organizacionSelected);
            return encargadoDAO.AddEncargado(encargado);
        }

        public List<Encargado> GetEncargados(Object organización)
        {
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            return encargadoDAO.GetEncargadoByOrganización((Organizacion) organización);
        }

        public string GetEncargado(string idEncarado)
        {
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            Encargado encargado = encargadoDAO.GetEncargadoByID(idEncarado);
            return encargado.NombreEncargado;

        }
    }
}
