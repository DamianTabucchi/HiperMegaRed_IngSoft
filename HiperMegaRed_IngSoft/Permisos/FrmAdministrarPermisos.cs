using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiperMegaRed.BE;
using HiperMegaRed.BLL;
using HiperMegaRed.Services;

namespace HiperMegaRed_IngSoft.Permisos
{
    public partial class FrmAdministrarPermisos : Form
    {
        private IEnumerable<Familia> familias = null;
        private IEnumerable<Patente> patentes = null;

        private PermisosBLL permisosBLL = PermisosBLL.Instance;

        private Familia edicion;
        public FrmAdministrarPermisos()
        {
            InitializeComponent();
            CargarFamilias();
            CargarPatentes();
            FiltrarComponentes(lbxFamilias, this.familias, txtFamilia.Text);
            FiltrarComponentes(lbxPatente, this.patentes, txtPatente.Text);

            cbxTipoPermiso.DataSource = permisosBLL.GetAllPermission();
        }

        private void CargarFamilias()
        {
            this.familias = permisosBLL.GetAllFamilias();
            lbxFamilias.DataSource = familias;
        }
        private void CargarPatentes()
        {
            this.patentes = permisosBLL.GetAllPatentes();
            lbxPatente.DataSource = this.patentes;
        }
        private void txtFamilia_TextChanged(object sender, EventArgs e)
        {
            FiltrarComponentes(lbxFamilias, this.familias, txtFamilia.Text);
        }


        private void FiltrarComponentes(ListBox lbx, IEnumerable<Componente> componentes, string text)
        {

            lbx.BeginUpdate();
            lbx.DataSource = null;
            lbx.Items.Clear();

            if (!string.IsNullOrEmpty(text))
            {
                foreach (var componente in componentes)
                {
                    if (componente.Nombre.Contains(text))
                    {
                        lbx.Items.Add(componente);
                    }
                }
            }
            else
                lbx.DataSource = componentes;
            lbx.EndUpdate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnCancelarFamilia_Click(sender, e);
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFamilia.Text))
            {
                MessageBox.Show("Complete los campos!");
            }
            else
            {
                var familia = new Familia
                {
                    Nombre = txtFamilia.Text
                };

                var compotemp = permisosBLL.GetByGrantName(familia.Nombre);

                if (compotemp != null)
                {
                    MessageBox.Show("Este componente ya existe!");
                }
                else
                {
                    permisosBLL.GuardarComponente(familia, true);
                    CargarFamilias();
                    txtFamilia.Text = null;
                    MessageBox.Show("Familia Creada");
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            updateTreeView((Familia)lbxFamilias.SelectedItem);
        }
        private TreeNode GenerateTreeNode(Componente componente)
        {
            var nodo = new TreeNode();
            nodo.Text = componente.Nombre;

            if (componente is Familia)
            {
                foreach (var hijo in componente.Hijos)
                {
                    nodo.Nodes.Add(GenerateTreeNode(hijo));
                }
            }
            nodo.Expand();
            return nodo;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            var familia = (Componente)lbxFamilias.SelectedItem;
            BorrarComponente(familia);
        }

        private void BorrarComponente(Componente componente)
        {
            if (this.edicion != null && componente != null && componente.Nombre != this.edicion.Nombre && this.permisosBLL.DeleteRelatedComponent(this.edicion, componente))
            {
                this.updateTreeView(this.edicion);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarPatente_Click(object sender, EventArgs e)
        {
            AgregarComponente((Componente)lbxPatente.SelectedItem);
        }

        private void AgregarComponente(Componente componente)
        {
            if (this.edicion != null && componente != null && permisosBLL.AddToComponent(this.edicion, componente))
            {
                this.updateTreeView(this.edicion);
            }
        }

        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
            FiltrarComponentes(lbxPatente, this.patentes, txtPatente.Text);
        }

        private void btnCrearPatente_Click(object sender, EventArgs e)
        {
            var nombre = txtPatente.Text;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Debe indicar el nombre del permiso para crearlo");
            }

            var p = new Patente()
            {
                Nombre = nombre,
                Permiso = (TipoPermiso)cbxTipoPermiso.SelectedItem
            };

            var compotemp = permisosBLL.GetByGrantName(p.Nombre);

            if (compotemp != null)
            {
                MessageBox.Show("Este componente ya existe!");
            }
            else
            {
                permisosBLL.GuardarComponente(p, false);
                CargarPatentes();
                txtPatente.Text = null;
                MessageBox.Show("Patente Creada");
            }
        }

        private void btnQuitarPatente_Click(object sender, EventArgs e)
        {
            BorrarComponente((Componente)lbxPatente.SelectedItem);
        }

        private void btnCancelarFamilia_Click(object sender, EventArgs e)
        {
            this.edicion = null;
            tvPermisos.Nodes.Clear();
        }

        private void updateTreeView(Familia component)
        {

            tvPermisos.BeginUpdate();
            tvPermisos.Nodes.Clear();
            this.edicion = component;
            this.permisosBLL.FillFamilyComponents(component);

            tvPermisos.Nodes.Add(GenerateTreeNode(component));
            tvPermisos.ExpandAll();

            tvPermisos.EndUpdate();
        }

        private void FrmAdministrarPermisos_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            //this.edicion = (Familia)lbxFamilias.SelectedItem;
            AgregarComponente((Componente)lbxFamilias.SelectedItem);
        }

        private void lbxFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.edicion = (Familia)lbxFamilias.SelectedItem;
        }
    }
}
