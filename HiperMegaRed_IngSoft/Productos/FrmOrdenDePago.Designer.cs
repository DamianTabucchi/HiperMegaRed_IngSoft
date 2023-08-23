
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
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.cbOrdenes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carritos Pendientes de Pago";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(269, 62);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(114, 20);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha Emision";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(389, 59);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(207, 26);
            this.txtFecha.TabIndex = 2;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(242, 18);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 40);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cbOrdenes
            // 
            this.cbOrdenes.FormattingEnabled = true;
            this.cbOrdenes.Location = new System.Drawing.Point(12, 25);
            this.cbOrdenes.Name = "cbOrdenes";
            this.cbOrdenes.Size = new System.Drawing.Size(224, 28);
            this.cbOrdenes.TabIndex = 0;
            this.cbOrdenes.SelectedIndexChanged += new System.EventHandler(this.cbOrdenes_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 561);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvProductos);
            this.groupBox4.Location = new System.Drawing.Point(6, 167);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(590, 356);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Productos";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(6, 25);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 62;
            this.dgvProductos.RowTemplate.Height = 28;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(578, 325);
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
            this.groupBox3.Location = new System.Drawing.Point(6, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(590, 136);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cliente";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(250, 86);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(161, 26);
            this.txtApellido.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(250, 54);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(161, 26);
            this.txtNombre.TabIndex = 4;
            // 
            // txtDNI
            // 
            this.txtDNI.Enabled = false;
            this.txtDNI.Location = new System.Drawing.Point(250, 22);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(161, 26);
            this.txtDNI.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(89, 621);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 40);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Enabled = false;
            this.btnPagar.Location = new System.Drawing.Point(215, 601);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(120, 60);
            this.btnPagar.TabIndex = 7;
            this.btnPagar.Text = "Confirmar Pago";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(174, 32);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(161, 26);
            this.txtTotal.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 2;
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
            this.groupBox5.Location = new System.Drawing.Point(620, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(341, 667);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Metodo de Pago";
            // 
            // txtTransfer
            // 
            this.txtTransfer.Enabled = false;
            this.txtTransfer.Location = new System.Drawing.Point(125, 515);
            this.txtTransfer.MaxLength = 16;
            this.txtTransfer.Name = "txtTransfer";
            this.txtTransfer.Size = new System.Drawing.Size(210, 26);
            this.txtTransfer.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 518);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "Operación:";
            // 
            // rdbTransfer
            // 
            this.rdbTransfer.AutoSize = true;
            this.rdbTransfer.Location = new System.Drawing.Point(16, 482);
            this.rdbTransfer.Name = "rdbTransfer";
            this.rdbTransfer.Size = new System.Drawing.Size(131, 24);
            this.rdbTransfer.TabIndex = 23;
            this.rdbTransfer.TabStop = true;
            this.rdbTransfer.Text = "Transferencia";
            this.rdbTransfer.UseVisualStyleBackColor = true;
            // 
            // txtCVVCred
            // 
            this.txtCVVCred.Enabled = false;
            this.txtCVVCred.Location = new System.Drawing.Point(125, 418);
            this.txtCVVCred.MaxLength = 3;
            this.txtCVVCred.Name = "txtCVVCred";
            this.txtCVVCred.Size = new System.Drawing.Size(58, 26);
            this.txtCVVCred.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 421);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "CVV:";
            // 
            // dtpCred
            // 
            this.dtpCred.CustomFormat = "MM/yy";
            this.dtpCred.Enabled = false;
            this.dtpCred.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCred.Location = new System.Drawing.Point(125, 385);
            this.dtpCred.Name = "dtpCred";
            this.dtpCred.Size = new System.Drawing.Size(100, 26);
            this.dtpCred.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 390);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Vencimiento:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 356);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "N° Tarjeta:";
            // 
            // txtNCred
            // 
            this.txtNCred.Enabled = false;
            this.txtNCred.Location = new System.Drawing.Point(125, 353);
            this.txtNCred.MaxLength = 16;
            this.txtNCred.Name = "txtNCred";
            this.txtNCred.Size = new System.Drawing.Size(210, 26);
            this.txtNCred.TabIndex = 17;
            // 
            // rdbCred
            // 
            this.rdbCred.AutoSize = true;
            this.rdbCred.Location = new System.Drawing.Point(16, 320);
            this.rdbCred.Name = "rdbCred";
            this.rdbCred.Size = new System.Drawing.Size(85, 24);
            this.rdbCred.TabIndex = 16;
            this.rdbCred.TabStop = true;
            this.rdbCred.Text = "Credito";
            this.rdbCred.UseVisualStyleBackColor = true;
            // 
            // txtCVVDeb
            // 
            this.txtCVVDeb.Enabled = false;
            this.txtCVVDeb.Location = new System.Drawing.Point(125, 270);
            this.txtCVVDeb.MaxLength = 3;
            this.txtCVVDeb.Name = "txtCVVDeb";
            this.txtCVVDeb.Size = new System.Drawing.Size(58, 26);
            this.txtCVVDeb.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "CVV:";
            // 
            // dtpDeb
            // 
            this.dtpDeb.CustomFormat = "MM/yy";
            this.dtpDeb.Enabled = false;
            this.dtpDeb.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeb.Location = new System.Drawing.Point(125, 237);
            this.dtpDeb.Name = "dtpDeb";
            this.dtpDeb.Size = new System.Drawing.Size(100, 26);
            this.dtpDeb.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Vencimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "N° Tarjeta:";
            // 
            // txtNDeb
            // 
            this.txtNDeb.Enabled = false;
            this.txtNDeb.Location = new System.Drawing.Point(125, 205);
            this.txtNDeb.MaxLength = 16;
            this.txtNDeb.Name = "txtNDeb";
            this.txtNDeb.Size = new System.Drawing.Size(210, 26);
            this.txtNDeb.TabIndex = 10;
            // 
            // rdbDeb
            // 
            this.rdbDeb.AutoSize = true;
            this.rdbDeb.Location = new System.Drawing.Point(16, 172);
            this.rdbDeb.Name = "rdbDeb";
            this.rdbDeb.Size = new System.Drawing.Size(81, 24);
            this.rdbDeb.TabIndex = 9;
            this.rdbDeb.TabStop = true;
            this.rdbDeb.Text = "Debito";
            this.rdbDeb.UseVisualStyleBackColor = true;
            // 
            // txtVuelto
            // 
            this.txtVuelto.Enabled = false;
            this.txtVuelto.Location = new System.Drawing.Point(174, 125);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.Size = new System.Drawing.Size(161, 26);
            this.txtVuelto.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Vuelto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(174, 87);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(161, 26);
            this.txtMonto.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Monto:";
            // 
            // rdbEfectivo
            // 
            this.rdbEfectivo.AutoSize = true;
            this.rdbEfectivo.Checked = true;
            this.rdbEfectivo.Location = new System.Drawing.Point(16, 63);
            this.rdbEfectivo.Name = "rdbEfectivo";
            this.rdbEfectivo.Size = new System.Drawing.Size(91, 24);
            this.rdbEfectivo.TabIndex = 0;
            this.rdbEfectivo.TabStop = true;
            this.rdbEfectivo.Text = "Efectivo";
            this.rdbEfectivo.UseVisualStyleBackColor = true;
            // 
            // FrmOrdenDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 691);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmOrdenDePago";
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
    }
}