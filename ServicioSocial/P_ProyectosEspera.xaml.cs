using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        const int POSICION_FUERARANGO = -1;
        public P_ProyectosEspera()
        {
            InitializeComponent();
            LlenarGrid();
        }

        ControladorProyecto controladorProyecto = new ControladorProyecto();
        ControladorSolicitud controladorSolicitud = new ControladorSolicitud();



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

        private void Btn_MostrarInfo_Click(object sender, RoutedEventArgs e)
        {
            int posición = dgrid_ProyectosEspera.SelectedIndex;
            if(posición != POSICION_FUERARANGO)
            {
                Proyecto proyecto = (Proyecto)dgrid_ProyectosEspera.SelectedItem;
                P_InfoProyecto p_InfoProyecto = new P_InfoProyecto(proyecto);
                p_InfoProyecto.Show();

            }
            else
            {
                MessageBox.Show("Debes seleccionar un proyecto");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarSeleccion())
            {
                List<Proyecto> proyectosSeleccionados = SelecciónProyectos();
                if (controladorSolicitud.AñadirSolicitud(proyectosSeleccionados) == AddEnum.AddResult.Success)
                {
                    MessageBox.Show("Solicitud creada con éxito");
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la solicitud");
                }
            }
        }

        private List<Proyecto> SelecciónProyectos()
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            foreach (var item in dgrid_ProyectosEspera.SelectedItems)
            {
                var proyecto1 = item as Proyecto;
                proyectos.Add(proyecto1);
            }

            foreach (Proyecto proyecto2 in proyectos)
            {
                Console.WriteLine(proyecto2.IDProyecto);
            }
            return proyectos;
        }

        public bool ValidarSeleccion()
        {
            if (SelecciónProyectos().Count == 3)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Debes de elegir 3 proyectos");
                return false;
            }
        }
    }



}

