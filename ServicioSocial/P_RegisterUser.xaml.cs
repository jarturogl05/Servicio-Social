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
    /// Interaction logic for P_RegisterUser.xaml
    /// </summary>
    public partial class P_RegisterUser : Window
    {
        public P_RegisterUser()
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

        /// <summary>Checa si los campos ingresados estan vacios.</summary>
        /// <returns>El resultado del chequeo</returns>
        private CheckResult CheckEmptyFields()
        {
            CheckResult check = CheckResult.Failed;
            if (textboxUserName.Text == String.Empty || textboxEmail.Text == String.Empty || textboxName.Text == String.Empty || passwordBoxUserPass.Password == String.Empty || comboboxUserType.SelectedIndex == -1)
            {
                check = CheckResult.Failed;
            }
            else
            {
                check = CheckResult.Passed;
            }
            return check;
        }

        /// <summary>Checa por datos no validos en los datos ingresados.</summary>
        /// <returns>El resultado del chequeo</returns>
        private CheckResult CheckFields()
        {
            CheckResult check = CheckResult.Failed;
            ValidarCampos validarCampos = new ValidarCampos();
            if (CheckEmptyFields() == CheckResult.Failed)
            {
                MessageBox.Show("Existen campos sin llenar");
                check = CheckResult.Failed;
            }
            else if (validarCampos.ValidarPassword(passwordBoxUserPass.Password) == ValidarCampos.ResultadosValidación.ContraseñaInválida)
            {
                MessageBox.Show("La contraseña es muy débil \n Intenta combinar letras mayúsculas, minúsculas y números");
            }else if (validarCampos.ValidarCorreo(textboxEmail.Text) == ValidarCampos.ResultadosValidación.Correoinválido)
            {
                MessageBox.Show("El correo ingresado no es valido");
            }
            else
            {
                check = CheckResult.Passed;
            }
            return check;
        }

        /// <summary>Comprueba el resultado de la operacion.</summary>
        /// <param name="result">El resultado.</param>
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
                MessageBox.Show("El usuario ya existe en el sistema");
            }
        }


        private void ButtonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (comboboxUserType.Text == "Coordinador" || comboboxUserType.Text == "Director")
            {
                if (Properties.Settings.Default.UserType == "Director")
                {
                    if (CheckFields() == CheckResult.Passed)
                    {
                        UsuarioController usuarioController = new UsuarioController();
                        ComprobarResultado((OperationResult)usuarioController.AddUsuario(textboxName.Text, textboxEmail.Text, comboboxUserType.Text, textboxUserName.Text, passwordBoxUserPass.Password));
                    }
                }else
                {
                    MessageBox.Show("Un usuario de tipo: " + Properties.Settings.Default.UserType + " no tiene los permisos suficientes en el sistema para registrar un usuario de tipo: " + comboboxUserType.Text + ", consulte con un administrador");
                }
            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonLimpiar_Click(object sender, RoutedEventArgs e)
        {
            textboxUserName.Text = String.Empty;
            textboxEmail.Text = String.Empty;
            textboxName.Text = String.Empty;
            passwordBoxUserPass.Password = String.Empty;
            comboboxUserType.SelectedIndex = -1;

        }
    }
}
