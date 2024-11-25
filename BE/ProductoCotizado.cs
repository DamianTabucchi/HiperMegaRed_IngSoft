using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class ProductoCotizado : ProductoSolicitado
    {
        public ProductoCotizado() { }

        public double productocotizado_precio_unidad { get; set; }
        public double productocotizado_total { get; set; }

    }
}
