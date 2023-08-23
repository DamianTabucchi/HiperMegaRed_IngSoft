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
    public partial class FrmCarrito : Form
    {
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private CarritoBLL carritoBLL = CarritoBLL.Instance;
        private OrdenDePagoBLL ordenBLL = OrdenDePagoBLL.Instance;
        private static OrdenDePago ordpago;
        private static Carrito cart = new Carrito();

        public FrmCarrito()
        {
            InitializeComponent();  
        }

        public FrmCarrito(Carrito c)
        {
            InitializeComponent();
            cart = c;
            RefreshData();
        }

        private void RefreshData()
        {
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = cart.carrito_productos;
            dgvCarrito.Columns["Id"].Visible = false;
            dgvCarrito.Columns["producto_stock"].Visible = false;
            dgvCarrito.Columns["producto_descripcion"].Visible = false;
            dgvCarrito.Columns["producto_deposito"].Visible = false;
            txtTotal.Text = cart.carrito_total.ToString();
        }
        private void FrmCarrito_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRemProd_Click(object sender, EventArgs e)
        {
            if (cart.carrito_productos.Count > 0)
            {
                var fila = dgvCarrito.SelectedRows[0];
                var pid = (Guid)fila.Cells["id"].Value;
                cart.RemProductCart(pid);
                RefreshData();
            }
            else
            {
                MessageBox.Show("No hay productos que borrar");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDNI.Text) || string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("Ingrese el Documento del comprador");
            }
            else
            {
                decimal dni;
                if (decimal.TryParse(txtDNI.Text, out dni))
                {
                    cart.carrito_cliente_dni = dni;
                    cart.carrito_fecha = DateTime.Now;
                    carritoBLL.SaveCart(cart);
                    int prodIngresados = carritoBLL.AddProdToCart(cart);
                    var data = productBLL.GetAll().ToList();
                    foreach (var group in cart.carrito_productos.GroupBy(x => x.Id).ToList())
                    {
                        foreach (Producto p in group)
                        {
                            p.producto_stock = data.Find(x=> x.Id==p.Id).producto_stock - cart.carrito_productos.Count(x => x.Id == p.Id);
                            productBLL.UpdateStock(p);
                        }
                    }
                    MessageBox.Show($"Se ha guardado un carrito con {prodIngresados} articulos");
                    //ordpago = new OrdenDePago(cart.Id, cart.carrito_cliente_dni, cart.carrito_total);
                    //ordenBLL.CrearOrden(ordpago);
                    this.Dispose();
                }
                else
                {
                    throw new ValidationException("El DNI ingresado es incorrecto");
                }
            }

        }
    }
}

//foreach (Producto i in cart.Productos)
//{
//    foreach (Producto p in cart.Productos.FindAll(x=>x.Id==i.Id))
//    {
//        p.producto_stock = p.producto_stock - cart.Productos.FindAll(x => x.Id == p.Id).Count;
//        productBLL.UpdateStock(p);
//    }
//    y se han ingresado {prodIngresados} productos.");
//}
