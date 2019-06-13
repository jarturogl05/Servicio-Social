using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    public class ControladorCoordinador
    {
        CoordinadorDAO coordinadorDAO = new CoordinadorDAO();
        AddEnum AddEnum = new AddEnum();



        public AddResult AñadirCoordinador(string nombre, string  númeroPersonal, string carrera)
        {
            Coordinador coordinador = new Coordinador(nombre, carrera, Convert.ToInt32(númeroPersonal));
            return coordinadorDAO.AddCoordinador(coordinador);            

        }


    }
}
