using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;
using HiperMegaRed.DAL;

namespace HiperMegaRed.DAL
{
    public interface Iobserver
    {
        void Update(Idioma idioma);
    }
}
