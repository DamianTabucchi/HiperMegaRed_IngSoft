using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class OrdenDePago : AbstractGuidEntity
    {
        public OrdenDePago() { }
        public OrdenDePago(Guid c, decimal doc, double tot)
        {
            this.Id = Guid.NewGuid();
            orden_carrito_id = c;
            orden_cliente_dni = doc;
            orden_fecha = DateTime.Now;
            orden_total = tot;
            orden_pago = false;
        }

        public Guid orden_carrito_id { get; set; }
        public decimal orden_cliente_dni { get; set; }
        public DateTime orden_fecha { get; set; }
        public double orden_total { get; set; }
        public bool orden_pago { get; set; } = false;
    }
}
