namespace HiperMegaRed_IngSoft.Compras
{
    partial class FrmSolicitarCotizacion
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.gpbOrden = new System.Windows.Forms.GroupBox();
            this.btnGenerarSolicitud = new System.Windows.Forms.Button();
            this.dgvProdSolicitados = new System.Windows.Forms.DataGridView();
            this.txtApprovalDate = new System.Windows.Forms.TextBox();
            this.txtApprover = new System.Windows.Forms.TextBox();
            this.txtJustify = new System.Windows.Forms.TextBox();
            this.txtApplicant = new System.Windows.Forms.TextBox();
            this.txtCreationDate = new System.Windows.Forms.TextBox();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEmitirSolicitud = new System.Windows.Forms.Button();
            this.dgvSolicitudProductos = new System.Windows.Forms.DataGridView();
            this.btnNewSupplier = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbProveedores = new System.Windows.Forms.ComboBox();
            this.txtSolOrdenNum = new System.Windows.Forms.TextBox();
            this.txtSolFecha = new System.Windows.Forms.TextBox();
            this.txtSolNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.gpbOrden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdSolicitados)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.dgvOrdenes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenes de Reposicion Aprobadas";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(444, 19);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 39);
            this.btnLoad.TabIndex = 14;
            this.btnLoad.Tag = "btn.cargar";
            this.btnLoad.Text = "Cargar";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.AllowUserToResizeColumns = false;
            this.dgvOrdenes.AllowUserToResizeRows = false;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(6, 19);
            this.dgvOrdenes.MultiSelect = false;
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.Size = new System.Drawing.Size(432, 147);
            this.dgvOrdenes.TabIndex = 0;
            // 
            // gpbOrden
            // 
            this.gpbOrden.Controls.Add(this.btnGenerarSolicitud);
            this.gpbOrden.Controls.Add(this.dgvProdSolicitados);
            this.gpbOrden.Controls.Add(this.txtApprovalDate);
            this.gpbOrden.Controls.Add(this.txtApprover);
            this.gpbOrden.Controls.Add(this.txtJustify);
            this.gpbOrden.Controls.Add(this.txtApplicant);
            this.gpbOrden.Controls.Add(this.txtCreationDate);
            this.gpbOrden.Controls.Add(this.txtOrderNumber);
            this.gpbOrden.Controls.Add(this.label6);
            this.gpbOrden.Controls.Add(this.label5);
            this.gpbOrden.Controls.Add(this.label4);
            this.gpbOrden.Controls.Add(this.label3);
            this.gpbOrden.Controls.Add(this.label2);
            this.gpbOrden.Controls.Add(this.label1);
            this.gpbOrden.Location = new System.Drawing.Point(12, 194);
            this.gpbOrden.Name = "gpbOrden";
            this.gpbOrden.Size = new System.Drawing.Size(530, 339);
            this.gpbOrden.TabIndex = 2;
            this.gpbOrden.TabStop = false;
            this.gpbOrden.Tag = "gpb.aprobar.orden.pendiente";
            this.gpbOrden.Text = "Orden de Reposicion";
            // 
            // btnGenerarSolicitud
            // 
            this.btnGenerarSolicitud.Enabled = false;
            this.btnGenerarSolicitud.Location = new System.Drawing.Point(435, 293);
            this.btnGenerarSolicitud.Name = "btnGenerarSolicitud";
            this.btnGenerarSolicitud.Size = new System.Drawing.Size(80, 39);
            this.btnGenerarSolicitud.TabIndex = 2;
            this.btnGenerarSolicitud.Tag = "btn.generate.solicitud";
            this.btnGenerarSolicitud.Text = "Cargar Solicitud";
            this.btnGenerarSolicitud.UseVisualStyleBackColor = true;
            this.btnGenerarSolicitud.Click += new System.EventHandler(this.btnGenerarSolicitud_Click);
            // 
            // dgvProdSolicitados
            // 
            this.dgvProdSolicitados.AllowUserToAddRows = false;
            this.dgvProdSolicitados.AllowUserToDeleteRows = false;
            this.dgvProdSolicitados.AllowUserToResizeColumns = false;
            this.dgvProdSolicitados.AllowUserToResizeRows = false;
            this.dgvProdSolicitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdSolicitados.Location = new System.Drawing.Point(9, 100);
            this.dgvProdSolicitados.MultiSelect = false;
            this.dgvProdSolicitados.Name = "dgvProdSolicitados";
            this.dgvProdSolicitados.ReadOnly = true;
            this.dgvProdSolicitados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProdSolicitados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdSolicitados.Size = new System.Drawing.Size(506, 187);
            this.dgvProdSolicitados.TabIndex = 12;
            // 
            // txtApprovalDate
            // 
            this.txtApprovalDate.Enabled = false;
            this.txtApprovalDate.Location = new System.Drawing.Point(380, 48);
            this.txtApprovalDate.Name = "txtApprovalDate";
            this.txtApprovalDate.Size = new System.Drawing.Size(135, 20);
            this.txtApprovalDate.TabIndex = 11;
            // 
            // txtApprover
            // 
            this.txtApprover.Enabled = false;
            this.txtApprover.Location = new System.Drawing.Point(380, 22);
            this.txtApprover.Name = "txtApprover";
            this.txtApprover.Size = new System.Drawing.Size(135, 20);
            this.txtApprover.TabIndex = 10;
            // 
            // txtJustify
            // 
            this.txtJustify.Enabled = false;
            this.txtJustify.Location = new System.Drawing.Point(85, 293);
            this.txtJustify.MaxLength = 250;
            this.txtJustify.Multiline = true;
            this.txtJustify.Name = "txtJustify";
            this.txtJustify.Size = new System.Drawing.Size(258, 39);
            this.txtJustify.TabIndex = 9;
            // 
            // txtApplicant
            // 
            this.txtApplicant.Enabled = false;
            this.txtApplicant.Location = new System.Drawing.Point(106, 74);
            this.txtApplicant.Name = "txtApplicant";
            this.txtApplicant.Size = new System.Drawing.Size(156, 20);
            this.txtApplicant.TabIndex = 8;
            // 
            // txtCreationDate
            // 
            this.txtCreationDate.Enabled = false;
            this.txtCreationDate.Location = new System.Drawing.Point(106, 48);
            this.txtCreationDate.Name = "txtCreationDate";
            this.txtCreationDate.Size = new System.Drawing.Size(156, 20);
            this.txtCreationDate.TabIndex = 7;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Enabled = false;
            this.txtOrderNumber.Location = new System.Drawing.Point(106, 22);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(96, 20);
            this.txtOrderNumber.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 5;
            this.label6.Tag = "lbl.creation.date";
            this.label6.Text = "Fecha Aprobacion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 4;
            this.label5.Tag = "lbl.approver";
            this.label5.Text = "Aprobador:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Tag = "lbl.justify";
            this.label4.Text = "Justificacion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 2;
            this.label3.Tag = "lbl.creation.date";
            this.label3.Text = "Fecha Creacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Tag = "lbl.applicant";
            this.label2.Text = "Solicitante:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "lbl.numero.orden";
            this.label1.Text = "Numero de Orden:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnEmitirSolicitud);
            this.groupBox2.Controls.Add(this.dgvSolicitudProductos);
            this.groupBox2.Controls.Add(this.btnNewSupplier);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbProveedores);
            this.groupBox2.Controls.Add(this.txtSolOrdenNum);
            this.groupBox2.Controls.Add(this.txtSolFecha);
            this.groupBox2.Controls.Add(this.txtSolNum);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(548, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 521);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Solicitud de Reposicion";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(313, 476);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 39);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Tag = "btn.cancel";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEmitirSolicitud
            // 
            this.btnEmitirSolicitud.Enabled = false;
            this.btnEmitirSolicitud.Location = new System.Drawing.Point(399, 476);
            this.btnEmitirSolicitud.Name = "btnEmitirSolicitud";
            this.btnEmitirSolicitud.Size = new System.Drawing.Size(80, 39);
            this.btnEmitirSolicitud.TabIndex = 13;
            this.btnEmitirSolicitud.Tag = "btn.emitir.solicitud";
            this.btnEmitirSolicitud.Text = "Emitir Solicitud";
            this.btnEmitirSolicitud.UseVisualStyleBackColor = true;
            this.btnEmitirSolicitud.Click += new System.EventHandler(this.btnEmitirSolicitud_Click);
            // 
            // dgvSolicitudProductos
            // 
            this.dgvSolicitudProductos.AllowUserToAddRows = false;
            this.dgvSolicitudProductos.AllowUserToDeleteRows = false;
            this.dgvSolicitudProductos.AllowUserToResizeColumns = false;
            this.dgvSolicitudProductos.AllowUserToResizeRows = false;
            this.dgvSolicitudProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudProductos.Location = new System.Drawing.Point(6, 157);
            this.dgvSolicitudProductos.MultiSelect = false;
            this.dgvSolicitudProductos.Name = "dgvSolicitudProductos";
            this.dgvSolicitudProductos.ReadOnly = true;
            this.dgvSolicitudProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitudProductos.Size = new System.Drawing.Size(473, 312);
            this.dgvSolicitudProductos.TabIndex = 9;
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.Enabled = false;
            this.btnNewSupplier.Location = new System.Drawing.Point(358, 124);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.Size = new System.Drawing.Size(121, 23);
            this.btnNewSupplier.TabIndex = 8;
            this.btnNewSupplier.Tag = "btn.new";
            this.btnNewSupplier.Text = "Nuevo Proveedor";
            this.btnNewSupplier.UseVisualStyleBackColor = true;
            this.btnNewSupplier.Click += new System.EventHandler(this.btnNewSupplier_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 7;
            this.label10.Tag = "lbl.Prov";
            this.label10.Text = "Proveedor:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 6;
            this.label9.Tag = "lbl.numero.orden";
            this.label9.Text = "Numero de Orden:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 5;
            this.label8.Tag = "lbl.sol.fecha";
            this.label8.Text = "Fecha:";
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.Enabled = false;
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Location = new System.Drawing.Point(289, 97);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(190, 21);
            this.cmbProveedores.TabIndex = 4;
            // 
            // txtSolOrdenNum
            // 
            this.txtSolOrdenNum.Enabled = false;
            this.txtSolOrdenNum.Location = new System.Drawing.Point(289, 71);
            this.txtSolOrdenNum.Name = "txtSolOrdenNum";
            this.txtSolOrdenNum.Size = new System.Drawing.Size(190, 20);
            this.txtSolOrdenNum.TabIndex = 3;
            // 
            // txtSolFecha
            // 
            this.txtSolFecha.Enabled = false;
            this.txtSolFecha.Location = new System.Drawing.Point(289, 45);
            this.txtSolFecha.Name = "txtSolFecha";
            this.txtSolFecha.Size = new System.Drawing.Size(190, 20);
            this.txtSolFecha.TabIndex = 2;
            // 
            // txtSolNum
            // 
            this.txtSolNum.Enabled = false;
            this.txtSolNum.Location = new System.Drawing.Point(289, 19);
            this.txtSolNum.Name = "txtSolNum";
            this.txtSolNum.Size = new System.Drawing.Size(190, 20);
            this.txtSolNum.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 0;
            this.label7.Tag = "lbl.sol.number";
            this.label7.Text = "Numero de Solicitud:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(947, 539);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 39);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Tag = "btn.quit";
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmSolicitarCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 586);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpbOrden);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSolicitarCotizacion";
            this.Tag = "frm.sol.cot";
            this.Text = "Solicitar Cotizacion";
            this.Load += new System.EventHandler(this.FrmSolicitarCotizacion_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.gpbOrden.ResumeLayout(false);
            this.gpbOrden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdSolicitados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.GroupBox gpbOrden;
        private System.Windows.Forms.Button btnGenerarSolicitud;
        private System.Windows.Forms.DataGridView dgvProdSolicitados;
        private System.Windows.Forms.TextBox txtApprovalDate;
        private System.Windows.Forms.TextBox txtApprover;
        private System.Windows.Forms.TextBox txtJustify;
        private System.Windows.Forms.TextBox txtCreationDate;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtApplicant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSolFecha;
        private System.Windows.Forms.TextBox txtSolNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSolOrdenNum;
        private System.Windows.Forms.ComboBox cmbProveedores;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.DataGridView dgvSolicitudProductos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEmitirSolicitud;
        private System.Windows.Forms.Button btnSalir;
    }
}