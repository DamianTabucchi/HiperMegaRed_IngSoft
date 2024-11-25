using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperMegaRed.DAL
{
    public class OrdenDeCompraDAL : AbstractDAL
    {
        private static OrdenDeCompraDAL instance = new OrdenDeCompraDAL();
        private OrdenDeCompraDAL() { }
        public static OrdenDeCompraDAL GetInstance() => instance;

        public IList<OrdenDeCompra> GetAll()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var ordenes = new Database(con).ExecuteQuery<OrdenDeCompra>("SELECT * FROM ordenesdecompra;");
                return ordenes;
            }
        }

        public int GenerarNumeroOrden()
        {
            using (var con = this.GetSqlConnection())  
            {
                con.Open();
                int maxOrdenNumero = new Database(con)
                                     .ExecuteScalar<int>("SELECT ISNULL(MAX(ordendecompra_numero), 0) FROM ordenesdecompra");
                return maxOrdenNumero + 1;
            }
        }

        public int SaveOrdenCompra(OrdenDeCompra ordComp)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var affected = new Database(con)
                    .AddParameter("@ocId", ordComp.Id)
                    .AddParameter("@ocNum", ordComp.ordendecompra_numero)
                    .AddParameter("@ocFecEmi", ordComp.ordendecompra_fecha_emision)
                    .AddParameter("@ocCotId", ordComp.ordendecompra_cotizacion_id)
                    .AddParameter("@ocProvId", ordComp.ordendecompra_proveedor_id)
                    .AddParameter("@ocFecEnt", ordComp.ordendecompra_fecha_entrega)
                    .AddParameter("@ocTot", ordComp.ordendecompra_total)
                    .AddParameter("@ocCond", ordComp.ordendecompra_condiciones)
                    .AddParameter("@ocDir", ordComp.ordendecompra_direccion)
                    .AddParameter("@ocContact", ordComp.ordendecompra_numerocontacto)
                    .ExecuteNonQuery("INSERT INTO ordenesdecompra (Id, ordendecompra_numero, ordendecompra_fecha_emision, ordendecompra_cotizacion_id, ordendecompra_proveedor_id, ordendecompra_fecha_entrega, ordendecompra_total, ordendecompra_condiciones, ordendecompra_direccion, ordendecompra_numerocontacto)" +
                    "VALUES (@ocId, @ocNum, @ocFecEmi, @ocCotId, @ocProvId, @ocFecEnt, @ocTot, @ocCond, @ocDir, @ocContact);");
                return affected;
            }
        }

    }
}
