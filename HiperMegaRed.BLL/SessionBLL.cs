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
    public class SessionBLL
    {
        private static readonly SessionBLL instance = new SessionBLL();

        private UserBLL userBLL = UserBLL.Instance;
        private DigitoVerificadorBLL dvBLL = DigitoVerificadorBLL.Instance;
        // GetInstance() => instance; es lo mismo que escribir public static SessionBLL GetInstance { get { return instance; } }
        public static SessionBLL GetInstance() => instance;

        private SessionBLL()
        {

        }

        private static readonly SessionManager SESSION = SessionManager.GetInstance;

        //private readonly UserDAL usuarioDAL = UserDAL.GetInstance();

        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ValidationException("Complete los datos!");
            }

            var user = userBLL.FindUser(username);
            
            if(user == null)
            {
                throw new ValidationException("El usuario no existe");
            }

            if(user.FailCount>2)
            {
                userBLL.BlockUser(user.Username);
                throw new ValidationException("Usuario bloqueado, contactese con un administrador");
            }

            var pass = Encriptador.Hash(password, user.Id);

            if (user.Password != pass)
            {
                user.FailCount++;
                userBLL.SaveUser(user);
                throw new ValidationException("Contraseña erronea");
            }

            user.LastLogin = DateTime.Now; 
            user.FailCount = 0;

            userBLL.SaveUser(user);
            //dvBLL.CalcularDVGenerico("usuarios", user.Id);
            ISet<object> grants = PermisosBLL.Instance.FindAllPermissions(user);
            SESSION.Login(user, grants);
            return user;
        }

        public void Logout()
        {
            SESSION.Logout();
        }
    }
}
