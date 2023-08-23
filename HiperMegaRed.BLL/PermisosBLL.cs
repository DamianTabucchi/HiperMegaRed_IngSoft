using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;
using HiperMegaRed.DAL;
using HiperMegaRed.Services;

namespace HiperMegaRed.BLL
{
    public class PermisosBLL
    {
        private static PermisosBLL instance = new PermisosBLL();
        private static PermisosDAL permisosDAL = PermisosDAL.GetInstance();
        private PermisosBLL() { }

        public static PermisosBLL Instance => instance;

        public bool Existe(Componente c, int id)
        {
            bool existe = false;
            if (c.Id.Equals(id)) existe = true;
            else
                foreach (var item in c.Hijos)
                {

                    existe = Existe(item, id);
                    if (existe) return true;
                }
            return existe;
        }
        public Array GetAllPermission()
        {
            return Enum.GetValues(typeof(TipoPermiso));
        }

        public Componente GuardarComponente(Componente p, bool esfamilia)
        {
            return permisosDAL.SaveComponent(p, esfamilia);
        }

        public Componente GetByGrantName(string n)
        {
            return permisosDAL.GetByGrantName(n);
        }
        public void GuardarFamilia(Familia f)
        {
            permisosDAL.SaveFamily(f);
        }

        public IList<Patente> GetAllPatentes()
        {
            return permisosDAL.GetAllPatentes();
        }

        public IList<Familia> GetAllFamilias()
        {
            return permisosDAL.GetAllFamilias();
        }

        public IList<Componente> GetAll(string family)
        {
            return permisosDAL.GetAll(family);
        }

        public void FillUserComponents(User u)
        {
            permisosDAL.FillUserComponents(u);
        }
        public List<Componente> GetAllUserComponents(User user) => permisosDAL.GetAllUserComponents(user);
        public ISet<object> FindAllPermissions(User u)
        {
            List<Componente> componentes = GetAllUserComponents(u);
            ISet<object> permissions = new HashSet<object>();
            foreach (var component in componentes)
            {
                FillAllPermissions(component, permissions);
            }
            return permissions;
        }

        private void FillAllPermissions(Componente component, ISet<object> permissions)
        {

            if (component.Permiso != null)
            {
                permissions.Add((TipoPermiso)component.Permiso);
            }
            else
            {
                foreach (var c in component.Hijos)
                {
                    FillAllPermissions(c, permissions);
                }
            }
        }


        public void FillFamilyComponents(Familia family)
        {
            permisosDAL.FillFamilyComponents(family);
        }

        public bool DeleteRelatedComponent(Componente parent, Componente child)
        {
            if (Existe(parent, child.Id))
            {
                permisosDAL.DeleteRelatedComponent(parent.Id, child.Id);
                return true;
            }
            return false;
        }
        public bool AddToComponent(Componente parent, Componente child)
        {
            if (!Existe(parent, child.Id))
            {
                permisosDAL.AddRelatedComponent(parent.Id, child.Id);
                return true;
            }

            return false;
        }
    }
}
