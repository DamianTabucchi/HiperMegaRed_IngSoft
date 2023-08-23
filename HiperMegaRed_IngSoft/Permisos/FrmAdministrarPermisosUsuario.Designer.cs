
namespace HiperMegaRed_IngSoft.Permisos
{
    partial class FrmAdministrarPermisosUsuario
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnConfig = new System.Windows.Forms.Button();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbFamilies = new System.Windows.Forms.ComboBox();
            this.btnRemF = new System.Windows.Forms.Button();
            this.btnAddF = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbPatente = new System.Windows.Forms.ComboBox();
            this.btnRemP = new System.Windows.Forms.Button();
            this.btnAddP = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Controls.Add(this.btnConfig);
            this.groupBox1.Controls.Add(this.cmbUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurar Usuario";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 97);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(323, 346);
            this.treeView1.TabIndex = 2;
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(209, 59);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(120, 28);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "Configurar";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(6, 25);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(323, 28);
            this.cmbUsuarios.TabIndex = 0;
            this.cmbUsuarios.Text = "Usuarios";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbFamilies);
            this.groupBox2.Controls.Add(this.btnRemF);
            this.groupBox2.Controls.Add(this.btnAddF);
            this.groupBox2.Location = new System.Drawing.Point(353, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 99);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Familia";
            // 
            // cmbFamilies
            // 
            this.cmbFamilies.FormattingEnabled = true;
            this.cmbFamilies.Location = new System.Drawing.Point(6, 25);
            this.cmbFamilies.Name = "cmbFamilies";
            this.cmbFamilies.Size = new System.Drawing.Size(316, 28);
            this.cmbFamilies.TabIndex = 3;
            // 
            // btnRemF
            // 
            this.btnRemF.Location = new System.Drawing.Point(132, 59);
            this.btnRemF.Name = "btnRemF";
            this.btnRemF.Size = new System.Drawing.Size(120, 30);
            this.btnRemF.TabIndex = 5;
            this.btnRemF.Text = "Quitar";
            this.btnRemF.UseVisualStyleBackColor = true;
            this.btnRemF.Click += new System.EventHandler(this.btnRemF_Click);
            // 
            // btnAddF
            // 
            this.btnAddF.Location = new System.Drawing.Point(6, 59);
            this.btnAddF.Name = "btnAddF";
            this.btnAddF.Size = new System.Drawing.Size(120, 30);
            this.btnAddF.TabIndex = 4;
            this.btnAddF.Text = "Agregar";
            this.btnAddF.UseVisualStyleBackColor = true;
            this.btnAddF.Click += new System.EventHandler(this.btnAddF_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbPatente);
            this.groupBox3.Controls.Add(this.btnRemP);
            this.groupBox3.Controls.Add(this.btnAddP);
            this.groupBox3.Location = new System.Drawing.Point(353, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 99);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Patente";
            // 
            // cmbPatente
            // 
            this.cmbPatente.FormattingEnabled = true;
            this.cmbPatente.Location = new System.Drawing.Point(6, 25);
            this.cmbPatente.Name = "cmbPatente";
            this.cmbPatente.Size = new System.Drawing.Size(316, 28);
            this.cmbPatente.TabIndex = 6;
            // 
            // btnRemP
            // 
            this.btnRemP.Location = new System.Drawing.Point(132, 59);
            this.btnRemP.Name = "btnRemP";
            this.btnRemP.Size = new System.Drawing.Size(120, 30);
            this.btnRemP.TabIndex = 8;
            this.btnRemP.Text = "Quitar";
            this.btnRemP.UseVisualStyleBackColor = true;
            this.btnRemP.Click += new System.EventHandler(this.btnRemP_Click);
            // 
            // btnAddP
            // 
            this.btnAddP.Location = new System.Drawing.Point(6, 59);
            this.btnAddP.Name = "btnAddP";
            this.btnAddP.Size = new System.Drawing.Size(120, 30);
            this.btnAddP.TabIndex = 7;
            this.btnAddP.Text = "Agregar";
            this.btnAddP.UseVisualStyleBackColor = true;
            this.btnAddP.Click += new System.EventHandler(this.btnAddP_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(561, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(353, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmAdministrarPermisosUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 466);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAdministrarPermisosUsuario";
            this.Text = "Administrar Permisos del Usuario";
            this.Load += new System.EventHandler(this.FrmAdministrarPermisosUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbFamilies;
        private System.Windows.Forms.Button btnRemF;
        private System.Windows.Forms.Button btnAddF;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbPatente;
        private System.Windows.Forms.Button btnRemP;
        private System.Windows.Forms.Button btnAddP;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}