using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    interface IUsuarioDAO
    {
        AddResult AddUsuario(Usuario organizacion);
    }
}
