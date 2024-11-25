using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiperMegaRed.DAL
{
    public class OrdenDeReposicionDAL : AbstractDAL
    {
        private static OrdenDeReposicionDAL instance = new OrdenDeReposicionDAL();
        private OrdenDeReposicionDAL() { }
        public static OrdenDeReposicionDAL GetInstance() => instance;

        public IList<OrdenDeReposicion> GetAll()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var ordenesrepo = new Database(con).ExecuteQuery<OrdenDeReposicion>("SELECT * FROM ordenesdereposicion;");
                return ordenesrepo;
            }
        }

        public OrdenDeReposicion GetById(Guid _id)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var ordenreposicion = new Database(con)
                    .AddParameter("@orderId", _id)
                    .ExecuteQuery<OrdenDeReposicion>("SELECT * FROM ordenesdereposicion WHERE Id = @orderId;");
                return ordenreposicion.Count > 0 ? ordenreposicion[0] : null;
            }
        }

        public IList<OrdenDeReposicion> GetPending()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var ordenesrepo = new Database(con)
                    .AddParameter("@estado", TipoEstado.Pendiente.ToString())
                    .ExecuteQuery<OrdenDeReposicion>("SELECT * FROM ordenesdereposicion WHERE orden_estado = @estado;");
                return ordenesrepo;
            }
        }

        public IList<OrdenDeReposicion> GetByState(TipoEstado state)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var ordenesrepo = new Database(con)
                    .AddParameter("@estado", state.ToString())
                    .ExecuteQuery<OrdenDeReposicion>("SELECT * FROM ordenesdereposicion WHERE orden_estado = @estado;");
                return ordenesrepo;
            }
        }

        public IList<OrdenDeReposicion> GetByApplicant(Guid uid)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var ordenesrepo = new Database(con).AddParameter("@idsolicitante", uid).ExecuteQuery<OrdenDeReposicion>("SELECT * FROM ordenesdereposicion WHERE orden_solicitante = @idsolicitante;");
                return ordenesrepo;
            }
        }
        public int GenerarNumeroOrden()
        {
            using (var con = this.GetSqlConnection())  // Obtén la conexión
            {
                con.Open();
                int maxOrdenNumero = new Database(con)
                                     .ExecuteScalar<int>("SELECT ISNULL(MAX(orden_numero), 0) FROM ordenesdereposicion");
                return maxOrdenNumero + 1;  // Retorna el objeto modificado
            }
        }

        public void SaveOrdenRepo (OrdenDeReposicion ordenrepo)
        {
            using (var con = this.GetSqlConnection())
            {
                try
                {
                    con.Open();
                    var affected = new Database(con)
                            .AddParameter("@ordenId", ordenrepo.Id)
                            .AddParameter("@ordenNum", ordenrepo.orden_numero)
                            .AddParameter("@ordenFechaCreacion", ordenrepo.orden_fecha_creacion)
                            .AddParameter("@ordenFechaAprob", ordenrepo.orden_fecha_aprobacion)
                            .AddParameter("@ordenJustify", ordenrepo.orden_justificacion)
                            .AddParameter("@ordenEstado", ordenrepo.orden_estado)
                            .AddParameter("@ordenSolicitante", ordenrepo.orden_solicitante)
                            .AddParameter("@ordenAprobador", ordenrepo.orden_aprobador)
                            .AddParameter("@ordenTipo", ordenrepo.orden_tipo)
                            .ExecuteNonQuery("INSERT INTO ordenesdereposicion (Id, orden_numero, orden_fecha_creacion, orden_fecha_aprobacion, orden_justificacion, orden_estado, orden_solicitante, orden_aprobador, orden_tipo) VALUES (@ordenId, @ordenNum, @ordenFechaCreacion, @ordenFechaAprob, @ordenJustify, @ordenEstado, @ordenSolicitante, @ordenAprobador, @ordenTipo);");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        public int SaveOrdenProductos(OrdenDeReposicion ordenrepo)
        {
            using (var con = this.GetSqlConnection())
            {
                try
                {
                    int affected = 0;
                    con.Open();
                    foreach (ProductoSolicitado ps in ordenrepo.orden_productos_solicitados)
                    {
                        affected = affected + new Database(con)
                            .AddParameter("@ordenId", ordenrepo.Id)
                            .AddParameter("@prodsolId", ps.Id)
                            .AddParameter("@cant", ps.prodsol_cantidad)
                            .ExecuteNonQuery("INSERT INTO ordenproductos (id_orden_reposicion, id_prodsol, cantidad) VALUES (@ordenId, @prodsolId, @cant);");
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

        public int EstadoOrden(OrdenDeReposicion ordenrepo)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var affected = new Database(con)
                    .AddParameter("@ordenId", ordenrepo.Id)
                    .AddParameter("@ordenEstado", ordenrepo.orden_estado)
                    .AddParameter("@ordenFechaAprobado", ordenrepo.orden_fecha_aprobacion)
                    .AddParameter("@ordenAprobador", ordenrepo.orden_aprobador)
                    .AddParameter("@ordenJustify", ordenrepo.orden_justificacion)
                    .ExecuteNonQuery("UPDATE ordenesdereposicion SET orden_fecha_aprobacion = @ordenFechaAprobado, orden_justificacion = @ordenJustify, orden_estado = @ordenEstado, orden_aprobador = @ordenAprobador WHERE Id = @ordenId ;");
                return affected;
            }
        }

        public IList<ProductoSolicitado> GetProdSolicitados(Guid _ordenId)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var ProdSolicitados = new Database(con)
                    .AddParameter("@ordenId", _ordenId)
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
                    op.cantidad AS prodsol_cantidad
                FROM 
                    ordenproductos op
                JOIN 
                    productos p ON op.id_prodsol = p.Id
                WHERE 
                    op.id_orden_reposicion = @ordenId");
                return ProdSolicitados;
            }
        }
    }
}
