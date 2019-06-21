using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLogic;
using Controller;

namespace ServicioSocial
{
    /// <summary>
    /// Interaction logic for P_Registrar_Cooordinador.xaml
    /// </summary>
    public partial class P_Registrar_Cooordinador : Window
    {
        public P_Registrar_Cooordinador()
        {

            InitializeComponent();
        }


        private void Cbb_Carrera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>Handles the Click event of the Btn_Aceptar control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            ControladorCoordinador controladorCoordinador = new ControladorCoordinador();
            if ( ValidarCamposVacios() && ValidarCorreo() && ValidarPassword() && ValidarNúmeroPersonal())
            {
                if(controladorCoordinador.AñadirCoordinador(txb_NombreCompleto.Text,txb_NúmeroPersonal.Text, cbb_Carrera.Text, txb_Correo.Text, psb_Contraseña.Password) == AddEnum.AddResult.Success)
                {
                    MessageBox.Show("Coordinador agregado con éxito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el coordinador, intentelo más tarde");
                }
            }

         
            
        }

        /// <summary>  Validar si existen campos vacios</summary>
        /// <returns>Resultado de la validación</returns>
        private bool ValidarCamposVacios()
        {
            if(string.IsNullOrEmpty(txb_NombreCompleto.Text) || string.IsNullOrEmpty(txb_Correo.Text) || string.IsNullOrEmpty(txb_NúmeroPersonal.Text)
                || cbb_Carrera.SelectedIndex == -1 || string.IsNullOrWhiteSpace(psb_Contraseña.Password))
            {
                MessageBox.Show("Debes llenar todos los campos");
                return false;
            }
            return true;            
        }

        /// <summary>  Valida la la estructura de la contraseña</summary>
        /// <returns>el resultado de la validación</returns>
        private bool ValidarPassword()
        {
            ValidarCampos validarCampos = new ValidarCampos();
            if (validarCampos.ValidarPassword(psb_Contraseña.Password) == ValidarCampos.ResultadosValidación.ContraseñaInválida)
            {
                MessageBox.Show("Las contraseñas deben de tener por lo menos 8 carácteres, alfanumérica y por lo menos una letra mayúscula");
                return false;

            }
            return true;
        }

        /// <summary>  Valida que el número personal solo contenga números</summary>
        /// <returns>el resultado de la operación</returns>
        private bool ValidarNúmeroPersonal()
        {
            ValidarCampos validarCampos = new ValidarCampos();
            if (validarCampos.ValidarNúmero(txb_NúmeroPersonal.Text) == ValidarCampos.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("El campo Número personal solo acepta números");
                return false;
            }
            return true;
        }

        /// <summary>  Valida la la estructura del correo electónico</summary>
        /// <returns>el resultado de la validación</returns>
        private bool ValidarCorreo()
        {
            ValidarCampos validarCampos = new ValidarCampos();
            if (validarCampos.ValidarCorreo(txb_Correo.Text) == ValidarCampos.ResultadosValidación.Correoinválido)
            {
                MessageBox.Show("El correo es inválido");
                return false;
            }
            return true;
        }

        /// <summary>Handles the Click event of the Btn_Cancelar control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
