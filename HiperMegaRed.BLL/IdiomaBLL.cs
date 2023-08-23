using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;
using HiperMegaRed.DAL;
using HiperMegaRed.Services;

namespace HiperMegaRed.BLL
{
    public class IdiomaBLL
    {
        private static IdiomaBLL instance = new IdiomaBLL();
        private static IdiomaDAL idiomaDAL = IdiomaDAL.GetInstance();
        private IdiomaBLL() { }
        public static IdiomaBLL Instance => instance;

        public IList<Idioma> GetIdiomas()
        {
            return idiomaDAL.GetAll();
        }
    }
}
