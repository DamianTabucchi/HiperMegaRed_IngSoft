using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class Cotizacion : AbstractGuidEntity
    {
        public Cotizacion()
        {
            cotizacion_productos_cotizados = new List<ProductoCotizado>();
        }
        public int cotizacion_numero {  get; set; }
        public DateTime cotizacion_fecha_emision {  get; set; }
        public DateTime cotizacion_fecha_entrega { get; set; }

        public Guid cotizacion_proveedor_id { get; set; }
        public Guid cotizacion_solcot_id { get; set; }
        public double cotizacion_monto_total { get; set; }
        public string cotizacion_condiciones { get; set; }
        public string cotizacion_estado {  get; set; }

        public List<ProductoCotizado> cotizacion_productos_cotizados;

        public Proveedor cotizacion_proveedor { get; set; }
        public SolicitudCotizacion cotizacion_solicitud_cotizacion { get; set; }

        public void AddProduct (ProductoCotizado p)
        {
            cotizacion_productos_cotizados.Add(p);
        }

        public void RemProduct(Guid p)
        {
            cotizacion_productos_cotizados.Remove(cotizacion_productos_cotizados.Find(x => x.Id == p));
        }

        public string NombreProveedor => cotizacion_proveedor != null ? cotizacion_proveedor.proveedor_nombre : "N/A";
        public int CantidadProductos => cotizacion_productos_cotizados != null ? cotizacion_productos_cotizados.Count : 0;

    }
}
