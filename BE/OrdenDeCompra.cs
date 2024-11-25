using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class OrdenDeCompra : AbstractGuidEntity
    {
        public OrdenDeCompra()
        {
            ordendecompra_direccion = "Direccion de HiperMegaRed";
            ordendecompra_numerocontacto = "Damian (1167905762)";
        }


        public int ordendecompra_numero {  get; set; }
        public DateTime ordendecompra_fecha_emision {  get; set; }
        public Guid ordendecompra_cotizacion_id { get; set; }
        public Guid ordendecompra_proveedor_id { get; set; }
        public DateTime ordendecompra_fecha_entrega {  get; set; }
        public string ordendecompra_condiciones {  get; set; }
        public double ordendecompra_total { get; set; }

        public string ordendecompra_direccion {  get; set; }

        public string ordendecompra_numerocontacto { get; set; }

        public Cotizacion ordendecompra_cotizacion { get; set; }
        public Proveedor ordendecompra_proveedor { get; set; }

    }
}
