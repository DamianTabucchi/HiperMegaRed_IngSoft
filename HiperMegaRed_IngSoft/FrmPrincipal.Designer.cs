
namespace HiperMegaRed_IngSoft
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPrincipal1 = new System.Windows.Forms.Label();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificar2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entregarProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarPermisosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.productosToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirOrdenDeReposicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirSolicitudDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitarCotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarCotizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirOrdenDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraDeEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitácoraDeCambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // registrarToolStripMenuItem
            // 
            this.registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            this.registrarToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // lblPrincipal1
            // 
            this.lblPrincipal1.AutoSize = true;
            this.lblPrincipal1.Location = new System.Drawing.Point(904, 8);
            this.lblPrincipal1.Name = "lblPrincipal1";
            this.lblPrincipal1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPrincipal1.Size = new System.Drawing.Size(44, 16);
            this.lblPrincipal1.TabIndex = 1;
            this.lblPrincipal1.Text = "label1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.idiomaToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Tag = "mnu.home";
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Tag = "mnu.logout";
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Visible = false;
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // idiomaToolStripMenuItem
            // 
            this.idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarIdiomaToolStripMenuItem,
            this.gestionarIdiomaToolStripMenuItem});
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            this.idiomaToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.idiomaToolStripMenuItem.Tag = "mnu.lang";
            this.idiomaToolStripMenuItem.Text = "Idioma";
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            this.cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            this.cambiarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cambiarIdiomaToolStripMenuItem.Tag = "mnu.change.lang";
            this.cambiarIdiomaToolStripMenuItem.Text = "Cambiar Idioma";
            this.cambiarIdiomaToolStripMenuItem.Click += new System.EventHandler(this.cambiarIdiomaToolStripMenuItem_Click);
            // 
            // gestionarIdiomaToolStripMenuItem
            // 
            this.gestionarIdiomaToolStripMenuItem.Name = "gestionarIdiomaToolStripMenuItem";
            this.gestionarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.gestionarIdiomaToolStripMenuItem.Tag = "mnu.gestionar.idioma";
            this.gestionarIdiomaToolStripMenuItem.Text = "Gestionar Idioma";
            this.gestionarIdiomaToolStripMenuItem.Visible = false;
            this.gestionarIdiomaToolStripMenuItem.Click += new System.EventHandler(this.gestionarIdiomaToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Tag = "mnu.exit";
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem1
            // 
            this.usuarioToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarContraseñaToolStripMenuItem,
            this.registrarToolStripMenuItem1,
            this.modificar2ToolStripMenuItem,
            this.administrarPermisosToolStripMenuItem});
            this.usuarioToolStripMenuItem1.Name = "usuarioToolStripMenuItem1";
            this.usuarioToolStripMenuItem1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.usuarioToolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.usuarioToolStripMenuItem1.Tag = "mnu.user";
            this.usuarioToolStripMenuItem1.Text = "Usuario";
            this.usuarioToolStripMenuItem1.Visible = false;
            this.usuarioToolStripMenuItem1.Click += new System.EventHandler(this.usuarioToolStripMenuItem1_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.cambiarContraseñaToolStripMenuItem.Tag = "mnu.pass.user";
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña";
            this.cambiarContraseñaToolStripMenuItem.Visible = false;
            this.cambiarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);
            // 
            // registrarToolStripMenuItem1
            // 
            this.registrarToolStripMenuItem1.Name = "registrarToolStripMenuItem1";
            this.registrarToolStripMenuItem1.Size = new System.Drawing.Size(234, 22);
            this.registrarToolStripMenuItem1.Tag = "mnu.reg.user";
            this.registrarToolStripMenuItem1.Text = "Registrar";
            this.registrarToolStripMenuItem1.Visible = false;
            this.registrarToolStripMenuItem1.Click += new System.EventHandler(this.registrarToolStripMenuItem1_Click);
            // 
            // modificar2ToolStripMenuItem
            // 
            this.modificar2ToolStripMenuItem.Name = "modificar2ToolStripMenuItem";
            this.modificar2ToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.modificar2ToolStripMenuItem.Tag = "mnu.mod.user";
            this.modificar2ToolStripMenuItem.Text = "Modificar";
            this.modificar2ToolStripMenuItem.Visible = false;
            this.modificar2ToolStripMenuItem.Click += new System.EventHandler(this.modificar2ToolStripMenuItem_Click);
            // 
            // administrarPermisosToolStripMenuItem
            // 
            this.administrarPermisosToolStripMenuItem.Name = "administrarPermisosToolStripMenuItem";
            this.administrarPermisosToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.administrarPermisosToolStripMenuItem.Tag = "mnu.adm.grants.user";
            this.administrarPermisosToolStripMenuItem.Text = "Gestionar Permisos de Usuario";
            this.administrarPermisosToolStripMenuItem.Visible = false;
            this.administrarPermisosToolStripMenuItem.Click += new System.EventHandler(this.administrarPermisosToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verProductosToolStripMenuItem,
            this.aPagarToolStripMenuItem,
            this.entregarProductosToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.productosToolStripMenuItem.Tag = "mnu.prod";
            this.productosToolStripMenuItem.Text = "Ventas";
            this.productosToolStripMenuItem.Visible = false;
            // 
            // verProductosToolStripMenuItem
            // 
            this.verProductosToolStripMenuItem.Name = "verProductosToolStripMenuItem";
            this.verProductosToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.verProductosToolStripMenuItem.Tag = "mnu.view.prod";
            this.verProductosToolStripMenuItem.Text = "Llenar Carrito";
            this.verProductosToolStripMenuItem.Visible = false;
            this.verProductosToolStripMenuItem.Click += new System.EventHandler(this.verProductosToolStripMenuItem_Click);
            // 
            // aPagarToolStripMenuItem
            // 
            this.aPagarToolStripMenuItem.Name = "aPagarToolStripMenuItem";
            this.aPagarToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.aPagarToolStripMenuItem.Tag = "mnu.pay.carts";
            this.aPagarToolStripMenuItem.Text = "Facturar";
            this.aPagarToolStripMenuItem.Visible = false;
            this.aPagarToolStripMenuItem.Click += new System.EventHandler(this.aPagarToolStripMenuItem_Click_1);
            // 
            // entregarProductosToolStripMenuItem
            // 
            this.entregarProductosToolStripMenuItem.Name = "entregarProductosToolStripMenuItem";
            this.entregarProductosToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.entregarProductosToolStripMenuItem.Tag = "mnu.deliver.prod";
            this.entregarProductosToolStripMenuItem.Text = "Despachar Productos";
            this.entregarProductosToolStripMenuItem.Visible = false;
            this.entregarProductosToolStripMenuItem.Click += new System.EventHandler(this.entregarProductosToolStripMenuItem_Click_1);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarClienteToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Tag = "mnu.client";
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Visible = false;
            // 
            // registrarClienteToolStripMenuItem
            // 
            this.registrarClienteToolStripMenuItem.Name = "registrarClienteToolStripMenuItem";
            this.registrarClienteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.registrarClienteToolStripMenuItem.Tag = "mnu.reg.client";
            this.registrarClienteToolStripMenuItem.Text = "Registrar Cliente";
            this.registrarClienteToolStripMenuItem.Visible = false;
            this.registrarClienteToolStripMenuItem.Click += new System.EventHandler(this.registrarClienteToolStripMenuItem_Click);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarPermisosToolStripMenuItem1});
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.permisosToolStripMenuItem.Tag = "mnu.grants";
            this.permisosToolStripMenuItem.Text = "Permisos";
            this.permisosToolStripMenuItem.Visible = false;
            // 
            // administrarPermisosToolStripMenuItem1
            // 
            this.administrarPermisosToolStripMenuItem1.Name = "administrarPermisosToolStripMenuItem1";
            this.administrarPermisosToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.administrarPermisosToolStripMenuItem1.Tag = "mnu.adm.grants";
            this.administrarPermisosToolStripMenuItem1.Text = "Administrar Permisos";
            this.administrarPermisosToolStripMenuItem1.Visible = false;
            this.administrarPermisosToolStripMenuItem1.Click += new System.EventHandler(this.administrarPermisosToolStripMenuItem1_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.usuarioToolStripMenuItem1,
            this.productosToolStripMenuItem,
            this.productosToolStripMenuItem2,
            this.comprasToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.permisosToolStripMenuItem,
            this.bitacoraToolStripMenuItem,
            this.baseDeDatosToolStripMenuItem,
            this.aBMToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(960, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // productosToolStripMenuItem2
            // 
            this.productosToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emitirOrdenDeReposicionToolStripMenuItem,
            this.emitirSolicitudDeCompraToolStripMenuItem,
            this.validarToolStripMenuItem});
            this.productosToolStripMenuItem2.Name = "productosToolStripMenuItem2";
            this.productosToolStripMenuItem2.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem2.Tag = "mnu.productos";
            this.productosToolStripMenuItem2.Text = "Productos";
            this.productosToolStripMenuItem2.Visible = false;
            // 
            // emitirOrdenDeReposicionToolStripMenuItem
            // 
            this.emitirOrdenDeReposicionToolStripMenuItem.Name = "emitirOrdenDeReposicionToolStripMenuItem";
            this.emitirOrdenDeReposicionToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.emitirOrdenDeReposicionToolStripMenuItem.Tag = "mnu.emitir.orden.repo";
            this.emitirOrdenDeReposicionToolStripMenuItem.Text = "Emitir Orden de Reposicion";
            this.emitirOrdenDeReposicionToolStripMenuItem.Visible = false;
            this.emitirOrdenDeReposicionToolStripMenuItem.Click += new System.EventHandler(this.emitirOrdenDeReposicionToolStripMenuItem_Click);
            // 
            // emitirSolicitudDeCompraToolStripMenuItem
            // 
            this.emitirSolicitudDeCompraToolStripMenuItem.Name = "emitirSolicitudDeCompraToolStripMenuItem";
            this.emitirSolicitudDeCompraToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.emitirSolicitudDeCompraToolStripMenuItem.Text = "Emitir Solicitud de Compra";
            this.emitirSolicitudDeCompraToolStripMenuItem.Visible = false;
            this.emitirSolicitudDeCompraToolStripMenuItem.Click += new System.EventHandler(this.emitirSolicitudDeCompraToolStripMenuItem_Click);
            // 
            // validarToolStripMenuItem
            // 
            this.validarToolStripMenuItem.Name = "validarToolStripMenuItem";
            this.validarToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.validarToolStripMenuItem.Tag = "mnu.validar.pedido";
            this.validarToolStripMenuItem.Text = "Validar Pedidos";
            this.validarToolStripMenuItem.Visible = false;
            this.validarToolStripMenuItem.Click += new System.EventHandler(this.validarToolStripMenuItem_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solicitarCotizacionToolStripMenuItem,
            this.registrarCotizacionToolStripMenuItem,
            this.emitirOrdenDeCompraToolStripMenuItem});
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.comprasToolStripMenuItem.Text = "Compras";
            this.comprasToolStripMenuItem.Visible = false;
            this.comprasToolStripMenuItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // solicitarCotizacionToolStripMenuItem
            // 
            this.solicitarCotizacionToolStripMenuItem.Name = "solicitarCotizacionToolStripMenuItem";
            this.solicitarCotizacionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.solicitarCotizacionToolStripMenuItem.Text = "Solicitar Cotizacion";
            this.solicitarCotizacionToolStripMenuItem.Visible = false;
            this.solicitarCotizacionToolStripMenuItem.Click += new System.EventHandler(this.solicitarCotizacionToolStripMenuItem_Click);
            // 
            // registrarCotizacionToolStripMenuItem
            // 
            this.registrarCotizacionToolStripMenuItem.Name = "registrarCotizacionToolStripMenuItem";
            this.registrarCotizacionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.registrarCotizacionToolStripMenuItem.Text = "Registrar Cotizacion";
            this.registrarCotizacionToolStripMenuItem.Visible = false;
            this.registrarCotizacionToolStripMenuItem.Click += new System.EventHandler(this.registrarCotizacionToolStripMenuItem_Click);
            // 
            // emitirOrdenDeCompraToolStripMenuItem
            // 
            this.emitirOrdenDeCompraToolStripMenuItem.Name = "emitirOrdenDeCompraToolStripMenuItem";
            this.emitirOrdenDeCompraToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.emitirOrdenDeCompraToolStripMenuItem.Text = "Emitir Orden de Compra";
            this.emitirOrdenDeCompraToolStripMenuItem.Visible = false;
            this.emitirOrdenDeCompraToolStripMenuItem.Click += new System.EventHandler(this.emitirOrdenDeCompraToolStripMenuItem_Click);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitacoraDeEventosToolStripMenuItem,
            this.bitácoraDeCambiosToolStripMenuItem});
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.bitacoraToolStripMenuItem.Tag = "mnu.bitacoras";
            this.bitacoraToolStripMenuItem.Text = "Bitácoras";
            this.bitacoraToolStripMenuItem.Visible = false;
            // 
            // bitacoraDeEventosToolStripMenuItem
            // 
            this.bitacoraDeEventosToolStripMenuItem.Name = "bitacoraDeEventosToolStripMenuItem";
            this.bitacoraDeEventosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bitacoraDeEventosToolStripMenuItem.Tag = "mnu.bitacora.events";
            this.bitacoraDeEventosToolStripMenuItem.Text = "Bitácora de Eventos";
            this.bitacoraDeEventosToolStripMenuItem.Click += new System.EventHandler(this.bitacoraDeEventosToolStripMenuItem_Click);
            // 
            // bitácoraDeCambiosToolStripMenuItem
            // 
            this.bitácoraDeCambiosToolStripMenuItem.Name = "bitácoraDeCambiosToolStripMenuItem";
            this.bitácoraDeCambiosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bitácoraDeCambiosToolStripMenuItem.Tag = "mnucontrolcambios";
            this.bitácoraDeCambiosToolStripMenuItem.Text = "Control de Cambios";
            this.bitácoraDeCambiosToolStripMenuItem.Click += new System.EventHandler(this.bitácoraDeCambiosToolStripMenuItem_Click);
            // 
            // baseDeDatosToolStripMenuItem
            // 
            this.baseDeDatosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backUpToolStripMenuItem,
            this.restoreToolStripMenuItem});
            this.baseDeDatosToolStripMenuItem.Name = "baseDeDatosToolStripMenuItem";
            this.baseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.baseDeDatosToolStripMenuItem.Tag = "mnu.bbdd";
            this.baseDeDatosToolStripMenuItem.Text = "Base de Datos";
            this.baseDeDatosToolStripMenuItem.Visible = false;
            // 
            // backUpToolStripMenuItem
            // 
            this.backUpToolStripMenuItem.Name = "backUpToolStripMenuItem";
            this.backUpToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.backUpToolStripMenuItem.Text = "Back Up";
            this.backUpToolStripMenuItem.Visible = false;
            this.backUpToolStripMenuItem.Click += new System.EventHandler(this.backUpToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Visible = false;
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // aBMToolStripMenuItem
            // 
            this.aBMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem1});
            this.aBMToolStripMenuItem.Name = "aBMToolStripMenuItem";
            this.aBMToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.aBMToolStripMenuItem.Text = "ABM";
            this.aBMToolStripMenuItem.Visible = false;
            // 
            // productosToolStripMenuItem1
            // 
            this.productosToolStripMenuItem1.Name = "productosToolStripMenuItem1";
            this.productosToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.productosToolStripMenuItem1.Text = "Productos";
            this.productosToolStripMenuItem1.Visible = false;
            this.productosToolStripMenuItem1.Click += new System.EventHandler(this.productosToolStripMenuItem1_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarReporteToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Tag = "mnu.reportes";
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Visible = false;
            // 
            // generarReporteToolStripMenuItem
            // 
            this.generarReporteToolStripMenuItem.Name = "generarReporteToolStripMenuItem";
            this.generarReporteToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.generarReporteToolStripMenuItem.Tag = "mnu.generar.reporte";
            this.generarReporteToolStripMenuItem.Text = "Generar Reporte";
            this.generarReporteToolStripMenuItem.Visible = false;
            this.generarReporteToolStripMenuItem.Click += new System.EventHandler(this.generarReporteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // FrmPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(960, 517);
            this.Controls.Add(this.lblPrincipal1);
            this.Controls.Add(this.menuStrip2);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "FrmPrincipal";
            this.Text = "HiperMegaRed";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load_1);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem;
        private System.Windows.Forms.Label lblPrincipal1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificar2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPagarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entregarProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarPermisosToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarReporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraDeEventosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bitácoraDeCambiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitarCotizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarCotizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emitirOrdenDeCompraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emitirOrdenDeReposicionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emitirSolicitudDeCompraToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}