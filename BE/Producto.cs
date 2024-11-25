using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class Producto : AbstractGuidEntity
    {
        public Producto() { }
        public string producto_nombre { get; set; }
        public string producto_marca { get; set; }
        public string producto_modelo { get; set; }
        public TipoDeProducto producto_tipo { get; set; }
        public string producto_deposito { get; set; }
        public int producto_stock { get; set; }
        public double producto_precio_unidad { get; set; }
        public string producto_descripcion { get; set; }
        public int producto_punto_pedido { get; set; }
        public bool producto_activo { get; set; }
        public Guid producto_proveedor { get; set; }

    }
}
