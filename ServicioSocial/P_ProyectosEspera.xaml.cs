﻿using System;
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
using Controller;

namespace ServicioSocial
{
    /// <summary>
    /// Interaction logic for P_ProyectosEspera.xaml
    /// </summary>
    public partial class P_ProyectosEspera : Window
    {

        const int POSICION_FUERARANGO = -1;
        Alumno alumno = new Alumno(); 

        public P_ProyectosEspera()
        {
            InitializeComponent();
            LlenarGrid();
            
        }


        /// <summary>
        ///   <para>Llena el datagrid con proyectos</para>
        /// </summary>
        public void LlenarGrid()
        {
            ControladorProyecto controladorProyecto = new ControladorProyecto();
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

        /// <summary>Handles the Click event of the Btn_MostrarInfo control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>Handles the Click event of the Button control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarSeleccion())
            {
                ControladorSolicitud controladorSolicitud = new ControladorSolicitud();
                List<Proyecto> proyectosSeleccionados = SelecciónProyectos();
                if (controladorSolicitud.AñadirSolicitud(proyectosSeleccionados, Properties.Settings.Default.UserID) == AddEnum.AddResult.Success)
                {
                    MessageBox.Show("Solicitud creada con éxito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la solicitud");
                }
            }
        }

        /// <summary>  obtiene la lista de proyectos</summary>
        /// <returns></returns>
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

        /// <summary>  Valida que sel seleccionen 3 proyectos</summary>
        /// <returns>resultado de la validación</returns>
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

        /// <summary>Handles the 1 event of the Button_Click control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }



}

