using Controller;
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
        private CheckResult CheckFields()
        {
            CheckResult check = CheckResult.Failed;
            ValidarCampos validarCampos = new ValidarCampos();
            if (CheckEmptyFields() == CheckResult.Failed)
            {
                MessageBox.Show("Existen campos sin llenar");
                check = CheckResult.Failed;
            }
            else if (validarCampos.ValidarRFC(textboxRFC.Text) == ValidarCampos.ResultadosValidación.RfcInválido)
            {
                MessageBox.Show("El RFC ingresado es inválido");
            }
            else if (validarCampos.ValidarNúmero(textboxTelefono.Text) == ValidarCampos.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("El numero contiene caracteres no validos");
                check = CheckResult.Failed;
            }
            else if (validarCampos.ValidarCorreo(textboxCorreo.Text) == ValidarCampos.ResultadosValidación.Correoinválido)
            {
                MessageBox.Show("El correo ingresado no es valido");
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
            }else if (result == OperationResult.ExistingRecord)
            {
                MessageBox.Show("El registro ya existe en el sistema");
            }
        }
        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields() == CheckResult.Passed)
            {
                OrganizacionController organizacionController = new OrganizacionController();
                ComprobarResultado ((OperationResult)organizacionController.AddOrganizacion(textboxRFC.Text, textboxNombre.Text, textboxDireccion.Text, textboxSector.Text, textboxTelefono.Text, textboxCorreo.Text));
            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
