using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Proyecto
    {
        public string NombreProyecto { get; set; }
        public int NumeroAlumnos { get; set; }
        public string EstadoProyetcto { get; set; }
        public string Horario { get; set; }
        public string Lugar { get; set; }
        public string Actividades { get; set; }
        public string Requisitos { get; set; }

        public Coordinador Coordinador { get; set; }
        public Encargado Encargado { get; set; }
    }
}
