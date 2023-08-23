using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BE
{
    public abstract class AbstractEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
