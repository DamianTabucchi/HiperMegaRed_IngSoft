using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiperMegaRed.BE;
using HiperMegaRed.BLL;
using HiperMegaRed.Services;
using HiperMegaRed.DAL.MultiLenguaje;
using HiperMegaRed.DAL;

namespace HiperMegaRed_IngSoft
{
    public partial class frmReportes : Form
    {
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private ClienteBLL clienteBLL = ClienteBLL.Instance;
        private FacturaBLL facturaBLL = FacturaBLL.Instance;


        public frmReportes()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }
        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClientList_Click(object sender, EventArgs e)
        {
            dgvInfo.DataSource = null;
            dgvInfo.DataSource = clienteBLL.GetAll();

            dgvInfo.Columns["cliente_dni"].HeaderText = "DNI";
            dgvInfo.Columns["cliente_nombre"].HeaderText = MultiLang.TranslateOrDefault("Header.Name", "Nombre");
            dgvInfo.Columns["cliente_apellido"].HeaderText = MultiLang.TranslateOrDefault("lbl.lastname", "Apellido");
            dgvInfo.Columns["cliente_mail"].HeaderText = "E-Mail";
            dgvInfo.Columns["cliente_telefono"].HeaderText = MultiLang.TranslateOrDefault("lbl.telefono", "Telefono");
        }

        private void btnVentasRealizadas_Click(object sender, EventArgs e)
        {
            dgvInfo.DataSource = null;
            dgvInfo.DataSource = facturaBLL.GetAll();

            dgvInfo.Columns["factura_fecha"].HeaderText = MultiLang.TranslateOrDefault("Header.Date", "Fecha Emision");
            dgvInfo.Columns["factura_monto"].HeaderText = MultiLang.TranslateOrDefault("Header.Amount", "Monto");
            dgvInfo.Columns["factura_productos_entregados"].HeaderText = MultiLang.TranslateOrDefault("Header.Delivered", "Entregado?");
            dgvInfo.Columns["factura_metodo_pago"].HeaderText = MultiLang.TranslateOrDefault("gbx.metodo.pago", "Metodo de Pago");
            dgvInfo.Columns["factura_monto"].HeaderText = MultiLang.TranslateOrDefault("Header.Amount", "Monto");
            dgvInfo.Columns["id"].Visible = false;
            dgvInfo.Columns["factura_carrito_id"].Visible = false;
            dgvInfo.Columns["factura_cliente_dni"].Visible = false;
            dgvInfo.Columns["factura_vuelto"].Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvInfo.DataSource = null;
        }
    }
}
