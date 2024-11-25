using HiperMegaRed.BE;
using HiperMegaRed.DAL;
using HiperMegaRed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperMegaRed.BLL
{
    public class DigitoVerificadorBLL
    {
        private static DigitoVerificadorBLL instance = new DigitoVerificadorBLL();
        private static DigitoVerificadorDAL dvDAL = new DigitoVerificadorDAL();
        private static UserBLL userBLL = UserBLL.Instance;

        private DigitoVerificadorBLL() { }
        public static DigitoVerificadorBLL Instance => instance;

        public void CalcularDigitoVerificadorUsers()
        {
            var usuarios = userBLL.GetAll();
            foreach (var u in usuarios)
            {
                string dataConcatenada = $"{u.Id}{u.Username}{u.Password}{u.LastLogin}{u.FailCount}{u.Language}{u.Expired}{u.Name}{u.Lastname}{u.Mail}{u.Phone}{u.DNI}";
                int dv = dvDAL.GetDigitoVerificador(dataConcatenada);
                dvDAL.UpdateDVHorizontal(u.Id, dv);
            }
        }
       
        public void CalcularDVUser(User u)
        {
            string dataConcatenada = $"{u.Id}{u.Username}{u.Password}{u.LastLogin}{u.FailCount}{u.Language}{u.Expired}{u.Name}{u.Lastname}{u.Mail}{u.Phone}{u.DNI}";
            int dv = dvDAL.GetDigitoVerificador(dataConcatenada);
            dvDAL.UpdateDVHorizontal(u.Id, dv);
        }

        public void CalcularDVGenerico (string table, Guid _id)
        {
            dvDAL.UpdateDVGeneric(table, _id);
        }

        //public bool VerificarDigito()
        //{
        //    return dvDAL.CheckDigits();
        //}

        public void CalcularDVGenerico(string table)
        {
            dvDAL.CalculateDVGeneric(table);
        }

        public bool VerificarDigitosGeneric(string table)
        {
            return dvDAL.CheckDigitsGeneric(table);
        }
    }
}
