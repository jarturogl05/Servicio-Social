using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ControladorOrganización
    {
        public List<Organizacion> ObtenerOrganizaciones()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            List<Organizacion> organizacions = organizacionDAO.GetOrganizacion();
            return organizacions;
        }

    }
}
