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
    public partial class P_RegistrarAlumno : Window
    {
        public P_RegistrarAlumno()
        {
            InitializeComponent();
        }
        private enum CheckResult
        {
            Passed,
            Failed
        }
        public enum OperationResult
        {
            Success,
            NullOrganization,
            InvalidOrganization,
            UnknowFail,
            SQLFail,
            ExistingRecord
        }
        private CheckResult CheckEmptyFields()
        {
            CheckResult check = CheckResult.Failed;
            if (textboxMatricula.Text == String.Empty || textboxNombre.Text == String.Empty || comboBloque.Text == String.Empty || comboSeccion.Text == String.Empty || comboCarrera.Text == String.Empty || alumnoPassword.Password == String.Empty)
            {
                check = CheckResult.Failed;
            }
            else
            {
                check = CheckResult.Passed;
            }
            return check;
        }
        private CheckResult CheckFields()
        {
            CheckResult check = CheckResult.Failed;
            ValidarCampos validarCampos = new ValidarCampos();
            if (CheckEmptyFields() == CheckResult.Failed)
            {
                MessageBox.Show("Existen campos sin llenar");
                check = CheckResult.Failed;
            }
            else if (validarCampos.ValidarPassword(alumnoPassword.Password) == ValidarCampos.ResultadosValidación.ContraseñaInválida)
            {
                MessageBox.Show("La contraseña es muy débil \n Intenta combinar letras mayúsculas, minúsculas y números");
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
                MessageBox.Show("Añadido con exito");
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
            else if (result == OperationResult.ExistingRecord)
            {
                MessageBox.Show("El alumno ya existe en el sistema");
            }
        }

        private void ButtonRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            if (alumnoPassword.Password == alumnoPasswordRepite.Password)
            {
                if (CheckFields() == CheckResult.Passed)
                {
                    AlumnoController alumnoController = new AlumnoController();
                    ComprobarResultado((OperationResult)alumnoController.AddAlumno(textboxMatricula.Text,textboxNombre.Text,comboSeccion.Text,comboBloque.Text,comboCarrera.Text,alumnoPassword.Password));
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                alumnoPassword.Password = String.Empty;
                alumnoPasswordRepite.Password = String.Empty;
            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
