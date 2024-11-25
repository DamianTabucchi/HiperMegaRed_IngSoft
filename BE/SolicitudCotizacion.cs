using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class SolicitudCotizacion : AbstractGuidEntity
    {
        public SolicitudCotizacion() 
        {
            solcot_productos = new List<ProductoSolicitado>();
        }

        public DateTime solcot_fecha_solicitud { get; set; }
        public Guid solcot_ordenrepo_id { get; set; }
        public Guid solcot_proveedor { get; set; }
        public Guid solcot_solicitante {  get; set; }
        public int solcot_numero_solicitud { get; set; }

        public string solcot_estado {  get; set; }

        public List<ProductoSolicitado> solcot_productos;

        public void AddProdSol(ProductoSolicitado prodSol)
        {
            solcot_productos.Add(prodSol);
        }

        public void RemoveProdSol(Guid psid)
        {
            solcot_productos.Remove(solcot_productos.Find(x => x.Id == psid));
        }
    }
}
