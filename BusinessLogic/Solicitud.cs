using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Solicitud
    {
        public string FechaSolicitud { get; set; }
        public string EstadoSolicitud { get; set; }
        public List<Proyecto> Proyectos { get; set; }
        public Alumno Alumno { get; set; }

    }
}
