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

        ValidarCampos ValidarCampos = new ValidarCampos();
        ControladorEncargado controladorEncargado = new ControladorEncargado();
        ControladorOrganización controladorOrganización = new ControladorOrganización();


        private void Btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if(ValidarCamposVacios() && ValidarCorreo())
            {
                if(controladorEncargado.AñadirEncargado(txb_NombreCompleto.Text, txb_Cargo.Text, txt_Teléfono.Text , tbx_CorreoElectrónico.Text 
                    ,cbb_Organización.Text) == AddResult.Success)
                {
                    MessageBox.Show("Encargado Agregado con éxito");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el encargado");
                }
            }

        }

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

        private bool ValidarCorreo()
        {
            if(ValidarCampos.ValidarCorreo(tbx_CorreoElectrónico.Text) == ValidarCampos.ResultadosValidación.Correoinválido)
            {
                MessageBox.Show("Debes escribir un correo válido");
                return false;
            }
            return true;
        }

        private void LlenarOrganizaciones()
        {
            
            int contador = 0;
            List<Organizacion> organizacions = controladorOrganización.ObtenerOrganizaciones();
            foreach (Organizacion organizacion in organizacions)
            {
                cbb_Organización.Items.Add(organizacions[contador].NombreOrganizacion);
                contador++;
            }
            
        }



    }
}
