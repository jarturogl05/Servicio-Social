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
    /// Interaction logic for P_RegistrarEmpresa.xaml
    /// </summary>
    public partial class P_RegistrarEmpresa : Window
    {
        public P_RegistrarEmpresa()
        {
            InitializeComponent();
        }
        private enum CheckResult
        {
            Passed = 1,
            Failed = 0
        }
        public enum OperationResult
        {
            Success = 1,
            NullOrganization = 2,
            InvalidOrganization = 3,
            UnknowFail = 0,
            SQLFail = 4,
        }
        private CheckResult CheckEmptyFields()
        {
            CheckResult check = CheckResult.Failed;
            if (textboxRFC.Text == String.Empty || textboxNombre.Text == String.Empty || textboxDireccion.Text == String.Empty || textboxSector.Text == String.Empty || textboxTelefono.Text == String.Empty || textboxCorreo.Text == String.Empty)
            {
                check = CheckResult.Failed;
            }
            else
            {
                check = CheckResult.Passed;
            }
            return check;
        }
        private void ComprobarResultado(OperationResult result)
        {
            if (result == OperationResult.Success)
            {
                MessageBox.Show("Añadido con exito \n Intenta iniciar sesion");
                this.Close();
            }
            else if (result == OperationResult.UnknowFail)
            {
                MessageBox.Show("Error desconocido");
            }
            else if (result == OperationResult.SQLFail)
            {
                MessageBox.Show("Error de la base de datos, intente mas tarde");
            }
        }
        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            OrganizacionController organizacionController = new OrganizacionController();
            ComprobarResultado ((OperationResult)organizacionController.AddOrganizacion(textboxRFC.Text, textboxNombre.Text, textboxDireccion.Text, textboxSector.Text, textboxTelefono.Text, textboxCorreo.Text));

        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
