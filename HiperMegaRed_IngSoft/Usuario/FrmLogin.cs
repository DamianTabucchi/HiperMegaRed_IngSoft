using HiperMegaRed.BLL;
using HiperMegaRed.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperMegaRed_IngSoft.Usuario
{
    public partial class FrmLogin : Form
    {
        private SessionBLL sessionBLL = SessionBLL.GetInstance();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = sessionBLL.Login(this.txtUsername.Text, this.txtPassword.Text);
                FrmPrincipal frm = (FrmPrincipal)this.MdiParent;
                frm.RefreshData();
                this.Close();
                
            }
            catch(ValidationException ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
