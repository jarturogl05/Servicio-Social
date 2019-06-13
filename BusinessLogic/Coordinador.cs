using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Coordinador
    {

        public String NombreCoordinador { get; set; }
        public String Carrera { get; set; }
        public int NumeroPersonal { get; set; }

        public Coordinador()
        {

        }

        public Coordinador(String NombreCoordinador, String Carrera, int NumeroPersonal)
        {
            this.NombreCoordinador = NombreCoordinador;
            this.Carrera = Carrera;
            this.NumeroPersonal = NumeroPersonal;
        }

        public Coordinador(string NombreCoordinador)
        {
            this.NombreCoordinador = NombreCoordinador;
        }


    }
}
