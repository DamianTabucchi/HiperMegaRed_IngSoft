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
    public class ProductoBLL
    {
        private static ProductoBLL instance = new ProductoBLL();
        private static ProductoDAL productoDAL = ProductoDAL.GetInstance();
        private static BitacoraCambioBLL bitaBLL = BitacoraCambioBLL.Instance;
        private ProductoBLL() { }
        public static ProductoBLL Instance => instance;

        public Producto FindProductById(Guid p)
        {
            return productoDAL.FindById(p);
        }

        public bool ProdNameExist(string name)
        {
            return productoDAL.ProdNameExists(name);
        }

        public IList<ItemProducto> FindByCart(Guid c)
        {
            return productoDAL.FindByCart(c);
        }
        public IList<Producto> FindByType(string t)
        {
            return productoDAL.FindByType(t);
        }
        public IList<Producto> GetAll()
        {
            return productoDAL.GetAll();
        }
        public IList<Producto> GetActive()
        {
            return productoDAL.GetActive();
        }
        public IList<Producto> GetAllWithStock()
        {
            return productoDAL.GetAllWithStock();
        }
        public int SaveProduct (Producto p)
        {
            if (p.Id == null || p.Id == Guid.Empty)
            {
                p.Id = Guid.NewGuid();
            }

            ActualizarBitaCambios(p);

            return productoDAL.SaveProducto(p);
        }

        public void UpdateStock(Producto p)
        {
            ActualizarBitaCambios(p);
            productoDAL.UpdateStock(p);
        }

        public int RemoveProd(Guid p)
        {
            return productoDAL.RemoveProd(p);

        }

        public void ActualizarBitaCambios(Producto p)
        {
            bitaBLL.SaveBitacoraCambio(p);
        }
    }
}
