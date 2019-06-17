using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for P_Registrar_Cooordinador.xaml
    /// </summary>
    public partial class P_Registrar_Cooordinador : Window
    {
        public P_Registrar_Cooordinador()
        {

            InitializeComponent();
        }

        ValidarCampos validarCampos = new ValidarCampos();
        ControladorCoordinador controladorCoordinador = new ControladorCoordinador();

        private void Cbb_Carrera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {


            if ( ValidarCamposVacios() && ValidarPassword() && ValidarNúmeroPersonal())
            {
                if(controladorCoordinador.AñadirCoordinador(txb_NombreCompleto.Text,txb_NúmeroPersonal.Text, cbb_Carrera.Text) == AddEnum.AddResult.Success)
                {
                    MessageBox.Show("Coordinador agregado con éxito");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el coordinador, intentelo más tarde");
                }
            }

         
            
        }

        private bool ValidarCamposVacios()
        {
            if(string.IsNullOrEmpty(txb_NombreCompleto.Text) || string.IsNullOrEmpty(txb_NúmeroPersonal.Text)
                || cbb_Carrera.SelectedIndex == -1 || string.IsNullOrWhiteSpace(psb_Contraseña.Password))
            {
                MessageBox.Show("Debes llenar todos los campos");
                return false;
            }
            return true;            
        }

        private bool ValidarPassword()
        {
            if(validarCampos.ValidarPassword(psb_Contraseña.Password) == ValidarCampos.ResultadosValidación.ContraseñaInválida)
            {
                MessageBox.Show("Las contraseñas deben de tener por lo menos 8 carácteres, alfanumérica y por lo menos una letra mayúscula");
                return false;

            }
            return true;
        }

        private bool ValidarNúmeroPersonal()
        {
            if(validarCampos.ValidarNúmero(txb_NúmeroPersonal.Text) == ValidarCampos.ResultadosValidación.NúmeroInválido)
            {
                MessageBox.Show("El campo Número personal solo acepta números");
                return false;
            }
            return true;
        }




    


    }
}
