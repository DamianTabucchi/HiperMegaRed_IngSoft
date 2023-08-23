using HiperMegaRed.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.DAL
{
    public class UserDAL : AbstractDAL
    {
        private static UserDAL instance = new UserDAL();

        private UserDAL() { }

        // GetInstance() => instance; es lo mismo que escribir public static UserDAL GetInstance { get { return instance; } }
        public static UserDAL GetInstance() => instance;

        public User FindByUsername(string username)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);
                var users = db.AddParameter("@username", username).ExecuteQuery<User>("SELECT * FROM usuarios WHERE Username like @username ;");
                return users.Count > 0 ? users[0] : null;
            }
        }

        public IList<User> GetAll()
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();

                IList<User> lista = new Database(connection).ExecuteQuery<User>("SELECT * FROM Usuarios");
                return lista;
            }
        }

        public void SaveUser(User user)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con)
                    
                    .AddParameter("@Id", user.Id)
                    .AddParameter("@Username", user.Username)
                    .AddParameter("@Password", user.Password)
                    .AddParameter("@LastLogin", user.LastLogin)
                    .AddParameter("@FailCount", user.FailCount)
                    .AddParameter("@Language", user.Language)
                    .AddParameter("@Expired", user.Expired)
                    .AddParameter("@Name", user.Name)
                    .AddParameter("@Lastname", user.Lastname)
                    .AddParameter("@Mail", user.Mail)
                    .AddParameter("@Phone", user.Phone)
                    .AddParameter("@dni", user.DNI)
                    .ExecuteNonQuery("sp_Usuario_UpdateOrInsert", true);
            }
        }

        public int SavePermisos(User u)
        {
            try
            {
                using (var con = this.GetSqlConnection())
                {
                    con.Open();
                    var affected = new Database(con)
                        .AddParameter("@id", u.Id)
                        .ExecuteNonQuery("DELETE FROM usuarios_permisos WHERE id_usuario = @id");

                    int permisosAgregados = 0;
                    foreach (var i in u.Permisos)
                    {
                        permisosAgregados =+ new Database(con)
                            .AddParameter("@iduser", u.Id)
                            .AddParameter("@idperm", i.Id)
                            .ExecuteNonQuery("INSERT INTO usuarios_permisos (id_usuario, id_permiso) values (@iduser, @idperm)");
                    }
                    return permisosAgregados;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
