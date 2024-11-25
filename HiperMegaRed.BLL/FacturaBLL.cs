using HiperMegaRed.BE;
using HiperMegaRed.DAL;
using HiperMegaRed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BLL
{
    public class FacturaBLL
    {
        private static FacturaBLL instance = new FacturaBLL();
        private static FacturaDAL facturaDAL = FacturaDAL.GetInstance();

        private FacturaBLL() { }
        // Instance => instance; es lo mismo que escribir public static UserBLL Instance { get { return instance; } }
        public static FacturaBLL Instance => instance;

        public IList<Factura> GetAll()
        {
            return facturaDAL.GetAll();
        }

        public Factura FindByID(Guid id)
        {
            return facturaDAL.FindById(id);
        }

        public IList<Factura> FindByClient(decimal dni)
        {
            return facturaDAL.FindByClient(dni);
        }

        public IList<Factura> GetNotDelivered()
        {
            return facturaDAL.GetNotDelivered();
        }
        //Validaciones aca
        public void SaveFact(Factura f)
        {

            facturaDAL.SaveFact(f);
        }

        public int UpdateFactura(Factura f)
        {
            return facturaDAL.UpdateFact(f);
        }
    }
}
