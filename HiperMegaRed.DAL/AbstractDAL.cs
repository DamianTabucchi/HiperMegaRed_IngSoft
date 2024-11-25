using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.DAL
{
    public abstract class AbstractDAL
    {
        protected string GetConnectionString()
        {
            //var cs = new SqlConnectionStringBuilder();
            //cs.IntegratedSecurity = true;
            //cs.DataSource = "DITS_ASUS\\SQLEXPRESS01";
            //cs.InitialCatalog = "HMR";

            //return cs.ConnectionString;
            return ConfigurationManager.ConnectionStrings["MiCadenaConexion"].ConnectionString;
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        protected SqlConnection GetSqlConnectionOpen()
        {
            var con = GetSqlConnection();
            con.Open();
            return con;
        }

        protected int InvokeProcedure(string name)
        {
            return InvokeProcedure(name, null);
        }

        protected int InvokeProcedure(string name, IDictionary<string, object> parameters)
        {
            using (var con = this.GetSqlConnectionOpen())
            {
                var db = new Database(con);

                if (parameters != null)
                {
                    foreach (string key in parameters.Keys)
                    {
                        db.AddParameter(key, parameters[key]);
                    }
                }

                return db.ExecuteNonQuery(name, true);
            }
        }
    }
}
