using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.DAL
{
    public class BitacoraCambioDAL : AbstractDAL
    {
        private static BitacoraCambioDAL instance = new BitacoraCambioDAL();
        public static BitacoraCambioDAL Instance => instance;

        public IList<BitacoraCambio> GetAll()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                IList<BitacoraCambio> lista = new Database(connection).ExecuteQuery<BitacoraCambio>("SELECT * FROM bcproductos");
                return lista;
            }
        }

        public void SaveBitacoraCambio(Producto bita)
        {
            using (var connection = this.GetSqlConnection())
            {
                var bcId = Guid.NewGuid();
                var fechacreacion = DateTime.Now;
                connection.Open();
                new Database(connection).AddParameter("@bcId", bcId)
                    .AddParameter("@bcIdProd", bita.Id)
                    .AddParameter("@bcPName", bita.producto_nombre)
                    .AddParameter("@bcPMar", bita.producto_marca)
                    .AddParameter("@bcPMod", bita.producto_modelo)
                    .AddParameter("@bcPType", bita.producto_tipo.ToString())
                    .AddParameter("@bcPSto", bita.producto_stock)
                    .AddParameter("@bcPDepo", bita.producto_deposito)
                    .AddParameter("@bcPDesc", bita.producto_descripcion)
                    .AddParameter("@bcPPU", bita.producto_precio_unidad)
                    .AddParameter("@bcDate", fechacreacion)
                    .AddParameter("@bcPP", bita.producto_punto_pedido)
                    .AddParameter("@bcAct", bita.producto_activo)
                    .AddParameter("@bcProv", bita.producto_proveedor)
                    .ExecuteNonQuery("INSERT INTO bcproductos VALUES (@bcId,@bcIdProd,@bcPName,@bcPMar,@bcPMod,@bcPType,@bcPSto,@bcPDepo,@bcPDesc,@bcPPU, @bcDate, @bcPP, @bcAct, @bcProv)");
            }
        }

        //public void ActivarCambio(BitacoraCambio bita)
        //{
        //    using (var connection = this.GetSqlConnection())
        //    {
        //        connection.Open();
        //        var db = new Database(connection);
        //        db.AddParameter("@bcId", bita.Id)
        //            .AddParameter("@bcIdProd", bita.producto_id)
        //            .AddParameter("@bcAct", bita.activo)
        //            .AddParameter("@bcPName", bita.producto_nombre)
        //            .AddParameter("@bcPMar", bita.producto_marca)
        //            .AddParameter("@bcPMod", bita.producto_modelo)
        //            .AddParameter("@bcPType", bita.producto_tipo.ToString())
        //            .AddParameter("@bcPSto", bita.producto_stock)
        //            .AddParameter("@bcPDepo", bita.producto_deposito)
        //            .AddParameter("@bcPDesc", bita.producto_descripcion)
        //            .AddParameter("@bcPPU", bita.producto_precio_unidad)
        //            .ExecuteNonQuery("UPDATE bitacorascambios SET activo = 'False' WHERE producto_id = @bcIdProd");
        //        db.ExecuteNonQuery("UPDATE bitacorascambios SET activo = 'True' WHERE id = @bcId");
        //        db.ExecuteNonQuery("UPDATE productos SET producto_nombre = @bcPName, producto_marca = @bcPMar, producto_modelo = @bcPMod, producto_tipo = @bcPType, producto_stock = @bcPSto, producto_deposito = @bcPDepo, producto_descripcion = @bcPDesc, producto_precio_unidad = @bcPPU WHERE id = @bcIdProd");

        //    }

        //}
    }
}
