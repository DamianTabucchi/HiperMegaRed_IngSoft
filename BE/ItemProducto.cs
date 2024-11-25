using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class ItemProducto: Producto
    {
        public int cantidad { get; set; }

        public override string ToString()
        {
            return $"{base.producto_nombre}, {base.producto_marca}, {base.producto_modelo}, {base.producto_precio_unidad}, {cantidad}";
        }
    }
}
