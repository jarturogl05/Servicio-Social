using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>Clase con los atributos del una solicitud</summary>
    public class Solicitud
    {
        public string FechaSolicitud { get; set; }
        public string EstadoSolicitud { get; set; }
        public List<Proyecto> Proyectos { get; set; }
        public Alumno Alumno { get; set; }

        public Solicitud()
        {

        }

        public Solicitud (String FechaSolicitud, string EstadoSolicitud,List<Proyecto> proyectos, Alumno alumno)
        {
            this.FechaSolicitud = FechaSolicitud;
            this.EstadoSolicitud = EstadoSolicitud;
            this.Proyectos = proyectos;
            this.Alumno = alumno;

        }

        public Solicitud(Alumno alumno)
        {
            this.Alumno = alumno;
        }
     

    }
}
