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
            Properties.Settings.Default.Reset();
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
            TryLogin();
        }

        private void TryLogin()
        {
            AuthenticationController authentication = new AuthenticationController();
            LoginData login = authentication.UserAuthentication(textboxUser.Text.ToString(), passwordBoxPass.Password);
            if (login.Result.Equals(validationResult.UserOrPasswordIncorrect))
            {
                MessageBox.Show("Usuario y/o contraseña incorrecto");
                passwordBoxPass.Password = String.Empty;
            }
            else if (login.Result.Equals(validationResult.Success))
            {
                Properties.Settings.Default.UserID = authentication.GetUserName(textboxUser.Text.ToString(), passwordBoxPass.Password);
                Properties.Settings.Default.UserType = authentication.GetUserType(textboxUser.Text.ToString(), passwordBoxPass.Password);
                CheckRemember();
                OpenWindow();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error no identificado");
            }
        }

        private void OpenWindow()
        {
            string typeUser = Properties.Settings.Default.UserType;
            switch (typeUser)
            {
                case "Coordinador":
                    P_PrincipalCoordinador p_PrincipalCoordinador = new P_PrincipalCoordinador();
                    p_PrincipalCoordinador.Show();
                    break;
                case "Director":
                    P_PrincipalDirector p_PrincipalDirector = new P_PrincipalDirector();
                    p_PrincipalDirector.Show();
                    break;
                case "Alumno":
                    P_PrincipalAlumno p_PrincipalAlumno = new P_PrincipalAlumno();
                    p_PrincipalAlumno.Show();
                    break;
            }
            
        }

        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            P_RegistrarAlumno p_RegistrarAlumno = new P_RegistrarAlumno();
            p_RegistrarAlumno.ShowDialog();
        }
    }
}
