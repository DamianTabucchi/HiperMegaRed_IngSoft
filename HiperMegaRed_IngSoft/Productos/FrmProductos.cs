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
    public partial class FrmProductos : Form
    {
        
        private ProductoBLL productBLL = ProductoBLL.Instance;
        //private HiperMegaRed.BE.Producto prod;
        private ItemProducto itemProd;
        private CarritoBLL carritoBLL = CarritoBLL.Instance;
        private static Carrito cart = new Carrito();
        //private IList<Producto> sessionProductos = new List<Producto>();

        public FrmProductos()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
        }

        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = GlobalStorage.Deposito;
            RefreshData();
        }
        private void RefreshData()
        {
            dgvProductos.ClearSelection();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = GlobalStorage.Deposito;
            cmbTipo1.DataSource = Enum.GetValues(typeof(TipoDeProducto));
            dgvProductos.Columns["Id"].Visible = false;
            cmbTipo1.Text = MultiLang.TranslateOrDefault("Text.Tipo","Tipo");
            btnClear.Text = MultiLang.TranslateOrDefault("Text.Buscar", "Buscar");
            dgvCart.DataSource = null;
            dgvCart.DataSource = cart.carrito_productos.ToArray();
            VisualizarData();
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
            nudCantidad.Enabled = false;
            nudCantidad.Value = 0;
        }

        private void VisualizarData() // función para visualizar la informacion en los data grid views
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
            dgvProductos.Columns["producto_stock"].Visible = true;
            dgvProductos.Columns["producto_stock"].DisplayIndex = 4;  // Quinta columna
            dgvProductos.Columns["producto_stock"].HeaderText = MultiLang.TranslateOrDefault("Header.Stock", "Stock");
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
                    column.Name != "producto_stock")
                {
                    column.Visible = false;
                }
            }

            dgvCart.Columns["producto_nombre"].Visible = true;
            dgvCart.Columns["producto_nombre"].DisplayIndex = 0;  // Primer columna
            dgvCart.Columns["producto_nombre"].HeaderText = MultiLang.TranslateOrDefault("Header.Name", "Nombre");
            dgvCart.Columns["producto_marca"].Visible = true;
            dgvCart.Columns["producto_marca"].DisplayIndex = 1;  // Segunda columna
            dgvCart.Columns["producto_marca"].HeaderText = MultiLang.TranslateOrDefault("Header.Brand", "Marca");
            dgvCart.Columns["producto_modelo"].Visible = true;
            dgvCart.Columns["producto_modelo"].DisplayIndex = 2;  // Tercer columna
            dgvCart.Columns["producto_modelo"].HeaderText = MultiLang.TranslateOrDefault("Header.Model", "Modelo");
            dgvCart.Columns["producto_tipo"].Visible = true;
            dgvCart.Columns["producto_tipo"].DisplayIndex = 3;  // Cuarta columna
            dgvCart.Columns["producto_tipo"].HeaderText = MultiLang.TranslateOrDefault("Header.Type", "Tipo");
            dgvCart.Columns["cantidad"].Visible = true;
            dgvCart.Columns["cantidad"].DisplayIndex = 4;  // Quinta columna
            dgvCart.Columns["cantidad"].HeaderText = MultiLang.TranslateOrDefault("Header.Quantiy", "Cantidad");
            dgvCart.Columns["producto_precio_unidad"].Visible = true;
            dgvCart.Columns["producto_precio_unidad"].DisplayIndex = 5;  // Sexta columna
            dgvCart.Columns["producto_precio_unidad"].HeaderText = MultiLang.TranslateOrDefault("Header.Price", "Precio");

            foreach (DataGridViewColumn column in dgvCart.Columns)
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
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void cmbTipo1_SelectedIndexChanged(object sender, EventArgs e)
        {
                   
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (string.Equals(btnClear.Text, "Buscar") || string.Equals(btnClear.Text, "Search"))
            {
                //dgvProductos.DataSource = productBLL.FindByType(cmbTipo1.Text);
                dgvProductos.DataSource = GlobalStorage.Deposito.Where(p => p.producto_tipo.ToString() == cmbTipo1.Text).ToList();
                if (string.Equals(btnClear.Text, "Buscar") || string.Equals(btnClear.Text, "Search"))
                {
                    btnClear.Text = MultiLang.TranslateOrDefault("Limpiar", "Limpiar");
                }
            }
            else
            {
                RefreshData();
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            //prod = new HiperMegaRed.BE.Producto();
            itemProd = new ItemProducto();
            DataGridViewRow fila = dgvProductos.SelectedRows[0];
            itemProd.Id = (Guid)fila.Cells["id"].Value;
            if (GlobalStorage.Deposito.ToList().Find(x => x.Id == itemProd.Id).producto_stock > 0)
            {
                var prod = productBLL.FindProductById(itemProd.Id);
                itemProd.producto_nombre = prod.producto_nombre;
                itemProd.producto_marca = prod.producto_marca;
                itemProd.producto_modelo = prod.producto_modelo;
                itemProd.producto_precio_unidad = prod.producto_precio_unidad;
                itemProd.producto_tipo = prod.producto_tipo;
                itemProd.producto_descripcion = prod.producto_descripcion;
                itemProd.cantidad = Convert.ToInt32(nudCantidad.Value);

                GlobalStorage.Deposito.ToList().Find(x => x.Id == itemProd.Id).producto_stock -= Convert.ToInt32(itemProd.cantidad);
                try
                {
                    if (cart.carrito_productos.Count > 0)
                    {
                        if (cart.carrito_productos.ToList().Find(x => x.Id == itemProd.Id) != null)
                        {
                            cart.carrito_productos.ToList().Find(x => x.Id == itemProd.Id).cantidad += itemProd.cantidad;
                            MessageBox.Show("Cantidad actualizada");
                            RefreshData();
                        }
                        else
                        {
                            cart.AddProduct(itemProd);
                            MessageBox.Show("Producto agregado al carrito");
                            RefreshData();
                        }
                    }
                    else
                    {
                        cart.AddProduct(itemProd);
                        MessageBox.Show("Producto agregado al carrito");
                    }
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
                GlobalStorage.Deposito.ToList().Find(x => x.Id == pid).producto_stock += Convert.ToInt32(cart.carrito_productos.ToList().Find(y => y.Id == pid).cantidad);
                cart.RemProductCart(pid);
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

                    //var data = productBLL.GetAll().ToList();
                    //foreach (var group in cart.carrito_productos.GroupBy(x => x.Id).ToList())
                    //{
                    //    foreach (Producto p in group)
                    //    {
                    //        p.producto_stock = data.Find(x => x.Id == p.Id).producto_stock - cart.carrito_productos.Count(x => x.Id == p.Id);
                    //        productBLL.UpdateStock(p);
                    //    }
                    //}
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

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            nudCantidad.Value = 1;

            if (dgvProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvProductos.SelectedRows[0];
                int maxCantidad = Convert.ToInt32(fila.Cells["producto_stock"].Value);
                nudCantidad.Enabled = true;
                nudCantidad.Value = 1;
                nudCantidad.Maximum = Convert.ToDecimal(maxCantidad);
            }
        }
    }
}
