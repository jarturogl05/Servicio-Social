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
    /// Interaction logic for P_InfoProyecto.xaml
    /// </summary>
    public partial class P_InfoProyecto : Window
    {
        Proyecto proyecto = new Proyecto();
        public P_InfoProyecto()
        {
            InitializeComponent();
           
        }


        public P_InfoProyecto(Proyecto proyecto)
        {
            this.proyecto = proyecto;
            InitializeComponent();
            MostrarDatos();

        }

        private void MostrarDatos()
        {
            txbk_Organización.Text = GetNombreOrganización();
            txbk_NumAlumnos.Text = proyecto.NumeroAlumnos.ToString();
            txbk_Actividades.Text = proyecto.Actividades;
            txbk_Horario.Text = proyecto.Horario;
            txbk_Lugar.Text = proyecto.Lugar;
            txbk_Responsable.Text = GetNombreEncargado();
            txbl_Requisitos.Text = proyecto.Requisitos;
        }

        private string GetNombreOrganización()
        {
            ControladorOrganización controladorOrganización = new ControladorOrganización();
            return controladorOrganización.GetOrganizacionByEmpleado(proyecto.Encargado.IdEncargado);
        }

        private string GetNombreEncargado()
        {
            ControladorEncargado controladorEncargado = new ControladorEncargado();
            return controladorEncargado.GetEncargado(proyecto.Encargado.IdEncargado);
        }
    }
}
