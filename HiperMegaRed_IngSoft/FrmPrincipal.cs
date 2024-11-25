using HiperMegaRed.BE;
using HiperMegaRed.BLL;
using HiperMegaRed.DAL.MultiLenguaje;
using HiperMegaRed.DAL;
using HiperMegaRed.Services;
using HiperMegaRed_IngSoft.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiperMegaRed_IngSoft.Productos;
using HiperMegaRed_IngSoft.Compras;

namespace HiperMegaRed_IngSoft
{
    public partial class FrmPrincipal : Form
    {
        private readonly SessionManager session = SessionManager.GetInstance;
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private static BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;
        private static BackupBLL backBLL = BackupBLL.Instance;
        
        

        public FrmPrincipal()
        {
            InitializeComponent();
            GlobalStorage.Deposito = productBLL.GetAllWithStock();
            ShowMenus();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
            this.WindowState = FormWindowState.Maximized;
        }

        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        // Modificar visibilidad de menues según permisos
        private void ShowMenus()
        {
            if (session.TienePermiso(TipoPermiso.Admin))
            {
                this.usuarioToolStripMenuItem1.Visible = true;
                this.registrarToolStripMenuItem1.Visible = true;
                this.modificar2ToolStripMenuItem.Visible = true;
                this.cambiarContraseñaToolStripMenuItem.Visible = true;
                this.administrarPermisosToolStripMenuItem.Visible = true;

                this.productosToolStripMenuItem.Visible = true;
                this.verProductosToolStripMenuItem.Visible = true;
                this.aPagarToolStripMenuItem.Visible = true;
                this.entregarProductosToolStripMenuItem.Visible = true;

                this.comprasToolStripMenuItem.Visible = true;
                this.solicitarCotizacionToolStripMenuItem.Visible = true;
                this.registrarCotizacionToolStripMenuItem.Visible = true;
                this.emitirOrdenDeCompraToolStripMenuItem.Visible = true;

                this.productosToolStripMenuItem2.Visible = true;
                this.emitirOrdenDeReposicionToolStripMenuItem.Visible = true;
                this.emitirSolicitudDeCompraToolStripMenuItem.Visible = true;
                this.validarToolStripMenuItem.Visible = true;

                this.clientesToolStripMenuItem.Visible = true;
                this.registrarClienteToolStripMenuItem.Visible = true;

                this.permisosToolStripMenuItem.Visible = true;
                this.administrarPermisosToolStripMenuItem1.Visible = true;

                this.bitacoraToolStripMenuItem.Visible = true;
                this.bitacoraDeEventosToolStripMenuItem.Visible = true;
                this.bitácoraDeCambiosToolStripMenuItem.Visible = true;

                this.baseDeDatosToolStripMenuItem.Visible = true;
                this.backUpToolStripMenuItem.Visible = true;
                this.restoreToolStripMenuItem.Visible = true;

                this.aBMToolStripMenuItem.Visible = true;
                this.productosToolStripMenuItem1.Visible = true;

                this.reportesToolStripMenuItem.Visible = true;
                this.generarReporteToolStripMenuItem.Visible = true;

                this.gestionarIdiomaToolStripMenuItem.Visible = true;
            }

            if (session.TienePermiso(TipoPermiso.Vendedor))
            {
                this.productosToolStripMenuItem.Visible = true;
                this.verProductosToolStripMenuItem.Visible = true;
            }

            if (session.TienePermiso(TipoPermiso.Cajero))
            {
                this.productosToolStripMenuItem.Visible = true;
                this.aPagarToolStripMenuItem.Visible = true;
            }

            if (session.TienePermiso(TipoPermiso.Despachador))
            {
                this.productosToolStripMenuItem.Visible = true;
                this.entregarProductosToolStripMenuItem.Visible = true;
            }

            if (session.TienePermiso(TipoPermiso.Deposito))
            {
                this.productosToolStripMenuItem2.Visible = true;
                this.emitirOrdenDeReposicionToolStripMenuItem.Visible = true;
            }

            if (session.TienePermiso(TipoPermiso.SectorVarios))
            {
                this.productosToolStripMenuItem2.Visible = true;
                this.emitirSolicitudDeCompraToolStripMenuItem.Visible = true;
            }

            if (session.TienePermiso(TipoPermiso.Inventario))
            {
                this.productosToolStripMenuItem2.Visible = true;
                this.validarToolStripMenuItem.Visible = true;
            }

            if (session.TienePermiso(TipoPermiso.Comprador))
            {
                this.comprasToolStripMenuItem.Visible = true;
                this.solicitarCotizacionToolStripMenuItem.Visible = true;
                this.registrarCotizacionToolStripMenuItem.Visible = true;
                this.emitirOrdenDeCompraToolStripMenuItem.Visible = true;
            }

            if (session.User == null)
            {
                this.usuarioToolStripMenuItem1.Visible = false;
                this.registrarToolStripMenuItem1.Visible = false;
                this.modificar2ToolStripMenuItem.Visible = false;
                this.cambiarContraseñaToolStripMenuItem.Visible = false;
                this.administrarPermisosToolStripMenuItem.Visible = false;

                this.productosToolStripMenuItem.Visible = false;
                this.verProductosToolStripMenuItem.Visible = false;
                this.aPagarToolStripMenuItem.Visible = false;
                this.entregarProductosToolStripMenuItem.Visible = false;

                this.comprasToolStripMenuItem.Visible = false;
                this.solicitarCotizacionToolStripMenuItem.Visible = false;
                this.registrarCotizacionToolStripMenuItem.Visible = false;
                this.emitirOrdenDeCompraToolStripMenuItem.Visible = false;

                this.productosToolStripMenuItem2.Visible = false;
                this.emitirOrdenDeReposicionToolStripMenuItem.Visible = false;
                this.emitirSolicitudDeCompraToolStripMenuItem.Visible = false;
                this.validarToolStripMenuItem.Visible = false;

                this.clientesToolStripMenuItem.Visible = false;
                this.registrarClienteToolStripMenuItem.Visible = false;

                this.permisosToolStripMenuItem.Visible = false;
                this.administrarPermisosToolStripMenuItem1.Visible = false;

                this.bitacoraToolStripMenuItem.Visible = false;
                this.bitacoraDeEventosToolStripMenuItem.Visible = false;
                this.bitácoraDeCambiosToolStripMenuItem.Visible = false;

                this.baseDeDatosToolStripMenuItem.Visible = false;
                this.backUpToolStripMenuItem.Visible = false;
                this.restoreToolStripMenuItem.Visible = false;

                this.aBMToolStripMenuItem.Visible = false;
                this.productosToolStripMenuItem1.Visible = false;

                this.reportesToolStripMenuItem.Visible = false;
                this.generarReporteToolStripMenuItem.Visible = false;

                this.logoutToolStripMenuItem.Visible = false;
            }

            this.logoutToolStripMenuItem.Visible = session.IsLogged();
            this.usuarioToolStripMenuItem1.Visible = session.IsLogged();
            this.cambiarContraseñaToolStripMenuItem.Visible = session.IsLogged();


        }
        public void RefreshData()
        {
            if(session.IsLogged())
            {
                var h = (HiperMegaRed.BE.User)session.User;
                lblPrincipal1.Text = h.Name;
                usuarioToolStripMenuItem1.Enabled = true;
                logoutToolStripMenuItem.Enabled = true;
                ShowMenus();
            }
            else
            {
                lblPrincipal1.Text = "";
                this.usuarioToolStripMenuItem1.Visible = false;
                logoutToolStripMenuItem.Enabled = false;
                this.registrarToolStripMenuItem1.Visible = false ;
                this.modificar2ToolStripMenuItem.Visible = false;
                this.administrarPermisosToolStripMenuItem.Visible = false;
                this.productosToolStripMenuItem.Visible = false;
                this.clientesToolStripMenuItem.Visible = false;
                this.permisosToolStripMenuItem.Visible = false;
                this.aPagarToolStripMenuItem.Visible = false;
                this.entregarProductosToolStripMenuItem.Visible = false;
                this.verProductosToolStripMenuItem.Visible = false;
                this.gestionarIdiomaToolStripMenuItem.Visible = false;
                this.reportesToolStripMenuItem.Visible = false;
                this.baseDeDatosToolStripMenuItem.Visible = false;
            }
        }
        private void FrmPrincipal_Load_1(object sender, EventArgs e)
        {
            TraducirTextos();
            if (session.IsNotLogged())
            {
                var frmLog = new Usuario.FrmLogin();
                frmLog.MdiParent = this;
                frmLog.Show();
                usuarioToolStripMenuItem1.Enabled = false;
                logoutToolStripMenuItem.Enabled = false;
            }
            else
            {
                var h = (HiperMegaRed.BE.User)session.User;
                lblPrincipal1.Text = h.Name;
                usuarioToolStripMenuItem1.Enabled = true;
                logoutToolStripMenuItem.Enabled = true;
            }
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmReg = new Usuario.FrmRegistrar();
            ShowFormAlone(frmReg);

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmMod = new Usuario.FrmModificar();
            frmMod.MdiParent = this;
            frmMod.Show();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCPass = new Usuario.FrmChangePass();
            ShowFormAlone(frmCPass);
            //frmCPass.MdiParent = this;
            //frmCPass.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (session.IsLogged())
            {
                MessageBox.Show("Usuario " + ((HiperMegaRed.BE.User)session.User).Name + " esta por desloguearse", "Deslogueo");
                //session.Logout();
                var bitacora = new Bitacora("Logout", "Baja", DateTime.Now, "Principal", session.User.Username);
                SessionBLL.GetInstance().Logout();
                bitacoraBLL.SaveBitacora(bitacora);
                MessageBox.Show("El Usuario se ha deslogueado", "Deslogueo Completo");
                lblPrincipal1.Text = "";
                ShowMenus();
                var frm = new Usuario.FrmLogin();
                ShowFormAlone(frm);
                RefreshData();

            }
            else
            {
                MessageBox.Show("No hay ninguna session iniciada");
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void modificar2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmMod2 = new Usuario.FrmGestionUsuarios();
            ShowFormAlone(frmMod2);

        }

        private void verProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmProd = new Productos.FrmProductos();
            ShowFormAlone(frmProd);
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmClient = new HiperMegaRed_IngSoft.Cliente.FrmRegistrarCliente();
            ShowFormAlone(frmClient);

        }

