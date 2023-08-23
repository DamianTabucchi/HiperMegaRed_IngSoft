using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;


namespace HiperMegaRed.DAL
{
    public class PermisosDAL : AbstractDAL
    {
        private static PermisosDAL instance = new PermisosDAL();
        private PermisosDAL() { }
        public static PermisosDAL GetInstance() => instance;

        public Componente SaveComponent(Componente comp, bool esFamilia)
        {
            try
            {
                using (var con = this.GetSqlConnection())
                {
                    var db = new Database(con);

                    var sql = $@"insert into permiso (nombre,permiso) values (@nombre,@permiso); SELECT ID AS LastID FROM permiso WHERE ID = @@Identity;";

                    db.AddParameter("@nombre", comp.Nombre);

                    if (esFamilia)
                        db.AddParameter("@permiso", DBNull.Value);
                    else
                        db.AddParameter("@permiso", comp.Permiso.ToString());

                    con.Open();
                    db.ExecuteNonQuery(sql);
                    return comp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Componente GetByGrantName(string grantName)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;

                var sql = $@"select * from permiso p where p.nombre like @grantName;";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@grantName", grantName);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader.GetInt32(reader.GetOrdinal("id"));
                    var nombre = reader.GetString(reader.GetOrdinal("nombre"));
                    var permiso = reader.GetString(reader.GetOrdinal("permiso"));
                    Componente c;
                    if (string.IsNullOrWhiteSpace(permiso))
                    {
                        c = new Familia();
                    }
                    else
                    {
                        c = new Patente();
                    }

                    c.Id = id;
                    c.Nombre = nombre;
                    c.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);
                    reader.Close();
                    return c;
                }
                return null;
            }
        }

