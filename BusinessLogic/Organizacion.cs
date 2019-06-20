using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Organizacion
    {
        public String rfc { get; set; }
        public string NombreOrganizacion { get; set; }
        public string DireccionOrganizacion { get; set; }
        public string TelefonoOrganizacion { get; set; }
        public string Sector { get; set; }
        public string CorreoOrganizacion { get; set; }

        public Organizacion()
        {
        }
        public Organizacion(string rfc, string nombre, string direccion, string telefono, string sector, string correo)
        {
            this.rfc = rfc;
            this.NombreOrganizacion = nombre;
            this.DireccionOrganizacion = direccion;
            this.TelefonoOrganizacion = telefono;
            this.Sector = sector;
            this.CorreoOrganizacion = correo;
        }
        public override String ToString()
        {
            return rfc;
        }

        public Organizacion(string rfc)
        {
            this.rfc = rfc;
        }
    }
}
