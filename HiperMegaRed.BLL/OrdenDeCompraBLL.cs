using HiperMegaRed.DAL;
using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BLL
{
    public class OrdenDeCompraBLL
    {
        private static OrdenDeCompraBLL instance = new OrdenDeCompraBLL();
        private static OrdenDeCompraDAL ocDAL = OrdenDeCompraDAL.GetInstance();
        private OrdenDeCompraBLL() { }
        public static OrdenDeCompraBLL Instance => instance;

        public IList<OrdenDeCompra> GetAll()
        {
            return ocDAL.GetAll();
        }

        public int GenerarNumeroOrden()
        {
            return ocDAL.GenerarNumeroOrden();
        }

        public int SaveOrdenDeCompra(OrdenDeCompra o)
        {
            return ocDAL.SaveOrdenCompra(o);
        }


    }
}
