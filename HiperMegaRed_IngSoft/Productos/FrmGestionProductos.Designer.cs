namespace HiperMegaRed_IngSoft.Productos
{
    partial class FrmGestionProductos
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNewSup = new System.Windows.Forms.Button();
            this.cmbProveedores = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rbtActive = new System.Windows.Forms.RadioButton();
            this.txtPPedido = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtProdDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbProdTipo = new System.Windows.Forms.ComboBox();
            this.txtProdPU = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProdDepo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProdStock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProdModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProdMarca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnMod);
            this.groupBox1.Controls.Add(this.dgvProductos);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 558);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "group.productos";
            this.groupBox1.Text = "Productos";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(775, 513);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 39);
            this.btnEliminar.TabIndex = 26;
            this.btnEliminar.Tag = "btn.remove";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnMod
            // 
            this.btnMod.Location = new System.Drawing.Point(689, 513);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(80, 39);
            this.btnMod.TabIndex = 25;
            this.btnMod.Tag = "btn.mod";
            this.btnMod.Text = "Modificar";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(6, 19);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(849, 488);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNewSup);
            this.groupBox2.Controls.Add(this.cmbProveedores);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.rbtActive);
            this.groupBox2.Controls.Add(this.txtPPedido);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtProdDesc);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbProdTipo);
            this.groupBox2.Controls.Add(this.txtProdPU);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtProdDepo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtProdStock);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtProdModel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtProdMarca);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtProdNombre);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(894, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 392);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "group.nuevoprod";
            this.groupBox2.Text = "Nuevo Producto";
            // 
            // btnNewSup
            // 
            this.btnNewSup.Location = new System.Drawing.Point(98, 284);
            this.btnNewSup.Name = "btnNewSup";
            this.btnNewSup.Size = new System.Drawing.Size(196, 23);
            this.btnNewSup.TabIndex = 21;
            this.btnNewSup.Text = "Nuevo Proveedor";
            this.btnNewSup.UseVisualStyleBackColor = true;
            this.btnNewSup.Click += new System.EventHandler(this.btnNewSup_Click);
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Location = new System.Drawing.Point(98, 257);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(196, 21);
            this.cmbProveedores.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 19;
            this.label10.Tag = "lbl.Prov";
            this.label10.Text = "Proveedor:";
            // 
            // rbtActive
            // 
            this.rbtActive.AutoSize = true;
            this.rbtActive.Enabled = false;
            this.rbtActive.Location = new System.Drawing.Point(239, 313);
            this.rbtActive.Name = "rbtActive";
            this.rbtActive.Size = new System.Drawing.Size(55, 17);
            this.rbtActive.TabIndex = 11;
            this.rbtActive.TabStop = true;
            this.rbtActive.Tag = "rbtActive";
            this.rbtActive.Text = "Activo";
            this.rbtActive.UseVisualStyleBackColor = true;
            // 
            // txtPPedido
            // 
            this.txtPPedido.Location = new System.Drawing.Point(98, 153);
            this.txtPPedido.Name = "txtPPedido";
            this.txtPPedido.Size = new System.Drawing.Size(196, 20);
            this.txtPPedido.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 18;
            this.label9.Tag = "lbl.puntoped";
            this.label9.Text = "P. Pedido:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(137, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 39);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Tag = "btn.cancel";
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(51, 340);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 39);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Tag = "btn.add";
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtProdDesc
            // 
            this.txtProdDesc.Location = new System.Drawing.Point(98, 205);
            this.txtProdDesc.Name = "txtProdDesc";
            this.txtProdDesc.Size = new System.Drawing.Size(196, 20);
            this.txtProdDesc.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 15;
            this.label8.Tag = "lbl.description";
            this.label8.Text = "Descripcion:";
            // 
            // cmbProdTipo
            // 
            this.cmbProdTipo.FormattingEnabled = true;
            this.cmbProdTipo.Location = new System.Drawing.Point(98, 101);
            this.cmbProdTipo.Name = "cmbProdTipo";
            this.cmbProdTipo.Size = new System.Drawing.Size(196, 21);
            this.cmbProdTipo.TabIndex = 4;
            // 
            // txtProdPU
            // 
            this.txtProdPU.Location = new System.Drawing.Point(98, 231);
            this.txtProdPU.Name = "txtProdPU";
            this.txtProdPU.Size = new System.Drawing.Size(196, 20);
            this.txtProdPU.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 12;
            this.label7.Tag = "lbl.PU";
            this.label7.Text = "Precio Unidad:";
            // 
            // txtProdDepo
            // 
            this.txtProdDepo.Location = new System.Drawing.Point(98, 179);
            this.txtProdDepo.Name = "txtProdDepo";
            this.txtProdDepo.Size = new System.Drawing.Size(196, 20);
            this.txtProdDepo.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Tag = "Header.Deposit";
            this.label6.Text = "Deposito:";
            // 
            // txtProdStock
            // 
            this.txtProdStock.Location = new System.Drawing.Point(98, 127);
            this.txtProdStock.Name = "txtProdStock";
            this.txtProdStock.Size = new System.Drawing.Size(196, 20);
            this.txtProdStock.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Tag = "Header.Stock";
            this.label5.Text = "Stock";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Tag = "Header.Type";
            this.label4.Text = "Tipo:";
            // 
            // txtProdModel
            // 
            this.txtProdModel.Location = new System.Drawing.Point(98, 75);
            this.txtProdModel.Name = "txtProdModel";
            this.txtProdModel.Size = new System.Drawing.Size(196, 20);
            this.txtProdModel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Tag = "Header.Model";
            this.label3.Text = "Modelo:";
            // 
            // txtProdMarca
            // 
            this.txtProdMarca.Location = new System.Drawing.Point(98, 49);
            this.txtProdMarca.Name = "txtProdMarca";
            this.txtProdMarca.Size = new System.Drawing.Size(196, 20);
            this.txtProdMarca.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Tag = "Header.Brand";
            this.label2.Text = "Marca:";
            // 
            // txtProdNombre
            // 
            this.txtProdNombre.Location = new System.Drawing.Point(98, 23);
            this.txtProdNombre.Name = "txtProdNombre";
            this.txtProdNombre.Size = new System.Drawing.Size(196, 20);
            this.txtProdNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "lbl.name";
            this.label1.Text = "Nombre:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1114, 525);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 39);
            this.btnSalir.TabIndex = 22;
            this.btnSalir.Tag = "btn.exit";
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmGestionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 589);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmGestionProductos";
            this.Text = "FrmGestionProductos";
            this.Load += new System.EventHandler(this.FrmGestionProductos_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtProdNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProdPU;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProdDepo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProdStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProdModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProdMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProdTipo;
        private System.Windows.Forms.TextBox txtProdDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPPedido;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbtActive;
        private System.Windows.Forms.ComboBox cmbProveedores;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnNewSup;
    }
}