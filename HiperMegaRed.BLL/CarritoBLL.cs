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
    public class CarritoBLL
    {
        private static CarritoBLL instance = new CarritoBLL();
        private static CarritoDAL carritoDAL = CarritoDAL.GetInstance();
        private CarritoBLL() { }
        public static CarritoBLL Instance => instance;

        public IList<Carrito> GetAll()
        {
            return carritoDAL.GetAll();
        }

        public Carrito FindByID(Guid id)
        {
            return carritoDAL.FindById(id);
        }

        public IList<Carrito> FindByClient(decimal doc)
        {
            return carritoDAL.FindByClient(doc);
        }

        public IList<Carrito> GetUnpayed()
        {
            return carritoDAL.GetUnpayed();
        }
        //Hacer verificaciones antes de guardar el carrito!!
        public void SaveCart(Carrito cart)
        {
            carritoDAL.SaveCart(cart);
        }

        public int RemoveCart(Carrito cart)
        {
            return carritoDAL.RemoveCart(cart);
        }

        public int UpdateCart(Carrito cart)
        {
            return carritoDAL.UpdateCart(cart);
        }

        public int AddProdToCart(Carrito cart)
        {
            return carritoDAL.AddProdToCart(cart);
        }
    }
}
