using HiperMegaRed.BE;
using HiperMegaRed.BLL;
using HiperMegaRed.Services;
using HiperMegaRed.DAL.MultiLenguaje;
using System;
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
    public partial class FrmCambiarIdioma : Form
    {
        private MultiLangBLL multiIdiomaBLL = MultiLangBLL.Instance;

        public FrmCambiarIdioma()
        {
            InitializeComponent();
            MultiLang.SubscribeChangeLangEvent(this.TraducirForm);
        }

        private void TraducirForm()
        {
            WinformUtils.TraducirControl(this);
        }

        private void FrmCambiarIdioma_Load(object sender, EventArgs e)
        {
            cbxIdiomas.DisplayMember = "Descripcion";
            cbxIdiomas.DataSource = multiIdiomaBLL.GetAllIdiomas();
            cbxIdiomas.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbxIdiomas.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxIdiomas.SelectedItem = null;

            btnGestion.Visible = SessionManager.GetInstance.TienePermiso(TipoPermiso.Admin);
            TraducirForm();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            new FrmGestionIdiomas().Show();
            this.Close();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (cbxIdiomas.SelectedItem != null)
            {
                MultiLang.ChangeLang(((HiperMegaRed.BE.Idioma)cbxIdiomas.SelectedItem).Id);
                Close();
            }
        }
    }
}
