using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    interface IProyectoDAO
    {
       List<Proyecto> GetProyectos();
        List<Proyecto> GetProyectosGrid();

        AddResult AddProyecto(Proyecto proyecto);
        Proyecto GetProyectoByID(String idToSearch);
       

    
    }
}
