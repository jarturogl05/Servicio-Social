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
            this.Close();
        }
    }
}
