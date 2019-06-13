using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
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
using System.Windows.Xps.Packaging;

namespace ServicioSocial
{
    /// <summary>
    /// Interaction logic for P_VisorDocumento.xaml
    /// </summary>
    public partial class P_VisorDocumento : Window
    {
        public P_VisorDocumento()
        {
            InitializeComponent();
            XpsDocument xpsPackage = new XpsDocument("C:\\Users\\bestr\\Desktop\\PDF_Target.pdf",
                FileAccess.Read, CompressionOption.NotCompressed);

            FixedDocumentSequence fixedDocumentSequence =
                xpsPackage.GetFixedDocumentSequence();

            DocumentVisor.Document =
                fixedDocumentSequence as IDocumentPaginatorSource;
        }
        public P_VisorDocumento(string documentName)
        {
            InitializeComponent();
            textblockDocumentName.Text = documentName;
        }
    }
}
