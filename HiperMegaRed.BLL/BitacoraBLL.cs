using HiperMegaRed.BE;
using HiperMegaRed.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BLL
{
    public class BitacoraBLL
    {
        private static BitacoraBLL instance = new BitacoraBLL();
        private static BitacoraDAL bitacoraDAL = new BitacoraDAL();
        private BitacoraBLL() { }
        public static BitacoraBLL Instance => instance;

        public IList<Bitacora> GetAll()
        {
            return bitacoraDAL.GetAll();
        }

        //public IList<Bitacora> FindByUser(User usuario)
        //{
        //    return bitacoraDAL.FindByUser(usuario.Id);
        //}

        public IList<Bitacora> FindByCriticality(string criticality)
        {
            return bitacoraDAL.FindByCriticality(criticality);
        }

        public IList<Bitacora> GetByDates(DateTime desde, DateTime hasta)
        {
            return bitacoraDAL.GetByDates(desde, hasta);
        }

        public int SaveBitacora(Bitacora bitacora)
        {
            bitacora.Id = Guid.NewGuid();
            return bitacoraDAL.SaveBitacora(bitacora);
        }

    }
}
