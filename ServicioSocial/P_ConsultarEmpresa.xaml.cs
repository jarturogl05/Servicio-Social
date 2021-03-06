﻿using Controller;
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
    /// Interaction logic for P_ConsultarEmpresa.xaml
    /// </summary>
    public partial class P_ConsultarEmpresa : Window
    {
        public P_ConsultarEmpresa()
        {
            InitializeComponent();
            UpdateGrid();
            gridOrganizacion.IsReadOnly = true;
        }

        private void ButtonSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (gridOrganizacion.SelectedIndex != -1)
            {
                P_DatosEmpresa p_DatosEmpresa = new P_DatosEmpresa(gridOrganizacion.SelectedValue.ToString());
                p_DatosEmpresa.ShowDialog();
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una empresa");
            }
            
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>Actualiza el grid si contiene datos.</summary>
        private void UpdateGrid()
        {
            OrganizacionController organizacionController = new OrganizacionController();
            gridOrganizacion.ItemsSource = null;
            if (organizacionController.GetOrganizacion().Any())
            {
                gridOrganizacion.ItemsSource = organizacionController.GetOrganizacion();
            }
            else
            {
                this.Close();
            }
        }

        private void ButtonAgregar_Click(object sender, RoutedEventArgs e)
        {
            P_RegistrarEmpresa p_RegistrarEmpresa = new P_RegistrarEmpresa();
            p_RegistrarEmpresa.ShowDialog();
            UpdateGrid();
        }
    }
}
