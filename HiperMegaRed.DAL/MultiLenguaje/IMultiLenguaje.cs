using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.DAL.MultiLenguaje
{
    public interface IMultiLenguaje
    {
        Dictionary<string, string> LoadLang(string idioma);
        void UpsertTranslate(string idioma, string key, string value);
    }
}
