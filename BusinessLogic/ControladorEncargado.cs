using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ControladorEncargado
    {
        EncargadoDAO encargadoDAO = new EncargadoDAO();
        OrganizacionDAO organizacionDAO = new OrganizacionDAO();

        public AddResult AñadirEncargado(string nombre, string cargo, string teléfono, string correo, string Nombreorganización)
        {
            Organizacion organizacion = organizacionDAO.GetOrganizacionByName(Nombreorganización);
            Encargado encargado = new Encargado(nombre, cargo, correo, teléfono, organizacion);
            return encargadoDAO.AddEncargado(encargado);
        }

        public List<Encargado> GetEncargados(string organización)
        {
            return encargadoDAO.GetEncargadoByOrganización(organización);
        }
    }
}
