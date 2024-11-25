using HiperMegaRed.BE;
using HiperMegaRed.BLL;
using HiperMegaRed.DAL;
using HiperMegaRed.DAL.MultiLenguaje;
using HiperMegaRed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperMegaRed_IngSoft
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MultiLang.Initialize(MultiLangBLL.Instance, "es-AR");

            Application.Run(new FrmPrincipal());

            
        }
    }
}
