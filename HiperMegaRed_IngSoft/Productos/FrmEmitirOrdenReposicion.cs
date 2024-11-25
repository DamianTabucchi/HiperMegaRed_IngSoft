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

namespace HiperMegaRed_IngSoft.Productos
{
    public partial class FrmEmitirOrdenReposicion : Form
    {
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;
        private OrdenDeReposicionBLL ordenRepoBLL = OrdenDeReposicionBLL.Instance;
        private ProductoSolicitado prodselect;
        private OrdenDeReposicion ordenrepo;


        public FrmEmitirOrdenReposicion()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }
        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        private void FrmEmitirOrdenReposicion_Load(object sender, EventArgs e)
        {
            VisualizarData();
            RefreshDataProductos();
        }

        private void RefreshDataProductos()
        {
            txtProdName.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtCantidad.Enabled = false;
            btnAddToOrder.Enabled = false;
            //txtSolicitante.Text = string.Empty;
            //txtCreationDate.Text = string.Empty;
            //txtOrderNumber.Text = string.Empty;
            
        }

        private void VisualizarData()
        {
            //Verificar que los productos no hayan sido solicitados previamente... Orden de reposicion = pendiente. Si el producto aparece en orden_productos_solicitados
            //no deberia de mostrarse en la grilla.
            var products = productBLL.GetActive();
            var productslowstock = products.Where(p => p.producto_stock <= p.producto_punto_pedido).OrderBy(x => x.producto_stock).ToList();
            var OrdenesPendientes = ordenRepoBLL.GetPending();
            var OrdenesAprobadas = ordenRepoBLL.GetByState(TipoEstado.Aprobada);
            var OrdenesSolicitadas = ordenRepoBLL.GetByState(TipoEstado.Solicitada);
            var productosSolicitadosId = new List<Guid>();
            if (OrdenesPendientes != null && OrdenesPendientes.Any())
            {
                foreach (var ors in OrdenesPendientes)
                {
                    var ProductosSolicitadosEnOrden = ordenRepoBLL.GetProdSolicitados(ors.Id);
                    productosSolicitadosId.AddRange(ProductosSolicitadosEnOrden.Select(p => p.Id));
                }
            }

            if (OrdenesAprobadas != null && OrdenesAprobadas.Any())
            {
                foreach (var ors in OrdenesAprobadas)
                {
                    var ProductosSolicitadosEnOrden = ordenRepoBLL.GetProdSolicitados(ors.Id);
                    productosSolicitadosId.AddRange(ProductosSolicitadosEnOrden.Select(p => p.Id));
                }
            }

            if (OrdenesSolicitadas != null && OrdenesSolicitadas.Any())
            {
                foreach (var ors in OrdenesSolicitadas)
                {
                    var ProductosSolicitadosEnOrden = ordenRepoBLL.GetProdSolicitados(ors.Id);
                    productosSolicitadosId.AddRange(ProductosSolicitadosEnOrden.Select(p => p.Id));
                }
            }

            if (ordenrepo != null)
            {
                productosSolicitadosId.AddRange(ordenrepo.orden_productos_solicitados.Select(p => p.Id));
            }
            var tiposProductosSolicitados = ordenrepo?.orden_productos_solicitados.Select(p => p.producto_tipo).Distinct().ToList();
            //productslowstock = productslowstock.Where(p => !productosSolicitadosId.Contains(p.Id)).ToList();
            productslowstock = productslowstock.Where(p => !productosSolicitadosId.Contains(p.Id) && (tiposProductosSolicitados == null || !tiposProductosSolicitados.Any() || tiposProductosSolicitados.Contains(p.producto_tipo))).ToList();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productslowstock;
            dgvProductos.Columns["producto_nombre"].Visible = true;
            dgvProductos.Columns["producto_nombre"].DisplayIndex = 0;  // Primer columna
            dgvProductos.Columns["producto_nombre"].HeaderText = "Nombre";

            dgvProductos.Columns["producto_marca"].Visible = true;
            dgvProductos.Columns["producto_marca"].DisplayIndex = 1;  // Segunda columna
            dgvProductos.Columns["producto_marca"].HeaderText = "Marca";

            dgvProductos.Columns["producto_modelo"].Visible = true;
            dgvProductos.Columns["producto_modelo"].DisplayIndex = 2;  // Tercera columna
            dgvProductos.Columns["producto_modelo"].HeaderText = "Modelo";

            dgvProductos.Columns["producto_tipo"].Visible = true;
            dgvProductos.Columns["producto_tipo"].DisplayIndex = 3;  // Cuarta columna
            dgvProductos.Columns["producto_tipo"].HeaderText = "Tipo";

            dgvProductos.Columns["producto_stock"].Visible = true;
            dgvProductos.Columns["producto_stock"].DisplayIndex = 4;  // Quinta columna
            dgvProductos.Columns["producto_stock"].HeaderText = "Stock";

            dgvProductos.Columns["producto_punto_pedido"].Visible = true;
            dgvProductos.Columns["producto_punto_pedido"].DisplayIndex = 5;  // Sexta columna
            dgvProductos.Columns["producto_punto_pedido"].HeaderText = "Punto de Pedido";

            // Oculta todas las demás columnas no deseadas
            foreach (DataGridViewColumn column in dgvProductos.Columns)
            {
                if (column.Name != "producto_nombre" &&
                    column.Name != "producto_marca" &&
                    column.Name != "producto_modelo" &&
                    column.Name != "producto_tipo" &&
                    column.Name != "producto_stock" &&
                    column.Name != "producto_punto_pedido")
                {
                    column.Visible = false;
                }
            }
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                prodselect = new ProductoSolicitado();
                DataGridViewRow fila = dgvProductos.SelectedRows[0];
                prodselect.Id = (Guid)fila.Cells["id"].Value;
                var prod = productBLL.FindProductById((Guid)fila.Cells["id"].Value);
                prodselect.producto_nombre = prod.producto_nombre;
                prodselect.producto_marca = prod.producto_marca;
                prodselect.producto_modelo = prod.producto_modelo;
                prodselect.producto_tipo = prod.producto_tipo;
                prodselect.producto_descripcion = prod.producto_descripcion;
                prodselect.producto_punto_pedido = prod.producto_punto_pedido;
                prodselect.producto_deposito = prod.producto_deposito;
                prodselect.producto_stock = prod.producto_stock;
                prodselect.producto_activo = prod.producto_activo;
                prodselect.producto_proveedor = prod.producto_proveedor;
                prodselect.producto_precio_unidad = prod.producto_precio_unidad;
                txtProdName.Text = prodselect.producto_nombre;
                txtModelo.Text = prodselect.producto_modelo;
                txtMarca.Text = prodselect.producto_marca;
                txtTipoProd.Text = prodselect.producto_tipo.ToString();
                txtStock.Text = prodselect.producto_stock.ToString();
                var cant = prodselect.producto_punto_pedido + 10;
                txtCantidad.Text = cant.ToString();
                txtCantidad.Enabled = true;
                btnAddToOrder.Enabled = true;
            }
        }
        private void ActualizarGrillaOrdenes()
        {
            dgvOrdenRepo.DataSource = null;
            dgvOrdenRepo.DataSource = ordenrepo.orden_productos_solicitados;

            dgvOrdenRepo.Columns["producto_nombre"].Visible = true;
            dgvOrdenRepo.Columns["producto_nombre"].DisplayIndex = 0;  // Primer columna
            dgvOrdenRepo.Columns["producto_nombre"].HeaderText = "Nombre";

            dgvOrdenRepo.Columns["producto_marca"].Visible = true;
            dgvOrdenRepo.Columns["producto_marca"].DisplayIndex = 1;  // Segunda columna
            dgvOrdenRepo.Columns["producto_marca"].HeaderText = "Marca";

            dgvOrdenRepo.Columns["producto_modelo"].Visible = true;
            dgvOrdenRepo.Columns["producto_modelo"].DisplayIndex = 2;  // Tercera columna
            dgvOrdenRepo.Columns["producto_modelo"].HeaderText = "Modelo";

            dgvOrdenRepo.Columns["producto_tipo"].Visible = true;
            dgvOrdenRepo.Columns["producto_tipo"].DisplayIndex = 3;  // Cuarta columna
            dgvOrdenRepo.Columns["producto_tipo"].HeaderText = "Tipo";

            dgvOrdenRepo.Columns["producto_stock"].Visible = true;
            dgvOrdenRepo.Columns["producto_stock"].DisplayIndex = 4;  // Quinta columna
            dgvOrdenRepo.Columns["producto_stock"].HeaderText = "Stock Actual";

            dgvOrdenRepo.Columns["prodsol_cantidad"].Visible = true;
            dgvOrdenRepo.Columns["prodsol_cantidad"].DisplayIndex = 5;  // Sexta columna
            dgvOrdenRepo.Columns["prodsol_cantidad"].HeaderText = "Cantidad Solicitada";

            // Oculta todas las demás columnas no deseadas
            foreach (DataGridViewColumn column in dgvOrdenRepo.Columns)
            {
                if (column.Name != "producto_nombre" &&
                    column.Name != "producto_marca" &&
                    column.Name != "producto_modelo" &&
                    column.Name != "producto_tipo" &&
                    column.Name != "producto_stock" &&
                    column.Name != "prodsol_cantidad")
                {
                    column.Visible = false;
                }
            }
            dgvOrdenRepo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (ordenrepo == null || ordenrepo.orden_productos_solicitados.Count == 0)
            {
                ordenrepo = new OrdenDeReposicion();
                ordenrepo.Id = Guid.NewGuid();
                ordenrepo.orden_fecha_creacion = DateTime.Now;
                ordenrepo.orden_fecha_aprobacion = DateTime.Now;
                ordenrepo.orden_estado = TipoEstado.Pendiente.ToString();
                ordenrepo.orden_solicitante = SessionManager.GetInstance.User.Id;
                ordenrepo.orden_aprobador = Guid.Empty;
                ordenrepo.orden_numero = ordenRepoBLL.GenerarNumeroOrden();
                txtOrderNumber.Text = ordenrepo.orden_numero.ToString();
                txtSolicitante.Text = SessionManager.GetInstance.User.Username.ToString();
                txtCreationDate.Text = ordenrepo.orden_fecha_creacion.ToString();
                prodselect.prodsol_cantidad = int.Parse(txtCantidad.Text);
                ordenrepo.AddProdSol(prodselect);
                btnQuitarProd.Enabled = true;
                btnEmitirOrdenRepo.Enabled = true;
                txtJustificacion.Enabled = true;
                txtJustificacion.Text = "Reposicion de productos";
            }
            else
            {
                prodselect.prodsol_cantidad = int.Parse(txtCantidad.Text);
                ordenrepo.AddProdSol(prodselect);
            }
            ActualizarGrillaOrdenes();
            RefreshDataProductos();
            VisualizarData();
        }

        private void btnQuitarProd_Click(object sender, EventArgs e)
        {
            if (ordenrepo.orden_productos_solicitados.Count > 0)
            {
                var fila = dgvOrdenRepo.SelectedRows[0];
                var psid = (Guid)fila.Cells["Id"].Value;
                ordenrepo.RemoveProdSol(psid);
                if (ordenrepo.orden_productos_solicitados.Count == 0)
                {
                    btnQuitarProd.Enabled = false;
                    btnEmitirOrdenRepo.Enabled = false;
                    txtSolicitante.Text = string.Empty;
                    txtCreationDate.Text = string.Empty;
                    txtOrderNumber.Text = string.Empty;
                    txtJustificacion.Text = string.Empty;
                    txtJustificacion.Enabled = false;
                    ordenrepo = new OrdenDeReposicion();
                }
            }
            ActualizarGrillaOrdenes();
            RefreshDataProductos();
            VisualizarData();
        }

        private void btnEmitirOrdenRepo_Click(object sender, EventArgs e)
        {
            if (ordenrepo != null && ordenrepo.orden_productos_solicitados.Count > 0)
            {
                try
                {
                    ordenrepo.orden_justificacion = txtJustificacion.Text;
                    ordenrepo.orden_tipo = TipoOrden.Reposicion.ToString();
                    var affected = ordenRepoBLL.SaveOrdenRepo(ordenrepo);
                    MessageBox.Show(MultiLang.TranslateOrDefault("Orden Emitida", "Se ha emitido una Orden de Reposicion"), MultiLang.TranslateOrDefault("Orden.Emitir", "Orden Emitida"), MessageBoxButtons.OK);
                    ordenrepo = new OrdenDeReposicion();
                    btnQuitarProd.Enabled = false;
                    btnEmitirOrdenRepo.Enabled = false;
                    txtSolicitante.Text = string.Empty;
                    txtCreationDate.Text = string.Empty;
                    txtOrderNumber.Text = string.Empty;
                    txtJustificacion.Text = string.Empty;
                    txtJustificacion.Enabled = false;
                    ActualizarGrillaOrdenes();
                    RefreshDataProductos();
                    VisualizarData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                throw new Exception("Error, la orden es nula");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
