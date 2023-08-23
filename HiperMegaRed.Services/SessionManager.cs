using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.Services
{
    public class SessionManager
    {
        //private static object _lock = new Object();
        private static SessionManager _session = new SessionManager();

        private IUser _user;
        private ISet<object> _permisos;
        private DateTime FechaInicio { get; set; }

        private SessionManager() { }

        public static SessionManager GetInstance { get { return _session; } }

        public IUser User
        {
            get
            {
                return _user;
            }
        }


        public void Login (IUser usuario, ISet<object> permisos)
        {
            _user = usuario;
            _permisos = permisos;
            if (_session == null)
            {
                _session = new SessionManager();
            }

        }

        public void Logout()
        {
            if (_session != null)
            {
                _user = null;
                _session = null;
            }
            else throw new Exception("Sesion no iniciada");
        }

        public bool IsLogged()
        {
            return _user != null;
        }
        public bool IsNotLogged()
        {
            return !IsLogged();
        }

        public bool TienePermiso(IComparable checkPermiso)
        {
            if (IsLogged())
            {
                foreach (var perm in _permisos)
                {
                    if (perm.Equals(checkPermiso))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
