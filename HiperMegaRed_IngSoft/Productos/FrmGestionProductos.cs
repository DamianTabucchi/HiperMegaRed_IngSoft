using HiperMegaRed.BE;
using HiperMegaRed.BLL;
using HiperMegaRed.Services;
using HiperMegaRed.DAL.MultiLenguaje;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Collections.Specialized.BitVector32;

namespace HiperMegaRed_IngSoft.Productos
{
    public partial class FrmGestionProductos : Form
    {
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;
        private ProveedoresBLL provBLL = ProveedoresBLL.Instance;
        private readonly SessionManager session = SessionManager.GetInstance;
        private Producto prod;
        private bool modify = false;

        public FrmGestionProductos()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }
        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        private void FrmGestionProductos_Load(object sender, EventArgs e)
        {
            //dgvProductos.DataSource = productBLL.GetAll();
            RefreshData();
        }

        private void RefreshData()
        {
            //dgvProductos.ClearSelection();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productBLL.GetAll();
            dgvProductos.Columns["Id"].Visible = false;
            cmbProdTipo.DataSource = null;
            cmbProdTipo.DataSource = Enum.GetValues(typeof(TipoDeProducto));
            cmbProdTipo.Text = MultiLang.TranslateOrDefault("Text.Tipo", "Tipo");
            btnMod.Enabled = false;
            btnEliminar.Enabled = false;
            btnAdd.Text = MultiLang.TranslateOrDefault("btn.add", "Agregar");
            CargarProveedores();

            txtProdNombre.Text = "";
            txtProdMarca.Text = "";
            txtProdModel.Text = "";
            txtProdDesc.Text = "";
            txtProdDepo.Text = "";
            txtProdPU.Text = "";
            txtProdStock.Text = "";
            txtPPedido.Text = "";
            rbtActive.Enabled = false;
            rbtActive.Checked = true;
            prod = new Producto();
            modify = false;
        }

        private void CargarProveedores()
        {
            // Llama a la función que obtiene la lista de proveedores activos
            var proveedores = provBLL.GetActive();

            // Configura el ComboBox para que no enlace directamente la lista, sino que use el DisplayMember y ValueMember
            cmbProveedores.DataSource = proveedores;
            cmbProveedores.DisplayMember = "NombreCompleto";
            cmbProveedores.ValueMember = "Id";
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            btnMod.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                prod = new Producto();
                DataGridViewRow fila = dgvProductos.SelectedRows[0];
                prod = productBLL.FindProductById((Guid)fila.Cells["id"].Value);
                txtProdNombre.Text = prod.producto_nombre;
                txtProdMarca.Text = prod.producto_marca;
                txtProdModel.Text = prod.producto_modelo;
                txtProdDesc.Text = prod.producto_descripcion;
                txtProdDepo.Text = prod.producto_deposito;
                txtProdPU.Text = prod.producto_precio_unidad.ToString();
                txtPPedido.Text = prod.producto_punto_pedido.ToString();
                rbtActive.Enabled = true;
                rbtActive.Checked = prod.producto_activo;
                txtProdStock.Text = prod.producto_stock.ToString();
                cmbProdTipo.SelectedItem = prod.producto_tipo;
                cmbProveedores.SelectedValue = prod.producto_proveedor;
                modify = true;
                btnAdd.Text = MultiLang.TranslateOrDefault("btn.mod", "Modificar");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult seleccion = MessageBox.Show(MultiLang.TranslateOrDefault("Eliminate.Prod.Question", "Desea eliminar el producto?"), MultiLang.TranslateOrDefault("Eliminate.Prod.Hader", "Confirmar eliminación"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (seleccion == DialogResult.Yes)
            {
                try
                {
                    var a = productBLL.RemoveProd((Guid)dgvProductos.SelectedRows[0].Cells["id"].Value);
                    if (a > 0)
                    {
                        MessageBox.Show(MultiLang.TranslateOrDefault("Prod.Eliminado", "Se ha eliminado el producto"), MultiLang.TranslateOrDefault("Producto.Eliminado", "Producto eliminado"), MessageBoxButtons.OK);
                        var bitacora = new Bitacora("Se ha eliminado un Producto", "Alta", DateTime.Now, "Gestión de Producto", session.User.Username);
                        bitacoraBLL.SaveBitacora(bitacora);
                        GlobalStorage.Deposito = productBLL.GetAllWithStock();
                        RefreshData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProdNombre.Text) || string.IsNullOrWhiteSpace(txtProdMarca.Text) || string.IsNullOrWhiteSpace(txtProdModel.Text) ||
                string.IsNullOrWhiteSpace(txtProdStock.Text) || string.IsNullOrWhiteSpace(txtProdDepo.Text) || string.IsNullOrWhiteSpace(txtProdPU.Text) ||
                string.IsNullOrWhiteSpace(txtProdDesc.Text) || string.IsNullOrWhiteSpace(txtPPedido.Text))
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("Complete.Datos", "Por favor complete los datos para continuar"), MultiLang.TranslateOrDefault("Datos.Incompletos", "Datos incompletos"), MessageBoxButtons.OK);
            }
            else
            {
                prod.producto_nombre = txtProdNombre.Text;
                prod.producto_modelo = txtProdModel.Text;
                prod.producto_marca = txtProdMarca.Text;
                prod.producto_deposito = txtProdDepo.Text;
                prod.producto_stock = Int32.Parse(txtProdStock.Text);
                prod.producto_tipo = (TipoDeProducto)cmbProdTipo.SelectedItem;
                prod.producto_precio_unidad = double.Parse(txtProdPU.Text);
                prod.producto_descripcion = txtProdDesc.Text;
                prod.producto_punto_pedido = Int32.Parse(txtPPedido.Text);
                prod.producto_activo = rbtActive.Checked;
                prod.producto_proveedor = (Guid)cmbProveedores.SelectedValue;
                try
                {
                    var affected = productBLL.SaveProduct(prod);
                    if (modify != true)
                    {
                        MessageBox.Show(MultiLang.TranslateOrDefault("Producto.Nuevo", "Se ha dado de alta un nuevo producto"), MultiLang.TranslateOrDefault("Alta.Producto", "Alta de producto"), MessageBoxButtons.OK);
                        var bitacora = new Bitacora("Se ha dado de alta un nuevo Producto", "Media", DateTime.Now, "Gestión de Producto", session.User.Username);
                        bitacoraBLL.SaveBitacora(bitacora);
                        RefreshData();
                    }
                    else
                    {
                        MessageBox.Show(MultiLang.TranslateOrDefault("Producto.Actualizado", "Se ha actualizado un producto"), MultiLang.TranslateOrDefault("Update.Producto", "Producto Actualizado"), MessageBoxButtons.OK);
                        var bitacora = new Bitacora("Se ha modificado un Producto", "Media", DateTime.Now, "Gestión de Producto", session.User.Username);
                        bitacoraBLL.SaveBitacora(bitacora);
                        RefreshData();
                    }
                    GlobalStorage.Deposito = productBLL.GetAllWithStock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnNewSup_Click(object sender, EventArgs e)
        {
            FrmRegistrarProveedor frmRegistrarProveedor = new FrmRegistrarProveedor();
            frmRegistrarProveedor.ShowDialog();
            CargarProveedores();
        }
    }
}
