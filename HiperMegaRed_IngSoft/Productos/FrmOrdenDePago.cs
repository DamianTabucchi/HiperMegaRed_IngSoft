using HiperMegaRed.BE;
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

namespace HiperMegaRed_IngSoft.Productos
{
    public partial class FrmOrdenDePago : Form
    {
        private readonly SessionManager session = SessionManager.GetInstance;
        private BitacoraBLL bitacoraBLL = BitacoraBLL.Instance;
        private ClienteBLL clienteBLL = ClienteBLL.Instance;
        private CarritoBLL cartBLL = CarritoBLL.Instance;
        private static Carrito cart = new Carrito();
        private ProductoBLL productoBLL = ProductoBLL.Instance;
        private HiperMegaRed.BE.Cliente client = new HiperMegaRed.BE.Cliente();
        private IList<ItemProducto> productos = new List<ItemProducto>();
        private FacturaBLL facturaBLL = FacturaBLL.Instance;
        private Factura fact;

        public FrmOrdenDePago()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }

        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
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
            cbOrdenes.DataSource = null;
            cbOrdenes.DataSource = cartBLL.GetUnpayed();
            cbOrdenes.DisplayMember = "carrito_cliente_dni";
        }

        public void RefreshData()
        {
            dgvProductos.DataSource = null;
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMonto.Text = "";
            //productos = new List<ItemProducto>();
            client = null;
            cart = new Carrito();
            txtFecha.Text = "";
            txtTotal.Text = "";
            btnPagar.Enabled = false;
            btnRemCart.Enabled = false;
            btnRemCart.Visible = false;
            ObtenerCarritos();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            cart = (Carrito)cbOrdenes.SelectedItem;
            txtFecha.Text = cart.carrito_fecha.ToString();
            btnRemCart.Enabled = true;
            btnRemCart.Visible = true;
            if (clienteBLL.FindByDNI(cart.carrito_cliente_dni) is null)
            {
                DialogResult diagres = MessageBox.Show(MultiLang.TranslateOrDefault("DNI.Insert.No.Existe", "El DNI ingresado no existe en la base de datos, desea registrarlo?"), MultiLang.TranslateOrDefault("DNI.Insert.Header", "Cliente no existe"), MessageBoxButtons.YesNo);
                if (diagres == DialogResult.Yes)
                {
                    var FrmRegClient = new Cliente.FrmRegistrarCliente(cart.carrito_cliente_dni);
                    FrmRegClient.MdiParent = this.MdiParent;
                    FrmRegClient.Show();
                }
            }
            else
            {
                client = clienteBLL.FindByDNI(cart.carrito_cliente_dni);
                txtDNI.Text = client.cliente_dni.ToString();
                txtNombre.Text = client.cliente_nombre;
                txtApellido.Text = client.cliente_apellido;
                cart.carrito_productos = (List<ItemProducto>)productoBLL.FindByCart(cart.Id);
                dgvProductos.DataSource = cart.carrito_productos;
                VisualizarProductos();
                txtTotal.Text = cart.carrito_total.ToString();
                btnPagar.Enabled = true;
            }

        }

        private void VisualizarProductos()
        {
            dgvProductos.Columns["producto_nombre"].Visible = true;
            dgvProductos.Columns["producto_nombre"].DisplayIndex = 0;  // Primer columna
            dgvProductos.Columns["producto_nombre"].HeaderText = MultiLang.TranslateOrDefault("Header.Name", "Nombre");
            dgvProductos.Columns["producto_marca"].Visible = true;
            dgvProductos.Columns["producto_marca"].DisplayIndex = 1;  // Segunda columna
            dgvProductos.Columns["producto_marca"].HeaderText = MultiLang.TranslateOrDefault("Header.Brand", "Marca");
            dgvProductos.Columns["producto_modelo"].Visible = true;
            dgvProductos.Columns["producto_modelo"].DisplayIndex = 2;  // Tercer columna
            dgvProductos.Columns["producto_modelo"].HeaderText = MultiLang.TranslateOrDefault("Header.Model", "Modelo");
            dgvProductos.Columns["producto_tipo"].Visible = true;
            dgvProductos.Columns["producto_tipo"].DisplayIndex = 3;  // Cuarta columna
            dgvProductos.Columns["producto_tipo"].HeaderText = MultiLang.TranslateOrDefault("Header.Type", "Tipo");
            dgvProductos.Columns["cantidad"].Visible = true;
            dgvProductos.Columns["cantidad"].DisplayIndex = 4;  // Quinta columna
            dgvProductos.Columns["cantidad"].HeaderText = MultiLang.TranslateOrDefault("Header.Quantity", "Cantidad");
            dgvProductos.Columns["producto_precio_unidad"].Visible = true;
            dgvProductos.Columns["producto_precio_unidad"].DisplayIndex = 5;  // Sexta columna
            dgvProductos.Columns["producto_precio_unidad"].HeaderText = MultiLang.TranslateOrDefault("Header.Price", "Precio");

            foreach (DataGridViewColumn column in dgvProductos.Columns)
            {
                if (column.Name != "producto_nombre" &&
                    column.Name != "producto_marca" &&
                    column.Name != "producto_modelo" &&
                    column.Name != "producto_precio_unidad" &&
                    column.Name != "producto_tipo" &&
                    column.Name != "cantidad")
                {
                    column.Visible = false;
                }
            }
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (rdbEfectivo.Checked)
            {
                if (double.TryParse(txtTotal.Text, out double total) && double.TryParse(txtMonto.Text, out double monto))
                {
                    if (monto >= total)
                    {
                        var vuelto = -(total - monto);
                        txtVuelto.Text = vuelto.ToString();
                        var metodoDePago = MultiLang.TranslateOrDefault("Payment.Method.Cash","Efectivo");
                        Pagar(metodoDePago, vuelto);
                    }
                    else
                    {
                        MessageBox.Show(MultiLang.TranslateOrDefault("Monto.Insuficiente","El monto ingresado no alcanza para pagar"));
                    }
                }
                else
                {
                    MessageBox.Show(MultiLang.TranslateOrDefault("Value.Incorrect","Por favor, ingrese un valor numerico valido."));
                }
            }
            else if (rdbDeb.Checked)
            {
                if (txtNDeb.Text.Length == 16 && long.TryParse(txtNDeb.Text, out _))
                {
                    if (dtpDeb.Value > DateTime.Now)
                    {
                        // Check if txtCVVDeb contains a 3-digit number
                        if (txtCVVDeb.Text.Length == 3 && int.TryParse(txtCVVDeb.Text, out _))
                        {
                            var metodoDePago = MultiLang.TranslateOrDefault("Payment.Method.Debit","Debito");
                            Pagar(metodoDePago);
                        }
                        else
                        {
                            MessageBox.Show(MultiLang.TranslateOrDefault("CVV.Value.Incorrect","CVV tiene que ser un numero valido de 3 digitos."));
                        }
                    }
                    else
                    {
                        MessageBox.Show(MultiLang.TranslateOrDefault("Date.Selected.Incorrect","La fecha seleccionada es erronea"));
                    }
                }
                else
                {
                    MessageBox.Show(MultiLang.TranslateOrDefault("Card.Number.Incorrect","El numero de la tarjeta es incorrecto"));
                }
            }
            else
            {
                if (txtNCred.Text.Length == 16 && long.TryParse(txtNCred.Text, out _))
                {
                    // Check if the DateTimePicker has a valid date
                    if (dtpCred.Value > DateTime.Now)
                    {
                        // Check if txtCVVDeb contains a 3-digit number
                        if (txtCVVCred.Text.Length == 3 && int.TryParse(txtCVVCred.Text, out _))
                        {
                            var metodoDePago = MultiLang.TranslateOrDefault("Payment.Method.Credit","Credito");
                            Pagar(metodoDePago);
                        }
                        else
                        {
                            MessageBox.Show(MultiLang.TranslateOrDefault("CVV.Value.Incorrect","CVV tiene que ser un numero valido de 3 digitos."));
                        }
                    }
                    else
                    {
                        MessageBox.Show(MultiLang.TranslateOrDefault("Date.Selected.Incorrect","La fecha seleccionada es erronea"));
                    }
                }
                else
                {
                    MessageBox.Show(MultiLang.TranslateOrDefault("Card.Number.Incorrect","El numero de la tarjeta es incorrecto"));
                }
            }
        }

        private int Pagar(string tipo, double v = 0)
        {
            
            try
            {
                cart.carrito_pagado = true;
                var hecho = cartBLL.UpdateCart(cart);
                
                if (hecho == 1)
                {
                    foreach (ItemProducto p in cart.carrito_productos)
                    {
                        var prod = productoBLL.FindProductById(p.Id);
                        prod.producto_stock = prod.producto_stock - p.cantidad;
                        productoBLL.UpdateStock(prod);
                    }

                    MessageBox.Show(MultiLang.TranslateOrDefault("Cart.Updated","Se ha actualizado el carrito"));
                    fact = new Factura(cart, tipo, v);
                    facturaBLL.SaveFact(fact);
                    bitacoraBLL.SaveBitacora(new Bitacora("Se ha creado una factura", "Media", DateTime.Now, "Cobrar Venta", session.User.Username));
                    MessageBox.Show(MultiLang.TranslateOrDefault("Ticket.Created","Se ha creado la factura"));
                    RefreshData();
                    ObtenerCarritos();
                    return hecho;
                }
                else
                {
                    return 0;
                    throw new ValidationException("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MultiLang.TranslateOrDefault("Error.Has.Occurred","Ha ocurrido un error:") + ex.Message);
                return 0;
            }
        }


        private void cbOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnRemCart_Click(object sender, EventArgs e)
        {

            var resul = MessageBox.Show(MultiLang.TranslateOrDefault("Eliminate.Cart.Question","Desea eliminar el carrito?"), MultiLang.TranslateOrDefault("Eliminate.Cart.Hader","Eliminar carrito"), MessageBoxButtons.YesNo);
            if (resul == DialogResult.Yes)
            {

                if (cart != null)
                {
                    var carritoBorrado = cartBLL.RemoveCart(cart);
                    if (carritoBorrado > 0)
                    {
                        //if (cart.carrito_productos.Count > 0)
                        //{
                        //    var fila = dgvCart.SelectedRows[0];
                        //    var pid = (Guid)fila.Cells["id"].Value;
                        //    GlobalStorage.Deposito.ToList().Find(x => x.Id == pid).producto_stock += Convert.ToInt32(cart.carrito_productos.ToList().Find(y => y.Id == pid).ItemCantidad);
                        //    cart.RemProductCart(pid);
                        //    RefreshData();    
                        //}
                        foreach (ItemProducto i in cart.carrito_productos)
                        {
                            GlobalStorage.Deposito.ToList().Find(x => x.Id == i.Id).producto_stock += Convert.ToInt32(i.cantidad);
                        }
                        
                        MessageBox.Show(MultiLang.TranslateOrDefault("Cart.Eliminated.Correctly","Carrito borrado con exito"));
                        bitacoraBLL.SaveBitacora(new Bitacora("Se ha eliminado un carrito", "Alta", DateTime.Now, "Cobrar Venta", session.User.Username));
                        RefreshData();
                    }
                    else
                    {
                        MessageBox.Show(MultiLang.TranslateOrDefault("Cart.Not.Eliminated", "No se ha borrado ningun carrito"));
                    }

                }
            }
            
        }

        private void CambioMetodo()
        {
            txtNDeb.Enabled = rdbDeb.Checked;
            txtCVVDeb.Enabled = rdbDeb.Checked;
            dtpDeb.Enabled = rdbDeb.Checked;
            txtNCred.Enabled = rdbCred.Checked;
            txtCVVCred.Enabled = rdbCred.Checked;
            dtpCred.Enabled = rdbCred.Checked;
            txtTransfer.Enabled = rdbTransfer.Checked;
            txtMonto.Enabled = rdbEfectivo.Checked;
            txtNDeb.Text = txtCVVDeb.Text = txtNCred.Text = txtCVVCred.Text = txtTransfer.Text = txtMonto.Text = "";
            dtpCred.Value = dtpDeb.Value = DateTime.Today;
        }

        private void rdbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            CambioMetodo();
        }
        private void rdbDeb_CheckedChanged(object sender, EventArgs e)
        {
            CambioMetodo();
        }

        private void rdbCred_CheckedChanged(object sender, EventArgs e)
        {
            CambioMetodo();
        }

        private void rdbTransfer_CheckedChanged(object sender, EventArgs e)
        {
            CambioMetodo();
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
