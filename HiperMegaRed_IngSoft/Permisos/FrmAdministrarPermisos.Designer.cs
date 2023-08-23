
namespace HiperMegaRed_IngSoft.Permisos
{
    partial class FrmAdministrarPermisos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbxFamilias = new System.Windows.Forms.ListBox();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCrearPatente = new System.Windows.Forms.Button();
            this.lbxPatente = new System.Windows.Forms.ListBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.btnQuitarPatente = new System.Windows.Forms.Button();
            this.btnAgregarPatente = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tvPermisos = new System.Windows.Forms.TreeView();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbxTipoPermiso = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lbxFamilias);
            this.groupBox1.Controls.Add(this.txtFamilia);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Familias";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(296, 144);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 60);
            this.btnQuitar.TabIndex = 5;
            this.btnQuitar.Text = "<<";
            this.btnQuitar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(296, 78);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 60);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = ">>";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(132, 227);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 30);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Configurar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 227);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbxFamilias
            // 
            this.lbxFamilias.FormattingEnabled = true;
            this.lbxFamilias.ItemHeight = 20;
            this.lbxFamilias.Location = new System.Drawing.Point(6, 57);
            this.lbxFamilias.Name = "lbxFamilias";
            this.lbxFamilias.Size = new System.Drawing.Size(261, 164);
            this.lbxFamilias.TabIndex = 1;
            this.lbxFamilias.SelectedIndexChanged += new System.EventHandler(this.lbxFamilias_SelectedIndexChanged);
            // 
            // txtFamilia
            // 
            this.txtFamilia.Location = new System.Drawing.Point(6, 25);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.Size = new System.Drawing.Size(261, 26);
            this.txtFamilia.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxTipoPermiso);
            this.groupBox2.Controls.Add(this.btnCrearPatente);
            this.groupBox2.Controls.Add(this.lbxPatente);
            this.groupBox2.Controls.Add(this.txtPatente);
            this.groupBox2.Controls.Add(this.btnQuitarPatente);
            this.groupBox2.Controls.Add(this.btnAgregarPatente);
            this.groupBox2.Location = new System.Drawing.Point(12, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 301);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patente";
            // 
            // btnCrearPatente
            // 
            this.btnCrearPatente.Location = new System.Drawing.Point(6, 265);
            this.btnCrearPatente.Name = "btnCrearPatente";
            this.btnCrearPatente.Size = new System.Drawing.Size(120, 30);
            this.btnCrearPatente.TabIndex = 10;
            this.btnCrearPatente.Text = "Crear";
            this.btnCrearPatente.UseVisualStyleBackColor = true;
            this.btnCrearPatente.Click += new System.EventHandler(this.btnCrearPatente_Click);
            // 
            // lbxPatente
            // 
            this.lbxPatente.FormattingEnabled = true;
            this.lbxPatente.ItemHeight = 20;
            this.lbxPatente.Location = new System.Drawing.Point(6, 56);
            this.lbxPatente.Name = "lbxPatente";
            this.lbxPatente.Size = new System.Drawing.Size(261, 164);
            this.lbxPatente.TabIndex = 9;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(6, 24);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(261, 26);
            this.txtPatente.TabIndex = 8;
            this.txtPatente.TextChanged += new System.EventHandler(this.txtPatente_TextChanged);
            // 
            // btnQuitarPatente
            // 
            this.btnQuitarPatente.Location = new System.Drawing.Point(296, 140);
            this.btnQuitarPatente.Name = "btnQuitarPatente";
            this.btnQuitarPatente.Size = new System.Drawing.Size(60, 60);
            this.btnQuitarPatente.TabIndex = 7;
            this.btnQuitarPatente.Text = "<<";
            this.btnQuitarPatente.UseVisualStyleBackColor = true;
            this.btnQuitarPatente.Click += new System.EventHandler(this.btnQuitarPatente_Click);
            // 
            // btnAgregarPatente
            // 
            this.btnAgregarPatente.Location = new System.Drawing.Point(296, 74);
            this.btnAgregarPatente.Name = "btnAgregarPatente";
            this.btnAgregarPatente.Size = new System.Drawing.Size(60, 60);
            this.btnAgregarPatente.TabIndex = 6;
            this.btnAgregarPatente.Text = ">>";
            this.btnAgregarPatente.UseVisualStyleBackColor = true;
            this.btnAgregarPatente.Click += new System.EventHandler(this.btnAgregarPatente_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tvPermisos);
            this.groupBox3.Location = new System.Drawing.Point(415, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(373, 503);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Editar Familia";
            // 
            // tvPermisos
            // 
            this.tvPermisos.Location = new System.Drawing.Point(6, 25);
            this.tvPermisos.Name = "tvPermisos";
            this.tvPermisos.Size = new System.Drawing.Size(357, 472);
            this.tvPermisos.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(668, 533);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 30);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbxTipoPermiso
            // 
            this.cbxTipoPermiso.FormattingEnabled = true;
            this.cbxTipoPermiso.Location = new System.Drawing.Point(6, 226);
            this.cbxTipoPermiso.Name = "cbxTipoPermiso";
            this.cbxTipoPermiso.Size = new System.Drawing.Size(261, 28);
            this.cbxTipoPermiso.TabIndex = 11;
            // 
            // FrmAdministrarPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 608);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAdministrarPermisos";
            this.Text = "Gestion Permisos";
            this.Load += new System.EventHandler(this.FrmAdministrarPermisos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbxFamilias;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCrearPatente;
        private System.Windows.Forms.ListBox lbxPatente;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Button btnQuitarPatente;
        private System.Windows.Forms.Button btnAgregarPatente;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView tvPermisos;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbxTipoPermiso;
    }
}