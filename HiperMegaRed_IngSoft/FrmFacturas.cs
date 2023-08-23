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

namespace HiperMegaRed_IngSoft
{
    public partial class FrmFacturas : Form
    {
        private FacturaBLL facturaBLL = FacturaBLL.Instance;
        private OrdenDePagoBLL ordenBLL = OrdenDePagoBLL.Instance;
        private ProductoBLL productoBLL = ProductoBLL.Instance;
        private ClienteBLL clientBLL = ClienteBLL.Instance;
        private IList<Producto> productos = new List<Producto>();
        private static Factura fact = new Factura();
        private HiperMegaRed.BE.Cliente client = new HiperMegaRed.BE.Cliente();
        
        public FrmFacturas()
        {
            InitializeComponent();
            ObtenerDatos();
        }

        public void ObtenerDatos()
        {
            if (facturaBLL.GetNotDelivered().Count > 0)
            {
                cmbFacturas.DataSource = facturaBLL.GetNotDelivered();
                cmbFacturas.DisplayMember = "factura_fecha";
            }
            else
            {
                MessageBox.Show("Todos los productos han sido entregados");
                Dispose();
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbFacturas.Items.Count > 0)
            {
                fact = (Factura)cmbFacturas.SelectedItem;
                client = clientBLL.FindByDNI(fact.factura_cliente_dni);
                txtCliente.Text = $"{client.cliente_apellido}, {client.cliente_nombre}. DNI: {client.cliente_dni}";
                var ord = ordenBLL.FindById(fact.factura_carrito_id);
                dgvProductos.DataSource = productoBLL.FindByCart(ord.orden_carrito_id);
                dgvProductos.Columns["id"].Visible = false;
                dgvProductos.Columns["producto_marca"].Visible = false;
                dgvProductos.Columns["producto_modelo"].Visible = false;
                dgvProductos.Columns["producto_stock"].Visible = false;
                dgvProductos.Columns["producto_descripcion"].Visible = false;
                dgvProductos.Columns["producto_precio_unidad"].Visible = false;
            }
            else
            {
                MessageBox.Show("No hay factura seleccionada.");
            }
        }

        private void btnEntregado_Click(object sender, EventArgs e)
        {
            fact.factura_productos_entregados = true;
            try
            {
                if (facturaBLL.UpdateFactura(fact) == 1)
                {
                    MessageBox.Show("Factura Actualizada con exito");
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
                MessageBox.Show("Ha ocurrido un error:" + ex.Message);
            }
        }
    }
}
