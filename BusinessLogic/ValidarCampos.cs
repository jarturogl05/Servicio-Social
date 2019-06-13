using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class ValidarCampos
    {
        public enum ResultadosValidación
        {
            ContraseñaInválida,
            ContraseñaVálida,
            Correoinválido,
            TeléfonoInválido,
            NúmeroInválido,
            NúmeroVálido

        }

        public ResultadosValidación ValidarPassword( string contraseña)
        {
            string patrón = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,50}$";

            if (Regex.IsMatch(contraseña, patrón))
            {
                return ResultadosValidación.ContraseñaVálida;
            }
            return ResultadosValidación.ContraseñaInválida;

        }

        public ResultadosValidación ValidarNúmero(string número)
        {
            string patrón = @"^[0-9]*$";
            if(Regex.IsMatch( número, patrón))
            {
                return ResultadosValidación.NúmeroVálido;
            }
            return ResultadosValidación.NúmeroInválido;
        }

    }
}