        private void administrarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAdmPerm = new Permisos.FrmAdministrarPermisosUsuario();
            ShowFormAlone(frmAdmPerm);
 
        }

        private void administrarPermisosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var permisosForm = new Permisos.FrmAdministrarPermisos();
            ShowFormAlone(permisosForm);
        }

        private void ShowFormAlone(Form form)
        {
            this.SuspendLayout();

            foreach (var child in this.MdiChildren)
            {
                child.Close();
            }
            PrepareForm(form);
            form.Show();
            this.ResumeLayout();
        }

        private void PrepareForm(Form form)
        {
            //form.Dock = DockStyle.Fill;
            form.MdiParent = this;
            form.ControlBox = false;
            form.ShowIcon = false;
            form.Text = "";
            form.Activate();
            form.WindowState = FormWindowState.Normal;
        }


        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IdiomaFRMs.FrmCambiarIdioma().Show();
        }

        private void gestionarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IdiomaFRMs.FrmGestionIdiomas().Show();
        }

        private void aPagarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frmOrdenes = new Productos.FrmOrdenDePago();
            ShowFormAlone(frmOrdenes);
        }

        private void entregarProductosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frmFact = new FrmFacturas();
            ShowFormAlone(frmFact);
        }

        private void generarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmReport = new frmReportes();
            ShowFormAlone(frmReport);
        }

        private void bitacoraDeEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmEventLog = new FrmBitacoraEventos();
            ShowFormAlone(frmEventLog);
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmManageProds = new FrmGestionProductos();
            ShowFormAlone(frmManageProds);
        }
        private void emitirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmEmitirOrdenRepo = new FrmEmitirOrdenReposicion();
            ShowFormAlone(frmEmitirOrdenRepo);
        }
        private void bitácoraDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmBitacoraCambios = new FrmBitacoraCambios();
            ShowFormAlone(frmBitacoraCambios);
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog()==System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    path = fd.SelectedPath;
                    try
                    {
                        backBLL.GenerarBackup(path);
                        MessageBox.Show(MultiLang.TranslateOrDefault("Backup.Generado", "Back up generado con exito"), MultiLang.TranslateOrDefault("BackUp", "Backup"), MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "SQL SERVER database backup files|*.bak";
            opn.Title = "Database Restore";
            if (opn.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    backBLL.RestaurarBackup(opn.FileName);
                    MessageBox.Show("Restore de la base de datos generado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void solicitarCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmSolicitarCotizacion = new FrmSolicitarCotizacion();
            ShowFormAlone(frmSolicitarCotizacion);
        }

        private void registrarCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmRegistrarCotizacion = new FrmRegistrarCotizacion();
            ShowFormAlone(frmRegistrarCotizacion);
        }

        private void emitirOrdenDeReposicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmEmitirOrdenRepo = new FrmEmitirOrdenReposicion();
            ShowFormAlone(frmEmitirOrdenRepo);
        }

        private void validarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAprobarOrdenes = new FrmAprobarOrdenReposicion();
            ShowFormAlone(frmAprobarOrdenes);
        }

        private void emitirSolicitudDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmSolicitarCompra = new FrmSolicitudCompra();
            ShowFormAlone(frmSolicitarCompra);
        }

        private void emitirOrdenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmEmitirOrdenCompra = new FrmEmitirOrdenCompra();
            ShowFormAlone(frmEmitirOrdenCompra);
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
