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
    /// Interaction logic for P_DatosAlumno.xaml
    /// </summary>
    public partial class P_DatosAlumno : Window
    {
        public P_DatosAlumno()
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
            if (textboxMatricula.Text == String.Empty || textboxNombre.Text == String.Empty || textboxBloque.Text == String.Empty || textboxSeccion.Text == String.Empty || comboCarrera.Text == String.Empty)
            {
                check = CheckResult.Failed;
            }
            else
            {
                check = CheckResult.Passed;
            }
            return check;
        }
        public P_DatosAlumno(String Matricula)
        {
            InitializeComponent();
            AlumnoController alumnoController = new AlumnoController();
            var alumno = alumnoController.GetAlumnoByMatricula(Matricula);
            textboxBloque.Text = alumno.Bloque;
            textboxMatricula.Text = alumno.Matricula;
            textboxNombre.Text = alumno.NombreAlumno;
            textboxSeccion.Text = alumno.NombreAlumno;
            comboCarrera.Text = alumno.Carrera;
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionalidad no implementada");
        }

        private void ButtonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta es una operacion destructiva. \n ¿Desea Continuar?", "¿Esta seguro?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes))
            {
                AlumnoController alumnoController = new AlumnoController();
                ComprobarResultado((OperationResult)alumnoController.DeleteAlumno(textboxMatricula.Text));
            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ComprobarResultado(OperationResult result)
        {
            if (result == OperationResult.Success)
            {
                MessageBox.Show("Operacion realizada con exito");
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
    }
}
