using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HiperMegaRed.DAL
{
    public class SolicitudCotizacionDAL : AbstractDAL
    {
        private static SolicitudCotizacionDAL instance = new SolicitudCotizacionDAL();
        private SolicitudCotizacionDAL() { }
        public static SolicitudCotizacionDAL GetInstance() => instance;

        public IList<SolicitudCotizacion> GetAll()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var SolicitudesDeCotizacion = new Database(con).ExecuteQuery<SolicitudCotizacion>("SELECT * FROM solicitudesdecotizacion;");
                return SolicitudesDeCotizacion;
            }
        }

        public IList<SolicitudCotizacion> GetPending()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var SolicitudesDeCotizacion = new Database(con)
                    .AddParameter("@state","Pendiente")
                    .ExecuteQuery<SolicitudCotizacion>("SELECT * FROM solicitudesdecotizacion WHERE solcot_estado = @state;");
                return SolicitudesDeCotizacion;
            }
        }

        public IList<SolicitudCotizacion> GetRegistered()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var SolicitudesDeCotizacion = new Database(con)
                    .AddParameter("@state", "Registrada")
                    .ExecuteQuery<SolicitudCotizacion>("SELECT * FROM solicitudesdecotizacion WHERE solcot_estado = @state;");
                return SolicitudesDeCotizacion;
            }
        }

        public IList<SolicitudCotizacion> GetCotizada()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var SolicitudesDeCotizacion = new Database(con)
                    .AddParameter("@state", "Cotizada")
                    .ExecuteQuery<SolicitudCotizacion>("SELECT * FROM solicitudesdecotizacion WHERE solcot_estado = @state;");
                return SolicitudesDeCotizacion;
            }
        }

        public IList<SolicitudCotizacion> GetBySupplier(Guid proveedorId)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var SolicitudesPorProveedor = new Database(con)
                    .AddParameter("@pId", proveedorId)
                    .ExecuteQuery<SolicitudCotizacion>("SELECT * FROM solicitudesdecotizacion WHERE solcot_proveedor = @pId;");
                return SolicitudesPorProveedor;
            }
        }

        public SolicitudCotizacion GetById(Guid solcotId)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var solcot = new Database(con)
                    .AddParameter("@sId", solcotId)
                    .ExecuteQuery<SolicitudCotizacion>("SELECT * FROM solicitudesdecotizacion WHERE Id = @sId;");
                return solcot.Count > 0 ? solcot[0] : null;
            }
        }

        public IList<SolicitudCotizacion> GetByOrder(Guid orderId)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var SolicitudesPorOrden = new Database(con)
                    .AddParameter("@oId", orderId)
                    .ExecuteQuery<SolicitudCotizacion>("SELECT * FROM solicitudesdecotizacion WHERE solcot_ordenrepo_id = @oId;");
                return SolicitudesPorOrden;
            }
        }
        public int GenerarNumeroSolicitud()
        {
            using (var con = this.GetSqlConnection())  // Obtén la conexión
            {
                con.Open();
                int maxOrdenNumero = new Database(con)
                                     .ExecuteScalar<int>("SELECT ISNULL(MAX(solcot_numero_solicitud), 0) FROM solicitudesdecotizacion");
                return maxOrdenNumero + 1;  // Retorna el objeto modificado
            }
        }
        public void SaveSolicitud(SolicitudCotizacion solcot)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    .AddParameter("@solcotId", solcot.Id)
                    .AddParameter("@solcotDate", solcot.solcot_fecha_solicitud)
                    .AddParameter("@solcotOrden", solcot.solcot_ordenrepo_id)
                    .AddParameter("@solcotProveedor", solcot.solcot_proveedor)
                    .AddParameter("@solcotSolicitante", solcot.solcot_solicitante)
                    .AddParameter("@solcotNumero", solcot.solcot_numero_solicitud)
                    .AddParameter("@solcotState", solcot.solcot_estado)
                    .ExecuteNonQuery("INSERT INTO solicitudesdecotizacion (Id, solcot_fecha_solicitud, solcot_ordenrepo_id, solcot_proveedor, solcot_solicitante, solcot_numero_solicitud, solcot_estado) VALUES (@solcotId, @solcotDate, @solcotOrden, @solcotProveedor, @solcotSolicitante, @solcotNumero, @solcotState);");
            }
        }

        public int SaveSolicitudProductos(SolicitudCotizacion solcot)
        {
            using (var con = this.GetSqlConnection())
            {
                try
                {
                    int affected = 0;
                    con.Open();
                    foreach (ProductoSolicitado ps in solcot.solcot_productos)
                    {
                        affected = new Database(con)
                            .AddParameter("@solcotId", solcot.Id)
                            .AddParameter("@prodsolId", ps.Id)
                            .AddParameter("@cant", ps.prodsol_cantidad)
                            .ExecuteNonQuery("INSERT INTO solicitudproductos (id_solcot, id_solprod, cantidad) values (@solcotId, @prodsolId, @cant);");
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

        public IList<ProductoSolicitado> GetProdSolicitados(Guid _solcotId)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var ProdSolicitados = new Database(con)
                    .AddParameter("@sId", _solcotId)
                    .ExecuteQuery<ProductoSolicitado>(@"
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
                    sp.cantidad AS prodsol_cantidad
                FROM 
                    solicitudproductos sp
                JOIN 
                    productos p ON sp.id_solprod = p.Id
                WHERE 
                    sp.id_solcot = @sId");
                return ProdSolicitados;
            }
        }

        public int UpdateState(Guid _solcotId, string state)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var affected = new Database(con)
                    .AddParameter("@scId", _solcotId)
                    .AddParameter("@state", state)
                    .ExecuteNonQuery("UPDATE solicitudesdecotizacion SET solcot_estado = @state WHERE Id = @scId;");
                return affected;
            }
        }

    }
}
