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

namespace ServicioSocial
{
    /// <summary>
    /// Interaction logic for P_PrincipalCoordinador.xaml
    /// </summary>
    public partial class P_PrincipalCoordinador : Window
    {
        public P_PrincipalCoordinador()
        {
            InitializeComponent();
        }

        private void Btn_AgregarEncargado_Click(object sender, RoutedEventArgs e)
        {
            P_RegistrarEncargado p_RegistrarEncargado = new P_RegistrarEncargado();
            p_RegistrarEncargado.ShowDialog();
        }

        private void Btn_AgregarOrganización_Click(object sender, RoutedEventArgs e)
        {
            P_RegistrarEmpresa p_registrarEmpresa = new P_RegistrarEmpresa();
            p_registrarEmpresa.ShowDialog();
        }

        private void Btn_AgregarProyecto_Click(object sender, RoutedEventArgs e)
        {
            Coordinador coordinador = new Coordinador(12145);
            P_RegistrarProyecto p_RegistrarProyecto = new P_RegistrarProyecto(coordinador);
            p_RegistrarProyecto.ShowDialog();
        }

        private void Btn_CerrarSesión_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
