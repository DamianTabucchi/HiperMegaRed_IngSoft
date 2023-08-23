using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class Cliente
    {
        public Cliente() { }

        public decimal cliente_dni { get; set; }
        public string cliente_nombre { get; set; }
        public string cliente_apellido { get; set; }
        public string cliente_mail { get; set; }
        public string cliente_telefono { get; set; }

    }
}
