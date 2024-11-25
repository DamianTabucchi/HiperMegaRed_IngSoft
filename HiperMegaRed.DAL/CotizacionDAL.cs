using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperMegaRed.DAL
{
    public class CotizacionDAL : AbstractDAL
    {
        private static CotizacionDAL instance = new CotizacionDAL();
        private CotizacionDAL() { }
        public static CotizacionDAL GetInstance() => instance;

        public IList<Cotizacion> GetAll()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var _cotizacion = new Database(con).ExecuteQuery<Cotizacion>("SELECT * FROM cotizaciones;");
                return _cotizacion;
            }
        }

        public IList<Cotizacion> GetPending()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var _cotizacion = new Database(con)
                    .AddParameter("@cotState", "Pendiente")
                    .ExecuteQuery<Cotizacion>("SELECT * FROM cotizaciones WHERE cotizacion_estado = @cotState;");
                return _cotizacion;
            }
        }
        public IList<Cotizacion> GetBySupplier(Guid proveedorId)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var CotizacionesPorProveedor = new Database(con)
                    .AddParameter("@pId", proveedorId)
                    .ExecuteQuery<Cotizacion>("SELECT * FROM cotizaciones WHERE cotizacion_proveedor_id = @pId;");
                return CotizacionesPorProveedor;
            }
        }

        public Cotizacion GetById(Guid cotId)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var cotiz = new Database(con)
                    .AddParameter("@cId", cotId)
                    .ExecuteQuery<Cotizacion>("SELECT * FROM cotizaciones WHERE Id = @cId;");
                return cotiz.Count > 0 ? cotiz[0] : null;
            }
        }

        public int GenerarNumeroCotizacion()
        {
            using (var con = this.GetSqlConnection())  // Obtén la conexión
            {
                con.Open();
                int maxOrdenNumero = new Database(con)
                                     .ExecuteScalar<int>("SELECT ISNULL(MAX(cotizacion_numero), 0) FROM cotizaciones");
                return maxOrdenNumero + 1;  // Retorna el objeto modificado
            }
        }

        public void SaveCotizacion(Cotizacion cot)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    .AddParameter("@cotId", cot.Id)
                    .AddParameter("@cotNum", cot.cotizacion_numero)
                    .AddParameter("@cotDate", cot.cotizacion_fecha_emision)
                    .AddParameter("@cotDDate", cot.cotizacion_fecha_entrega)
                    .AddParameter("@cotProvId", cot.cotizacion_proveedor_id)
                    .AddParameter("@cotSolCotId", cot.cotizacion_solcot_id)
                    .AddParameter("@cotMonto", cot.cotizacion_monto_total)
                    .AddParameter("@cotCond", cot.cotizacion_condiciones)
                    .AddParameter("@cotState", cot.cotizacion_estado)
                    .ExecuteNonQuery("INSERT INTO cotizaciones (Id, cotizacion_numero, cotizacion_fecha_emision, cotizacion_fecha_entrega, cotizacion_proveedor_id, cotizacion_solcot_id, cotizacion_monto_total, cotizacion_condiciones, cotizacion_estado) " +
                    "VALUES (@cotId, @cotNum, @cotDate, @cotDDate, @cotProvId, @cotSolCotId, @cotMonto, @cotCond, @cotState);");
            }
        }

        public void UpdateState(Guid cotId, string state)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    .AddParameter("@cId", cotId)
                    .AddParameter("@state", state)
                    .ExecuteNonQuery("UPDATE cotizaciones SET cotizacion_estado = @state WHERE Id = @cId;");
            }
        }

        public int SaveCotizacionProductos(Cotizacion cot)
        {
            using (var con = this.GetSqlConnection())
            {
                try
                {
                    int affected = 0;
                    con.Open();
                    foreach (ProductoCotizado pc in cot.cotizacion_productos_cotizados)
                    {
                        affected = new Database(con)
                            .AddParameter("@cotId", cot.Id)
                            .AddParameter("@prodcotId", pc.Id)
                            .AddParameter("@cant", pc.prodsol_cantidad)
                            .AddParameter("@precioU", pc.productocotizado_precio_unidad)
                            .AddParameter("@total", pc.productocotizado_total)
                            .ExecuteNonQuery("INSERT INTO cotizacionproductos (id_cotizacion, id_productocotizado, cantidad, productocotizado_precio_unidad, productocotizado_total) values (@cotId, @prodcotId, @cant, @precioU, @total);");
                    }
                    return affected;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }

        public IList<ProductoCotizado> GetProdSolicitados(Guid _cotId)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var ProdCotizados = new Database(con)
                    .AddParameter("@cId", _cotId)
                    .ExecuteQuery<ProductoCotizado>(@"
                SELECT 
                    p.Id,
                    p.producto_nombre,
                    p.producto_marca,
                    p.producto_modelo,
                    p.producto_tipo,
                    p.producto_deposito,
                    p.producto_stock,
                    p.producto_precio_unidad,
                    p.producto_descripcion,
                    p.producto_punto_pedido,
                    p.producto_activo,
                    p.producto_proveedor,
                    cp.cantidad AS prodsol_cantidad,
                    cp.productocotizado_precio_unidad,
                    cp.productocotizado_total
                FROM 
                    cotizacionproductos cp
                JOIN 
                    productos p ON cp.id_productocotizado = p.Id
                WHERE 
                    cp.id_cotizacion = @cId");
                return ProdCotizados;
            }
        }

    }
}
