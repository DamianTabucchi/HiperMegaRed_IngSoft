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
    public partial class FrmAprobarOrdenReposicion : Form
    {
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;
        private OrdenDeReposicionBLL ordenRepoBLL = OrdenDeReposicionBLL.Instance;
        private readonly SessionManager session = SessionManager.GetInstance;
        private UserBLL userBLL = UserBLL.Instance;
        private ProductoSolicitado prodselect;
        private OrdenDeReposicion ordenrepo;
        private IList<OrdenDeReposicion> ordenes;

        public FrmAprobarOrdenReposicion()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }

        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        private void FrmAprobarOrdenReposicion_Load(object sender, EventArgs e)
        {
            ActualizarGrillaOrdenes();
        }

        private void ActualizarGrillaOrdenes()
        {
            var ordenesPendientes = ordenRepoBLL.GetPending();
            if (ordenesPendientes.Count == 0 || ordenesPendientes == null)
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("Sin.Ordenes","No hay ordenes pendientes de aprobación"), MultiLang.TranslateOrDefault("No.Orders", "No hay ordenes pendientes"),MessageBoxButtons.OK);
                dgvOrdenes.DataSource = null;
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

                dgvOrdenes.Columns["orden_tipo"].Visible = true;
                dgvOrdenes.Columns["orden_tipo"].DisplayIndex = 2;
                dgvOrdenes.Columns["orden_tipo"].HeaderText = "Tipo de Pedido";

                dgvOrdenes.Columns["orden_justificacion"].Visible = true;
                dgvOrdenes.Columns["orden_justificacion"].DisplayIndex = 3;  // Primer columna
                dgvOrdenes.Columns["orden_justificacion"].HeaderText = "Justificacion";

                foreach (DataGridViewColumn column in dgvOrdenes.Columns)
                {
                    if (column.Name != "orden_numero" &&
                        column.Name != "orden_fecha_creacion" &&
                        column.Name != "orden_justificacion" &&
                        column.Name != "orden_tipo")
                    {
                        column.Visible = false;
                    }
                }
                dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void ActualizarGrillaProductosSolicitados()
        {
            if (ordenrepo != null && ordenrepo.orden_productos_solicitados.Count > 0)
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
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes != null && dgvOrdenes.Rows.Count > 0)
            {
                if (dgvOrdenes.SelectedRows.Count > 0)
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
                    txtApprover.Text = SessionManager.GetInstance.User.Username.ToString();
                    txtJustify.Text = ordenrepo.orden_justificacion.ToString();
                    ActualizarGrillaProductosSolicitados();
                    btnApprove.Enabled = true;
                    btnReject.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hay datos disponibles en la tabla de órdenes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarComponentes()
        {
            txtOrderNumber.Text = string.Empty;
            txtCreationDate.Text = string.Empty;
            txtApplicant.Text = string.Empty;
            txtApprovalDate.Text = string.Empty;
            txtApprover.Text = string.Empty;
            txtJustify.Text = string.Empty;
            dgvProdSolicitados.DataSource = null;
            btnReject.Enabled = false;
            btnApprove.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (ordenrepo != null)
            {
                if (string.Equals(txtJustify.Text, ordenrepo.orden_justificacion, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(MultiLang.TranslateOrDefault("Justifique.Rechazo", "Por favor, justifique su rechazo"), MultiLang.TranslateOrDefault("Justificacion.Rechazo", "Justifique el Rechazo"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var resultado = MessageBox.Show(MultiLang.TranslateOrDefault("Confirmar.Rechazo", "¿Esta seguro de rechazar la orden?"), MultiLang.TranslateOrDefault("Confirm.Rechazo", "¿Rechazar?"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (resultado == DialogResult.Yes)
                    {
                        ordenrepo.orden_justificacion = txtJustify.Text;
                        ordenrepo.orden_aprobador = SessionManager.GetInstance.User.Id;
                        ordenrepo.orden_estado = TipoEstado.Rechazada.ToString();
                        ordenrepo.orden_fecha_aprobacion = DateTime.Now;
                        var affected = ordenRepoBLL.ActualizarEstadoOrden(ordenrepo);
                        ActualizarGrillaOrdenes();
                        ActualizarComponentes();
                        var bita = new Bitacora("Orden de Reposicion Rechazada", "Media", DateTime.Now, session.User.Username);
                        bitacoraBLL.SaveBitacora(bita);
                    }
                    else if (resultado == DialogResult.Cancel)
                    {
                        ActualizarComponentes();
                    }
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (ordenrepo != null)
            {
                var resultado = MessageBox.Show(MultiLang.TranslateOrDefault("Confirmar.Aprobacion", "¿Esta seguro de aprobar la orden?"), MultiLang.TranslateOrDefault("Confirm.Aprobacion", "¿Aprobar?"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (resultado == DialogResult.Yes)
                {
                    ordenrepo.orden_justificacion = txtJustify.Text;
                    ordenrepo.orden_aprobador = SessionManager.GetInstance.User.Id;
                    ordenrepo.orden_estado = TipoEstado.Aprobada.ToString();
                    ordenrepo.orden_fecha_aprobacion = DateTime.Now;
                    var affected = ordenRepoBLL.ActualizarEstadoOrden(ordenrepo);
                    ActualizarGrillaOrdenes();
                    ActualizarComponentes();
                    var bita = new Bitacora("Orden de Reposicion Aceptada", "Baja", DateTime.Now, session.User.Username);
                    bitacoraBLL.SaveBitacora(bita);
                }
                else if (resultado == DialogResult.Cancel)
                {
                    ActualizarComponentes();
                }
            }
        }
    }
}
