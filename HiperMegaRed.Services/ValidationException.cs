using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.Services
{
    public class ValidationException : GenericException
    {
        public ValidationException(string message) : base(message)
        {

        }
    }
}
