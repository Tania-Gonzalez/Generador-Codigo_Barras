using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using BarcodeLib;
using System.Drawing.Imaging;
using System.IO;

namespace Codigo_De_Barras
{
    public partial class GenerarCodigoBarras : Form
    {
  

        public GenerarCodigoBarras()
        {
            InitializeComponent();
        }

        private void GenerarCodigoBarras_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // Importar la Librería BarcodeLib en NuGet

            BarcodeLib.Barcode CodigoBarras = new BarcodeLib.Barcode();
            CodigoBarras.IncludeLabel = true;
            PanelResultado.BackgroundImage = CodigoBarras.Encode(BarcodeLib.TYPE.CODE128, txtTexto.Text, Color.Black, Color.White, 400, 100); // <---------
            btnGuardar.Enabled = true;
            btnImprimir.Enabled = true;

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            Image imgFinal = (Image)PanelResultado.BackgroundImage.Clone();

            SaveFileDialog CajaDeDiaologoGuardar = new SaveFileDialog();
            CajaDeDiaologoGuardar.AddExtension = true;
            CajaDeDiaologoGuardar.Filter = "Image JPEG (*.jpeg)|*.jpeg";
            CajaDeDiaologoGuardar.ShowDialog();
            if (!string.IsNullOrEmpty(CajaDeDiaologoGuardar.FileName))
            {
                imgFinal.Save(CajaDeDiaologoGuardar.FileName, ImageFormat.Jpeg);
            }
            imgFinal.Dispose();

        }



        private void Metodo_Imprimir(object sender, PrintPageEventArgs e)
        {

            Image imgFinal = (Image)PanelResultado.BackgroundImage.Clone();

   
            e.Graphics.DrawImage(imgFinal, new Rectangle(0, 100, 400, 100)); //<-----


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            printDocument1 = new System.Drawing.Printing.PrintDocument();
            PrinterSettings ps = new PrinterSettings();

            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Metodo_Imprimir;
            printDocument1.Print();


        }



        

        
    }
}
