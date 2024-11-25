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
    public class ProveedoresBLL
    {
        private static ProveedoresBLL instance = new ProveedoresBLL();
        private static ProveedorDAL provDAL = ProveedorDAL.GetInstance();

        private ProveedoresBLL() { }

        public static ProveedoresBLL Instance => instance;
        public IList<Proveedor> GetAll()
        {
            return provDAL.GetAll();
        } 

        public IList<Proveedor> GetActive()
        {
            return provDAL.GetActive();
        }

        public Proveedor FindById(Guid id)
        {
            return provDAL.FindById(id);
        }

        public void SaveProveedor(Proveedor prov)
        {
            provDAL.SaveProveedor(prov);
        }

        public int RemoveProveedor(Guid _id)
        {
            return provDAL.RemoveProveedor(_id);
        }
    }
}
