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
    /// Interaction logic for P_PrincipalDirector.xaml
    /// </summary>
    public partial class P_PrincipalDirector : Window
    {
        public P_PrincipalDirector()
        {
            InitializeComponent();
        }

        private void Btn_AgregarCoordinador_Click(object sender, RoutedEventArgs e)
        {
            P_Registrar_Cooordinador p_Registrar_Cooordinador = new P_Registrar_Cooordinador();
            p_Registrar_Cooordinador.ShowDialog();
        }

        private void Btn_CerrarSesión_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UserID = String.Empty;
            Properties.Settings.Default.UserType = String.Empty;
            Properties.Settings.Default.Save();
            P_UserLogin p_UserLogin = new P_UserLogin();
            p_UserLogin.Show();
            this.Close();
        }

        private void Btn_AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            P_RegisterUser p_RegisterUser = new P_RegisterUser();
            p_RegisterUser.ShowDialog();
        }
    }
}