        public void SaveFamily(Familia c)
        {
            try
            {
                using (var con = this.GetSqlConnection())
                {
                    con.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = con;

                    var sql = $@"DELETE FROM permiso_permiso WHERE id_permiso_padre = @id;";

                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("id", c.Id));
                    cmd.ExecuteNonQuery();

                    foreach (var item in c.Hijos)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = con;


                        sql = $@"INSERT INTO permiso_permiso (id_permiso_padre,id_permiso_hijo) VALUES (@id_permiso_padre,@id_permiso_hijo) ";

                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SqlParameter("id_permiso_padre", c.Id));
                        cmd.Parameters.Add(new SqlParameter("id_permiso_hijo", item.Id));

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Patente> GetAllPatentes()
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                var sql = $@"SELECT * FROM permiso p WHERE p.permiso is not null;";
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();

                var lista = new List<Patente>();

                while (reader.Read())
                {


                    var id = reader.GetInt32(reader.GetOrdinal("id"));
                    var nombre = reader.GetString(reader.GetOrdinal("nombre"));
                    var permiso = reader.GetString(reader.GetOrdinal("permiso"));


                    Patente c = new Patente();

                    c.Id = id;
                    c.Nombre = nombre;
                    c.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);
                    lista.Add(c);

                }
                reader.Close();
                con.Close();
                return lista;
            }
        }
        public IList<Familia> GetAllFamilias()
        {
            using (var conn = this.GetSqlConnection())
            {
                conn.Open();
                var cmd = new SqlCommand();
                cmd.Connection = conn;

                var sql = $@"select * from permiso p where p.permiso is null;";

                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader();

                var lista = new List<Familia>();

                while (reader.Read())
                {
                    var id = reader.GetInt32(reader.GetOrdinal("id"));
                    var nombre = reader.GetString(reader.GetOrdinal("nombre"));

                    Familia c = new Familia();

                    c.Id = id;
                    c.Nombre = nombre;
                    lista.Add(c);
                }
                reader.Close();
                conn.Close();

                return lista;
            }
        }
        public IList<Componente> GetAll(string familia)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var where = "is NULL";
                if (!String.IsNullOrEmpty(familia))
                {
                    where = familia;
                }
                conn.Open();
                var cmd = new SqlCommand();
                cmd.Connection = conn;

                var sql = $@"with recursivo as (
                        select sp2.id_permiso_padre, sp2.id_permiso_hijo  from permiso_permiso SP2
                        where sp2.id_permiso_padre {where} --acá se va variando la familia que busco
                        UNION ALL 
                        select sp.id_permiso_padre, sp.id_permiso_hijo from permiso_permiso sp 
                        inner join recursivo r on r.id_permiso_hijo= sp.id_permiso_padre
                        )
                        select r.id_permiso_padre,r.id_permiso_hijo,p.id,p.nombre, p.permiso
                        from recursivo r 
                        inner join permiso p on r.id_permiso_hijo = p.id";

                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                var lista = new List<Componente>();

                while (reader.Read())
                {
                    int id_padre = 0;
                    if (reader["id_permiso_padre"] != DBNull.Value)
                    {
                        id_padre = reader.GetInt32(reader.GetOrdinal("id_permiso_padre"));
                    }

                    var id = reader.GetInt32(reader.GetOrdinal("id"));
                    var nombre = reader.GetString(reader.GetOrdinal("nombre"));

                    var permiso = string.Empty;
                    if (reader["permiso"] != DBNull.Value) permiso = reader.GetString(reader.GetOrdinal("permiso"));
                    
                    Componente c;

                    if (string.IsNullOrEmpty(permiso))//usamos este campo para identificar. Solo las patentes van a tener un permiso del sistema relacionado
                        c = new Familia();

                    else
                        c = new Patente();

                    c.Id = id;
                    c.Nombre = nombre;
                    if (!string.IsNullOrEmpty(permiso))
                        c.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);

                    var padre = GetComponent(id_padre, lista);

                    if (padre == null)
                    {
                        lista.Add(c);
                    }
                    else
                    {
                        padre.AgregarHijo(c);
                    }
                }
                reader.Close();
                conn.Close();
                return lista;
            }

        }
        private Componente GetComponent(int id, IList<Componente> lista)
        {
            Componente component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;
            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {
                    var l = GetComponent(id, c.Hijos);
                    if (l != null && l.Id == id) return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Hijos);
                }
            }
            return component;
        }
        public void FillUserComponents(User u)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                var cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = $@"SELECT p.* FROM usuarios_permisos up INNER JOIN permiso p ON up.id_permiso=p.id WHERE id_usuario=@id;";
                cmd2.Parameters.AddWithValue("id", u.Id);

                var reader = cmd2.ExecuteReader();
                u.Permisos.Clear();
                while (reader.Read())
                {

                    var idp = reader.GetInt32(reader.GetOrdinal("id"));
                    var nombrep = reader.GetString(reader.GetOrdinal("nombre"));

                    var permisop = String.Empty;
                    if (reader["permiso"] != DBNull.Value)
                        permisop = reader.GetString(reader.GetOrdinal("permiso"));

                    Componente c1;
                    if (!String.IsNullOrEmpty(permisop))
                    {
                        c1 = new Patente();
                        c1.Id = idp;
                        c1.Nombre = nombrep;
                        c1.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permisop);
                        u.Permisos.Add(c1);
                    }
                    else
                    {
                        c1 = new Familia();
                        c1.Id = idp;
                        c1.Nombre = nombrep;

                        var f = GetAll("=" + idp);

                        foreach (var familia in f)
                        {
                            c1.AgregarHijo(familia);
                        }
                        u.Permisos.Add(c1);
                    }
                }
                reader.Close();
            }
        }

        public List<Componente> GetAllUserComponents(User usuario)
        {
            using (var cnn = this.GetSqlConnection())
            {
                cnn.Open();

                var cmd2 = new SqlCommand();
                cmd2.Connection = cnn;
                cmd2.CommandText = $@"select p.* from usuarios_permisos up inner join permiso p on up.id_permiso=p.id where id_usuario=@id;";
                cmd2.Parameters.AddWithValue("id", usuario.Id);

                var reader = cmd2.ExecuteReader();
                var componentes = new List<Componente>();
                while (reader.Read())
                {

                    var idp = reader.GetInt32(reader.GetOrdinal("id"));
                    var nombrep = reader.GetString(reader.GetOrdinal("nombre"));

                    var permisop = String.Empty;
                    if (reader["permiso"] != DBNull.Value)
                        permisop = reader.GetString(reader.GetOrdinal("permiso"));

                    Componente c1;
                    if (String.IsNullOrEmpty(permisop))
                    {
                        c1 = new Familia();
                        c1.Id = idp;
                        c1.Nombre = nombrep;

                        var f = GetAll($"='{idp}'");

                        foreach (var familia in f)
                        {
                            c1.AgregarHijo(familia);
                        }
                        componentes.Add(c1);
                    }
                    else
                    {
                        c1 = new Patente();
                        c1.Id = idp;
                        c1.Nombre = nombrep;
                        c1.Permiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permisop);
                        componentes.Add(c1);
                    }

                }
                reader.Close();
                return componentes;
            }
        }
        public void FillFamilyComponents(Familia familia)
        {
            familia.VaciarHijos();
            foreach (var item in GetAll("=" + familia.Id))
            {
                familia.AgregarHijo(item);
            }
        }

        public void DeleteRelatedComponent(int parentId, int childId)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);

                var sql = "DELETE FROM [permiso_permiso] WHERE [id_permiso_padre] = @id_permiso_padre AND [id_permiso_hijo] = @id_permiso_hijo";

                db.AddParameter("@id_permiso_padre", parentId)
                    .AddParameter("@id_permiso_hijo", childId)
                    .ExecuteNonQuery(sql);

            }
        }

        public void AddRelatedComponent(int parentId, int childId)
        {
            using (var connection = this.GetSqlConnection())
            {
                connection.Open();
                var db = new Database(connection);

                var sql = "INSERT INTO [permiso_permiso] ([id_permiso_padre],[id_permiso_hijo]) VALUES (@id_permiso_padre, @id_permiso_hijo)";

                db.AddParameter("@id_permiso_padre", parentId)
                    .AddParameter("@id_permiso_hijo", childId)
                    .ExecuteNonQuery(sql);

            }
        }
    }
}
