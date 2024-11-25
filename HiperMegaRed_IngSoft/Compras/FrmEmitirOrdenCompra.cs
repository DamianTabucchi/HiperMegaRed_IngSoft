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
    public partial class FrmEmitirOrdenCompra : Form
    {
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;
        private CotizacionBLL cotBLL = CotizacionBLL.Instance;
        private ProveedoresBLL proveedorBLL = ProveedoresBLL.Instance;
        private OrdenDeCompraBLL ocBLL = OrdenDeCompraBLL.Instance;
        private readonly SessionManager session = SessionManager.GetInstance;

        Cotizacion coti;
        OrdenDeCompra ordenCompra;
        public FrmEmitirOrdenCompra()
        {
            InitializeComponent();
            ActualizarGrillaCotizacion();
        }

        public void ActualizarGrillaCotizacion()
        {
            var cotizaciones = cotBLL.GetPending();
            if (cotizaciones.Count > 0)
            {
                foreach (Cotizacion c in cotizaciones)
                {
                    c.cotizacion_proveedor = proveedorBLL.FindById(c.cotizacion_proveedor_id);
                    c.cotizacion_productos_cotizados.AddRange(cotBLL.GetProdSolicitados(c.Id));
                }

                dgvCotizaciones.DataSource = null;
                dgvCotizaciones.DataSource = cotizaciones.OrderBy(x => x.cotizacion_numero).ToList();

                dgvCotizaciones.Columns["cotizacion_numero"].Visible = true;
                dgvCotizaciones.Columns["cotizacion_numero"].DisplayIndex = 0;
                dgvCotizaciones.Columns["cotizacion_numero"].HeaderText = "Numero Cotizacion";

                dgvCotizaciones.Columns["NombreProveedor"].Visible = true;
                dgvCotizaciones.Columns["NombreProveedor"].DisplayIndex = 1;
                dgvCotizaciones.Columns["NombreProveedor"].HeaderText = "Nombre Proveedor";

                dgvCotizaciones.Columns["CantidadProductos"].Visible = true;
                dgvCotizaciones.Columns["CantidadProductos"].DisplayIndex = 2;
                dgvCotizaciones.Columns["CantidadProductos"].HeaderText = "Cantidad Productos";

                dgvCotizaciones.Columns["cotizacion_monto_total"].Visible = true;
                dgvCotizaciones.Columns["cotizacion_monto_total"].DisplayIndex = 3;
                dgvCotizaciones.Columns["cotizacion_monto_total"].HeaderText = "Monto Total";

                dgvCotizaciones.Columns["cotizacion_condiciones"].Visible = true;
                dgvCotizaciones.Columns["cotizacion_condiciones"].DisplayIndex = 4;
                dgvCotizaciones.Columns["cotizacion_condiciones"].HeaderText = "Condiciones";

                foreach (DataGridViewColumn column in dgvCotizaciones.Columns)
                {
                    if (column.Name != "cotizacion_numero" &&
                        column.Name != "NombreProveedor" &&
                        column.Name != "CantidadProductos" &&
                        column.Name != "cotizacion_condiciones" &&
                        column.Name != "cotizacion_monto_total")
                    {
                        column.Visible = false;
                    }
                }

                dgvCotizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("No hay cotizaciones","Sin Cotizaciones", MessageBoxButtons.OK);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvCotizaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvCotizaciones.SelectedRows[0];
                coti = (Cotizacion)fila.DataBoundItem;
                CargarDatosOrden();
                txtOrdenNumero.Text = ordenCompra.ordendecompra_numero.ToString();
                txtFechaEmision.Text = DateTime.Today.ToString();
                txtProveedor.Text = ordenCompra.ordendecompra_proveedor.proveedor_nombre_poc;
                txtCotNum.Text = coti.cotizacion_numero.ToString();
                dtpCotizacion.Value = coti.cotizacion_fecha_emision;
                txtDireccion.Text = ordenCompra.ordendecompra_direccion;
                dtpEntrega.Value = dtpCotizacion.Value.AddDays(14);
                dtpEntrega.Enabled = true;
                txtNumeroContacto.Text = ordenCompra.ordendecompra_numerocontacto;
                txtCondiciones.Text = coti.cotizacion_condiciones;
                CargarProductosCotizados();
                txtTotalPagar.Text = ordenCompra.ordendecompra_total.ToString();
                btnEmitirOrden.Enabled = true;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una cotizacion", "Seleccion nula", MessageBoxButtons.OK);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CargarDatosOrden()
        {
            ordenCompra = new OrdenDeCompra();
            ordenCompra.ordendecompra_numero = ocBLL.GenerarNumeroOrden();
            ordenCompra.ordendecompra_cotizacion_id = coti.Id;
            ordenCompra.ordendecompra_cotizacion = coti;
            ordenCompra.ordendecompra_proveedor_id = coti.cotizacion_proveedor_id;
            ordenCompra.ordendecompra_total = coti.cotizacion_monto_total;
            ordenCompra.ordendecompra_proveedor = coti.cotizacion_proveedor;
        }

        private void CargarProductosCotizados()
        {
            if (coti != null || coti.cotizacion_productos_cotizados.Count > 0)
            {
                dgvProductosCotizados.DataSource = null;
                dgvProductosCotizados.DataSource = coti.cotizacion_productos_cotizados;

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
            else
            {
                MessageBox.Show("No hay productos cotizados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtOrdenNumero.Text = string.Empty;
            txtFechaEmision.Text = string.Empty;
            txtProveedor.Text = string.Empty;
            txtCotNum.Text = string.Empty;
            dtpCotizacion.Value = DateTime.Today;
            txtDireccion.Text = string.Empty;
            dtpEntrega.Value = DateTime.Today;
            dtpEntrega.Enabled = false;
            txtNumeroContacto.Text = string.Empty;
            txtCondiciones.Text = string.Empty;
            txtTotalPagar.Text = string.Empty;
            dgvProductosCotizados.DataSource = null;
            ordenCompra = new OrdenDeCompra();
            coti = new Cotizacion();
            btnEmitirOrden.Enabled = false;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnEmitirOrden_Click(object sender, EventArgs e)
        {
            ordenCompra.Id = Guid.NewGuid();
            ordenCompra.ordendecompra_fecha_entrega = dtpEntrega.Value.Date;
            ordenCompra.ordendecompra_condiciones = txtCondiciones.Text;
            ordenCompra.ordendecompra_direccion = txtDireccion.Text;
            ordenCompra.ordendecompra_numerocontacto = txtNumeroContacto.Text;
            ordenCompra.ordendecompra_fecha_emision = DateTime.Today;
            try
            {
                var affected = ocBLL.SaveOrdenDeCompra(ordenCompra);
                if (affected > 0)
                {
                    MessageBox.Show("Se ha guardado una Orden de Compra", "Orden Guardada", MessageBoxButtons.OK);
                }
                cotBLL.UpdateState(ordenCompra.ordendecompra_cotizacion_id, "OrdenGenerada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GenerarOrdenDeCompraPDF(ordenCompra);
            ClearFields();
            ActualizarGrillaCotizacion();
        }

        public void GenerarOrdenDeCompraPDF(OrdenDeCompra ordcompra)
        {
            // Obtiene los datos del proveedor usando el ID del proveedor en la solicitud de cotización
            //var proveedor = proveedorBLL.FindById(solicitudcotizacion.solcot_proveedor);

            // Genera el nombre del archivo con la fecha y el nombre del proveedor
            string nombreArchivo = $"Orden de Compra {ordcompra.ordendecompra_numero} {ordcompra.ordendecompra_fecha_emision:yyyy-MM-dd} {ordcompra.ordendecompra_proveedor.proveedor_nombre} {ordcompra.ordendecompra_proveedor.proveedor_nombre_poc}.pdf";

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
                    document.Add(new Paragraph("ORDEN DE COMPRA")
                        .SetFont(font)
                        .SetFontSize(16)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER));

                    // Membrete de la empresa
                    document.Add(new Paragraph("Hipermegared!")
                        .SetFont(font)
                        .SetFontSize(12)
                        .SetBold());

                    //Numero de Orden
                    document.Add(new Paragraph($"Numero de Orden: {ordcompra.ordendecompra_numero}")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Fecha de emisión
                    document.Add(new Paragraph($"Fecha emisión: {ordcompra.ordendecompra_fecha_emision:dd/MM/yyyy}")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Destinatario
                    document.Add(new Paragraph($"Señor(es): {ordcompra.ordendecompra_proveedor.proveedor_nombre_poc}")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Cuerpo con numero de cotizacion y fecha de cotizacion
                    document.Add(new Paragraph($"Sirvanse proveernos los siguientes elementos, de acuerdo con su cotizacion N° {ordcompra.ordendecompra_cotizacion.cotizacion_numero} de fecha {ordcompra.ordendecompra_cotizacion.cotizacion_fecha_emision:dd/MM/yyyy}. \n")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Tabla de productos solicitados
                    Table table = new Table(5);  // 5 columnas: Item, Cantidad, Descripción, Precio unitario, total
                    table.SetWidth(UnitValue.CreatePercentValue(100));  // Ocupa el ancho completo

                    // Encabezados de la tabla
                    table.AddHeaderCell("Item").SetFont(font).SetBold();
                    table.AddHeaderCell("Cantidad").SetFont(font).SetBold();
                    table.AddHeaderCell("Descripción").SetFont(font).SetBold();
                    table.AddHeaderCell("Precio Unitario").SetFont(font).SetBold();
                    table.AddHeaderCell("TOTAL").SetFont(font).SetBold();

                    // Agrega los productos solicitados a la tabla
                    int item = 1;
                    foreach (var pc in ordcompra.ordendecompra_cotizacion.cotizacion_productos_cotizados)
                    {
                        table.AddCell(item.ToString()).SetFont(font);
                        table.AddCell(pc.prodsol_cantidad.ToString()).SetFont(font);
                        table.AddCell($"{pc.producto_nombre} {pc.producto_marca} {pc.producto_modelo}").SetFont(font);
                        table.AddCell($"{pc.productocotizado_precio_unidad}");
                        table.AddCell($"{pc.productocotizado_total}");
                        item++;
                    }
                    table.AddCell("").SetFont(font);
                    table.AddCell("").SetFont(font);
                    table.AddCell("").SetFont(font);
                    table.AddCell("").SetFont(font);
                    table.AddCell(ordcompra.ordendecompra_total.ToString()).SetFont(font).SetBold();

                    // Agrega la tabla al documento
                    document.Add(table);

                    //Table tabletotal = new Table(1);
                    //tabletotal.SetWidth(UnitValue.CreatePercentValue(25));

                    //tabletotal.AddHeaderCell("TOTAL").SetFont(font).SetBold();
                    //tabletotal.AddCell(ordcompra.ordendecompra_total.ToString()).SetFont(font).SetBold();

                    //document.Add(tabletotal);

                    // Texto adicional de especificaciones de cotización
                    document.Add(new Paragraph($"\nLa mercaderia debe entregarse en: {ordcompra.ordendecompra_direccion} antes de {ordcompra.ordendecompra_fecha_entrega:dd/MM/yyyy}\n \n " +
                        $"Ante cualquier consulta, contactar con: {ordcompra.ordendecompra_numerocontacto} \n \n" +
                        $"Enviar factura a: {ordcompra.ordendecompra_direccion} \n \n" +
                        $"CONDICIONES DE PAGO: {ordcompra.ordendecompra_condiciones} \n \n" +
                        $"Son pesos {ordcompra.ordendecompra_total}")
                        .SetFont(font)
                        .SetFontSize(10));

                    // Cierra el documento
                    document.Close();
                }
            }

            MessageBox.Show($"El archivo PDF '{nombreArchivo}' se ha creado correctamente en el escritorio.", "Archivo creado", MessageBoxButtons.OK);
        }
    }
}
