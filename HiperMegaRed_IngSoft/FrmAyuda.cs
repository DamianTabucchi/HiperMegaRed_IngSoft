using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;

namespace HiperMegaRed_IngSoft
{
    public partial class FrmAyuda : Form
    {
        public FrmAyuda()
        {
            InitializeComponent();
        }
        private readonly string rutaAyuda = Application.StartupPath + @"\help.pdf";

        private void FrmAyuda_Load(object sender, EventArgs e)
        {
            var h = rutaAyuda;
            var pdfDocument = PdfDocument.Load(rutaAyuda);
            pdfViewer.Document = pdfDocument;
        }
    }
}
