using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Proyecto
    {
        public int IDProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public int NumeroAlumnos { get; set; }
        public string EstadoProyecto { get; set; }
        public string Horario { get; set; }
        public string Lugar { get; set; }
        public string Actividades { get; set; }
        public string Requisitos { get; set; }

        public Coordinador Coordinador { get; set; }
        public Encargado Encargado { get; set; }

        public Proyecto()
        {

        }

        public Proyecto(string NombreProyecto,int NumeroAlumnos, string EstadoProyecto, string Horario,
            string Lugar, string Actividades, string Requisitos, Coordinador coordinador, Encargado encargado )
        {

            this.NombreProyecto = NombreProyecto;
            this.NumeroAlumnos = NumeroAlumnos;
            this.EstadoProyecto = EstadoProyecto;
            this.Horario = Horario;
            this.Lugar = Lugar;
            this.Actividades = Actividades;
            this.Requisitos = Requisitos;
            this.Coordinador = coordinador;
            this.Encargado = encargado;
        }
    }

   
}
