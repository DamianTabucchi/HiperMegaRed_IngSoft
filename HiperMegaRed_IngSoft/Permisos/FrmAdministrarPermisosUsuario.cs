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
using HiperMegaRed.DAL.MultiLenguaje;
using HiperMegaRed.DAL;

namespace HiperMegaRed_IngSoft.Permisos
{
    public partial class FrmAdministrarPermisosUsuario : Form
    {
        public UserBLL userbll = UserBLL.Instance;
        public PermisosBLL permisosbll = PermisosBLL.Instance;
        private User editable;



        public FrmAdministrarPermisosUsuario()
        {
            InitializeComponent();
            TraducirTextos();
            MultiLang.SubscribeChangeLangEvent(TraducirTextos);

        }
        private void TraducirTextos()
        {
            WinformUtils.TraducirControl(this);
        }
        void LlenarTreeView(TreeNode padre, Componente c)
        {
            TreeNode hijo = new TreeNode(c.Nombre);
            hijo.Tag = c;
            padre.Nodes.Add(hijo);

            foreach(var i in c.Hijos)
            {
                LlenarTreeView(hijo, i);
            }
        }

        void MostrarPermisos()
        {
            this.treeView1.Nodes.Clear();
            TreeNode root = new TreeNode(this.editable.Username);
            foreach (var i in this.editable.Permisos)
            {
                LlenarTreeView(root, i);
            }
            this.treeView1.Nodes.Add(root);
            this.treeView1.ExpandAll();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem != null)
            {
                this.editable = (User)cmbUsuarios.SelectedItem;
                this.editable.Permisos = this.permisosbll.GetAllUserComponents(editable);
                MostrarPermisos();
            }
        }

        private void FrmAdministrarPermisosUsuario_Load(object sender, EventArgs e)
        {
            this.cmbUsuarios.DataSource = userbll.GetAll();
            this.cmbFamilies.DataSource = permisosbll.GetAllFamilias();
            this.cmbPatente.DataSource = permisosbll.GetAllPatentes();

            cmbUsuarios.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbUsuarios.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbFamilies.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbFamilies.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbPatente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbPatente.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnAddF_Click(object sender, EventArgs e)
        {
            var componente = (Componente)cmbFamilies.SelectedItem;
            AgregarComponente(componente);
        }



        void AgregarComponente(Componente componente)
        {
            if (this.editable != null)
            {
                if (componente != null)
                {
                    var esta = false;

                    foreach (var item in this.editable.Permisos)
                    {
                        if (permisosbll.Existe(item, componente.Id))
                        {
                            esta = true;
                            break;
                        }
                    }
                    // Patente esta?
                    if (!esta)
                    {
                        // no esta!
                        if (componente is Familia)
                            permisosbll.FillFamilyComponents((Familia)componente);

                        this.editable.Permisos.Add(componente);
                        this.MostrarPermisos();
                    }
                }
            }
        }

        void QuitarComponente(Componente componente)
        {
            if (this.editable != null && componente != null)
            {
                if (this.editable.Permisos.RemoveAll(c => c.Id == componente.Id) > 0)
                {
                    MostrarPermisos();
                }
            }
        }

        private void btnAddP_Click(object sender, EventArgs e)
        {
            var componente = (Componente)cmbPatente.SelectedItem;
            AgregarComponente(componente);
        }

        private void btnRemF_Click(object sender, EventArgs e)
        {
            QuitarComponente((Familia)cmbFamilies.SelectedItem);
        }

        private void btnRemP_Click(object sender, EventArgs e)
        {
            QuitarComponente((Componente)cmbPatente.SelectedItem);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var user = (User)cmbUsuarios.SelectedItem;
            if (this.editable != null)
            {
                var affected = userbll.SavePermisos(this.editable);
                MessageBox.Show($"Los permisos se guardaron correctamente para el usuario " + this.editable);
            }
        }
    }
}
