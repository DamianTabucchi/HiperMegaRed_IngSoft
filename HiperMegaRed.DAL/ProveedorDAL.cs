using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;

namespace HiperMegaRed.DAL
{
    public class ProveedorDAL : AbstractDAL
    {
        private static ProveedorDAL instance = new ProveedorDAL();
        private ProveedorDAL() { }
        public static ProveedorDAL GetInstance() => instance;

        public IList<Proveedor> GetAll()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                IList<Proveedor> lista = new Database(con).ExecuteQuery<Proveedor>("SELECT * FROM proveedores");
                return lista;
            }
        }

        public IList<Proveedor> GetActive()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                IList<Proveedor> lista = new Database(con).ExecuteQuery<Proveedor>("SELECT * FROM proveedores WHERE proveedor_activo = 1");
                return lista;
            }
        }
        public Proveedor FindById(Guid _id)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var proveedores = new Database(con).AddParameter("@provId", _id).ExecuteQuery<Proveedor>("SELECT * FROM proveedores WHERE Id = @provId;");
                return proveedores.Count > 0 ? proveedores[0] : null;
            }
        }

        public void SaveProveedor(Proveedor prov)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    .AddParameter("@provId", prov.Id)
                    .AddParameter("@provCuit", prov.proveedor_cuit)
                    .AddParameter("@provNombre", prov.proveedor_nombre)
                    .AddParameter("@provNombrePoc", prov.proveedor_nombre_poc)
                    .AddParameter("@provDireccion", prov.proveedor_direccion)
                    .AddParameter("@provTelefono", prov.proveedor_telefono)
                    .AddParameter("@provEmail", prov.proveedor_email)
                    .AddParameter("@provCategoria", prov.proveedor_categoria)
                    .AddParameter("@provNotasAdicionales", prov.proveedor_notas_adicionales)
                    .AddParameter("@provActivo", prov.proveedor_activo)
                    .ExecuteNonQuery("proveedor_upsert", true);
            }
        }

        public int RemoveProveedor(Guid _id)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var affected = new Database(con)
                    .AddParameter("@provId", _id)
                    .ExecuteNonQuery("UPDATE proveedores SET proveedor_activo = 0 WHERE Id = provId;");
                return affected;
            }
        }



    }
}
