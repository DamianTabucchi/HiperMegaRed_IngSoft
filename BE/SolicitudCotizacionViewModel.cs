using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class SolicitudCotizacionViewModel : AbstractGuidEntity
    {
        public int NumeroSolicitud {  get; set; }
        public DateTime FechaEmision { get; set; }
        public int NumeroOrdenReposicion { get; set; }
        public string NombreProveedor { get; set; }
        public int CantidadProductosSolicitados { get; set; }

    }
}
