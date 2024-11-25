
namespace HiperMegaRed_IngSoft.Productos
{
    partial class FrmOrdenDePago
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
            this.btnRemCart = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cbOrdenes = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtTransfer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rdbTransfer = new System.Windows.Forms.RadioButton();
            this.txtCVVCred = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpCred = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNCred = new System.Windows.Forms.TextBox();
            this.rdbCred = new System.Windows.Forms.RadioButton();
            this.txtCVVDeb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDeb = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNDeb = new System.Windows.Forms.TextBox();
            this.rdbDeb = new System.Windows.Forms.RadioButton();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbEfectivo = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemCart);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.cbOrdenes);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(535, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "gbx.cart.pendientes";
            this.groupBox1.Text = "Carritos Pendientes de Pago";
            // 
            // btnRemCart
            // 
            this.btnRemCart.Enabled = false;
            this.btnRemCart.Location = new System.Drawing.Point(408, 15);
            this.btnRemCart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemCart.Name = "btnRemCart";
            this.btnRemCart.Size = new System.Drawing.Size(121, 32);
            this.btnRemCart.TabIndex = 4;
            this.btnRemCart.Tag = "btn.eliminar.cart";
            this.btnRemCart.Text = "Eliminar Carrito";
            this.btnRemCart.UseVisualStyleBackColor = true;
            this.btnRemCart.Visible = false;
            this.btnRemCart.Click += new System.EventHandler(this.btnRemCart_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(239, 49);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(97, 16);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Tag = "lbl.fecha.emision";
            this.lblFecha.Text = "Fecha Emision";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(345, 47);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(184, 22);
            this.txtFecha.TabIndex = 2;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(215, 15);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(107, 32);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Tag = "btn.select";
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cbOrdenes
            // 
            this.cbOrdenes.FormattingEnabled = true;
            this.cbOrdenes.Location = new System.Drawing.Point(11, 20);
            this.cbOrdenes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbOrdenes.Name = "cbOrdenes";
            this.cbOrdenes.Size = new System.Drawing.Size(200, 24);
            this.cbOrdenes.TabIndex = 0;
            this.cbOrdenes.SelectedIndexChanged += new System.EventHandler(this.cbOrdenes_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(11, 95);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(535, 449);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "gbx.datos";
            this.groupBox2.Text = "Datos:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvProductos);
            this.groupBox4.Location = new System.Drawing.Point(5, 134);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(524, 284);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "gbx.prod";
            this.groupBox4.Text = "Productos";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(5, 20);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 62;
            this.dgvProductos.RowTemplate.Height = 28;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(513, 260);
            this.dgvProductos.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtApellido);
            this.groupBox3.Controls.Add(this.txtNombre);
            this.groupBox3.Controls.Add(this.txtDNI);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(5, 20);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(524, 108);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "gbx.client";
            this.groupBox3.Text = "Cliente";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(223, 69);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(144, 22);
            this.txtApellido.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(223, 43);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(144, 22);
            this.txtNombre.TabIndex = 4;
            // 
            // txtDNI
            // 
            this.txtDNI.Enabled = false;
            this.txtDNI.Location = new System.Drawing.Point(223, 17);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(144, 22);
            this.txtDNI.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 2;
            this.label3.Tag = "lbl.client.lastname";
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 1;
            this.label2.Tag = "lbl.client.name";
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(79, 497);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 32);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Tag = "btn.exit";
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Enabled = false;
            this.btnPagar.Location = new System.Drawing.Point(191, 481);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(107, 48);
            this.btnPagar.TabIndex = 7;
            this.btnPagar.Tag = "btn.confirmar.pago";
            this.btnPagar.Text = "Confirmar Pago";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(155, 26);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(144, 22);
            this.txtTotal.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 2;
            this.label4.Tag = "lbl.total.pagar";
            this.label4.Text = "Total a pagar:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSalir);
            this.groupBox5.Controls.Add(this.txtTransfer);
            this.groupBox5.Controls.Add(this.btnPagar);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.rdbTransfer);
            this.groupBox5.Controls.Add(this.txtCVVCred);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.dtpCred);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtNCred);
            this.groupBox5.Controls.Add(this.rdbCred);
            this.groupBox5.Controls.Add(this.txtCVVDeb);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.dtpDeb);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtNDeb);
            this.groupBox5.Controls.Add(this.rdbDeb);
            this.groupBox5.Controls.Add(this.txtVuelto);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtMonto);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtTotal);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.rdbEfectivo);
            this.groupBox5.Location = new System.Drawing.Point(551, 10);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(303, 534);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "gbx.metodo.pago";
            this.groupBox5.Text = "Metodo de Pago";
            // 
            // txtTransfer
            // 
            this.txtTransfer.Enabled = false;
            this.txtTransfer.Location = new System.Drawing.Point(111, 412);
            this.txtTransfer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTransfer.MaxLength = 16;
            this.txtTransfer.Name = "txtTransfer";
            this.txtTransfer.Size = new System.Drawing.Size(187, 22);
            this.txtTransfer.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 415);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 16);
            this.label13.TabIndex = 24;
            this.label13.Tag = "lbl.operacion";
            this.label13.Text = "Operación:";
            // 
            // rdbTransfer
            // 
            this.rdbTransfer.AutoSize = true;
            this.rdbTransfer.Location = new System.Drawing.Point(15, 385);
            this.rdbTransfer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbTransfer.Name = "rdbTransfer";
            this.rdbTransfer.Size = new System.Drawing.Size(116, 20);
            this.rdbTransfer.TabIndex = 23;
            this.rdbTransfer.TabStop = true;
            this.rdbTransfer.Tag = "rdb.transferencia";
            this.rdbTransfer.Text = "Transferencia";
            this.rdbTransfer.UseVisualStyleBackColor = true;
            this.rdbTransfer.CheckedChanged += new System.EventHandler(this.rdbTransfer_CheckedChanged);
            // 
            // txtCVVCred
            // 
            this.txtCVVCred.Enabled = false;
            this.txtCVVCred.Location = new System.Drawing.Point(111, 335);
            this.txtCVVCred.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCVVCred.MaxLength = 3;
            this.txtCVVCred.Name = "txtCVVCred";
            this.txtCVVCred.Size = new System.Drawing.Size(52, 22);
            this.txtCVVCred.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(55, 337);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "CVV:";
            // 
            // dtpCred
            // 
            this.dtpCred.CustomFormat = "MM/yy";
            this.dtpCred.Enabled = false;
            this.dtpCred.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCred.Location = new System.Drawing.Point(111, 308);
            this.dtpCred.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpCred.Name = "dtpCred";
            this.dtpCred.Size = new System.Drawing.Size(89, 22);
            this.dtpCred.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 16);
            this.label11.TabIndex = 19;
            this.label11.Tag = "lbl.vencimiento";
            this.label11.Text = "Vencimiento:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 284);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 16);
            this.label12.TabIndex = 18;
            this.label12.Tag = "lbl.num.tarjeta";
            this.label12.Text = "N° Tarjeta:";
            // 
            // txtNCred
            // 
            this.txtNCred.Enabled = false;
            this.txtNCred.Location = new System.Drawing.Point(111, 282);
            this.txtNCred.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNCred.MaxLength = 16;
            this.txtNCred.Name = "txtNCred";
            this.txtNCred.Size = new System.Drawing.Size(187, 22);
            this.txtNCred.TabIndex = 17;
            // 
            // rdbCred
            // 
            this.rdbCred.AutoSize = true;
            this.rdbCred.Location = new System.Drawing.Point(15, 256);
            this.rdbCred.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbCred.Name = "rdbCred";
            this.rdbCred.Size = new System.Drawing.Size(76, 20);
            this.rdbCred.TabIndex = 16;
            this.rdbCred.TabStop = true;
            this.rdbCred.Tag = "rdb.credito";
            this.rdbCred.Text = "Credito";
            this.rdbCred.UseVisualStyleBackColor = true;
            this.rdbCred.CheckedChanged += new System.EventHandler(this.rdbCred_CheckedChanged);
            // 
            // txtCVVDeb
            // 
            this.txtCVVDeb.Enabled = false;
            this.txtCVVDeb.Location = new System.Drawing.Point(111, 215);
            this.txtCVVDeb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCVVDeb.MaxLength = 3;
            this.txtCVVDeb.Name = "txtCVVDeb";
            this.txtCVVDeb.Size = new System.Drawing.Size(52, 22);
            this.txtCVVDeb.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "CVV:";
            // 
            // dtpDeb
            // 
            this.dtpDeb.CustomFormat = "MM/yy";
            this.dtpDeb.Enabled = false;
            this.dtpDeb.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeb.Location = new System.Drawing.Point(111, 190);
            this.dtpDeb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDeb.Name = "dtpDeb";
            this.dtpDeb.Size = new System.Drawing.Size(89, 22);
            this.dtpDeb.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 16);
            this.label8.TabIndex = 12;
            this.label8.Tag = "lbl.vencimiento";
            this.label8.Text = "Vencimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 11;
            this.label7.Tag = "lbl.num.tarjeta";
            this.label7.Text = "N° Tarjeta:";
            // 
            // txtNDeb
            // 
            this.txtNDeb.Enabled = false;
            this.txtNDeb.Location = new System.Drawing.Point(111, 164);
            this.txtNDeb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNDeb.MaxLength = 16;
            this.txtNDeb.Name = "txtNDeb";
            this.txtNDeb.Size = new System.Drawing.Size(187, 22);
            this.txtNDeb.TabIndex = 10;
            // 
            // rdbDeb
            // 
            this.rdbDeb.AutoSize = true;
            this.rdbDeb.Location = new System.Drawing.Point(15, 138);
            this.rdbDeb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbDeb.Name = "rdbDeb";
            this.rdbDeb.Size = new System.Drawing.Size(73, 20);
            this.rdbDeb.TabIndex = 9;
            this.rdbDeb.TabStop = true;
            this.rdbDeb.Tag = "rdb.debito";
            this.rdbDeb.Text = "Debito";
            this.rdbDeb.UseVisualStyleBackColor = true;
            this.rdbDeb.CheckedChanged += new System.EventHandler(this.rdbDeb_CheckedChanged);
            // 
            // txtVuelto
            // 
            this.txtVuelto.Enabled = false;
            this.txtVuelto.Location = new System.Drawing.Point(155, 100);
            this.txtVuelto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.Size = new System.Drawing.Size(144, 22);
            this.txtVuelto.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 7;
            this.label6.Tag = "lbl.vuelto";
            this.label6.Text = "Vuelto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(155, 70);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMonto.MaxLength = 100;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(144, 22);
            this.txtMonto.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 1;
            this.label5.Tag = "lbl.monto";
            this.label5.Text = "Monto:";
            // 
            // rdbEfectivo
            // 
            this.rdbEfectivo.AutoSize = true;
            this.rdbEfectivo.Checked = true;
            this.rdbEfectivo.Location = new System.Drawing.Point(15, 50);
            this.rdbEfectivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbEfectivo.Name = "rdbEfectivo";
            this.rdbEfectivo.Size = new System.Drawing.Size(81, 20);
            this.rdbEfectivo.TabIndex = 0;
            this.rdbEfectivo.TabStop = true;
            this.rdbEfectivo.Tag = "rdb.efectivo";
            this.rdbEfectivo.Text = "Efectivo";
            this.rdbEfectivo.UseVisualStyleBackColor = true;
            this.rdbEfectivo.CheckedChanged += new System.EventHandler(this.rdbEfectivo_CheckedChanged);
            // 
            // FrmOrdenDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 553);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmOrdenDePago";
            this.Tag = "Frm.Cobrar.Venta";
            this.Text = "Cobrar Venta";
            this.Load += new System.EventHandler(this.FrmOrdenDePago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbOrdenes;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtTransfer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rdbTransfer;
        private System.Windows.Forms.TextBox txtCVVCred;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpCred;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNCred;
        private System.Windows.Forms.RadioButton rdbCred;
        private System.Windows.Forms.TextBox txtCVVDeb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDeb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNDeb;
        private System.Windows.Forms.RadioButton rdbDeb;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbEfectivo;
        private System.Windows.Forms.Button btnRemCart;
    }
}