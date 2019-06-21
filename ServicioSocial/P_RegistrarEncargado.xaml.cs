using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for P_RegistrarEncargado.xaml
    /// </summary>
    public partial class P_RegistrarEncargado : Window
    {
        public P_RegistrarEncargado()
        {

            InitializeComponent();
            LlenarOrganizaciones();
        }



        /// <summary>Handles the Click event of the Btn_Aceptar control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {

            if (ValidarCamposVacios() && ValidarCorreo() && ValidarTeléfono())
            {
                ControladorEncargado controladorEncargado = new ControladorEncargado();
                if (controladorEncargado.AñadirEncargado(txb_NombreCompleto.Text, txb_Cargo.Text, txt_Teléfono.Text , tbx_CorreoElectrónico.Text 
                    ,cbb_Organización.SelectedItem) == AddEnum.AddResult.Success)
                {
                    MessageBox.Show("Encargado Agregado con éxito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el encargado");
                }
            }

        }
        /// <summary>  Validar si existen campos vacios</summary>
        /// <returns>Resultado de la validación</returns>
        private bool ValidarCamposVacios()
        {
            if(string.IsNullOrEmpty(txb_NombreCompleto.Text) || string.IsNullOrEmpty(txb_Cargo.Text) || string.IsNullOrEmpty(txt_Teléfono.Text)
                || string.IsNullOrEmpty(tbx_CorreoElectrónico.Text) || cbb_Organización.SelectedIndex == -1)
            {
                MessageBox.Show("Debes llenar todos los campos");
                return false;
            }
            return true;
        }
        /// <summary>  Valida la la estructura del correo electónico</summary>
        /// <returns>el resultado de la validación</returns>
        private bool ValidarCorreo()
        {
            ValidarCampos ValidarCampos = new ValidarCampos();
            if (ValidarCampos.ValidarCorreo(tbx_CorreoElectrónico.Text) == ValidarCampos.ResultadosValidación.Correoinválido)
            {
                MessageBox.Show("Debes escribir un correo válido");
                return false;
            }
            return true;
        }

        /// <summary>  Llena el combobox con las organizaciones</summary>
        private void LlenarOrganizaciones()
        {
            ControladorOrganización controladorOrganización = new ControladorOrganización();
            List<Organizacion> organizacions = controladorOrganización.ObtenerOrganizaciones();
            if (!organizacions.Any())
            {
                MessageBox.Show("No se encontraron organizaciones");
            }
            else
            {
                cbb_Organización.ItemsSource = organizacions;
            }

            
        }
        /// <summary>  Valida la la estructura del teléfono</summary>
        /// <returns>el resultado de la validación</returns>
        private bool ValidarTeléfono()
        {
            ValidarCampos ValidarCampos = new ValidarCampos();
            if (ValidarCampos.ValidarNúmero(txt_Teléfono.Text) == ValidarCampos.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("Debes escribir un teléfono válido");
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
