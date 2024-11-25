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
using Newtonsoft.Json.Linq;

namespace HiperMegaRed_IngSoft
{
    public partial class FrmBitacoraCambios : Form
    {
        private ProductoBLL productBLL = ProductoBLL.Instance;
        private BitacoraCambioBLL bitacoraCambioBLL = BitacoraCambioBLL.Instance;

        public FrmBitacoraCambios()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);
            RefreshDataProducto();
            //RefreshDataBC();
        }

        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }

        private void RefreshDataProducto()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productBLL.GetAll();
            dgvProductos.Columns["Id"].Visible = false;
            
        }
        private void RefreshDataBC()
        {

            dgvBitacoraCambios.DataSource = null;
            
        }



        private void BitacoraCambios_Load(object sender, EventArgs e)
        {

        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridViewRow fila = dgvProductos.SelectedRows[0];
            //var bita = bitacoraCambioBLL.GetAll();
            //dgvBitacoraCambios.DataSource = bita.ToList().FindAll(x => x.producto_id == (Guid)fila.Cells["id"].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = dgvProductos.SelectedRows[0];
            var bita = bitacoraCambioBLL.GetAll();

            // Filtrar por producto_id y ordenar por fecha descendente
            var bitacoraOrdenada = bita.Where(x => x.producto_id == (Guid)fila.Cells["id"].Value)
                                       .OrderByDescending(x => x.fecha)
                                       .ToList();

            dgvBitacoraCambios.DataSource = bitacoraOrdenada;

            //DataGridViewRow fila = dgvProductos.SelectedRows[0];
            //var bita = bitacoraCambioBLL.GetAll();
            //dgvBitacoraCambios.DataSource = bita.ToList().FindAll(x => x.producto_id == (Guid)fila.Cells["id"].Value);
            //dgvBitacoraCambios.Sort(dgvBitacoraCambios.Columns["fecha"], System.ComponentModel.ListSortDirection.Descending);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = dgvBitacoraCambios.SelectedRows[0];
            var prod = new Producto();
            prod.Id = (Guid)fila.Cells["producto_id"].Value;
            prod.producto_nombre = fila.Cells["producto_nombre"].Value.ToString();
            prod.producto_marca = fila.Cells["producto_marca"].Value.ToString();
            prod.producto_modelo = fila.Cells["producto_modelo"].Value.ToString();
            prod.producto_tipo = (TipoDeProducto)Enum.Parse(typeof(TipoDeProducto), fila.Cells["producto_tipo"].Value.ToString());
            prod.producto_stock = Convert.ToInt32(fila.Cells["producto_stock"].Value);
            prod.producto_deposito = fila.Cells["producto_deposito"].Value.ToString();
            prod.producto_precio_unidad = Convert.ToDouble(fila.Cells["producto_precio_unidad"].Value);
            prod.producto_descripcion = fila.Cells["producto_descripcion"].Value.ToString();
            productBLL.SaveProduct(prod);
            MessageBox.Show(MultiLang.TranslateOrDefault("Product.Restore", "Producto Restaurado"), MultiLang.TranslateOrDefault("Product.Restore", "Producto Restaurado"), MessageBoxButtons.OK);
            RefreshDataProducto();
            RefreshDataBC();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
