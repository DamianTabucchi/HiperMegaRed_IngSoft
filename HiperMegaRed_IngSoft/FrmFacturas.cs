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
    public partial class FrmFacturas : Form
    {
        private FacturaBLL facturaBLL = FacturaBLL.Instance;
        private OrdenDePagoBLL ordenBLL = OrdenDePagoBLL.Instance;
        private ProductoBLL productoBLL = ProductoBLL.Instance;
        private ClienteBLL clientBLL = ClienteBLL.Instance;
        private IList<ItemProducto> productos = new List<ItemProducto>();
        private static Factura fact = new Factura();
        private HiperMegaRed.BE.Cliente client = new HiperMegaRed.BE.Cliente();
        private readonly SessionManager session = SessionManager.GetInstance;
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;

        public FrmFacturas()
        {
            InitializeComponent();
            ObtenerDatos();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }

        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }
        public void ObtenerDatos()
        {
            if (facturaBLL.GetNotDelivered().Count > 0)
            {
                cmbFacturas.DataSource = facturaBLL.GetNotDelivered();
                cmbFacturas.DisplayMember = "factura_cliente_dni";
            }
            else
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("No.Products.To.Deliver","Todos los productos han sido entregados"));
            }
            
        }

        public void RefreshData()
        {
            fact = new Factura();
            client = new HiperMegaRed.BE.Cliente();
            txtCliente.Text = "";
            dgvProductos.DataSource = null;

        }
        private void FrmFacturas_Load(object sender, EventArgs e)
        {

        }
        
        public void VisualizarData()
        {
            dgvProductos.Columns["producto_nombre"].HeaderText = MultiLang.TranslateOrDefault("Header.Name", "Nombre");
            dgvProductos.Columns["cantidad"].HeaderText = MultiLang.TranslateOrDefault("Header.Quantity", "Cantidad");
            dgvProductos.Columns["producto_tipo"].HeaderText = MultiLang.TranslateOrDefault("Header.Type", "Tipo");
            dgvProductos.Columns["producto_deposito"].HeaderText = MultiLang.TranslateOrDefault("Header.Deposit", "Deposito");
            dgvProductos.Columns["producto_nombre"].DisplayIndex = 0;
            dgvProductos.Columns["producto_tipo"].DisplayIndex = 1;
            dgvProductos.Columns["cantidad"].DisplayIndex = 2;
            dgvProductos.Columns["producto_deposito"].DisplayIndex = 3;
            dgvProductos.Columns["id"].Visible = false;
            dgvProductos.Columns["producto_marca"].Visible = false;
            dgvProductos.Columns["producto_modelo"].Visible = false;
            dgvProductos.Columns["producto_stock"].Visible = false;
            dgvProductos.Columns["producto_descripcion"].Visible = false;
            dgvProductos.Columns["producto_precio_unidad"].Visible = false;
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbFacturas.Items.Count > 0)
            {
                fact = (Factura)cmbFacturas.SelectedItem;
                client = clientBLL.FindByDNI(fact.factura_cliente_dni);
                txtCliente.Text = $"{client.cliente_apellido}, {client.cliente_nombre}. DNI: {client.cliente_dni}";
                //var ord = ordenBLL.FindById(fact.factura_carrito_id);
                dgvProductos.DataSource = productoBLL.FindByCart(fact.factura_carrito_id);
                VisualizarData();
            }
            else
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("No.Ticket.Selected","No hay factura seleccionada."));
            }
        }

        private void btnEntregado_Click(object sender, EventArgs e)
        {
            fact.factura_productos_entregados = true;
            try
            {
                if (facturaBLL.UpdateFactura(fact) == 1)
                {
                    MessageBox.Show(MultiLang.TranslateOrDefault("Ticket.Updated","Factura Actualizada con exito"));
                    bitacoraBLL.SaveBitacora(new Bitacora("Producto Despachado", "Media", DateTime.Now, "Facturas", session.User.Username));
                    RefreshData();
                    ObtenerDatos();
                }
                else
                {
                    throw new Exception();
                }
            } 
            catch (Exception ex)
            {
                bitacoraBLL.SaveBitacora(new Bitacora($"Se ha producido un error al intentar despachar los productos: {ex.Message}", "Media", DateTime.Now, "Facturas", session.User.Username));
                MessageBox.Show(MultiLang.TranslateOrDefault("Error.Has.Occurred", "Ha ocurrido un error:") + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
