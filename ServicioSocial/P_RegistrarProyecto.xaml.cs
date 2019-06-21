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
    /// Interaction logic for P_RegistrarProyecto.xaml
    /// </summary>
    public partial class P_RegistrarProyecto : Window
    {
        Coordinador coordinador = new Coordinador();
        public P_RegistrarProyecto()
        {
            InitializeComponent();
            LlenarOrganizaciones();
        }

        /// <summary>Handles the SelectionChanged event of the Cbb_organización control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void Cbb_organización_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbb_organización.SelectedValue.ToString() != null)
            {
                LlenarEncargados();
            }
        }

        /// <summary>Handles the Click event of the Btn_Aceptar control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if(ValidarCamposVacios() && ValidarNumAlumnos())
            {
                string IdCoordinador = Properties.Settings.Default.UserID;
                ControladorProyecto ControladorProyecto = new ControladorProyecto();
                if (ControladorProyecto.AddProyecto(txb_NombreProyecto.Text, int.Parse(txb_NúmeroAlumnos.Text),txb_Lugar.Text,
                    txb_Horario.Text,txb_Actividades.Text, txb_Requisitos.Text, cbb_Responsable.SelectedItem, IdCoordinador) == AddEnum.AddResult.Success)
                {
                    MessageBox.Show("Proyecto agregado con éxito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el proyecto");
                }
            }
        }
        /// <summary>  Validar si existen campos vacios</summary>
        /// <returns>Resultado de la validación</returns>
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
        /// <summary>  Valida que el número de alumnos sea entre 1 y 3</summary>
        /// <returns>el resultado de la operación</returns>
        private bool ValidarNumAlumnos()
        {
            ValidarCampos validarCampos = new ValidarCampos();
            if (validarCampos.ValidarNumAlumnos(txb_NúmeroAlumnos.Text) == ValidarCampos.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("Los proyectos pueden tener hasta 3 alumnos, verfique su información");
                return false;
            }
            return true;
        }

        /// <summary>  Llena el combobox de las organizaciones</summary>
        public void LlenarOrganizaciones()
        {
            ControladorOrganización controladorOrganización = new ControladorOrganización();
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

        /// <summary>  Llena el combobox con encargados</summary>
        private void LlenarEncargados()
        {

            ControladorEncargado controladorEncargado = new ControladorEncargado();
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

        /// <summary>Handles the Click event of the Btn_Cancelar control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
