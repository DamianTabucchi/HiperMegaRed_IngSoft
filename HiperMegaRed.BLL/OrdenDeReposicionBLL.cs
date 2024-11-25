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
    public class OrdenDeReposicionBLL
    {
        private static OrdenDeReposicionBLL instance = new OrdenDeReposicionBLL();
        private static OrdenDeReposicionDAL ordenRepoDAL = OrdenDeReposicionDAL.GetInstance();
        private OrdenDeReposicionBLL() { }
        public static OrdenDeReposicionBLL Instance => instance;

        public IList<OrdenDeReposicion> GetAll()
        {
            return ordenRepoDAL.GetAll();
        }

        public IList<OrdenDeReposicion> GetPending()
        {
            return ordenRepoDAL.GetPending();
        }

        public IList<OrdenDeReposicion> GetByState(TipoEstado state)
        {
            return ordenRepoDAL.GetByState(state);
        }
        
        public OrdenDeReposicion GetById (Guid _id)
        {
            return ordenRepoDAL.GetById(_id);
        }

        public IList<OrdenDeReposicion> GetByApplicant(Guid _id)
        {
            return ordenRepoDAL.GetByApplicant(_id);
        }

        public int GenerarNumeroOrden()
        {
            return ordenRepoDAL.GenerarNumeroOrden();
        }

        public int SaveOrdenRepo(OrdenDeReposicion ordenRepo)
        {
            ordenRepoDAL.SaveOrdenRepo(ordenRepo);
            return ordenRepoDAL.SaveOrdenProductos(ordenRepo);
        }

        public int ActualizarEstadoOrden(OrdenDeReposicion ordenRepo)
        {
            return ordenRepoDAL.EstadoOrden(ordenRepo);
        }

        public IList<ProductoSolicitado> GetProdSolicitados(Guid _ordenId)
        {
            return ordenRepoDAL.GetProdSolicitados(_ordenId);
        }
    }
}
