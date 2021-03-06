﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>Clase que tiene como funcionalidad validar la estructura de los datos introducidos por el usuario</summary>
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
            NúmeroVálido,
            RfcInválido,
            RfcVálido,
            MatriculaVálida,
            MatriculaInválida

        }

        /// <summary>  Valida la estructura correcta de una contraseña. Debe contener por lo menos 8 caracteres, una mayúscula y un número</summary>
        /// <param name="contraseña">  contraseña.</param>
        /// <returns>Resultado de la validación</returns>
        public ResultadosValidación ValidarPassword( string contraseña)
        {
            string patrón = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,50}$";

            if (Regex.IsMatch(contraseña, patrón))
            {
                return ResultadosValidación.ContraseñaVálida;
            }
            return ResultadosValidación.ContraseñaInválida;

        }

        /// <summary>  Validar que el número no tenga letras ni caracteres especiales</summary>
        /// <param name="númeroInt">número int.</param>
        /// <returns>Resultado de la validación</returns>
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
        public ResultadosValidación ValidarRFC(string rfc)
        {
            string patrón = @"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\d]{3})?$";
            if (Regex.IsMatch(rfc, patrón))
            {
                return ResultadosValidación.RfcVálido;
            }
            return ResultadosValidación.RfcInválido;
        }
        public ResultadosValidación ValidarMatricula(string matricula)
        {
            string patrón = @"^[A-Z][0-9]+$";
            if (Regex.IsMatch(matricula, patrón))
            {
                return ResultadosValidación.MatriculaVálida;
            }
            return ResultadosValidación.MatriculaInválida;
        }

    }
}
