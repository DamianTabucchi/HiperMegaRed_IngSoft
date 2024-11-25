using HiperMegaRed.BLL;
using HiperMegaRed.BE;
using HiperMegaRed.DAL.MultiLenguaje;
using HiperMegaRed.Services;
using HiperMegaRed.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperMegaRed_IngSoft
{
    public partial class FrmBitacoraEventos : Form
    {
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;

        private enum Criticality { Baja, Media, Alta}

        public FrmBitacoraEventos()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);

        }

        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        private void FrmBitacoraEventos_Load(object sender, EventArgs e)
        {
            cmbCriticidad.DataSource = Enum.GetValues(typeof(Criticality));

            VisualizarData();
        }

        private void VisualizarData()
        {
            var bita = bitacoraBLL.GetAll();
            var bitacoraOrdenada = bita.OrderByDescending(x => x.fechacreacion)
                                       .ToList();
            dgvBitacoras.DataSource = bitacoraOrdenada;
            dgvBitacoras.Columns["Id"].Visible = false;
            dgvBitacoras.Columns["username"].HeaderText = MultiLang.TranslateOrDefault("Header.User", "Usuario");
            dgvBitacoras.Columns["fechacreacion"].HeaderText = MultiLang.TranslateOrDefault("Header.CreationDate", "Fecha de Creacion");
            dgvBitacoras.Columns["criticidad"].HeaderText = MultiLang.TranslateOrDefault("Header.Criticality", "Criticidad");
            dgvBitacoras.Columns["modulo"].HeaderText = MultiLang.TranslateOrDefault("Header.Module", "Módulo");
            dgvBitacoras.Columns["accion"].HeaderText = MultiLang.TranslateOrDefault("Header.Action", "Acción");
            dgvBitacoras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void RefreshData()
        {
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
            cmbCriticidad.DataSource = Enum.GetValues(typeof(Criticality));
            dgvBitacoras.DataSource = null;
            VisualizarData();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            dgvBitacoras.DataSource = bitacoraBLL.GetByDates(dtpDesde.Value, dtpHasta.Value);

        }

        private void btnBorrarFiltro_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmbCriticidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string criticidadseleccionada = cmbCriticidad.SelectedItem.ToString();
            var bita = bitacoraBLL.FindByCriticality(criticidadseleccionada); 
            var bitacoraOrdenada = bita.OrderByDescending(x => x.fechacreacion)
                                       .ToList();
            dgvBitacoras.DataSource = bitacoraOrdenada;
        }
    }
}
