using HiperMegaRed.BE;
using HiperMegaRed.DAL;
using HiperMegaRed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.BLL
{
    public class ClienteBLL
    {
        private static ClienteBLL instance = new ClienteBLL();
        private static ClienteDAL clienteDAL = ClienteDAL.GetInstance();
        private CryptoManager cryptoManager = new CryptoManager();
        private ClienteBLL() { }
        // Instance => instance; es lo mismo que escribir public static UserBLL Instance { get { return instance; } }
        public static ClienteBLL Instance => instance;

        public IList<Cliente> GetAll()
        {
            return clienteDAL.GetAll();
        }

        public Cliente FindByDNI(decimal doc)
        {
 
            return clienteDAL.FindByDNI(doc);
        }


        //Validaciones aca
        public void SaveClient(Cliente c)
        {

            clienteDAL.SaveClient(c);
        }

        
    }
}
