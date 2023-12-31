﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.DAL
{
    public class Database
    {
        public IDbCommand _cmd = null;
        public IDbConnection _conn = null;

        public Database (IDbConnection con)
        {
            _conn = con;
            _cmd = con.CreateCommand();
        }

        public Database AddParameter<T>(string name, T value)
        {
            var sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = name;
            if (value != null)
            {
                sqlParameter.Value = value;
            }
            else
            {
                sqlParameter.Value = DBNull.Value;
            }

            _cmd.Parameters.Add(sqlParameter);
            return this;
        }

        public T ExecuteScalar<T>(string query, bool isStoredProcedure = false)
        {

            if (isStoredProcedure)
            {
                this._cmd.CommandType = CommandType.StoredProcedure;
            }

            _cmd.CommandText = query;

            return (T)_cmd.ExecuteScalar();

        }

        public IList<T> ExecuteQuery<T>(string query, bool isStoreProcedure = false)
        {
            IList<T> list = new List<T>();
            Type t = typeof(T);

            if (isStoreProcedure)
            {
                _cmd.CommandType = CommandType.StoredProcedure;
            }

            _cmd.CommandText = query;

            IDataReader reader = null;
            try
            {
                reader = _cmd.ExecuteReader();
                while (reader.Read())
                {
                    T obj = (T)Activator.CreateInstance(t);

                    foreach (PropertyInfo p in t.GetProperties())
                    {
                        if (ColumnExists(p.Name, reader) && reader[p.Name] != DBNull.Value)
                        {
                            try
                            {
                                var value = reader[p.Name];
                                var u = Nullable.GetUnderlyingType(p.PropertyType);
                                if ((p.PropertyType.IsEnum || (u != null && u.IsEnum)) && value != null)
                                {
                                    Type type = u != null ? u : p.PropertyType;
                                    var enumValue = Enum.Parse(type, value.ToString());
                                    p.SetValue(obj, enumValue);
                                }
                                else
                                {
                                    p.SetValue(obj, value);
                                }

                            }
                            catch (ArgumentException ae)
                            {
                                Console.WriteLine(ae.Message);
                            }

                        }
                    }

                    list.Add(obj);
                }

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return list;
        }

        private bool ColumnExists(string name, IDataReader reader)
        {
            foreach (DataRow dr in reader.GetSchemaTable().Rows)
            {
                if (string.Equals(dr["ColumnName"].ToString(), name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public int ExecuteNonQuery(string query, bool isStoreProcedure = false)
        {
            int noOfAffectedRows = 0;
            if (isStoreProcedure) _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = query;
            noOfAffectedRows = _cmd.ExecuteNonQuery();
            return noOfAffectedRows;
        }

    }
}
