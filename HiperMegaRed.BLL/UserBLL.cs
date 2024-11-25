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
    public class UserBLL
    {
        private static UserBLL instance = new UserBLL();
        private static UserDAL userDAL = UserDAL.GetInstance();
        private static DigitoVerificadorBLL dvBLL = DigitoVerificadorBLL.Instance;
        private UserBLL() { }
        // Instance => instance; es lo mismo que escribir public static UserBLL Instance { get { return instance; } }
        public static UserBLL Instance => instance;
        public IList<User> GetAll()
        {
            return userDAL.GetAll();
        }

        public User FindById(Guid _id)
        {
            return userDAL.FindById(_id);
        }
        public User FindUser(string username)
        {
            User usuario = userDAL.FindByUsername(username);
            return usuario;
        }
        public void SaveUser(User user)
        {
            userDAL.SaveUser(user);
            dvBLL.CalcularDVGenerico("usuarios", user.Id);
        }
        public void Register(User usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Username)) throw new ValidationException("El Usuario debe de tener nombre de usuario");
            if (string.IsNullOrWhiteSpace(usuario.Password)) throw new ValidationException("El Usuario debe de tener Password");
            if (string.IsNullOrWhiteSpace(usuario.Mail)) throw new ValidationException("El Usuario debe de tener Email");
            if (string.IsNullOrWhiteSpace(usuario.Phone)) throw new ValidationException("El Usuario debe de tener telefono");

            var usuarioBD = FindUser(usuario.Username);

            if (usuarioBD != null) throw new ValidationException("El nombre de usuario ya existe");

            usuario.Id = Guid.NewGuid();

            EncryptPassword (usuario, usuario.Password);
            usuario.Expired = true;
            usuario.Language = "es-AR";
            SaveUser(usuario);
        }
        public void Modify(User usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Name)) throw new ValidationException("El Usuario debe de tener Nombre");
            if (string.IsNullOrWhiteSpace(usuario.Lastname)) throw new ValidationException("El Usuario debe de tener Apellido");
            if (string.IsNullOrWhiteSpace(usuario.Mail)) throw new ValidationException("El Usuario debe de tener Email");
            if (string.IsNullOrWhiteSpace(usuario.Phone)) throw new ValidationException("El Usuario debe de tener Telefono");
            if (string.IsNullOrWhiteSpace(usuario.Language)) throw new ValidationException("El Usuario debe de tener un Lenguaje");
            SaveUser(usuario);
        }
        private User EncryptPassword(User usuario, string password)
        {
            var passwordHash = Encriptador.Hash(password, usuario.Id);
            usuario.Password = passwordHash;
            usuario.FailCount = 0;
            return usuario;
        }
        public void ResetPassword(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ValidationException("Se requiere Contraseña");
            var user = FindUser(username);
            EncryptPassword(user, password);
            user.Expired = true;
            SaveUser(user);
        }
        public void ResetUserPassword(string username, string actualpass, string newpass)
        {
            if (string.IsNullOrWhiteSpace(actualpass)) throw new ValidationException("Ingrese la contraseña antigua");
            if (string.IsNullOrWhiteSpace(newpass)) throw new ValidationException("Ingrese la nueva contraseña");

            var user = FindUser(username);

            var actualhash = Encriptador.Hash(actualpass, user.Id);
            var newhash = Encriptador.Hash(newpass, user.Id);

            if (newhash.Equals(user.Password))
            {
                throw new ValidationException("La nueva contraseña no pueda ser igual a la anterior");
            }
            if (!actualhash.Equals(user.Password))
            {
                throw new ValidationException("La contraseña ingresada es incorrecta");
            }

            //user.Password = Encriptador.Hash(actualpass, user.Id);
            EncryptPassword(user, newpass);
            SaveUser(user);
        }
        public void BlockUser(string username)
        {
            var user = FindUser(username);
            user.FailCount = 10;
            SaveUser(user);
        }

        public int SavePermisos(User u)
        {
            return userDAL.SavePermisos(u);
        }

        public int RemoveUser(User u)
        {
            return userDAL.RemoveUser(u);
        }

        //bool isInRole(Componente c, TipoPermiso permiso, bool existe)
        //{
        //    if (c.Permiso.Equals(permiso))
        //        existe = true;
        //    else
        //    {
        //        foreach (var item in c.Hijos)
        //        {
        //            existe = isInRole(item, permiso, existe);
        //            if (existe) return true;
        //        }
        //    }
        //    return existe;
        //}
        //public bool IsInRole(TipoPermiso permiso)
        //{
        //    bool existe = false;
        //    foreach (var item in _session.Usuario.Permisos)
        //    {
        //        if (item.Permiso.Equals(permiso))
        //            return true;
        //        else
        //        {
        //            existe = isInRole(item, permiso, existe);
        //            if (existe) return true;
        //        }

        //    }
        //    return existe;
        //}
    }
}
