using HiperMegaRed.BE;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HiperMegaRed.DAL
{
    public class DigitoVerificadorDAL : AbstractDAL
    {
        private static DigitoVerificadorDAL instance = new DigitoVerificadorDAL();
        private static DigitoVerificadorDAL GetInstance() => instance;

        public int GetDigitoVerificador(string str)
        {
            return str.GetHashCode();
        }

        public void CalculateDVGeneric (string table)
        {
            SqlCommand comando = new SqlCommand(string.Format("SELECT * FROM " + table + ";"), this.GetSqlConnection());
            SqlDataAdapter DA = new SqlDataAdapter(comando);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            //string NombreCampo = "DigitoHorizontal";

            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Dr in DS.Tables[0].Rows)
                {
                    string cadena = "";
                    foreach (object valor in Dr.ItemArray)
                    {
                        if (valor.ToString() == Dr["DVHorizontal"].ToString())
                            continue;
                        cadena += valor.ToString();
                    }

                    using (var con = this.GetSqlConnection())
                    {
                        con.Open();
                        int cadenaEncriptada = GetDigitoVerificador(cadena);
                        Guid idtable = new Guid();
                        if (Dr.Table.Columns.Contains("Id"))
                        {
                            idtable = (Guid)Dr["Id"];
                        }
                        else if (Dr.Table.Columns.Contains("id"))
                        {
                            idtable = (Guid)Dr["id"];
                        }
                        new Database(con).AddParameter("@id", idtable).AddParameter("@dvh", cadenaEncriptada).ExecuteNonQuery($"UPDATE {table} SET DVHorizontal = @dvh WHERE Id = @id;");

                    }

                }
            }
            
        }

        public bool CheckDigitsGeneric(string table)
        {
            SqlCommand comando = new SqlCommand(string.Format("SELECT * FROM " + table + ";"), this.GetSqlConnection());
            SqlDataAdapter DA = new SqlDataAdapter(comando);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Dr in DS.Tables[0].Rows)
                {
                    string cadena = "";
                    foreach (object valor in Dr.ItemArray)
                    {
                        if (valor.ToString() == Dr["DVHorizontal"].ToString())
                            continue;
                        cadena += valor.ToString();
                    }
                    int cadenaEncriptada = GetDigitoVerificador(cadena);
                    if ((int)Dr["DVHorizontal"] != cadenaEncriptada)
                    {
                        MessageBox.Show("Error en la consistencia de la informacion en la tabla: " + table);
                        return false;
                    }

                }
                return true;
            }
            return false;
        }

        public void UpdateDVGeneric(string table, Guid _id)
        {
            SqlCommand comando = new SqlCommand($"SELECT * FROM {table} WHERE Id = @id", this.GetSqlConnection());
            // Add parameter for the GUID
            comando.Parameters.AddWithValue("@id", _id);
            SqlDataAdapter DA = new SqlDataAdapter(comando);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Dr in DS.Tables[0].Rows)
                {
                    string cadena = "";
                    foreach (object valor in Dr.ItemArray)
                    {
                        if (valor.ToString() == Dr["DVHorizontal"].ToString())
                            continue;
                        cadena += valor.ToString();
                    }

                    using (var con = this.GetSqlConnection())
                    {
                        con.Open();
                        int cadenaEncriptada = GetDigitoVerificador(cadena);
                        new Database(con).AddParameter("@id", _id).AddParameter("@dvh", cadenaEncriptada).ExecuteNonQuery($"UPDATE {table} SET DVHorizontal = @dvh WHERE Id = @id;");
                    }
                }
            }

        }

        public void UpdateDVHorizontal(Guid userid, int dvh)
        {
            using (var con = this.GetSqlConnection())
            {
                con.Open();
                new Database(con).AddParameter("@uid", userid).AddParameter("@dvh", dvh)
                    .ExecuteNonQuery("UPDATE usuarios SET DVHorizontal = @dvh WHERE Id = @uid");
            }
        }
       
    }
}
