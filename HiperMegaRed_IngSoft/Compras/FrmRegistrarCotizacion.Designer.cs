namespace HiperMegaRed_IngSoft.Compras
{
    partial class FrmRegistrarCotizacion
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
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgvSolicitudesCotizacion = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemProd = new System.Windows.Forms.Button();
            this.btnSelectProd = new System.Windows.Forms.Button();
            this.txtProdModel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProdMarca = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProdNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProdPrecioUnidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProdCant = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvProductosCotizados = new System.Windows.Forms.DataGridView();
            this.dtPiker1 = new System.Windows.Forms.DateTimePicker();
            this.txtSolicitudNumero = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFechaEmision = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCotizacionNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbCondiciones = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudesCotizacion)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosCotizados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSeleccionar);
            this.groupBox1.Controls.Add(this.dgvSolicitudesCotizacion);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(904, 380);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "gpb.solicitudes";
            this.groupBox1.Text = "Solicitudes Enviadas";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(781, 325);
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(107, 48);
            this.btnSeleccionar.TabIndex = 1;
            this.btnSeleccionar.Tag = "btnSelect";
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dgvSolicitudesCotizacion
            // 
            this.dgvSolicitudesCotizacion.AllowUserToAddRows = false;
            this.dgvSolicitudesCotizacion.AllowUserToDeleteRows = false;
            this.dgvSolicitudesCotizacion.AllowUserToResizeColumns = false;
            this.dgvSolicitudesCotizacion.AllowUserToResizeRows = false;
            this.dgvSolicitudesCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudesCotizacion.Location = new System.Drawing.Point(8, 23);
            this.dgvSolicitudesCotizacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSolicitudesCotizacion.MultiSelect = false;
            this.dgvSolicitudesCotizacion.Name = "dgvSolicitudesCotizacion";
            this.dgvSolicitudesCotizacion.ReadOnly = true;
            this.dgvSolicitudesCotizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitudesCotizacion.Size = new System.Drawing.Size(880, 295);
            this.dgvSolicitudesCotizacion.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.dtPiker1);
            this.groupBox2.Controls.Add(this.txtSolicitudNumero);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtProveedor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtFechaEmision);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtCotizacionNumero);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 402);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(904, 446);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registrar Cotizacion";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(928, 727);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 48);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Guardar Cotizacion";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 277);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 16);
            this.label12.TabIndex = 25;
            this.label12.Tag = "lbl.condiciones";
            this.label12.Text = "Condiciones:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbCondiciones);
            this.groupBox3.Controls.Add(this.btnRemProd);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.btnSelectProd);
            this.groupBox3.Controls.Add(this.txtProdModel);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtProdMarca);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtProdNombre);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtProdPrecioUnidad);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtProdCant);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnActualizar);
            this.groupBox3.Controls.Add(this.dgvProductosCotizados);
            this.groupBox3.Location = new System.Drawing.Point(8, 119);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(888, 316);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Productos Solicitados:";
            // 
            // btnRemProd
            // 
            this.btnRemProd.Enabled = false;
            this.btnRemProd.Location = new System.Drawing.Point(647, 235);
            this.btnRemProd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemProd.Name = "btnRemProd";
            this.btnRemProd.Size = new System.Drawing.Size(100, 28);
            this.btnRemProd.TabIndex = 25;
            this.btnRemProd.Tag = "btn.remove";
            this.btnRemProd.Text = "Eliminar";
            this.btnRemProd.UseVisualStyleBackColor = true;
            this.btnRemProd.Click += new System.EventHandler(this.btnRemProd_Click);
            // 
            // btnSelectProd
            // 
            this.btnSelectProd.Enabled = false;
            this.btnSelectProd.Location = new System.Drawing.Point(773, 206);
            this.btnSelectProd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectProd.Name = "btnSelectProd";
            this.btnSelectProd.Size = new System.Drawing.Size(107, 48);
            this.btnSelectProd.TabIndex = 24;
            this.btnSelectProd.Tag = "btnselectprod";
            this.btnSelectProd.Text = "Seleccionar Producto";
            this.btnSelectProd.UseVisualStyleBackColor = true;
            this.btnSelectProd.Click += new System.EventHandler(this.btnSelectProd_Click);
            // 
            // txtProdModel
            // 
            this.txtProdModel.Enabled = false;
            this.txtProdModel.Location = new System.Drawing.Point(583, 206);
            this.txtProdModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProdModel.Name = "txtProdModel";
            this.txtProdModel.Size = new System.Drawing.Size(163, 22);
            this.txtProdModel.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(515, 209);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Modelo:";
            // 
            // txtProdMarca
            // 
            this.txtProdMarca.Enabled = false;
            this.txtProdMarca.Location = new System.Drawing.Point(331, 206);
            this.txtProdMarca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProdMarca.Name = "txtProdMarca";
            this.txtProdMarca.Size = new System.Drawing.Size(163, 22);
            this.txtProdMarca.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 209);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Marca:";
            // 
            // txtProdNombre
            // 
            this.txtProdNombre.Enabled = false;
            this.txtProdNombre.Location = new System.Drawing.Point(103, 206);
            this.txtProdNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProdNombre.Name = "txtProdNombre";
            this.txtProdNombre.Size = new System.Drawing.Size(151, 22);
            this.txtProdNombre.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 209);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Nombre:";
            // 
            // txtProdPrecioUnidad
            // 
            this.txtProdPrecioUnidad.Enabled = false;
            this.txtProdPrecioUnidad.Location = new System.Drawing.Point(381, 238);
            this.txtProdPrecioUnidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProdPrecioUnidad.Name = "txtProdPrecioUnidad";
            this.txtProdPrecioUnidad.Size = new System.Drawing.Size(132, 22);
            this.txtProdPrecioUnidad.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 241);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Precio Unidad:";
            // 
            // txtProdCant
            // 
            this.txtProdCant.Enabled = false;
            this.txtProdCant.Location = new System.Drawing.Point(103, 238);
            this.txtProdCant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProdCant.Name = "txtProdCant";
            this.txtProdCant.Size = new System.Drawing.Size(151, 22);
            this.txtProdCant.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 244);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cantidad:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new System.Drawing.Point(773, 261);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(107, 48);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Tag = "btnupdate";
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvProductosCotizados
            // 
            this.dgvProductosCotizados.AllowUserToAddRows = false;
            this.dgvProductosCotizados.AllowUserToDeleteRows = false;
            this.dgvProductosCotizados.AllowUserToResizeColumns = false;
            this.dgvProductosCotizados.AllowUserToResizeRows = false;
            this.dgvProductosCotizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosCotizados.Location = new System.Drawing.Point(8, 23);
            this.dgvProductosCotizados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProductosCotizados.MultiSelect = false;
            this.dgvProductosCotizados.Name = "dgvProductosCotizados";
            this.dgvProductosCotizados.ReadOnly = true;
            this.dgvProductosCotizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductosCotizados.Size = new System.Drawing.Size(872, 175);
            this.dgvProductosCotizados.TabIndex = 11;
            this.dgvProductosCotizados.SelectionChanged += new System.EventHandler(this.dgvProductosCotizados_SelectionChanged);
            // 
            // dtPiker1
            // 
            this.dtPiker1.Location = new System.Drawing.Point(621, 55);
            this.dtPiker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPiker1.Name = "dtPiker1";
            this.dtPiker1.Size = new System.Drawing.Size(265, 22);
            this.dtPiker1.TabIndex = 10;
            // 
            // txtSolicitudNumero
            // 
            this.txtSolicitudNumero.Enabled = false;
            this.txtSolicitudNumero.Location = new System.Drawing.Point(159, 55);
            this.txtSolicitudNumero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSolicitudNumero.Name = "txtSolicitudNumero";
            this.txtSolicitudNumero.Size = new System.Drawing.Size(192, 22);
            this.txtSolicitudNumero.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "N. Solicitud:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Enabled = false;
            this.txtProveedor.Location = new System.Drawing.Point(621, 87);
            this.txtProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(192, 22);
            this.txtProveedor.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(535, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Proveedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Estimada Entrega:";
            // 
            // txtFechaEmision
            // 
            this.txtFechaEmision.Enabled = false;
            this.txtFechaEmision.Location = new System.Drawing.Point(159, 87);
            this.txtFechaEmision.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFechaEmision.Name = "txtFechaEmision";
            this.txtFechaEmision.Size = new System.Drawing.Size(192, 22);
            this.txtFechaEmision.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Emision:";
            // 
            // txtCotizacionNumero
            // 
            this.txtCotizacionNumero.Enabled = false;
            this.txtCotizacionNumero.Location = new System.Drawing.Point(159, 23);
            this.txtCotizacionNumero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCotizacionNumero.Name = "txtCotizacionNumero";
            this.txtCotizacionNumero.Size = new System.Drawing.Size(192, 22);
            this.txtCotizacionNumero.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero Cotizacion:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(928, 782);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 48);
            this.btnExit.TabIndex = 2;
            this.btnExit.Tag = "btn.exit";
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbCondiciones
            // 
            this.cmbCondiciones.Enabled = false;
            this.cmbCondiciones.FormattingEnabled = true;
            this.cmbCondiciones.Location = new System.Drawing.Point(103, 274);
            this.cmbCondiciones.Name = "cmbCondiciones";
            this.cmbCondiciones.Size = new System.Drawing.Size(214, 24);
            this.cmbCondiciones.TabIndex = 26;
            // 
            // FrmRegistrarCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 856);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmRegistrarCotizacion";
            this.Tag = "frmregistrarcotizacion";
            this.Text = "Registrar Cotizacion";
            this.Load += new System.EventHandler(this.FrmRegistrarCotizacion_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudesCotizacion)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosCotizados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSolicitudesCotizacion;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCotizacionNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFechaEmision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPiker1;
        private System.Windows.Forms.TextBox txtSolicitudNumero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvProductosCotizados;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtProdModel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProdMarca;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProdNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProdPrecioUnidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProdCant;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectProd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemProd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbCondiciones;
    }
}