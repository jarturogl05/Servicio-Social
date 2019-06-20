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
using BusinessLogic;
using Controller;

namespace ServicioSocial
{
    /// <summary>
    /// Interaction logic for P_PrincipalAlumno.xaml
    /// </summary>
    public partial class P_PrincipalAlumno : Window
    {
        public P_PrincipalAlumno()
        {
            InitializeComponent();
        }
        

        private void Btn_AgregarSolicitud_Click(object sender, RoutedEventArgs e)
        {
            if (BuscarSolicitud())
            {
                P_ProyectosEspera p_ProyectosEspera = new P_ProyectosEspera();
                p_ProyectosEspera.ShowDialog();
            }

        }
        private bool BuscarSolicitud()
        {
            ControladorSolicitud controladorSolicitud = new ControladorSolicitud();
            if (!controladorSolicitud.BuscarSolicitud(Properties.Settings.Default.UserID))
            {
                MessageBox.Show("Ya tienes una solicitud creada");
                return false;
            }
            return true;
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
    }


}
