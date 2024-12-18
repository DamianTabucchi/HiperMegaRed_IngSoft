﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiperMegaRed.BE;
using HiperMegaRed.DAL.MultiLenguaje;



namespace HiperMegaRed.DAL
{
    public class MultiLangDAL : AbstractDAL, IMultiLenguaje
    {
        private static readonly MultiLangDAL instance = new MultiLangDAL();

        private MultiLangDAL() { }
        public static MultiLangDAL Instance => instance;
        public void UpsertIdioma(Idioma idioma)
        {
            this.InvokeProcedure("sp_Idioma_Upsert", new Dictionary<string, object>() {
                { "@idioma", idioma.Id},
                { "@descripcion", idioma.Descripcion}
            });
        }

        public void UpsertTranslate(string idioma, string key, string value)
        {
            this.InvokeProcedure("sp_Traducciones_Upsert", new Dictionary<string, object>() {
                { "@idioma", idioma},
                { "@clave", key},
                { "@valor", value}
            });
        }

        public Dictionary<string, string> LoadLang(string idioma)
        {
            using (var connection = this.GetSqlConnectionOpen())
            {
                SqlCommand sql = new SqlCommand("SELECT [clave],[valor] FROM Traducciones WHERE Idioma like @idioma; ");
                sql.Connection = connection;

                sql.Parameters.Add(new SqlParameter("@idioma", idioma));

                var reader = sql.ExecuteReader();

                Dictionary<string, string> traducciones = new Dictionary<string, string>();

                while (reader.Read())
                {
                    traducciones.Add(reader["Clave"].ToString(), reader["Valor"].ToString());
                }
                return traducciones;
            }
        }
        public List<Idioma> GetAllIdiomas()
        {
            using (var connection = this.GetSqlConnection())
            {
                SqlCommand sql = new SqlCommand("SELECT Id, Descripcion FROM Idiomas ");
                sql.Connection = connection;

                connection.Open();
                var reader = sql.ExecuteReader();

                var idiomas = new List<Idioma>();
                while (reader.Read())
                {
                    idiomas.Add(
                        new Idioma
                        {
                            Id = reader["Id"].ToString(),
                            Descripcion = reader["Descripcion"].ToString()
                        }
                    );
                }
                return idiomas;
            }
        }

    }
}
