using HiperMegaRed.BE;
using HiperMegaRed.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BLL
{
    public class BitacoraCambioBLL
    {
        private static BitacoraCambioBLL instance = new BitacoraCambioBLL();
        private static BitacoraCambioDAL bitaDAL = new BitacoraCambioDAL();
        private BitacoraCambioBLL() { }
        public static BitacoraCambioBLL Instance => instance;

        public IList<BitacoraCambio> GetAll()
        {
            return bitaDAL.GetAll();
        }

        public void SaveBitacoraCambio(Producto p)
        {
            bitaDAL.SaveBitacoraCambio(p);
        }

        //public void ActivarCambio(BitacoraCambio bitaCambio)
        //{
        //    bitaDAL.ActivarCambio(bitaCambio);
        //}



    }
}
