using System;
using HiperMegaRed.BE;
using HiperMegaRed.BLL;
using HiperMegaRed.DAL;
using HiperMegaRed.DAL.MultiLenguaje;
using HiperMegaRed.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperMegaRed_IngSoft.IdiomaFRMs
{
    public partial class FrmGestionIdiomas : Form
    {
        private MultiLangBLL multiIdiomaBLL = MultiLangBLL.Instance;
        private List<HiperMegaRed.BE.Idioma> idiomas;
        public FrmGestionIdiomas()
        {
            InitializeComponent();
            MultiLang.SubscribeChangeLangEvent(this.TraducirForm);
        }

        private void TraducirForm()
        {
            WinformUtils.TraducirControl(this);
        }

        private void FrmGestionIdiomas_Load(object sender, EventArgs e)
        {
            var lista = new List<string>();

            idiomas = multiIdiomaBLL.GetAllIdiomas();
            foreach (var idioma in idiomas)
            {
                lista.Add(idioma.Id);
            }

            cbxId.DisplayMember = "Descripcion";
            cbxId.DataSource = lista;
            cbxId.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbxId.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxId.SelectedItem = null;

            TraducirForm();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbxId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_idioma = (string)cbxId.Text;
            if (string.IsNullOrWhiteSpace(id_idioma))
            {
                txtDescripcion.Text = null;
                txtTraducciones.Text = null;
                return;
            }

            var idioma = idiomas.Where(i => i.Id == id_idioma).FirstOrDefault<HiperMegaRed.BE.Idioma>();

            if (idioma != null)
            {
                txtDescripcion.Text = idioma.Descripcion;
            }

            var traduccionesfull = multiIdiomaBLL.CargarIdiomaFull(id_idioma);

            StringBuilder sb = new StringBuilder();

            foreach (var key in traduccionesfull.Keys)
            {
                sb.Append(key).Append('=').Append(traduccionesfull[key]).Append(Environment.NewLine);
            }
            txtTraducciones.Text = sb.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.cbxId.Text))
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("FrmGestionIdioma.Error.SeleccionIdioma", "Escriba un identificador de idioma, se recomienda el formato de la RFC3066 (es-AR)"));
                return;
            } else if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("FrmGestionIdioma.Error.IngresarDescripcion", "Escriba una descripcion para el idioma"));
                return;
            } else if (string.IsNullOrWhiteSpace(txtTraducciones.Text))
            {
                var lang = multiIdiomaBLL.CrearIdioma(cbxId.Text, txtDescripcion.Text);
                FrmGestionIdiomas_Load(null, null);
                cbxId.Text = lang.Id;
                txtDescripcion.Text = lang.Descripcion;
                cbxId_SelectedIndexChanged(null, null);
                return;
            }

            var idioma = new HiperMegaRed.BE.Idioma
            {
                Id = (string)cbxId.Text,
                Descripcion = txtDescripcion.Text
            };

            var lineas = txtTraducciones.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var traducciones = new Dictionary<string, string>();
            foreach(var l in lineas)
            {
                if (!string.IsNullOrWhiteSpace(l)) traducciones.Add(l.Substring(0, l.IndexOf('=')), l.Substring(1 + l.IndexOf('=')));
            }

            multiIdiomaBLL.GuardarIdioma(idioma, traducciones);
            MessageBox.Show(MultiLang.TranslateOrDefault("Idioma.Guardado", "Se ha guardado el idioma"));
        }
    }
}
