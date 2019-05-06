using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Alumno
    {
        public string Matricula { get; set; }
        public string NombreAlumno { get; set; }
        public String Seccion { get; set; }
        public String Correo { get; set; }
        public String Bloque { get; set; }
        public String Carrera { get; set; }
        public String Estado { get; set; }
        public String Visibilidad { get; set; }

        public Alumno()
        {
        }
        public Alumno(string matricula, string seccion, string correo, string bloque, string nombre, string carrera, string estado, string visibilidad)
        {
            this.Matricula = matricula;
            this.Seccion = seccion;
            this.Correo = correo;
            this.Bloque = bloque;
            this.NombreAlumno = nombre;
            this.Carrera = carrera;
            this.Estado = estado;
            this.Visibilidad = visibilidad;
        }
    }
}
