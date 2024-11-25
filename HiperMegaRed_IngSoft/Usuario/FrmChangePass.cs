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

namespace HiperMegaRed_IngSoft.Usuario
{
    public partial class FrmChangePass : Form
    {
        private UserBLL userBLL = UserBLL.Instance;
        private readonly SessionManager session = SessionManager.GetInstance;


        public void ClearData()
        {
            txtPassword.Text = "";
            txtNewPassword.Text = "";
            txtNewPassRep.Text = "";
        }
        public FrmChangePass()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }

        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }
        private void FrmChangePass_Load(object sender, EventArgs e)
        {
            //cbxUsuario.DisplayMember = "Username";
            //cbxUsuario.DataSource = userBLL.GetAll();
            if (session.IsNotLogged())
            {
                throw new ValidationException("No hay sesion activa, el programa se cerrara");
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }

        //private void cbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (session.IsLogged())
            {
                var h = (HiperMegaRed.BE.User)session.User;

                if (string.IsNullOrWhiteSpace(txtPassword.Text) ||  string.IsNullOrWhiteSpace(txtNewPassword.Text) || string.IsNullOrWhiteSpace(txtNewPassRep.Text))
                {
                    MessageBox.Show("Por favor, llene los campos");
                    return;
                }
                if (!txtNewPassword.Text.Equals(txtNewPassRep.Text))
                {
                    MessageBox.Show("Las contraseñas ingresadas no coinciden");
                    return;
                }
                try
                {
                    userBLL.ResetUserPassword(h.Username, txtPassword.Text, txtNewPassword.Text);
                    MessageBox.Show("La clave se ha cambiado con exito");
                    ClearData();
                    this.Dispose();
                }
                catch (ValidationException ve)
                {
                    MessageBox.Show(ve.Message);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
