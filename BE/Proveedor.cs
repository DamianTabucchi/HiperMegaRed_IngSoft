using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class Proveedor : AbstractGuidEntity
    {

        public long proveedor_cuit { get; set; }
        public string proveedor_nombre { get; set; }
        public string proveedor_nombre_poc { get; set; }
        public string proveedor_direccion { get; set; }
        public string proveedor_telefono { get; set; }
        public string proveedor_email { get; set; }
        public TipoDeProducto proveedor_categoria { get; set; }
        public string proveedor_notas_adicionales { get; set; }
        public bool proveedor_activo { get; set; }
        public string NombreCompleto => $"{proveedor_nombre} - {proveedor_nombre_poc}";

    }
}
