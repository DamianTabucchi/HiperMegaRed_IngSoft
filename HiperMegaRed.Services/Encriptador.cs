using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.Services
{
    public class Encriptador
    {
        private static readonly MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
        public static string Hash(string value, Guid seed)
        {
            var md5data = md5Provider.ComputeHash(Encoding.ASCII.GetBytes(value + seed));
            return (new ASCIIEncoding()).GetString(md5data);
        }
    }
}
