﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class Encargado
    {
        public string IdEncargado { get; set; }
        public string NombreEncargado { get; set; }
        public string CargoOrganizacion { get; set; }
        public string CorreoEncargado { get; set; }
        public string TelefonoEncargado { get; set; }

        public Organizacion Organizacion;


        public Encargado()
        {

        }

        public Encargado(string IdEncargado, string NombreEncargado, string CargoOrganizacion,
            string CorreoEncargado,string TelefonoEncargado, Organizacion organizacion)
        {
            this.IdEncargado = IdEncargado;
            this.NombreEncargado = NombreEncargado;
            this.CargoOrganizacion = CargoOrganizacion;
            this.CorreoEncargado = CorreoEncargado;
            this.TelefonoEncargado = TelefonoEncargado;
            this.Organizacion = organizacion;
        }

       

    }
}
