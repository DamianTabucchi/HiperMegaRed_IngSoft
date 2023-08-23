using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;

namespace HiperMegaRed.DAL
{
    public class OrdenDePagoDAL : AbstractDAL
    {
        private static OrdenDePagoDAL instance = new OrdenDePagoDAL();
        private OrdenDePagoDAL() { }
        public static OrdenDePagoDAL GetInstance() => instance;

        public IList<OrdenDePago> FindByClient(long dni)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var orders = db.AddParameter("@clientdni", dni).ExecuteQuery<OrdenDePago>("SELECT * FROM ordenes_de_pago INNER JOIN clientes ON orden_cliente_dni = cliente_dni WHERE orden_cliente_dni like @clientdni ;");
                return orders;
            }
        }
        public OrdenDePago FindById(Guid i)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var orders = db.AddParameter("@orderid", i).ExecuteQuery<OrdenDePago>("SELECT * FROM ordenes_de_pago WHERE id = @orderid");
                return orders.Count > 0 ? orders[0] : null;
            }
        }
        public IList<OrdenDePago> GetAll()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                IList<OrdenDePago> lista = new Database(connection).ExecuteQuery<OrdenDePago>("SELECT * FROM ordenes_de_pago");
                return lista;
            }
        }

        public IList<OrdenDePago> GetAllNotPaid()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                IList<OrdenDePago> lista = new Database(connection).ExecuteQuery<OrdenDePago>("SELECT * FROM ordenes_de_pago WHERE orden_pago = 'False'");
                return lista;
            }
        }
        public void CrearOrden(OrdenDePago o)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    .AddParameter("@orderid", o.Id)
                    .AddParameter("@orderfecha", o.orden_fecha)
                    .AddParameter("@orderclientdni", o.orden_cliente_dni)
                    .AddParameter("@ordercartid", o.orden_carrito_id)
                    .AddParameter("@orderamount", o.orden_total)
                    .AddParameter("@orderpago", o.orden_pago)
                    .ExecuteNonQuery("sp_Orden_Insert", true);
            }
        }

        public int UpdateOrden(OrdenDePago o)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var rowaffected = new Database(con)
                    .AddParameter("@orderid", o.Id)
                    .AddParameter("@orderpago", o.orden_pago)
                    .ExecuteNonQuery("UPDATE ordenes_de_pago SET orden_pago = @orderpago WHERE id = @orderid");
                return rowaffected;
            }
        }
    }
}
