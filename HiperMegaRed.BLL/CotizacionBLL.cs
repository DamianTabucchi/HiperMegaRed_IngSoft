using HiperMegaRed.DAL;
using HiperMegaRed.BE;
using HiperMegaRed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BLL
{
    public class CotizacionBLL
    {
        private static CotizacionBLL instance = new CotizacionBLL();
        private static CotizacionDAL cotDAL = CotizacionDAL.GetInstance();
        private CotizacionBLL() { }
        public static CotizacionBLL Instance => instance;

        public IList<Cotizacion> GetAll()
        {
            return cotDAL.GetAll();
        }

        public IList<Cotizacion> GetPending() {  return cotDAL.GetPending(); }

        public IList<Cotizacion> GetBySupplier(Guid proveedorId)
        {
            return cotDAL.GetBySupplier(proveedorId);
        }

        public Cotizacion GetById(Guid cotId)
        {
            return cotDAL.GetById(cotId);
        }

        public int GenerarNumeroCotizacion()
        {
            return cotDAL.GenerarNumeroCotizacion();
        }

        public int SaveCotizacion(Cotizacion cot)
        {
            cotDAL.SaveCotizacion(cot);
            return cotDAL.SaveCotizacionProductos(cot);
        }

        public IList<ProductoCotizado> GetProdSolicitados(Guid cotId)
        {
            return cotDAL.GetProdSolicitados(cotId);
        }

        public void UpdateState(Guid cotId, string state)
        {
            cotDAL.UpdateState(cotId, state);
        }

    }
}
