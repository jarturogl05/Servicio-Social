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
            Passed = 1,
            Failed = 0
        }
        private CheckResult CheckEmptyFields()
        {
            CheckResult check = CheckResult.Failed;
            if (textboxUserName.Text == String.Empty || textboxEmail.Text == String.Empty || textboxName.Text == String.Empty || textboxPass.Text == String.Empty || comboboxUserType.SelectedIndex == -1)
            {
                check = CheckResult.Failed;
            }
            else
            {
                check = CheckResult.Passed;
            }
            return check;
        }

        private void ButtonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmptyFields() == CheckResult.Passed)
            {
                UsuarioController usuarioController = new UsuarioController();
                if ((int)usuarioController.AddUsuario(textboxName.Text, textboxEmail.Text,comboboxUserType.Text,textboxUserName.Text,textboxPass.Text) == 1)
                {
                    MessageBox.Show("Usuario Agregado con exito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el usuario");
                }
            }
            else
            {
                MessageBox.Show("Debes llenar todos los campos");
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
            textboxPass.Text = String.Empty;
            comboboxUserType.SelectedIndex = -1;

        }
    }
}
