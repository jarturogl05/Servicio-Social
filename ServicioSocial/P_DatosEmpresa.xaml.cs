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

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionalidad no implementada");
        }

        private void ButtonEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
