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
            CorreoVálido,
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

        public ResultadosValidación ValidarNúmero(string númeroInt)
        {
            string patrón = @"^[0-9]*$";
            if(Regex.IsMatch( númeroInt, patrón))
            {
                return ResultadosValidación.NúmeroVálido;
            }
            return ResultadosValidación.NúmeroInválido;
        }

        public ResultadosValidación ValidarCorreo(string correo)
        {
            string patrón = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            if (Regex.IsMatch(correo, patrón))
            {
                return ResultadosValidación.CorreoVálido;
            }
            return ResultadosValidación.Correoinválido;
        }

        public ResultadosValidación ValidarNumAlumnos(string numAlumnos)
        {
            string patrón = @"^[0-3]$";
            if(Regex.IsMatch(numAlumnos, patrón))
            {
                return ResultadosValidación.NúmeroVálido;
            }
            return ResultadosValidación.NúmeroInválido;
        }


    }
}
