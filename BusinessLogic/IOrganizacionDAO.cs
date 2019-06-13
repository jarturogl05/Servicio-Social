using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    interface IOrganizacionDAO
    {
        List<Organizacion> GetOrganizacion();
        Organizacion GetOrganizacionByName(String idToSearch);
        AddResult AddOrganizacion(Organizacion organizacion);
    }
}
