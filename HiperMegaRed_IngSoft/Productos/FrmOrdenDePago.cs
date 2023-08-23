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

namespace HiperMegaRed_IngSoft.Productos
{
    public partial class FrmOrdenDePago : Form
    {
        private ClienteBLL clienteBLL = ClienteBLL.Instance;
        private CarritoBLL cartBLL = CarritoBLL.Instance;
        private static Carrito cart = new Carrito();
        private ProductoBLL productoBLL = ProductoBLL.Instance;
        private HiperMegaRed.BE.Cliente client = new HiperMegaRed.BE.Cliente();
        private IList<Producto> productos = new List<Producto>();
        private FacturaBLL facturaBLL = FacturaBLL.Instance;
        private Factura fact;

        public FrmOrdenDePago()
        {
            InitializeComponent();
        }

        private void FrmOrdenDePago_Load(object sender, EventArgs e)
        {
            ObtenerCarritos();
            txtNDeb.KeyPress += new KeyPressEventHandler(txtNDeb_KeyPress);
            txtNCred.KeyPress += new KeyPressEventHandler(txtNCred_KeyPress);

        }
        private void txtNDeb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora el carácter ingresado si no es un número o una tecla de control
            }
        }
        private void txtNCred_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora el carácter ingresado si no es un número o una tecla de control
            }
        }
        public void ObtenerCarritos()
        {
            cbOrdenes.DataSource = cartBLL.GetUnpayed();
            cbOrdenes.DisplayMember = "carrito_fecha";
        }

        public void RefreshData()
        {
            dgvProductos.DataSource = null;
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            productos = new List<Producto>();
            client = null;
            cart = null;
            txtFecha.Text = "";
            txtTotal.Text = "";
            btnPagar.Enabled = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            cart = (Carrito)cbOrdenes.SelectedItem;
            txtFecha.Text = cart.carrito_fecha.ToString();
            if (clienteBLL.FindByDNI(cart.carrito_cliente_dni) is null)
            {
                MessageBox.Show("El DNI ingresado no existe en la base de datos, registre al cliente");
                var FrmRegClient = new Cliente.FrmRegistrarCliente(cart.carrito_cliente_dni);
                FrmRegClient.MdiParent = this.MdiParent;
                FrmRegClient.Show();
            }
            else
            {
                client = clienteBLL.FindByDNI(cart.carrito_cliente_dni);
                txtDNI.Text = client.cliente_dni.ToString();
                txtNombre.Text = client.cliente_nombre;
                txtApellido.Text = client.cliente_apellido;
                productos = productoBLL.FindByCart(cart.Id);
                dgvProductos.DataSource = productos;
                dgvProductos.Columns["producto_marca"].Visible = false;
                dgvProductos.Columns["producto_modelo"].Visible = false;
                dgvProductos.Columns["producto_descripcion"].Visible = false;
                dgvProductos.Columns["producto_stock"].Visible = false;
                dgvProductos.Columns["id"].Visible = false;
                dgvProductos.Columns["producto_deposito"].Visible = false;
                txtTotal.Text = cart.carrito_preciototal.ToString();
                btnPagar.Enabled = true;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            cart.carrito_pagado = true;
            try
            {
                var hecho = cartBLL.UpdateCart(cart);
                if (hecho == 1)
                {
                    MessageBox.Show("Se ha actualizado el carrito");
                    fact = new Factura(cart);
                    facturaBLL.SaveFact(fact);
                    MessageBox.Show("Se ha creado la factura");
                    RefreshData();
                    ObtenerCarritos();
                }
                else
                {
                    throw new ValidationException("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:" + ex.Message);
            }
        }

        private void cbOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        //private void rdbEfectivo_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdbEfectivo.Checked == true)
        //    {
        //        txtMonto.Enabled = true;
                
        //    }
        //}

        //private void txtMonto_TextChanged(object sender, EventArgs e)
        //{
        //    var res = (cart.carrito_preciototal - Convert.ToDouble(txtMonto.Text)) * (-1);
        //    txtVuelto.Text = res.ToString();
        //    if (Convert.ToDouble(txtVuelto.Text) >= 0)
        //    {
        //        btnPagar.Enabled = true;
        //    }
        //}

        //private void rdbDeb_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdbDeb.Checked == true)
        //    {
        //        txtNDeb.Enabled = true;
        //        dtpDeb.Enabled = true;
        //        txtCVVDeb.Enabled = true;
        //    }
        //}


    }
}
