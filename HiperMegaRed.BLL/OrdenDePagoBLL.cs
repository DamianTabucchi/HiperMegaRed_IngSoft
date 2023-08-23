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
    public class OrdenDePagoBLL
    {
        private static OrdenDePagoBLL instance = new OrdenDePagoBLL();
        private static OrdenDePagoDAL ordenDAL = OrdenDePagoDAL.GetInstance();
        private OrdenDePagoBLL() { }
        // Instance => instance; es lo mismo que escribir public static UserBLL Instance { get { return instance; } }
        public static OrdenDePagoBLL Instance => instance;

        public IList<OrdenDePago> GetAll()
        {
            return ordenDAL.GetAll();
        }

        public IList<OrdenDePago> GetUnpaid()
        {
            return ordenDAL.GetAllNotPaid();
        }

        public IList<OrdenDePago> FindByClient(long dni)
        {
            return ordenDAL.FindByClient(dni);
        }

        public OrdenDePago FindById(Guid i)
        {
            return ordenDAL.FindById(i);
        }

        //Validaciones aca
        public void CrearOrden(OrdenDePago o)
        {
            ordenDAL.CrearOrden(o);
        }

        public int UpdateOrden(OrdenDePago o)
        {
            return ordenDAL.UpdateOrden(o);
        }
    }
}
