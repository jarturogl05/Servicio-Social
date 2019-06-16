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
    /// Interaction logic for P_RegistrarProyecto.xaml
    /// </summary>
    public partial class P_RegistrarProyecto : Window
    {
        public P_RegistrarProyecto()
        {
            InitializeComponent();
            LlenarOrganizaciones();
        }
        ValidarCampos validarCampos = new ValidarCampos();
        ControladorOrganización controladorOrganización = new ControladorOrganización();
        ControladorEncargado controladorEncargado = new ControladorEncargado();
        ControladorProyecto ControladorProyecto = new ControladorProyecto();

        private void Cbb_organización_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbb_organización.SelectedValue.ToString() != null)
            {
                LlenarEncargados();
            }
        }

        private void Btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if(ValidarCamposVacios() && ValidarNumAlumnos())
            {
                if(ControladorProyecto.AddProyecto(txb_NombreProyecto.Text, int.Parse(txb_NúmeroAlumnos.Text),txb_Lugar.Text,
                    txb_Horario.Text,txb_Actividades.Text, txb_Requisitos.Text, cbb_Responsable.SelectedItem) == AddEnum.AddResult.Success)
                {
                    MessageBox.Show("Proyecto agregado con éxito");

                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el proyecto");
                }
            }
        }



        private bool ValidarCamposVacios()
        {
            if(string.IsNullOrEmpty(txb_NombreProyecto.Text) || string.IsNullOrEmpty(txb_NúmeroAlumnos.Text) ||
                string.IsNullOrEmpty(txb_Lugar.Text) || string.IsNullOrEmpty(txb_Horario.Text) || 
                string.IsNullOrEmpty(txb_Actividades.Text) || string.IsNullOrEmpty(txb_Requisitos.Text)
                || cbb_organización.SelectedIndex == -1 || cbb_Responsable.SelectedIndex == -1)
            {
                MessageBox.Show("Debe llenar todos los campos");
                return false;
            }

            return true;
        }

        private bool ValidarNumAlumnos()
        {
            if(validarCampos.ValidarNumAlumnos(txb_NúmeroAlumnos.Text) == ValidarCampos.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("Los proyectos pueden tener hasta 3 alumnos, verfique su información");
                return false;
            }
            return true;
        }

        public void LlenarOrganizaciones()
        {
            
            List<Organizacion> organizacions = controladorOrganización.ObtenerOrganizaciones();
            if (!organizacions.Any())
            {
                MessageBox.Show("No se encontraron organizaciones");
            }
            else
            {
                cbb_organización.ItemsSource = organizacions;
            }

        }

        private void LlenarEncargados()
        {
           
            
            List<Encargado> encargados = controladorEncargado.GetEncargados(cbb_organización.SelectedItem);
            if (!encargados.Any())
            {
                MessageBox.Show("No se encontraron encargados");
            }
            else
            {
                cbb_Responsable.ItemsSource = encargados;
            } 
            

        }

        private void Txb_NúmeroAlumnos_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
