using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IProyectoDAO
    {
       List<Proyecto> GetProyectos();
       void AddProyecto(Proyecto proyecto);

       

    
    }
}
