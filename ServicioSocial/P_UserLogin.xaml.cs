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
using static LoginAuth.LoginAuthentication;

namespace ServicioSocial
{
    public partial class P_UserLogin : Window
    {
        public P_UserLogin()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Remember == true && !String.IsNullOrEmpty(Properties.Settings.Default.Username.ToString()))
            {
                textboxUser.Text = Properties.Settings.Default.Username.ToString();
                rememberMeCheckbox.IsChecked = true;
            }
        }
        private void CheckRemember()
        {
            if (rememberMeCheckbox.IsChecked == true)
            {
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Username = textboxUser.Text.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Username = String.Empty;
                Properties.Settings.Default.Save();
            }

        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            CheckRemember();
            AuthenticationController authentication = new AuthenticationController();
            LoginData login = authentication.UserAuthentication(textboxUser.Text.ToString(), passwordBoxPass.Password);
            if (login.Result.Equals(validationResult.PasswordIncorrect))
            {
                MessageBox.Show("Contraseña invalida");
            }else if (login.Result.Equals(validationResult.UserOrPasswordIncorrect))
            {
                MessageBox.Show("Usurio y/o contraseña incorrecto");
            }else if (login.Result.Equals(validationResult.Success))
            {
                OpenWindow();
            }
            else
            {
                MessageBox.Show("Error no identificado");
            }
        }


        private void OpenWindow()
        {
            MessageBox.Show("Not implemented Exception, jeje");
        }

        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            P_RegistrarAlumno p_RegistrarAlumno = new P_RegistrarAlumno();
            p_RegistrarAlumno.ShowDialog();
        }
    }
}
