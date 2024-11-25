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

namespace HiperMegaRed_IngSoft.Compras
{
    public partial class FrmRegistrarCotizacion : Form
    {
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;
        private OrdenDeReposicionBLL ordenRepoBLL = OrdenDeReposicionBLL.Instance;
        private SolicitudCotizacionBLL solcotBLL = SolicitudCotizacionBLL.Instance;
        private CotizacionBLL cotBLL = CotizacionBLL.Instance;
        private ProveedoresBLL proveedorBLL = ProveedoresBLL.Instance;
        private readonly SessionManager session = SessionManager.GetInstance;

        private ProductoCotizado productoSeleccionado;
        private OrdenDeReposicion ordenrepo;
        private SolicitudCotizacion solicitudcotizacion;
        private Cotizacion newCoti;
        public FrmRegistrarCotizacion()
        {
            InitializeComponent();
            dgvProductosCotizados.SelectionChanged += dgvProductosCotizados_SelectionChanged;
            txtProdCant.KeyPress += txtProdCant_KeyPress;
            txtProdPrecioUnidad.KeyPress += txtProdPrecioUnidad_KeyPress;
        }

        public void CargarSolicitudesCotizacion()
        {
            var solicitudes = solcotBLL.GetPending();
            var solicitudesViewModel = new List<SolicitudCotizacionViewModel>();

            foreach (var solicitud in solicitudes)
            {
                var ordenReposicion = ordenRepoBLL.GetById(solicitud.solcot_ordenrepo_id);
                int numeroOrdenReposicion = ordenReposicion?.orden_numero ?? 0;

                var proveedor = proveedorBLL.FindById(solicitud.solcot_proveedor);
                string nombreProveedor = proveedor?.proveedor_nombre ?? "N/A";

                var productosSolicitados = solcotBLL.GetProdSolicitados(solicitud.Id);


                solicitudesViewModel.Add(new SolicitudCotizacionViewModel
                {
                    Id = solicitud.Id,
                    NumeroSolicitud = solicitud.solcot_numero_solicitud,
                    FechaEmision = solicitud.solcot_fecha_solicitud,
                    NumeroOrdenReposicion = numeroOrdenReposicion,
                    NombreProveedor = nombreProveedor,
                    CantidadProductosSolicitados = productosSolicitados.Count()
                });
            }
            dgvSolicitudesCotizacion.DataSource = solicitudesViewModel;
            dgvSolicitudesCotizacion.Columns["Id"].Visible = false;
            dgvSolicitudesCotizacion.Columns["NumeroSolicitud"].HeaderText = "Número de Solicitud";
            dgvSolicitudesCotizacion.Columns["FechaEmision"].HeaderText = "Fecha de Emisión";
            dgvSolicitudesCotizacion.Columns["NumeroOrdenReposicion"].HeaderText = "Número de Orden de Reposición";
            dgvSolicitudesCotizacion.Columns["NombreProveedor"].HeaderText = "Nombre del Proveedor";
            dgvSolicitudesCotizacion.Columns["CantidadProductosSolicitados"].HeaderText = "Cantidad de Productos Solicitados";
            dgvSolicitudesCotizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void FrmRegistrarCotizacion_Load(object sender, EventArgs e)
        {
            CargarSolicitudesCotizacion();
            CargarComboCondiciones();
            
        }

        private void txtProdCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como retroceso)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada de caracteres no válidos
            }
        }
        // Maneja el evento KeyPress para restringir la entrada en txtProdPrecioUnidad
        private void txtProdPrecioUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, comas y teclas de control
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada de caracteres no válidos
            }
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            solicitudcotizacion = new SolicitudCotizacion();
            DataGridViewRow fila = dgvSolicitudesCotizacion.SelectedRows[0];
            solicitudcotizacion = solcotBLL.GetById((Guid)fila.Cells["Id"].Value);

            newCoti = new Cotizacion();
            newCoti.cotizacion_numero = cotBLL.GenerarNumeroCotizacion();
            newCoti.cotizacion_solcot_id = solicitudcotizacion.Id;
            newCoti.cotizacion_solicitud_cotizacion = solicitudcotizacion;
            newCoti.cotizacion_fecha_emision = DateTime.Now;
            newCoti.cotizacion_proveedor_id = solicitudcotizacion.solcot_proveedor;
            newCoti.cotizacion_proveedor = proveedorBLL.FindById(newCoti.cotizacion_proveedor_id);

            ClearData();
            MapperProdCotizados();
            ActualizarGrillaProductosCotizados();

            cmbCondiciones.Enabled = true;
            txtCotizacionNumero.Text = newCoti.cotizacion_numero.ToString();
            txtSolicitudNumero.Text = newCoti.cotizacion_solicitud_cotizacion.solcot_numero_solicitud.ToString();
            txtFechaEmision.Text = newCoti.cotizacion_fecha_emision.ToString();
            txtProveedor.Text = newCoti.cotizacion_proveedor.NombreCompleto.ToString();
        }

        private void ClearData()
        {
            txtProdNombre.Text = string.Empty;
            txtProdMarca.Text = string.Empty;
            txtProdModel.Text = string.Empty;
            txtProdCant.Text = string.Empty;
            txtProdPrecioUnidad.Text = string.Empty;
            btnActualizar.Enabled = false;
            btnRemProd.Enabled = false;
        }

        private void CargarComboCondiciones()
        {
            cmbCondiciones.DataSource = null;
            cmbCondiciones.DataSource = Enum.GetValues(typeof(EnumCondiciones));
            cmbCondiciones.Text = MultiLang.TranslateOrDefault("cmb.condicion", "Condicion");
        }

        private void MapperProdCotizados()
        {
            var prodSolicitados = solcotBLL.GetProdSolicitados(solicitudcotizacion.Id);
            newCoti.cotizacion_productos_cotizados = prodSolicitados.Select(ps => new ProductoCotizado
            {
                // Propiedades heredadas de ProductoSolicitado
                Id = ps.Id,
                producto_nombre = ps.producto_nombre,
                producto_marca = ps.producto_marca,
                producto_modelo = ps.producto_modelo,
                producto_tipo = ps.producto_tipo,
                producto_deposito = ps.producto_deposito,
                producto_stock = ps.producto_stock,
                producto_precio_unidad = ps.producto_precio_unidad,
                producto_descripcion = ps.producto_descripcion,
                producto_punto_pedido = ps.producto_punto_pedido,
                producto_activo = ps.producto_activo,
                producto_proveedor = ps.producto_proveedor,
                prodsol_cantidad = ps.prodsol_cantidad,
                productocotizado_precio_unidad = 0,
                productocotizado_total = 0
            }).ToList();
        }

        private void ActualizarGrillaProductosCotizados()
        {

            dgvProductosCotizados.DataSource = null;
            dgvProductosCotizados.DataSource = newCoti.cotizacion_productos_cotizados;

            dgvProductosCotizados.Columns["producto_nombre"].Visible = true;
            dgvProductosCotizados.Columns["producto_nombre"].DisplayIndex = 0;  // Primer columna
            dgvProductosCotizados.Columns["producto_nombre"].HeaderText = "Nombre";

            dgvProductosCotizados.Columns["producto_marca"].Visible = true;
            dgvProductosCotizados.Columns["producto_marca"].DisplayIndex = 1;  // Segunda columna
            dgvProductosCotizados.Columns["producto_marca"].HeaderText = "Marca";

            dgvProductosCotizados.Columns["producto_modelo"].Visible = true;
            dgvProductosCotizados.Columns["producto_modelo"].DisplayIndex = 2;  // Tercera columna
            dgvProductosCotizados.Columns["producto_modelo"].HeaderText = "Modelo";

            dgvProductosCotizados.Columns["prodsol_cantidad"].Visible = true;
            dgvProductosCotizados.Columns["prodsol_cantidad"].DisplayIndex = 3;  // Cuarta columna
            dgvProductosCotizados.Columns["prodsol_cantidad"].HeaderText = "Cantidad Solicitada";

            dgvProductosCotizados.Columns["productocotizado_precio_unidad"].Visible = true;
            dgvProductosCotizados.Columns["productocotizado_precio_unidad"].DisplayIndex = 4;  // Quinta columna
            dgvProductosCotizados.Columns["productocotizado_precio_unidad"].HeaderText = "Precio Unidad";

            dgvProductosCotizados.Columns["productocotizado_total"].Visible = true;
            dgvProductosCotizados.Columns["productocotizado_total"].DisplayIndex = 5;  // Sexta columna
            dgvProductosCotizados.Columns["productocotizado_total"].HeaderText = "Total";

            foreach (DataGridViewColumn column in dgvProductosCotizados.Columns)
            {
                if (column.Name != "producto_nombre" &&
                    column.Name != "producto_marca" &&
                    column.Name != "prodsol_cantidad" &&
                    column.Name != "productocotizado_precio_unidad" &&
                    column.Name != "productocotizado_total")
                {
                    column.Visible = false;
                }
            }
            dgvProductosCotizados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnSelectProd_Click(object sender, EventArgs e)
        {
            if (dgvProductosCotizados.CurrentRow != null)
            {
                productoSeleccionado = (ProductoCotizado)dgvProductosCotizados.CurrentRow.DataBoundItem;
                txtProdNombre.Text = productoSeleccionado.producto_nombre;
                txtProdMarca.Text = productoSeleccionado.producto_marca;
                txtProdModel.Text = productoSeleccionado.producto_modelo;
                txtProdCant.Text = productoSeleccionado.prodsol_cantidad.ToString();
                txtProdCant.Enabled = true;
                txtProdPrecioUnidad.Text = string.Empty;
                txtProdPrecioUnidad.Enabled = true;
                btnActualizar.Enabled = true;
                if (newCoti.cotizacion_productos_cotizados.Count > 1)
                {
                    btnRemProd.Enabled = true;
                }
                else
                {
                    btnRemProd.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgvProductosCotizados_SelectionChanged(object sender, EventArgs e)
        {
            btnSelectProd.Enabled = dgvProductosCotizados.SelectedRows.Count > 0;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado != null)
            {
                // Validar y actualizar los valores de cantidad y precio unidad
                if (int.TryParse(txtProdCant.Text, out int cantidad) && double.TryParse(txtProdPrecioUnidad.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double precioUnidad))
                {
                    // Actualizar los valores en productoSeleccionado
                    productoSeleccionado.prodsol_cantidad = cantidad;
                    productoSeleccionado.productocotizado_precio_unidad = precioUnidad;
                    productoSeleccionado.productocotizado_total = cantidad * precioUnidad;

                    // Refresca el DataGridView para reflejar los cambios
                    dgvProductosCotizados.Refresh();

                    MessageBox.Show("Producto actualizado correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearData();
                    foreach (ProductoCotizado pc in newCoti.cotizacion_productos_cotizados)
                    {
                        if (pc.productocotizado_precio_unidad > 0)
                        {
                            btnSave.Enabled = true;
                        }
                        else
                        {
                            btnSave.Enabled = false;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese valores válidos para la cantidad y el precio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hay ningún producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtPiker1.Value.Date;
            DateTime fechaActual = DateTime.Now.Date;

            if (fechaSeleccionada <= fechaActual)
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("FechaNoValida", "Seleccione una fecha futura"), MultiLang.TranslateOrDefault("FechaNoValidaTitulo", "Fecha no valida"), MessageBoxButtons.OK);
                return;
            }
            else
            {
                newCoti.cotizacion_fecha_entrega = dtPiker1.Value;
                if (cmbCondiciones.Text == "Condicion")
                {
                    MessageBox.Show(MultiLang.TranslateOrDefault("FillCondiciones", "Seleccione una Condicion"), MultiLang.TranslateOrDefault("FillCondicionesTitulo", "Condiciones incompletas"), MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    //newCoti.cotizacion_condiciones = txtCondiciones.Text;
                    newCoti.cotizacion_condiciones = cmbCondiciones.SelectedValue.ToString();
                    newCoti.Id = Guid.NewGuid();
                    newCoti.cotizacion_estado = "Pendiente";
                    foreach (ProductoCotizado pc in newCoti.cotizacion_productos_cotizados)
                    {
                        newCoti.cotizacion_monto_total += pc.productocotizado_total;
                    }
                    try
                    {
                        var affected = cotBLL.SaveCotizacion(newCoti);
                        if (affected != 0)
                        {
                            MessageBox.Show(MultiLang.TranslateOrDefault("CotizacionGuarda", "Se ha registrado una cotizacion"), MultiLang.TranslateOrDefault("CotizacionGuardadaTitulo", "Cotizacion Registrada!"), MessageBoxButtons.OK);
                            var bita = new Bitacora($"Se ha registrado una cotizacion", "Media", DateTime.Now, "Compras - Registrar Cotizacion", session.User.Username.ToString());
                            bitacoraBLL.SaveBitacora(bita);
                            var x = solcotBLL.UpdateState(newCoti.cotizacion_solcot_id, "Cotizada");
                            CargarSolicitudesCotizacion();
                            ClearData();
                            ClearCotizacion();
                        }
                        else
                        {
                            MessageBox.Show(MultiLang.TranslateOrDefault("CotizacionNoGuardada", "Algo ha ocurrido. Cotizacion no registrada"), "Error", MessageBoxButtons.OK);
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
            
        }

        private void btnRemProd_Click(object sender, EventArgs e)
        {
            if (newCoti.cotizacion_productos_cotizados.Count > 1)
            {
                var fila = dgvProductosCotizados.SelectedRows[0];
                var pid = (Guid)fila.Cells["id"].Value;
                newCoti.RemProduct(pid);
                ActualizarGrillaProductosCotizados();
                btnRemProd.Enabled = false;
            }
            else
            {
                return;
            }
        }

        private void ClearCotizacion()
        {
            txtCotizacionNumero.Text = string.Empty;
            txtSolicitudNumero.Text = string.Empty;
            txtFechaEmision.Text = string.Empty;
            txtProveedor.Text = string.Empty;
            dtPiker1.Value = DateTime.Now;
            btnSave.Enabled = false;
            dgvProductosCotizados.DataSource = null;
            cmbCondiciones.Enabled = false;
            CargarComboCondiciones();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
