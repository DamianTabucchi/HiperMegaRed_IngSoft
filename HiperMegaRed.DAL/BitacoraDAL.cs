using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.DAL
{
    public class BitacoraDAL : AbstractDAL
    {
        private static BitacoraDAL instance = new BitacoraDAL();
        private static BitacoraDAL GetInstance() => instance;

        public IList<Bitacora> GetAll()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                IList<Bitacora> lista = new Database(connection).ExecuteQuery<Bitacora>("SELECT * FROM bitacoras");
                return lista;
            }
        }

        public IList<Bitacora> FindByCriticality(string criticality)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                IList<Bitacora> lista = new Database(connection).AddParameter("@crit", criticality).ExecuteQuery<Bitacora>($"SELECT * FROM bitacoras WHERE criticidad = @crit");
                return lista;
            }
        }

        public IList<Bitacora> FindByModule(string mod)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                IList<Bitacora> lista = new Database(connection).AddParameter("@mod", mod).ExecuteQuery<Bitacora>($"SELECT * FROM bitacoras WHERE modulo = @mod");
                return lista;
            }
        }

        public IList<Bitacora> GetByDates(DateTime desde, DateTime hasta)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                
                IList<Bitacora> lista = new Database(connection)
                    .AddParameter("@desde", desde)
                    .AddParameter("@hasta", hasta)
                    .ExecuteQuery<Bitacora>($"SELECT * FROM bitacoras WHERE fechacreacion >= @desde AND fechacreacion <= @hasta");
                return lista;
            }
        }

        public int SaveBitacora(Bitacora _bitacora)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var affected = new Database(connection)
                    .AddParameter("@bid", _bitacora.Id)
                    .AddParameter("@uname", _bitacora.username)
                    .AddParameter("@fecha", _bitacora.fechacreacion)
                    .AddParameter("@crit", _bitacora.criticidad)
                    .AddParameter("@mod", _bitacora.modulo)
                    .AddParameter("@acc", _bitacora.accion)
                    .ExecuteNonQuery("INSERT INTO bitacoras (Id, username, fechacreacion, criticidad, modulo, accion) VALUES (@bid, @uname, @fecha, @crit, @mod, @acc);");
                return affected;
            }
        }
    }
}
