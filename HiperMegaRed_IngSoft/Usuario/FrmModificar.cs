using HiperMegaRed.BE;
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
    public partial class FrmModificar : Form
    {
        private UserBLL userBLL = UserBLL.Instance;
        private User editable;
        public void ClearData()
        {
            this.editable = null;
            cbxUsuario.SelectedIndex = 0;
            txtUsername.Text = "";
            txtName.Text = "";
            txtName.Enabled = false;
            txtLastname.Text = "";
            txtLastname.Enabled = false;
            txtMail.Text = "";
            txtMail.Enabled = false;
            txtPhone.Text = "";
            txtMail.Enabled = false;
            btnAccept.Enabled = false;
            txtLanguage.Text = "";
            txtLanguage.Enabled = false;
            chkBlocked.Checked = false;
            chkBlocked.Enabled = false;

        }
        public FrmModificar()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmModificar_Load(object sender, EventArgs e)
        {
            cbxUsuario.DisplayMember = "Username";
            cbxUsuario.DataSource = userBLL.GetAll();
        }



        private void cbxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cbxUsuario.SelectedItem != null)
            {
                this.editable = (User)cbxUsuario.SelectedItem;
                txtUsername.Text = editable.Username;
                txtName.Text = editable.Name;
                txtName.Enabled = true;
                txtLastname.Text = editable.Lastname;
                txtLastname.Enabled = true;
                txtMail.Text = editable.Mail;
                txtMail.Enabled = true;
                txtPhone.Text = editable.Phone;
                txtMail.Enabled = true;
                btnAccept.Enabled = true;
                txtLanguage.Text = editable.Language;
                txtLanguage.Enabled = true;
                btnClearSelect.Enabled = true;
                if (editable.FailCount > 2) 
                { 
                    chkBlocked.Checked = true; 
                }
                else
                { 
                    chkBlocked.Checked = false;
                }
                chkBlocked.Enabled = true;
            }
        }

        private void btnClearSelect_Click(object sender, EventArgs e)
        {
            ClearData();
            btnClearSelect.Enabled = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (editable.Name == txtName.Text && editable.Lastname == txtLastname.Text && editable.Mail== txtMail.Text && editable.Phone == txtPhone.Text && editable.FailCount > 2 && chkBlocked.Checked == true)
            {
                MessageBox.Show("No se ha realizado ningun cambio");
                ClearData();
            }
            else
            {
                editable.Name = txtName.Text;
                editable.Lastname = txtLastname.Text;
                editable.Mail = txtMail.Text;
                editable.Phone = txtPhone.Text;
                editable.Language = txtLanguage.Text;
                if (chkBlocked.Checked == true)
                {
                    editable.FailCount = 10;
                }
                else
                {
                    editable.FailCount = 0;
                }
                try
                {
                    userBLL.Modify(editable);
                    MessageBox.Show("Usuario Modificado Correctamente");
                    ClearData();
                }
                catch(ValidationException ve)
                {
                    lblError.Text = ve.Message;
                    lblError.Visible = true;
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
