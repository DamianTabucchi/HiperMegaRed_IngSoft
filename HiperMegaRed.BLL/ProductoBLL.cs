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
        private ProductoBLL() { }
        public static ProductoBLL Instance => instance;

        public Producto FindProductById(Guid p)
        {
            return productoDAL.FindById(p);
        }

        public IList<Producto> FindByCart(Guid c)
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

        public void SaveProduct (Producto p)
        {
            productoDAL.SaveProducto(p);
        }

        public void UpdateStock(Producto p)
        {
            productoDAL.UpdateStock(p);
        }
    }
}
