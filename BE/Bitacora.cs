using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public class Bitacora: AbstractGuidEntity

    {
        public Bitacora (string _accion, string _crit, DateTime _fecha, string _mod, string _username)
        {
            accion = _accion;
            criticidad = _crit;
            fechacreacion = _fecha;
            modulo = _mod;
            username = _username;
        }

        public Bitacora (string _accion, string _crit, DateTime _fecha, string _mod)
        {
            accion = _accion;
            criticidad = _crit;
            fechacreacion = _fecha;
            modulo = _mod;
            username = "";
        }

        public Bitacora() { }
        public string accion {  get; set; }
        public string criticidad { get; set; }
        public DateTime fechacreacion { get; set; }
        public string modulo { get; set; }
        public string username { get; set; }

    }
}
