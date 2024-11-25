using HiperMegaRed.BLL;
using HiperMegaRed.Services;
using HiperMegaRed.DAL.MultiLenguaje;
using HiperMegaRed.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiperMegaRed.BE;

namespace HiperMegaRed_IngSoft.Usuario
{
    public partial class FrmLogin : Form
    {
        private SessionBLL sessionBLL = SessionBLL.GetInstance();
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;
        private static DigitoVerificadorBLL dvBLL = DigitoVerificadorBLL.Instance;
        public FrmLogin()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }
        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = sessionBLL.Login(this.txtUsername.Text, this.txtPassword.Text);
                FrmPrincipal frm = (FrmPrincipal)this.MdiParent;
                frm.RefreshData();
                var bitacora = new Bitacora("Inicio de Sesion satisfactorio", "Baja", DateTime.Now, "Modulo Login", usuario.Username);
                bitacoraBLL.SaveBitacora(bitacora);
                if (usuario != null)
                {
                    VerificandoDigitos();
                }
                this.Close();
            }
            catch(ValidationException ex)
            {
                var bitacora = new Bitacora($"Error en el login", "Baja", DateTime.Now, "Modulo Login", $"Usuario ingresado: {txtUsername.Text}");
                bitacoraBLL.SaveBitacora(bitacora);
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }
        private void VerificandoDigitos()
        {
            if (dvBLL.VerificarDigitosGeneric("usuarios") == false)
            {
                var res = MessageBox.Show(MultiLang.TranslateOrDefault("ErrorDigitos", "Se han encontrado inconcistencias en la base de datos, desea corregir los errores de integridad?"), MultiLang.TranslateOrDefault("Inconsistencia", "Inconsistencia en la base de datos"), MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    FrmDigitoVerificador frm = new FrmDigitoVerificador();
                    frm.ShowDialog();
                    this.Hide();
                }
                else
                {
                    this.Close();
                }

            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
