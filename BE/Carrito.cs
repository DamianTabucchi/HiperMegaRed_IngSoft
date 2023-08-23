using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class Carrito : AbstractGuidEntity
    {
        //public Carrito()
        //{

        //}
        public Carrito()
        {
            this.Id = Guid.NewGuid();
            carrito_productos = new List<Producto>();
        }

        public List<Producto> carrito_productos;
        public DateTime carrito_fecha { get; set; }

        
        public double carrito_total { get { return CalcularPrecioTotal(); } }
        public decimal carrito_cliente_dni { get; set; }
        public double carrito_preciototal { get; set; }
        public bool carrito_pagado { get; set; } = false;


        private double CalcularPrecioTotal()
        {
            double res = 0;
            foreach (Producto p in carrito_productos)
            {
                res += p.producto_precio_unidad;
            }
            return res;
        }

        public void AddProduct(Producto p)
        {
            carrito_productos.Add(p);
        }

        public void RemProduct(Producto p)
        {
            carrito_productos.Remove(p);
        }

        public void RemProductCart(Guid p)
        {
            carrito_productos.Remove(carrito_productos.Find(x=>x.Id==p));
        }

    }
}
