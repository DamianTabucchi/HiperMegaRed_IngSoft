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

namespace HiperMegaRed_IngSoft
{
    public partial class FrmRegistrarProveedor : Form
    {
        private ProveedoresBLL proveedorBLL = ProveedoresBLL.Instance;
        private Proveedor Supplier;

        public FrmRegistrarProveedor()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);

            txtCUIT.KeyPress += txtSoloNumeros_KeyPress;
            txtTelefono.KeyPress += txtSoloNumeros_KeyPress;
        }

        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }



        private void FrmRegistrarProveedor_Load(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            txtNombre.Text = string.Empty;
            txtCUIT.Text = string.Empty;
            txtPOC.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtAdicional.Text = string.Empty;
            cmbCategoria.DataSource = null;
            cmbCategoria.DataSource = Enum.GetValues(typeof(TipoDeProducto));
            cmbCategoria.Text = MultiLang.TranslateOrDefault("Text.Categoria", "Categoria");
        }
        private void txtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla es un número o la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada de caracteres no numéricos
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCUIT.Text) || 
                string.IsNullOrWhiteSpace(txtPOC.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAdicional.Text))
            {
                MessageBox.Show("Todos los campos de texto deben estar completos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que se haya seleccionado un tipo de producto en cmbCategoria
            if (cmbCategoria.SelectedIndex == -1 || !Enum.IsDefined(typeof(TipoDeProducto), cmbCategoria.SelectedItem))
            {
                MessageBox.Show("Debe seleccionar una categoría de producto válida.", "Categoría no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Supplier = new Proveedor();
            Supplier.Id = Guid.NewGuid();
            Supplier.proveedor_nombre = txtNombre.Text;
            Supplier.proveedor_cuit = long.Parse(txtCUIT.Text);
            Supplier.proveedor_nombre_poc = txtPOC.Text;
            Supplier.proveedor_direccion = txtDireccion.Text;
            Supplier.proveedor_telefono = txtTelefono.Text;
            Supplier.proveedor_email = txtEmail.Text; 
            Supplier.proveedor_categoria = (TipoDeProducto)cmbCategoria.SelectedItem;
            Supplier.proveedor_notas_adicionales = txtAdicional.Text;
            Supplier.proveedor_activo = true;
            try
            {
                proveedorBLL.SaveProveedor(Supplier);
                MessageBox.Show("Proveedor Registrado","Proveedor Registrado", MessageBoxButtons.OK);
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }
    }
}
