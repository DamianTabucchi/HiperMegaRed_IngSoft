using HiperMegaRed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class OrdenDeReposicion : AbstractGuidEntity
    {
        public OrdenDeReposicion()
        {
            //this.Id = Guid.NewGuid();
            //orden_fecha_creacion = DateTime.Now;
            //orden_fecha_aprobacion = DateTime.Now;
            //orden_estado = TipoEstado.Pendiente.ToString();
            //orden_solicitante = SessionManager.GetInstance.User.Id;
            //orden_aprobador = Guid.Empty;
            orden_productos_solicitados = new List<ProductoSolicitado>();
        }

        public int orden_numero {  get; set; }

        public DateTime orden_fecha_creacion { get; set; }
        public DateTime orden_fecha_aprobacion { get; set; }

        public string orden_justificacion { get; set; }
        public string orden_estado { get; set;}

        public Guid orden_solicitante { get; set; }

        public Guid orden_aprobador { get; set; }
        public string orden_tipo { get; set; }

        public List<ProductoSolicitado> orden_productos_solicitados;

        public void AddProdSol (ProductoSolicitado prodSol)
        {
            orden_productos_solicitados.Add (prodSol);
        }

        public void RemoveProdSol (Guid psid)
        {
            orden_productos_solicitados.Remove(orden_productos_solicitados.Find(x => x.Id == psid));
        }

    }
}
