using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.DAL
{
    public class CarritoDAL : AbstractDAL
    {
        private static CarritoDAL instance = new CarritoDAL();
        private CarritoDAL() { }
        public static CarritoDAL GetInstance() => instance;
        public IList<Carrito> FindByClient(decimal doc)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var carts = db.AddParameter("@clientdni", doc).ExecuteQuery<Carrito>("SELECT * FROM carritos INNER JOIN clientes ON carrito_client_dni = cliente_dni WHERE carrito_cliente_dni like @clientdni ;");
                return carts;
            }
        }
        public Carrito FindById(Guid id)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var carts = db.AddParameter("@cartid", id).ExecuteQuery<Carrito>("SELECT * FROM carritos WHERE carrito_id like @cartid ;");
                return carts.Count > 0 ? carts[0] : null;
            }
        }

        public IList<Carrito> GetAll()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                IList<Carrito> lista = new Database(connection).ExecuteQuery<Carrito>("SELECT * FROM carritos");
                return lista;
            }
        }

        public IList<Carrito> GetUnpayed()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                IList<Carrito> lista = new Database(connection).ExecuteQuery<Carrito>("SELECT * FROM carritos WHERE carrito_pagado = 'False'");
                return lista;
            }
        }

        public void SaveCart(Carrito cart)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    .AddParameter("@cartID", cart.Id)
                    .AddParameter("@cartClientId", cart.carrito_cliente_dni)
                    .AddParameter("@cartEmisionDate", cart.carrito_fecha)
                    .AddParameter("@cartTotal", cart.carrito_total)
                    .AddParameter("@cartpayed", cart.carrito_pagado)
                    .ExecuteNonQuery("Carrito_Insert", true);
            }
        }

        public int UpdateCart(Carrito cart)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var rowsaffected = new Database(con)
                    .AddParameter("@cartId", cart.Id)
                    .AddParameter("@cartpayed", cart.carrito_pagado)
                    .ExecuteNonQuery("UPDATE carritos SET carrito_pagado = @cartpayed WHERE id = @cartId");
                return rowsaffected;
            }
        }

        private int RemoveProdFromCart(Carrito cart)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                
                try
                {
                    var affrows = new Database(con)
                    .AddParameter("@cartId", cart.Id)
                    .ExecuteNonQuery("DELETE FROM carritos_productos WHERE id_carrito = @cartid;");
                    con.Close();
                    return affrows;
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw ex;
                }
            }
        }

        public int RemoveCart(Carrito cart)
        {
            var prodremoved = RemoveProdFromCart(cart);
            if (prodremoved > 0)
            {
                using (var con = this.GetSqlConnection())
                {
                    con.Open();
                    try
                    {
                        var affrows = new Database(con)
                        .AddParameter("@cartId", cart.Id)
                        .ExecuteNonQuery("DELETE FROM carritos WHERE id = @cartid;");
                        con.Close();
                        return affrows;
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        throw ex;
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        public int AddProdToCart(Carrito cart)
        {
            using (var con = this.GetSqlConnection())
            {
                int rowsaffected = 0;
                con.Open();
                foreach (ItemProducto p in cart.carrito_productos)
                {
                   rowsaffected += new Database(con)
                        .AddParameter("@cartid", cart.Id)
                        .AddParameter("@prodid", p.Id)
                        .AddParameter("@cant", p.cantidad)
                        .ExecuteNonQuery("INSERT INTO carritos_productos (id_carrito, id_producto, cantidad) VALUES (@cartid, @prodid, @cant);");
                }
                con.Close();
                return rowsaffected;
            }
        }
    }
}
