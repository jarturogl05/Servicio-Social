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
    public partial class P_ConsultarAlumno : Window
    {
        public P_ConsultarAlumno()
        {
            InitializeComponent();
            UpdateGrid();
            gridAlumno.IsReadOnly = true;
        }

        private void ButtonSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (gridAlumno.SelectedIndex != -1)
            {
                P_DatosAlumno p_DatosAlumno = new P_DatosAlumno(gridAlumno.SelectedValue.ToString());
                p_DatosAlumno.ShowDialog();
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Debes seleccionar un alumno");
            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>Actualiza el grid si contiene datos.</summary>
        private void UpdateGrid()
        {
            AlumnoController alumnoController = new AlumnoController();
            gridAlumno.ItemsSource = null;
            if (alumnoController.GetAlumno().Any())
            {
                gridAlumno.ItemsSource = alumnoController.GetAlumno();
            }
            else
            {
                this.Close();
            }
        }
    }
}
