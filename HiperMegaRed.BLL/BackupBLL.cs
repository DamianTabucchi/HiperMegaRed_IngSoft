using HiperMegaRed.BE;
using HiperMegaRed.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BLL
{
    public class BackupBLL
    {
        private static BackupBLL instance = new BackupBLL();
        private static BackupDAL backDAL = new BackupDAL();
        private BackupBLL() { }
        public static BackupBLL Instance => instance;

        public void GenerarBackup(string ruta)
        {
            backDAL.GenerarBackup(ruta);
        }

        public void RestaurarBackup(string ruta)
        {
            backDAL.RestaurarBackup(ruta);
        }
    }
}
