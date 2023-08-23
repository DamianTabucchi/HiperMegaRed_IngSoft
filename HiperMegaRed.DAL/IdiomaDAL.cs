using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;

namespace HiperMegaRed.DAL
{
    public class IdiomaDAL : AbstractDAL
    {
        private static IdiomaDAL instance = new IdiomaDAL();
        private IdiomaDAL() { }
        public static IdiomaDAL GetInstance() => instance;

        public IList<Idioma> GetAll()
        {
            try
            {
                using (var con = this.GetSqlConnection())
                {
                    con.Open();
                    IList<Idioma> list = new Database(con).ExecuteQuery<Idioma>("SELECT * FROM idiomas");
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
