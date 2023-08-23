using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;

namespace HiperMegaRed.DAL
{
    public class ProductoDAL : AbstractDAL
    {
        private static ProductoDAL instance = new ProductoDAL();

        private ProductoDAL() { }

        public static ProductoDAL GetInstance() => instance;

        public Producto FindById(Guid p)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var products = db.AddParameter("@prodId", p).ExecuteQuery<Producto>("SELECT * FROM productos WHERE producto_id like @prodId ;");
                return products.Count > 0 ? products[0] : null;
            }
        }
        public IList<Producto> FindByType(string t)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var products = db.AddParameter("@prodType", t).ExecuteQuery<Producto>("SELECT * FROM productos WHERE producto_tipo like @prodtype ;");
                return products;
            }
        }

        public IList<Producto> FindByCart(Guid c)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var products = db.AddParameter("@cartid", c).ExecuteQuery<Producto>("SELECT * FROM productos JOIN carritos_productos ON productos.id = carritos_productos.id_producto WHERE carritos_productos.id_carrito = @cartid");
                return products;
            }
        }
        public IList<Producto> GetAll()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                IList<Producto> lista = new Database(connection).ExecuteQuery<Producto>("SELECT * FROM productos WHERE producto_stock > 0");
                return lista;
            }
        }
        public void SaveProducto(Producto prod)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    .AddParameter("@prodId", prod.Id)
                    .AddParameter("@prodName", prod.producto_nombre)
                    .AddParameter("@prodMarc", prod.producto_marca)
                    .AddParameter("@prodModel", prod.producto_modelo)
                    .AddParameter("@prodType", prod.producto_tipo)
                    .AddParameter("@prodPrec", prod.producto_precio_unidad)
                    .AddParameter("@prodStock", prod.producto_stock)
                    .AddParameter("@prodDepo", prod.producto_deposito)
                    .AddParameter("@prodDesc", prod.producto_descripcion)
                    .ExecuteNonQuery("sp_Producto_UpdateOrInsert", true);
            }
        }
        public void UpdateStock(Producto prod)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    .AddParameter("@prodStock", prod.producto_stock)
                    .AddParameter("@prodId", prod.Id)
                    .ExecuteNonQuery("UPDATE productos SET producto_stock = @ProdStock WHERE id = @prodId");
            }
        }

    }
}
