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
    public partial class FrmSolicitudCompra : Form
    {
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;
        private OrdenDeReposicionBLL ordenRepoBLL = OrdenDeReposicionBLL.Instance;
        private ProductoSolicitado prodsol;
        private OrdenDeReposicion ordenrepo;
        private SessionManager session = SessionManager.GetInstance;
        public FrmSolicitudCompra()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }

        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        private void FrmSolicitudCompra_Load(object sender, EventArgs e)
        {
            RefreshFields();
        }

        public void RefreshFields()
        {
            if (ordenrepo != null && ordenrepo.orden_productos_solicitados.Count > 0)
            {
                txtNombre.Text = string.Empty;
                txtMarca.Text = string.Empty;
                txtModelo.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                nudCantidad.Value = 1;
            }
            else
            {
                cmbTipo.DataSource = Enum.GetValues(typeof(TipoDeProducto));
                cmbTipo.Text = MultiLang.TranslateOrDefault("Text.Tipo", "Tipo");

                txtNombre.Text = string.Empty;
                txtMarca.Text = string.Empty;
                txtModelo.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                nudCantidad.Value = 1;
            }

        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            RefreshFields();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtMarca.Text) || string.IsNullOrEmpty(txtModelo.Text)
                || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtMarca.Text)
                || string.IsNullOrWhiteSpace(txtModelo.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("Complete.Datos", "Por favor complete los datos para continuar"), "Error", MessageBoxButtons.OK);
            }
            else if (cmbTipo.SelectedIndex == -1 || cmbTipo.Text == "Tipo de Producto")
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("Select.Type", "Seleccione el tipo de Producto"), "Error", MessageBoxButtons.OK);
            }
            else if (productBLL.ProdNameExist(txtNombre.Text))
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("Producto.Existe", "Ya existe un producto con este nombre"), "Error", MessageBoxButtons.OK);
            }
            else
            {
                txtJustify.Text = "Pedido de producto(s) nuevo(s)";
                txtJustify.Enabled = true;
                cmbTipo.Enabled = false;
                prodsol = new ProductoSolicitado();
                prodsol.Id = Guid.NewGuid();
                prodsol.producto_nombre = txtNombre.Text;
                prodsol.producto_marca = txtMarca.Text;
                prodsol.producto_modelo = txtModelo.Text;
                prodsol.producto_tipo = (TipoDeProducto)cmbTipo.SelectedIndex;
                prodsol.producto_descripcion = txtDescripcion.Text;
                prodsol.producto_deposito = "N/A";
                prodsol.producto_stock = prodsol.producto_stock = 0;
                prodsol.producto_precio_unidad = 0;
                prodsol.producto_punto_pedido = Convert.ToInt32(nudCantidad.Value);
                prodsol.producto_activo = false;
                prodsol.producto_proveedor = Guid.Empty;
                prodsol.prodsol_cantidad = Convert.ToInt32(nudCantidad.Value);

                if (ordenrepo == null || ordenrepo.orden_productos_solicitados.Count == 0)
                {
                    ordenrepo = new OrdenDeReposicion();
                    ordenrepo.Id = Guid.NewGuid();
                    ordenrepo.orden_numero = ordenRepoBLL.GenerarNumeroOrden();
                    ordenrepo.orden_fecha_creacion = DateTime.Now;
                    ordenrepo.orden_fecha_aprobacion = DateTime.Now;
                    ordenrepo.orden_estado = TipoEstado.Pendiente.ToString();
                    ordenrepo.orden_solicitante = session.User.Id;
                    ordenrepo.orden_aprobador = Guid.Empty;
                    ordenrepo.orden_tipo = TipoOrden.Nuevo.ToString();
                    ordenrepo.AddProdSol(prodsol);
                    txtFecha.Text = ordenrepo.orden_fecha_creacion.ToString();
                    txtNumOrden.Text = ordenrepo.orden_numero.ToString();
                    txtSolicitante.Text = session.User.ToString();
                    ActualizarGrillaOrdenes();
                    RefreshFields();
                    btnQuitarProd.Enabled = true;
                    btnEmitirSol.Enabled = true;
                }
                else
                {
                    ordenrepo.AddProdSol(prodsol);
                    ActualizarGrillaOrdenes();
                    RefreshFields();
                }
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

            dgvOrdenRepo.Columns["prodsol_cantidad"].Visible = true;
            dgvOrdenRepo.Columns["prodsol_cantidad"].DisplayIndex = 4;  // Sexta columna
            dgvOrdenRepo.Columns["prodsol_cantidad"].HeaderText = "Cantidad Solicitada";

            // Oculta todas las demás columnas no deseadas
            foreach (DataGridViewColumn column in dgvOrdenRepo.Columns)
            {
                if (column.Name != "producto_nombre" &&
                    column.Name != "producto_marca" &&
                    column.Name != "producto_modelo" &&
                    column.Name != "producto_tipo" &&
                    column.Name != "prodsol_cantidad")
                {
                    column.Visible = false;
                }
            }
            dgvOrdenRepo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                    btnEmitirSol.Enabled = false;
                    txtSolicitante.Text = string.Empty;
                    txtFecha.Text = string.Empty;
                    txtNumOrden.Text = string.Empty;
                    txtJustify.Text = string.Empty;
                    txtJustify.Enabled = false;
                    ordenrepo = new OrdenDeReposicion();
                    cmbTipo.Enabled = true;
                }
            }
            ActualizarGrillaOrdenes();
        }

        private void btnEmitirSol_Click(object sender, EventArgs e)
        {
            if (ordenrepo != null && ordenrepo.orden_productos_solicitados.Count > 0)
            {
                foreach (ProductoSolicitado ps in ordenrepo.orden_productos_solicitados)
                {
                    Producto prod = ps;
                    try
                    {
                        var affected = productBLL.SaveProduct(prod);
                        if (affected != 0)
                        {
                            MessageBox.Show($"Se ha creado un producto {prod.producto_nombre}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message );
                    }
                }
                try
                {
                    ordenrepo.orden_justificacion = txtJustify.Text;
                    var affected = ordenRepoBLL.SaveOrdenRepo(ordenrepo);
                    if (affected != 0)
                    {
                        MessageBox.Show(MultiLang.TranslateOrDefault("Solicitud.Emitida", "Se ha emitido una Solicitud de Compras"), MultiLang.TranslateOrDefault("Orden.Emitir", "Orden Emitida"), MessageBoxButtons.OK);
                    }
                    ordenrepo = new OrdenDeReposicion();
                    btnQuitarProd.Enabled = false;
                    btnEmitirSol.Enabled = false;
                    txtSolicitante.Text = string.Empty;
                    txtFecha.Text = string.Empty;
                    txtNumOrden.Text = string.Empty;
                    txtJustify.Text = string.Empty;
                    txtJustify.Enabled = false;
                    ActualizarGrillaOrdenes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                throw new Exception("Error, la orden es nula");
            }
        }
    }
}
