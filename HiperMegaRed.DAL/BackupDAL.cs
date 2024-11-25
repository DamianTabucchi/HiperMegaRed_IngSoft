using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.DAL
{
    public class BackupDAL : AbstractDAL
    {
        private static BackupDAL instance = new BackupDAL();
        private static BackupDAL GetInstance() => instance;

        public void GenerarBackup(string ruta)
        {
            string nombrecopia = "Backup " + DateTime.Now.ToString("dd_MM_yyyy") + " Hora " + DateTime.Now.ToString("HH-mm") + ".bak";
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                new Database(connection).ExecuteNonQuery("BACKUP DATABASE [HMR] TO DISK = N'" + ruta + "\\" + nombrecopia + "'WITH FORMAT, INIT, SKIP, NOREWIND, NOUNLOAD, STATS = 10");
            }
        }

        public void RestaurarBackup(string ruta)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                db.ExecuteNonQuery("ALTER DATABASE [HMR] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                db.ExecuteNonQuery("USE MASTER RESTORE DATABASE [HMR] FROM DISK='" + ruta + "' WITH REPLACE");
                db.ExecuteNonQuery("ALTER DATABASE [HMR] SET MULTI_USER");
            }
        }
    }
}
