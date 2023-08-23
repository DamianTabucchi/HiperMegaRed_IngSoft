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
    public partial class FrmProductos : Form
    {
        
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private HiperMegaRed.BE.Producto prod;
        private CarritoBLL carritoBLL = CarritoBLL.Instance;
        private static Carrito cart = new Carrito();
        private IList<Producto> sessionProductos = new List<Producto>();
        
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            var data = productBLL.GetAll();
            dgvProductos.DataSource = data;
            sessionProductos = data;
            RefreshData();
            //VERIFICAR STOCK
            //if (cart.carrito_productos.Count > 0)
            //{
                
            //    foreach (Producto p in cart.carrito_productos)
            //    {
            //        sessionProductos.ToList().Find(x => x.Id == p.Id).producto_stock -= 1;
            //    }
            //}
            //else
            //{
            //}

        }
        private void RefreshData()
        {
            dgvProductos.ClearSelection();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = sessionProductos;
            cmbTipo1.DataSource = Enum.GetValues(typeof(TipoDeProducto));
            dgvProductos.Columns["Id"].Visible = false;
            cmbTipo1.Text = "Tipo";
            btnClear.Text = "Buscar";
            dgvCart.DataSource = null;
            dgvCart.DataSource = cart.carrito_productos.ToArray();
            if (cart.carrito_productos.Count > 0)
            {
                btnRemProd.Enabled = true;
                btnConfirmar.Enabled = true;
                txtTotalPagar.Text = cart.carrito_total.ToString();
            }
            if (cart.carrito_productos.Count == 0)
            {
                btnRemProd.Enabled = false;
                btnConfirmar.Enabled = false;
                txtTotalPagar.Text = "";
            }
            
            
        }
        private void cmbTipo1_SelectedIndexChanged(object sender, EventArgs e)
        {
                   
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (string.Equals(btnClear.Text, "Buscar"))
            {
                dgvProductos.DataSource = productBLL.FindByType(cmbTipo1.Text);
                btnClear.Text = "Limpiar";
            }
            else
            {
                RefreshData();
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            prod = new HiperMegaRed.BE.Producto();
            DataGridViewRow fila = dgvProductos.SelectedRows[0];
            prod.Id = (Guid)fila.Cells["id"].Value;
            if (sessionProductos.ToList().Find(x => x.Id == prod.Id).producto_stock > 0)
            {
                prod.producto_nombre = fila.Cells["producto_nombre"].Value.ToString();
                prod.producto_marca = fila.Cells["producto_marca"].Value.ToString();
                prod.producto_modelo = fila.Cells["producto_modelo"].Value.ToString();
                prod.producto_descripcion = fila.Cells["producto_descripcion"].Value.ToString();
                prod.producto_stock = Convert.ToInt32(fila.Cells["producto_stock"].Value);
                prod.producto_precio_unidad = Convert.ToDouble(fila.Cells["producto_precio_unidad"].Value);
                prod.producto_deposito = fila.Cells["producto_deposito"].Value.ToString();
                prod.producto_tipo = (TipoDeProducto)Enum.Parse(typeof(TipoDeProducto), fila.Cells["producto_tipo"].Value.ToString());
                sessionProductos.ToList().Find(x => x.Id == prod.Id).producto_stock -= 1;
                try
                {
                    cart.AddProduct(prod);
                    MessageBox.Show("Producto agregado al carrito");
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No hay mas stock del producto");
            }

            //string mensaje = $"ID: {prod.Id}\n" +
            //    $"Nombre: {prod.producto_nombre}\n" +
            //    $"Marca: {prod.producto_marca}\n" +
            //    $"Modelo: {prod.producto_modelo}\n" +
            //    $"Tipo: {prod.producto_tipo}\n" +
            //    $"Descripcion: {prod.producto_descripcion}\n" +
            //    $"Stock: {prod.producto_stock}\n" +
            //    $"PrecioUnidad: {prod.producto_precio_unidad}\n";

            //MessageBox.Show(mensaje, "Selected Product");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //private void btnShowCart_Click(object sender, EventArgs e)
        //{
        //    var frmCart = new Productos.FrmCarrito(cart);
        //    frmCart.MdiParent = this.MdiParent;
        //    frmCart.Show();
        //    this.Hide();
        //}

        private void btnRemProd_Click(object sender, EventArgs e)
        {
            if (cart.carrito_productos.Count > 0)
            {
                var fila = dgvCart.SelectedRows[0];
                var pid = (Guid)fila.Cells["id"].Value;
                cart.RemProductCart(pid);
                sessionProductos.ToList().Find(x => x.Id == pid).producto_stock += 1;
                RefreshData();
                //if (cart.carrito_productos.Count == 0)
                //{
                //    btnRemProd.Enabled = false;
                //    btnConfirmar.Enabled = false;
                //    txtTotalPagar.Text = "";
                //    dgvCart.DataSource = null;
                //    dgvCart.DataSource = cart.carrito_productos.ToArray();
                //}
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
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
                            p.producto_stock = data.Find(x => x.Id == p.Id).producto_stock - cart.carrito_productos.Count(x => x.Id == p.Id);
                            productBLL.UpdateStock(p);
                        }
                    }
                    MessageBox.Show($"Se ha guardado un carrito con {prodIngresados} articulos");
                    cart = new Carrito();
                    txtDNI.Text = "";
                    RefreshData();
                }
                else
                {
                    throw new ValidationException("El DNI ingresado es incorrecto");
                }
            }
        }
    }
}
