using HiperMegaRed.BE;
using HiperMegaRed.BLL;
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

namespace HiperMegaRed_IngSoft
{
    public partial class FrmPrincipal : Form, ILanguageObserver
    {
        private readonly SessionManager session = SessionManager.GetInstance;
        public FrmPrincipal()
        {
            InitializeComponent();
            Language.Instance.RegisterObserver(this);
            ShowMenus();
        }
        
        public void UpdateLanguage()
        {
            
        }

        private void ShowMenus()
        {
            if (session.TienePermiso(TipoPermiso.Admin))
            {
                this.registrarToolStripMenuItem1.Visible = true;
                this.modificar2ToolStripMenuItem.Visible = true;
                this.administrarPermisosToolStripMenuItem.Visible = true;
                this.productosToolStripMenuItem.Visible = true;
                this.ordenesDePagoToolStripMenuItem.Visible = true;
                this.facturasToolStripMenuItem.Visible = true;
                this.clientesToolStripMenuItem.Visible = true;
                this.permisosToolStripMenuItem.Visible = true;
            }

            if (session.TienePermiso(TipoPermiso.Vendedor))
            {
                this.productosToolStripMenuItem.Visible = true;
            }

            if (session.TienePermiso(TipoPermiso.Cajero))
            {
                this.ordenesDePagoToolStripMenuItem.Visible = true;
            }

            if (session.TienePermiso(TipoPermiso.Despachador))
            {
                this.facturasToolStripMenuItem.Visible = true;
            }

            this.usuarioToolStripMenuItem1.Visible = session.IsLogged();
            this.cambiarContraseñaToolStripMenuItem.Visible = session.IsLogged();
            this.logoutToolStripMenuItem.Visible = session.IsLogged();
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
                this.ordenesDePagoToolStripMenuItem.Visible = false;
                this.facturasToolStripMenuItem.Visible = false;
                this.clientesToolStripMenuItem.Visible = false;
                this.permisosToolStripMenuItem.Visible = false;
            }
        }
        private void FrmPrincipal_Load_1(object sender, EventArgs e)
        {
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
            //frmReg.MdiParent = this;
            //frmReg.Show();
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
                SessionBLL.GetInstance().Logout();
                MessageBox.Show("El Usuario se ha deslogueado", "Deslogueo Completo");
                lblPrincipal1.Text = "";
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
            //frmMod2.MdiParent = this;
            //frmMod2.Show();
        }

        private void verProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmProd = new Productos.FrmProductos();
            ShowFormAlone(frmProd);
            //frmProd.MdiParent = this;
            //frmProd.Show();
        }

        private void aPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmOrdenes = new Productos.FrmOrdenDePago();
            ShowFormAlone(frmOrdenes);
            //frmOrdenes.MdiParent = this;
            //frmOrdenes.Show();
        }

        private void entregarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmFact = new FrmFacturas();
            ShowFormAlone(frmFact);
            //frmFact.MdiParent = this;
            //frmFact.Show();
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmClient = new HiperMegaRed_IngSoft.Cliente.FrmRegistrarCliente();
            ShowFormAlone(frmClient);
            //frmClient.MdiParent = this;
            //frmClient.Show();
        }

        private void administrarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAdmPerm = new Permisos.FrmAdministrarPermisosUsuario();
            ShowFormAlone(frmAdmPerm);
            //frmAdmPerm.MdiParent = this;
            //frmAdmPerm.Show();
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
            form.Dock = DockStyle.Fill;
            form.MdiParent = this;
            form.ControlBox = false;
            form.ShowIcon = false;
            form.Text = "";
            form.Activate();
            form.WindowState = FormWindowState.Maximized;
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language.Instance.ChangeLanguage("Spanish");
        }

        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language.Instance.ChangeLanguage("English");
        }

        private void portuguésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language.Instance.ChangeLanguage("Portuguese");
        }


        //private void verCarritoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var frmCarrito = new Productos.FrmCarrito();
        //    frmCarrito.MdiParent = this;
        //    frmCarrito.Show();
        //}


    }
}
