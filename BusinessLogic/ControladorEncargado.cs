using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    public class ControladorEncargado
    {
        EncargadoDAO encargadoDAO = new EncargadoDAO();
        OrganizacionDAO organizacionDAO = new OrganizacionDAO();

        public AddResult AñadirEncargado(string nombre, string cargo, string teléfono, string correo, Object organizacionSelected)
        {
            Encargado encargado = new Encargado(nombre, cargo, correo, teléfono, (Organizacion)organizacionSelected);
            return encargadoDAO.AddEncargado(encargado);
        }

        public List<Encargado> GetEncargados(Object organización)
        {
            return encargadoDAO.GetEncargadoByOrganización((Organizacion) organización);
        }

        public string GetEncargado(string idEncarado)
        {
            Encargado encargado = encargadoDAO.GetEncargadoByID(idEncarado);
            return encargado.NombreEncargado;

        }
    }
}
