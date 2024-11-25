using HiperMegaRed.DAL.MultiLenguaje;
using HiperMegaRed.BLL;
using HiperMegaRed.Services;
using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperMegaRed_IngSoft
{
    public partial class FrmDigitoVerificador : Form
    {
        private static DigitoVerificadorBLL dvBLL = DigitoVerificadorBLL.Instance;
        private static BackupBLL backBLL = BackupBLL.Instance;
        private bool isClosing = false;
        public FrmDigitoVerificador()
        {
            InitializeComponent();
        }

        private void FrmDigitoVerificador_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrando();
            
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            try
            {
                //dvBLL.CalcularDigitoVerificadorUsers();
                dvBLL.CalcularDVGenerico("usuarios");
                MessageBox.Show(MultiLang.TranslateOrDefault("DigitosRecalculados", "Se han recalculado los digitos verificadores. Verificando integridad..."), MultiLang.TranslateOrDefault("DVRec", "Digitos Recalculados"), MessageBoxButtons.OK);
                if (dvBLL.VerificarDigitosGeneric("usuarios")==false)
                {
                    MessageBox.Show(MultiLang.TranslateOrDefault("ErrorEnDigitos", "La base de datos continua corrupta, contactese con un administrador. El programa se cerrará"), MultiLang.TranslateOrDefault("Inconsistencia", "Inconsistencia en la base de datos"), MessageBoxButtons.OK);
                    isClosing = true;
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Todo Ok");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error!");
            }
            

        }

        private void Cerrando()
        {
            if (!isClosing)
            {
                if (dvBLL.VerificarDigitosGeneric("usuarios") == false)
                {
                    MessageBox.Show(MultiLang.TranslateOrDefault("ErrorEnDigitos", "La base de datos continua corrupta, contactese con un administrador. El programa se cerrará"), MultiLang.TranslateOrDefault("Inconsistencia", "Inconsistencia en la base de datos"), MessageBoxButtons.OK);
                    isClosing = true;
                    Application.Exit();
                }
                else
                {
                    this.Dispose();
                }
            }
        }

        private void btnRestaurarBD_Click(object sender, EventArgs e)
        {
            string path = "";
            using (var fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    path = fd.SelectedPath;
                    try
                    {
                        backBLL.GenerarBackup(path);
                        MessageBox.Show(MultiLang.TranslateOrDefault("Backup.Generado", "Back up generado con exito"), MultiLang.TranslateOrDefault("BackUp", "Backup"), MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }
    }
}
