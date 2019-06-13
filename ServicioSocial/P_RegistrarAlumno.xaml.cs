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
    public partial class P_RegistrarAlumno : Window
    {
        public P_RegistrarAlumno()
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
            if (textboxMatricula.Text == String.Empty || textboxNombre.Text == String.Empty || textboxBloque.Text == String.Empty || textboxSeccion.Text == String.Empty || comboCarrera.Text == String.Empty || alumnoPassword.Password == String.Empty)
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

        private void ButtonRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            if (alumnoPassword.Password == alumnoPasswordRepite.Password)
            {
                if (CheckEmptyFields() == CheckResult.Failed)
                {
                    MessageBox.Show("Debes llenar todos los campos");
                }
                else
                {
                    
                }
            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboCarrera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
