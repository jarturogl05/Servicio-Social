using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IOrganizacionDAO
    {
        List<Organizacion> GetOrganizacion();
        Organizacion GetOrganizacionByID(String idToSearch);
        bool AddOrganizacion(Organizacion organizacion);
    }
}
