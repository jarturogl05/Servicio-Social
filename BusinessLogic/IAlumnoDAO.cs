using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    interface IAlumnoDAO
    {
        List<Alumno> GetAlumno();
        Alumno GetAlumnoByName(String idToSearch);
        AddResult AddAlumno(Alumno alumno);
        
    }
}
