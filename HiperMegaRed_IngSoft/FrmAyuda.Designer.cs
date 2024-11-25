namespace HiperMegaRed_IngSoft
{
    partial class FrmAyuda
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
            this.pdfViewer = new PdfiumViewer.PdfViewer();
            this.SuspendLayout();
            // 
            // pdfViewer
            // 
            this.pdfViewer.AutoSize = true;
            this.pdfViewer.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdfViewer.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Size = new System.Drawing.Size(1198, 685);
            this.pdfViewer.TabIndex = 0;
            this.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            // 
            // FrmAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1198, 685);
            this.Controls.Add(this.pdfViewer);
            this.Name = "FrmAyuda";
            this.Text = "Ayuda";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmAyuda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PdfiumViewer.PdfViewer pdfViewer;
    }
}