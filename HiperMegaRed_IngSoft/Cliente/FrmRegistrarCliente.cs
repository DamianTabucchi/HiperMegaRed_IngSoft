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

namespace HiperMegaRed_IngSoft.Cliente
{
    public partial class FrmRegistrarCliente : Form
    {
        private ClienteBLL clienteBLL = ClienteBLL.Instance;
        private HiperMegaRed.BE.Cliente client = new HiperMegaRed.BE.Cliente();
        public FrmRegistrarCliente(decimal doc)
        {
            InitializeComponent();
            txtDNI.Text = doc.ToString();
        }

        public FrmRegistrarCliente()
        {
            InitializeComponent();
            txtDNI.Enabled = true;
        }

        private void FrmRegistrarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNombre.Text) && string.IsNullOrWhiteSpace(txtApellido.Text) && string.IsNullOrWhiteSpace(txtTelefono.Text) && string.IsNullOrWhiteSpace(txtMail.Text))
            {
                MessageBox.Show("Por favor, complete los datos");
            }
            else
            {
                client.cliente_dni = decimal.Parse(txtDNI.Text);
                client.cliente_nombre = txtNombre.Text;
                client.cliente_apellido = txtApellido.Text;
                client.cliente_telefono = txtTelefono.Text;
                client.cliente_mail = txtMail.Text;
                try
                {
                    clienteBLL.SaveClient(client);
                    MessageBox.Show($"Se ha registrado el cliente {client.cliente_nombre}");
                    Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
