using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;

namespace HiperMegaRed.DAL
{
    public class FacturaDAL : AbstractDAL
    {
        private static FacturaDAL instance = new FacturaDAL();
        private FacturaDAL() { }
        public static FacturaDAL GetInstance() => instance;

        public Factura FindById(Guid f)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var facts = db.AddParameter("@factid", f).ExecuteQuery<Factura>("SELECT * FROM facturas WHERE factura_id like @factid");
                return facts.Count > 0 ? facts[0] : null;
            }
        }

        public IList<Factura> FindByClient(decimal dni)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var facts = db.AddParameter("@clientdni", dni).ExecuteQuery<Factura>("SELECT * FROM facturas INNER JOIN clientes ON factura_cliente_dni = cliente_dni WHERE factura_cliente_dni like @clientdni");
                return facts;
            }
        }

        public IList<Factura> GetAll()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();

                IList<Factura> lista = new Database(connection).ExecuteQuery<Factura>("SELECT * FROM facturas");
                return lista;
            }
        }
        public IList<Factura> GetNotDelivered()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();

                IList<Factura> lista = new Database(connection).ExecuteQuery<Factura>("SELECT * FROM facturas WHERE factura_productos_entregados = 'False'");
                return lista;
            }
        }
        public void SaveFact(Factura f)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    .AddParameter("@factid", f.Id)
                    .AddParameter("@factfecha", f.factura_fecha)
                    .AddParameter("@factcart", f.factura_carrito_id)
                    .AddParameter("@factmonto", f.factura_monto)
                    .AddParameter("@factclientdni", f.factura_cliente_dni)
                    .AddParameter("@factentregado", f.factura_productos_entregados)
                    .ExecuteNonQuery("sp_factura_insert", true);
            }
        }

        public int UpdateFact(Factura f)
        {
            using (var con = this.GetSqlConnection())
            {
                var affected = 0;
                con.Open();
                affected = new Database(con)
                    .AddParameter("@factid", f.Id)
                    .AddParameter("@factentregado", f.factura_productos_entregados)
                    .ExecuteNonQuery("UPDATE facturas SET factura_productos_entregados = @factentregado WHERE id = @factid");
                return affected;
            }
        }
        
    }
}
