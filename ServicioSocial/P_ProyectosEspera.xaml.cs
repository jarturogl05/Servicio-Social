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
    /// Interaction logic for P_ProyectosEspera.xaml
    /// </summary>
    public partial class P_ProyectosEspera : Window
    {
        public P_ProyectosEspera()
        {
            InitializeComponent();
            LlenarGrid();
        }

        ControladorProyecto controladorProyecto = new ControladorProyecto();



        public void LlenarGrid()
        {
            List<Proyecto> proyectos = controladorProyecto.ObtenerProyectos();
            if (!proyectos.Any())
            {
                MessageBox.Show("No se encontraron proyectos");

            }
            else
            {
                dgrid_ProyectosEspera.ItemsSource = proyectos;
            }

        }


    }
}
