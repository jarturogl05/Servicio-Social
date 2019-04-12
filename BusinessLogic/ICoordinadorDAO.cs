using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ICoordinadorDAO
    {
        List<Encargado> GetEncargado();        
        void AddCoordinador(Coordinador coordinador);
        Encargado GetEncargadoByID(string toSearch); 
    }
}
