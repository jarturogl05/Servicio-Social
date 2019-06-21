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
    public partial class P_DatosAlumno : Window
    {
        public P_DatosAlumno()
        {
            InitializeComponent();
        }
        public enum OperationResult
        {
            Success,
            NullOrganization,
            InvalidOrganization,
            UnknowFail,
            SQLFail,
        }
        public P_DatosAlumno(String Matricula)
        {
            InitializeComponent();
            AlumnoController alumnoController = new AlumnoController();
            var alumno = alumnoController.GetAlumnoByMatricula(Matricula);
            comboBloque.Text = alumno.Bloque;
            comboAsignacion.Text = alumno.Estado;
            comboSeccion.Text = alumno.Seccion;
            comboCarrera.Text = alumno.Carrera;
            textboxMatricula.Text = alumno.Matricula;
            textboxNombre.Text = alumno.NombreAlumno;
            textboxCorreo.Text = alumno.Correo;
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

        /// <summary>Comprueba el resultado de la operacion.</summary>
        /// <param name="result">El resultado.</param>
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
