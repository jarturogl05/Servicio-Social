using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IEncargadoDAO
    {
        List<Encargado> GetEncargado();
        void AddEncargado(Encargado encargado);

    }
}
