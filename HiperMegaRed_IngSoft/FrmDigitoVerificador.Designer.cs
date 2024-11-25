namespace HiperMegaRed_IngSoft
{
    partial class FrmDigitoVerificador
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
            this.btnRecalcular = new System.Windows.Forms.Button();
            this.btnRestaurarBD = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRecalcular
            // 
            this.btnRecalcular.Location = new System.Drawing.Point(12, 12);
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.Size = new System.Drawing.Size(119, 41);
            this.btnRecalcular.TabIndex = 0;
            this.btnRecalcular.Tag = "btn.recalcular";
            this.btnRecalcular.Text = "Recalcular Digitos";
            this.btnRecalcular.UseVisualStyleBackColor = true;
            this.btnRecalcular.Click += new System.EventHandler(this.btnRecalcular_Click);
            // 
            // btnRestaurarBD
            // 
            this.btnRestaurarBD.Location = new System.Drawing.Point(149, 12);
            this.btnRestaurarBD.Name = "btnRestaurarBD";
            this.btnRestaurarBD.Size = new System.Drawing.Size(119, 41);
            this.btnRestaurarBD.TabIndex = 1;
            this.btnRestaurarBD.Tag = "btn.bdrestore";
            this.btnRestaurarBD.Text = "Restaurar Base de Datos";
            this.btnRestaurarBD.UseVisualStyleBackColor = true;
            this.btnRestaurarBD.Click += new System.EventHandler(this.btnRestaurarBD_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(193, 59);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Tag = "btn.exit";
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // FrmDigitoVerificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 93);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRestaurarBD);
            this.Controls.Add(this.btnRecalcular);
            this.Name = "FrmDigitoVerificador";
            this.Text = "Digito Verificador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDigitoVerificador_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRecalcular;
        private System.Windows.Forms.Button btnRestaurarBD;
        private System.Windows.Forms.Button btnExit;
    }
}