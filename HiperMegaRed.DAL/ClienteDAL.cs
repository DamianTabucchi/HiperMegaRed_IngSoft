using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;

namespace HiperMegaRed.DAL
{
    public class ClienteDAL : AbstractDAL
    {
        private static ClienteDAL instance = new ClienteDAL();
        private ClienteDAL() { }
        public static ClienteDAL GetInstance() => instance;

        public IList<Cliente> GetAll()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                IList<Cliente> lista = new Database(connection).ExecuteQuery<Cliente>("SELECT * FROM clientes");
                return lista;
            }
        }

        public Cliente FindByDNI(decimal dni)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var clients = db.AddParameter("@clientdni", dni).ExecuteQuery<Cliente>("SELECT * FROM clientes WHERE cliente_dni like @clientdni ;");
                return clients.Count > 0 ? clients[0] : null;
            }
        }
        public void SaveClient(Cliente client)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    .AddParameter("@clientdni", client.cliente_dni)
                    .AddParameter("@clientname", client.cliente_nombre)
                    .AddParameter("@clientapellido", client.cliente_apellido)
                    .AddParameter("@clientmail", client.cliente_mail)
                    .AddParameter("@clienttel", client.cliente_telefono)
                    .ExecuteNonQuery("sp_Cliente_Insert", true);
            }
        }
    }
}
