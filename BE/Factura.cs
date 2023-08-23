using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class Factura : AbstractGuidEntity
    {
        public Factura()
        {

        }
        public Factura(Carrito c)
        {
            Id = Guid.NewGuid();
            factura_carrito_id = c.Id;
            factura_cliente_dni = c.carrito_cliente_dni;
            factura_fecha = DateTime.Now;
            factura_monto = c.carrito_preciototal;
        }

        public Guid factura_carrito_id { get; set; }
        public DateTime factura_fecha { get; set; }
        public decimal factura_cliente_dni { get; set; }
        public double factura_monto { get; set; }

        public bool factura_productos_entregados { get; set; } = false;
    }
}
