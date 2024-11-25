namespace HiperMegaRed_IngSoft.Productos
{
    partial class FrmAprobarOrdenReposicion
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
            this.gpbOrdenes = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.gpbOrden = new System.Windows.Forms.GroupBox();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.gpbOrdenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.gpbOrden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdSolicitados)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbOrdenes
            // 
            this.gpbOrdenes.Controls.Add(this.btnLoad);
            this.gpbOrdenes.Controls.Add(this.dgvOrdenes);
            this.gpbOrdenes.Location = new System.Drawing.Point(16, 15);
            this.gpbOrdenes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbOrdenes.Name = "gpbOrdenes";
            this.gpbOrdenes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbOrdenes.Size = new System.Drawing.Size(707, 284);
            this.gpbOrdenes.TabIndex = 0;
            this.gpbOrdenes.TabStop = false;
            this.gpbOrdenes.Tag = "gpb.aprobar.ordenes.pendientes";
            this.gpbOrdenes.Text = "Pedidos Pendientes";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(589, 23);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(107, 48);
            this.btnLoad.TabIndex = 1;
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
            this.dgvOrdenes.Location = new System.Drawing.Point(8, 23);
            this.dgvOrdenes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvOrdenes.MultiSelect = false;
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.Size = new System.Drawing.Size(573, 251);
            this.dgvOrdenes.TabIndex = 0;
            // 
            // gpbOrden
            // 
            this.gpbOrden.Controls.Add(this.btnReject);
            this.gpbOrden.Controls.Add(this.btnApprove);
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
            this.gpbOrden.Location = new System.Drawing.Point(16, 306);
            this.gpbOrden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbOrden.Name = "gpbOrden";
            this.gpbOrden.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbOrden.Size = new System.Drawing.Size(707, 417);
            this.gpbOrden.TabIndex = 1;
            this.gpbOrden.TabStop = false;
            this.gpbOrden.Tag = "gpb.aprobar.orden.pendiente";
            this.gpbOrden.Text = "Orden de Reposicion";
            // 
            // btnReject
            // 
            this.btnReject.Enabled = false;
            this.btnReject.Location = new System.Drawing.Point(465, 361);
            this.btnReject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(107, 48);
            this.btnReject.TabIndex = 13;
            this.btnReject.Tag = "btn.Reject";
            this.btnReject.Text = "Rechazar";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Enabled = false;
            this.btnApprove.Location = new System.Drawing.Point(580, 361);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(107, 48);
            this.btnApprove.TabIndex = 2;
            this.btnApprove.Tag = "btn.Approve";
            this.btnApprove.Text = "Aprobar";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // dgvProdSolicitados
            // 
            this.dgvProdSolicitados.AllowUserToAddRows = false;
            this.dgvProdSolicitados.AllowUserToDeleteRows = false;
            this.dgvProdSolicitados.AllowUserToResizeColumns = false;
            this.dgvProdSolicitados.AllowUserToResizeRows = false;
            this.dgvProdSolicitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdSolicitados.Location = new System.Drawing.Point(12, 123);
            this.dgvProdSolicitados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProdSolicitados.MultiSelect = false;
            this.dgvProdSolicitados.Name = "dgvProdSolicitados";
            this.dgvProdSolicitados.ReadOnly = true;
            this.dgvProdSolicitados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProdSolicitados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdSolicitados.Size = new System.Drawing.Size(675, 230);
            this.dgvProdSolicitados.TabIndex = 12;
            // 
            // txtApprovalDate
            // 
            this.txtApprovalDate.Enabled = false;
            this.txtApprovalDate.Location = new System.Drawing.Point(507, 59);
            this.txtApprovalDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApprovalDate.Name = "txtApprovalDate";
            this.txtApprovalDate.Size = new System.Drawing.Size(179, 22);
            this.txtApprovalDate.TabIndex = 11;
            // 
            // txtApprover
            // 
            this.txtApprover.Enabled = false;
            this.txtApprover.Location = new System.Drawing.Point(507, 27);
            this.txtApprover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApprover.Name = "txtApprover";
            this.txtApprover.Size = new System.Drawing.Size(179, 22);
            this.txtApprover.TabIndex = 10;
            // 
            // txtJustify
            // 
            this.txtJustify.Location = new System.Drawing.Point(113, 361);
            this.txtJustify.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtJustify.MaxLength = 250;
            this.txtJustify.Multiline = true;
            this.txtJustify.Name = "txtJustify";
            this.txtJustify.Size = new System.Drawing.Size(343, 47);
            this.txtJustify.TabIndex = 9;
            // 
            // txtApplicant
            // 
            this.txtApplicant.Enabled = false;
            this.txtApplicant.Location = new System.Drawing.Point(141, 91);
            this.txtApplicant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApplicant.Name = "txtApplicant";
            this.txtApplicant.Size = new System.Drawing.Size(207, 22);
            this.txtApplicant.TabIndex = 8;
            // 
            // txtCreationDate
            // 
            this.txtCreationDate.Enabled = false;
            this.txtCreationDate.Location = new System.Drawing.Point(141, 59);
            this.txtCreationDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCreationDate.Name = "txtCreationDate";
            this.txtCreationDate.Size = new System.Drawing.Size(207, 22);
            this.txtCreationDate.TabIndex = 7;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Enabled = false;
            this.txtOrderNumber.Location = new System.Drawing.Point(141, 27);
            this.txtOrderNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(127, 22);
            this.txtOrderNumber.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 5;
            this.label6.Tag = "lbl.approve.date";
            this.label6.Text = "Fecha Aprobacion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 4;
            this.label5.Tag = "lbl.approver";
            this.label5.Text = "Aprobador:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 393);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 3;
            this.label4.Tag = "lbl.justify";
            this.label4.Text = "Justificacion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 2;
            this.label3.Tag = "lbl.creation.date";
            this.label3.Text = "Fecha Creacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Tag = "lbl.applicant";
            this.label2.Text = "Solicitante:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 0;
            this.label1.Tag = "lbl.numero.orden";
            this.label1.Text = "Numero de Orden:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(731, 667);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 48);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Tag = "btn.quit";
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmAprobarOrdenReposicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 738);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.gpbOrden);
            this.Controls.Add(this.gpbOrdenes);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAprobarOrdenReposicion";
            this.Tag = "frm.aprobar.orden.repo";
            this.Text = "Validar Pedidos";
            this.Load += new System.EventHandler(this.FrmAprobarOrdenReposicion_Load);
            this.gpbOrdenes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.gpbOrden.ResumeLayout(false);
            this.gpbOrden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdSolicitados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbOrdenes;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.GroupBox gpbOrden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.DataGridView dgvProdSolicitados;
        private System.Windows.Forms.TextBox txtApprovalDate;
        private System.Windows.Forms.TextBox txtApprover;
        private System.Windows.Forms.TextBox txtJustify;
        private System.Windows.Forms.TextBox txtApplicant;
        private System.Windows.Forms.TextBox txtCreationDate;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalir;
    }
}