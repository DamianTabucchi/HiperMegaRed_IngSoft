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
    public class SolicitudCotizacionBLL
    {
        private static SolicitudCotizacionBLL instance = new SolicitudCotizacionBLL();
        private static SolicitudCotizacionDAL solcotDAL = SolicitudCotizacionDAL.GetInstance();
        private SolicitudCotizacionBLL() { }
        public static SolicitudCotizacionBLL Instance => instance;

        public IList<SolicitudCotizacion> GetAll()
        {
            return solcotDAL.GetAll();
        }
        public IList<SolicitudCotizacion> GetPending()
        {
            return solcotDAL.GetPending();
        }
        public IList<SolicitudCotizacion> GetRegistered()
        {
            return solcotDAL.GetRegistered();
        }

        public IList<SolicitudCotizacion> GetCotizada()
        {
            return solcotDAL.GetCotizada();
        }
        public IList<SolicitudCotizacion> GetBySupplier(Guid proveedorId)
        {
            return solcotDAL.GetBySupplier(proveedorId);
        }
        public SolicitudCotizacion GetById(Guid solcotId)
        {
            return solcotDAL.GetById(solcotId);
        }

        public IList<SolicitudCotizacion> GetByOrder(Guid orderId)
        {
            return solcotDAL.GetByOrder(orderId);
        }

        public int GenerarNumeroSolicitud()
        {
            return solcotDAL.GenerarNumeroSolicitud();
        }

        public int SaveSolicitud(SolicitudCotizacion solcot)
        {
            solcotDAL.SaveSolicitud(solcot);
            return solcotDAL.SaveSolicitudProductos(solcot);
        }
        public IList<ProductoSolicitado> GetProdSolicitados(Guid _solcotId)
        {
            return solcotDAL.GetProdSolicitados(_solcotId);
        }

        public int UpdateState(Guid _solcotId, string state)
        {
            return solcotDAL.UpdateState(_solcotId, state);
        }

    }
}
