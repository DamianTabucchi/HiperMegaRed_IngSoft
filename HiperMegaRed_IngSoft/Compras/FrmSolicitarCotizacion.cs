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
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;

namespace HiperMegaRed_IngSoft.Compras
{
    public partial class FrmSolicitarCotizacion : Form
    {
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;
        private OrdenDeReposicionBLL ordenRepoBLL = OrdenDeReposicionBLL.Instance;
        private SolicitudCotizacionBLL solcotBLL = SolicitudCotizacionBLL.Instance;
        private ProveedoresBLL proveedorBLL = ProveedoresBLL.Instance;
        private readonly SessionManager session = SessionManager.GetInstance;
        private UserBLL userBLL = UserBLL.Instance;
        
        
        private OrdenDeReposicion ordenrepo;
        private SolicitudCotizacion solicitudcotizacion;



        public FrmSolicitarCotizacion()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }
        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        private void FrmSolicitarCotizacion_Load(object sender, EventArgs e)
        {
            ActualizarGrillaOrdenes();
        }

        private void ActualizarGrillaOrdenes()
        {
            var ordenesPendientes = ordenRepoBLL.GetByState(TipoEstado.Aprobada);
            if (ordenesPendientes.Count == 0 || ordenesPendientes == null)
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("Sin.Ordenes", "No hay ordenes de reposición"), MultiLang.TranslateOrDefault("No.Orders", "No hay ordenes de reposicion"), MessageBoxButtons.OK);
                if (dgvOrdenes.ColumnCount > 0)
                {
                    dgvOrdenes.DataSource = null;
                }
                return;
            }
            else
            {
                dgvOrdenes.DataSource = null;
                dgvOrdenes.DataSource = ordenesPendientes.OrderBy(x => x.orden_numero).ToList();
                dgvOrdenes.Columns["orden_numero"].Visible = true;
                dgvOrdenes.Columns["orden_numero"].DisplayIndex = 0;  // Primer columna
                dgvOrdenes.Columns["orden_numero"].HeaderText = "Numero Orden";

                dgvOrdenes.Columns["orden_fecha_creacion"].Visible = true;
                dgvOrdenes.Columns["orden_fecha_creacion"].DisplayIndex = 1;  // Primer columna
                dgvOrdenes.Columns["orden_fecha_creacion"].HeaderText = "Fecha Creacion";

                dgvOrdenes.Columns["orden_justificacion"].Visible = true;
                dgvOrdenes.Columns["orden_justificacion"].DisplayIndex = 2;  // Primer columna
                dgvOrdenes.Columns["orden_justificacion"].HeaderText = "Justificacion";

                foreach (DataGridViewColumn column in dgvOrdenes.Columns)
                {
                    if (column.Name != "orden_numero" &&
                        column.Name != "orden_fecha_creacion" &&
                        column.Name != "orden_justificacion")
                    {
                        column.Visible = false;
                    }
                }

                dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void CargarProveedores()
        {
            var provs = proveedorBLL.GetActive();
            var tiposDeProductoEnSolicitud = solicitudcotizacion.solcot_productos.Select(p => p.producto_tipo).Distinct().ToList();
            var proveedoresFiltrados = provs.Where(proveedor => tiposDeProductoEnSolicitud.Contains(proveedor.proveedor_categoria)).ToList();
            cmbProveedores.DataSource = null;
            cmbProveedores.DataSource = proveedoresFiltrados;
            cmbProveedores.DisplayMember = "NombreCompleto";
            cmbProveedores.ValueMember = "Id";
        }
        private void ActualizarGrillaProductosSolicitados()
        {
            if (ordenrepo.orden_productos_solicitados.Count > 0)
            {
                dgvProdSolicitados.DataSource = null;
                dgvProdSolicitados.DataSource = ordenrepo.orden_productos_solicitados;

                dgvProdSolicitados.Columns["producto_nombre"].Visible = true;
                dgvProdSolicitados.Columns["producto_nombre"].DisplayIndex = 0;  // Primer columna
                dgvProdSolicitados.Columns["producto_nombre"].HeaderText = "Nombre";

                dgvProdSolicitados.Columns["producto_marca"].Visible = true;
                dgvProdSolicitados.Columns["producto_marca"].DisplayIndex = 1;  // Segunda columna
                dgvProdSolicitados.Columns["producto_marca"].HeaderText = "Marca";

                dgvProdSolicitados.Columns["producto_modelo"].Visible = true;
                dgvProdSolicitados.Columns["producto_modelo"].DisplayIndex = 2;  // Tercera columna
                dgvProdSolicitados.Columns["producto_modelo"].HeaderText = "Modelo";

                dgvProdSolicitados.Columns["producto_tipo"].Visible = true;
                dgvProdSolicitados.Columns["producto_tipo"].DisplayIndex = 3;  // Cuarta columna
                dgvProdSolicitados.Columns["producto_tipo"].HeaderText = "Tipo";

                dgvProdSolicitados.Columns["producto_stock"].Visible = true;
                dgvProdSolicitados.Columns["producto_stock"].DisplayIndex = 4;  // Quinta columna
                dgvProdSolicitados.Columns["producto_stock"].HeaderText = "Stock Actual";

                dgvProdSolicitados.Columns["prodsol_cantidad"].Visible = true;
                dgvProdSolicitados.Columns["prodsol_cantidad"].DisplayIndex = 5;  // Sexta columna
                dgvProdSolicitados.Columns["prodsol_cantidad"].HeaderText = "Cantidad Solicitada";

                foreach (DataGridViewColumn column in dgvProdSolicitados.Columns)
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
                dgvProdSolicitados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                dgvProdSolicitados.DataSource = null;
            }
            
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            ordenrepo = new OrdenDeReposicion();
            DataGridViewRow fila = dgvOrdenes.SelectedRows[0];
            ordenrepo = ordenRepoBLL.GetById((Guid)fila.Cells["Id"].Value);
            var productossolicitados = ordenRepoBLL.GetProdSolicitados(ordenrepo.Id);
            ordenrepo.orden_productos_solicitados.AddRange(productossolicitados);

            txtOrderNumber.Text = ordenrepo.orden_numero.ToString();
            txtCreationDate.Text = ordenrepo.orden_fecha_creacion.ToString();
            var usuariosolicitante = userBLL.FindById((Guid)ordenrepo.orden_solicitante);
            txtApplicant.Text = usuariosolicitante.Username.ToString();
            txtApprovalDate.Text = ordenrepo.orden_fecha_aprobacion.ToString();
            var usuarioaprobador = userBLL.FindById((Guid)ordenrepo.orden_aprobador);
            txtApprover.Text = usuarioaprobador.Username.ToString();
            txtJustify.Text = ordenrepo.orden_justificacion.ToString();
            ActualizarGrillaProductosSolicitados();
            btnGenerarSolicitud.Enabled = true;
        }

        private void btnGenerarSolicitud_Click(object sender, EventArgs e)
        {
            CargarSolicitud();
            CargarComponentesSolicitud();
        }

        private void CargarSolicitud()
        {
            solicitudcotizacion = new SolicitudCotizacion();
            solicitudcotizacion.Id = Guid.NewGuid();
            solicitudcotizacion.solcot_numero_solicitud = solcotBLL.GenerarNumeroSolicitud();
            solicitudcotizacion.solcot_fecha_solicitud = DateTime.Now;
            solicitudcotizacion.solcot_ordenrepo_id = ordenrepo.Id;
            solicitudcotizacion.solcot_productos.AddRange(ordenrepo.orden_productos_solicitados);
            solicitudcotizacion.solcot_solicitante = session.User.Id;
            CargarGrillaSolicitudProductos();
            CargarProveedores();
        }
        public void CargarComponentesSolicitud()
        {
            cmbProveedores.Enabled = true;
            txtSolNum.Text = solicitudcotizacion.solcot_numero_solicitud.ToString();
            txtSolFecha.Text = solicitudcotizacion.solcot_fecha_solicitud.ToString();
            txtSolOrdenNum.Text = ordenrepo.orden_numero.ToString();
            btnNewSupplier.Enabled = true;
            btnEmitirSolicitud.Enabled = true;
            btnCancelar.Enabled = true;
        }
        private void CargarGrillaSolicitudProductos()
        {
            if (solicitudcotizacion == null || solicitudcotizacion.solcot_productos.Count == 0)
            {
                dgvSolicitudProductos.DataSource = null;
                return;
            }
            else
            {
                dgvSolicitudProductos.DataSource = null;
                dgvSolicitudProductos.DataSource = solicitudcotizacion.solcot_productos;
                dgvSolicitudProductos.Columns["producto_nombre"].Visible = true;
                dgvSolicitudProductos.Columns["producto_nombre"].DisplayIndex = 0;  // Primer columna
                dgvSolicitudProductos.Columns["producto_nombre"].HeaderText = "Nombre";

                dgvSolicitudProductos.Columns["producto_marca"].Visible = true;
                dgvSolicitudProductos.Columns["producto_marca"].DisplayIndex = 1;  // Segunda columna
                dgvSolicitudProductos.Columns["producto_marca"].HeaderText = "Marca";

                dgvSolicitudProductos.Columns["producto_modelo"].Visible = true;
                dgvSolicitudProductos.Columns["producto_modelo"].DisplayIndex = 2;  // Tercera columna
                dgvSolicitudProductos.Columns["producto_modelo"].HeaderText = "Modelo";

                dgvSolicitudProductos.Columns["prodsol_cantidad"].Visible = true;
                dgvSolicitudProductos.Columns["prodsol_cantidad"].DisplayIndex = 3;  // Cuarta columna
                dgvSolicitudProductos.Columns["prodsol_cantidad"].HeaderText = "Cantidad Solicitada";

                foreach (DataGridViewColumn column in dgvSolicitudProductos.Columns)
                {
                    if (column.Name != "producto_nombre" &&
                        column.Name != "producto_marca" &&
                        column.Name != "producto_modelo" &&
                        column.Name != "prodsol_cantidad")
                    {
                        column.Visible = false;
                    }
                }
                dgvProdSolicitados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            
        }

        public void RefreshInfo()
        {
            solicitudcotizacion = new SolicitudCotizacion();
            ordenrepo = new OrdenDeReposicion();
            ActualizarGrillaOrdenes();
            CargarProveedores();
            txtSolNum.Text = string.Empty;
            txtSolFecha.Text = string.Empty;
            txtSolOrdenNum.Text = string.Empty;
            btnNewSupplier.Enabled = false;
            btnEmitirSolicitud.Enabled = false;
            btnCancelar.Enabled = false;
            cmbProveedores.Enabled = false;
            txtOrderNumber.Text = string.Empty;
            txtCreationDate.Text = string.Empty;
            txtApplicant.Text = string.Empty;
            txtApprovalDate.Text = string.Empty;
            txtApprover.Text = string.Empty;
            txtJustify.Text = string.Empty;
            btnGenerarSolicitud.Enabled = false;
            CargarGrillaSolicitudProductos();
            ActualizarGrillaProductosSolicitados();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (ordenrepo.orden_estado == "SolicitarOtro")
            {
                ordenrepo.orden_estado = TipoEstado.Solicitada.ToString();
                ordenrepo.orden_fecha_aprobacion = DateTime.Now;
                ordenRepoBLL.ActualizarEstadoOrden(ordenrepo);
            }
            RefreshInfo();
        
        }

        private void btnEmitirSolicitud_Click(object sender, EventArgs e)
        {
            solicitudcotizacion.solcot_proveedor = (Guid)cmbProveedores.SelectedValue;
            var solicitudesrealizadasproveedor = solcotBLL.GetBySupplier(solicitudcotizacion.solcot_proveedor);
            if (solicitudesrealizadasproveedor.Count > 0)
            {
                foreach (SolicitudCotizacion scr in solicitudesrealizadasproveedor)
                {
                    if (scr.solcot_ordenrepo_id == ordenrepo.Id)
                    {
                        MessageBox.Show(MultiLang.TranslateOrDefault("YaExiste.Solicitud.Orden", "Ya se ha solicitado la cotización de esta orden a este proveedor"), "Error", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            var res = MessageBox.Show(MultiLang.TranslateOrDefault("emitir.solicitud.body", "Se creará una solicitud de cotización. ¿Continuar?"), MultiLang.TranslateOrDefault("emitir.solicitud", "¿Emitir solicitud?"), MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                solicitudcotizacion.solcot_estado = "Pendiente";
                solcotBLL.SaveSolicitud(solicitudcotizacion);
                GenerarSolicitudPDF(solicitudcotizacion);
                var bita = new Bitacora($"Se ha generado una solicitud de cotizacion", "Media", DateTime.Now, "Compras - Solicitar Cotizacion", session.User.Username.ToString());
                bitacoraBLL.SaveBitacora(bita);

                var res2 = MessageBox.Show(MultiLang.TranslateOrDefault("Emitir.Otra.Solicitud", "¿Desea solicitar cotizacion a otro proveedor?"), MultiLang.TranslateOrDefault("otra.solicitud", "¿Emitir otra solicitud?"), MessageBoxButtons.YesNo);
                if (res2 == DialogResult.No)
                {
                    ordenrepo.orden_estado = TipoEstado.Solicitada.ToString();
                    ordenrepo.orden_fecha_aprobacion = DateTime.Now;
                    ordenRepoBLL.ActualizarEstadoOrden(ordenrepo);
                    RefreshInfo();
                }
                else
                {
                    ordenrepo.orden_estado = "SolicitarOtro";
                    CargarSolicitud();
                }


            }
            else
            {
                return;
            }
        }



        public void GenerarSolicitudPDF(SolicitudCotizacion solicitudcotizacion)
        {
            // Obtiene los datos del proveedor usando el ID del proveedor en la solicitud de cotización
            var proveedor = proveedorBLL.FindById(solicitudcotizacion.solcot_proveedor);

            // Genera el nombre del archivo con la fecha y el nombre del proveedor
            string nombreArchivo = $"Solicitud {solicitudcotizacion.solcot_numero_solicitud} {solicitudcotizacion.solcot_fecha_solicitud:yyyy-MM-dd} {proveedor.proveedor_nombre} {proveedor.proveedor_nombre_poc}.pdf";

            // Ruta del archivo PDF
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);

            // Crear el documento PDF
            using (PdfWriter writer = new PdfWriter(rutaArchivo))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Configura la fuente estándar
                    PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    // Título
                    document.Add(new Paragraph("Pedido de cotización a distintos proveedores.")
                        .SetFont(font)
                        .SetFontSize(14)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER));

                    // Membrete de la empresa
                    document.Add(new Paragraph("Hipermegared!")
                        .SetFont(font)
                        .SetFontSize(12)
                        .SetBold());

                    // Fecha de emisión
                    document.Add(new Paragraph($"Fecha emisión: {solicitudcotizacion.solcot_fecha_solicitud:dd/MM/yyyy}")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Pedido de Cotizacion N
                    document.Add(new Paragraph($"Pedido de Cotizacion: {solicitudcotizacion.solcot_numero_solicitud}")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Destinatario
                    document.Add(new Paragraph($"Señor(a): {proveedor.proveedor_nombre_poc}")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Referencia a la orden de reposición
                    document.Add(new Paragraph($"Ref.: Pedido de Reposición: {ordenrepo.orden_numero}")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Cuerpo de introducción
                    document.Add(new Paragraph("\nDe nuestra consideración:\nNos dirigimos a Ud a fin de solicitarles procedan a cotizar los elementos que a continuación detallamos:\n")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Tabla de productos solicitados
                    Table table = new Table(3);  // 3 columnas: Item, Cantidad, Descripción
                    table.SetWidth(UnitValue.CreatePercentValue(100));  // Ocupa el ancho completo

                    // Encabezados de la tabla
                    table.AddHeaderCell("Item").SetFont(font).SetBold();
                    table.AddHeaderCell("Cantidad").SetFont(font).SetBold();
                    table.AddHeaderCell("Descripción").SetFont(font).SetBold();

                    // Agrega los productos solicitados a la tabla
                    int item = 1;
                    foreach (var prodsol in solicitudcotizacion.solcot_productos)
                    {
                        table.AddCell(item.ToString()).SetFont(font);
                        table.AddCell(prodsol.prodsol_cantidad.ToString()).SetFont(font);
                        table.AddCell($"{prodsol.producto_nombre} {prodsol.producto_marca} {prodsol.producto_modelo}").SetFont(font);
                        item++;
                    }

                    // Agrega la tabla al documento
                    document.Add(table);

                    // Texto adicional de especificaciones de cotización
                    document.Add(new Paragraph("\nRogamos indicar:\n" +
                        "a) Fecha estimada de entrega, en días corridos contados a partir de la fecha de recepción de la Orden de Compras.\n" +
                        "b) Precio unitario sin incluir impuestos.\n" +
                        "c) Precio total con impuestos incluidos y discriminados.\n" +
                        "d) Mantenimiento de la oferta en días corridos contados a partir de la fecha de su cotización.\n" +
                        "e) Condiciones de pago indicando descuentos por pago contado y otros.\n\n" +
                        "La cotización debe observar INDEFECTIBLEMENTE las características detalladas y puede ser remitida por correo o personalmente.\n" +
                        "Este pedido debe ser recepcionado antes de la fecha indicada en el correo electrónico en el que fue adjunta.\n" +
                        "EN CASO DE NO COTIZAR ROGAMOS IGUALMENTE CONTESTAR.")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Cierra el documento
                    document.Close();
                }
            }

            MessageBox.Show($"El archivo PDF '{nombreArchivo}' se ha creado correctamente en el escritorio.","Archivo creado", MessageBoxButtons.OK);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario de registro de proveedor
            FrmRegistrarProveedor frmRegistrarProveedor = new FrmRegistrarProveedor();

            // Muestra el formulario como diálogo modal
            frmRegistrarProveedor.ShowDialog();

            // Llamar a CargarProveedores si el formulario fue cerrado después de registrar o cancelar
            CargarProveedores();
        }
    }
}
