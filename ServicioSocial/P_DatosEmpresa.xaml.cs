using Controller;
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

namespace ServicioSocial
{
    /// <summary>
    /// Interaction logic for P_BajaEmpresa.xaml
    /// </summary>
    public partial class P_DatosEmpresa : Window
    {
        public P_DatosEmpresa(String RFC)
        {
            InitializeComponent();
            OrganizacionController organizacionController = new OrganizacionController();
            var organizacion = organizacionController.GetOrganizacionByRFC(RFC);
            textboxNombre.Text = organizacion.NombreOrganizacion;
            textboxCorreo.Text = organizacion.CorreoOrganizacion;
            textboxDireccion.Text = organizacion.DireccionOrganizacion;
            textboxRFC.Text = organizacion.rfc;
            textboxSector.Text = organizacion.Sector;
            textboxTelefono.Text = organizacion.TelefonoOrganizacion;
        }
        public enum OperationResult
        {
            Success = 1,
            NullOrganization = 2,
            InvalidOrganization = 3,
            UnknowFail = 0,
            SQLFail = 4,
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionalidad no implementada");
        }

        private void ButtonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta es una operacion destructiva. \n ¿Desea Continuar?", "¿Esta seguro?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes))
            {
                OrganizacionController organizacionController = new OrganizacionController();
                ComprobarResultado((OperationResult)organizacionController.DeleteOrganizacion(textboxRFC.Text));

            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void ComprobarResultado(OperationResult result)
        {
            if (result == OperationResult.Success)
            {
                MessageBox.Show("Operacion realizada con exito");
                this.Close();
            }else if(result == OperationResult.UnknowFail){
                MessageBox.Show("Error desconocido");
            }else if (result == OperationResult.SQLFail)
            {
                MessageBox.Show("Error de la base de datos, intente mas tarde");
            }
        }
    }
}
