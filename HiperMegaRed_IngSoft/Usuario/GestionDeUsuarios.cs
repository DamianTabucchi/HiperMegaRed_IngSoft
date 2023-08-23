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

    public partial class FrmGestionUsuarios : Form
    {
        public UserBLL userbll = UserBLL.Instance;

        private User editable;
        public FrmGestionUsuarios()
        {
            InitializeComponent();
            ActualizarGrilla();
            ClearData();
        }

        public void ActualizarGrilla()
        {
            dgvUsuarios.DataSource = userbll.GetAll();
            dgvUsuarios.Columns["Password"].Visible = false;
            dgvUsuarios.Columns["Id"].Visible = false;
            dgvUsuarios.Columns["Username"].Visible = false;
            dgvUsuarios.Columns["LastLogin"].Visible = false;
            dgvUsuarios.Columns["Expired"].Visible = false;
        }
        public void ClearData()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtLogin.Text = "";
            txtApellido.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";

            btnMod.Enabled = false;
            btnAplicar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAdd.Enabled = true;
            btnCancel.Enabled = false;
        }
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = dgvUsuarios.CurrentRow;
            editable = new User();
            editable = userbll.FindUser(Convert.ToString(fila.Cells["Username"].Value));
            txtDNI.Text = editable.DNI.ToString();
            txtNombre.Text = editable.Name;
            txtApellido.Text = editable.Lastname;
            txtLogin.Text = editable.Username;
            txtTel.Text = editable.Phone;
            txtEmail.Text = editable.Mail;
            
            if (editable.FailCount > 2)
            {
                chbBlock.Checked = true;
            }
            else
            {
                chbBlock.Checked = false;
            }
            btnAplicar.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.SelectedRows != null)
            {
                btnMod.Enabled = true;
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            decimal dni;
            editable.Name = txtNombre.Text;
            editable.Lastname = txtApellido.Text;
            editable.Mail = txtEmail.Text;
            editable.Phone = txtTel.Text;
            if (decimal.TryParse(txtDNI.Text, out dni))
            {
                editable.DNI = Convert.ToDecimal(txtDNI.Text);
            }
            else
            {
                throw new ValidationException("El DNI ingresado no es correcto");
            }
            if (chbBlock.Checked == false)
            {
                editable.FailCount = 0;
            }
            else
            {
                editable.FailCount = 10;
            }

            try
            {
                userbll.SaveUser(editable);
                MessageBox.Show("Usuario modificado");
                ActualizarGrilla();
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
            ClearData();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
