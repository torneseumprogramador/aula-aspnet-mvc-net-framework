using Dapper;
using LabWebForms.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace LabMVC.DbSqLite
{
    public class SqliteDataAccess
    {
        private static string GetConnection(string id = "MinhaConexao")
        {
            string dataDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string connectionString = ConfigurationManager.ConnectionStrings[id].ConnectionString;

            connectionString = connectionString.Replace("|DataDirectory|", dataDirectory);

            return connectionString;
        }

        public static void SalvarValor<T>(string sql, T argument)
        {
            using (IDbConnection connection = new SQLiteConnection(GetConnection()))
            {
                connection.Execute(sql, argument);
            }
        }

        public static Task<List<T>> BuscarLista<T>(string sql)
        {
            IEnumerable<T> result;

            using (IDbConnection connection = new SQLiteConnection(GetConnection()))
            {
                result = connection.QueryAsync<T>(sql).Result;                
            }

            return Task.FromResult((List<T>)result);
        }

        public static Task<List<T>> BuscarLista<T, S>(string sql, S argument)
        {
            IEnumerable<T> result;

            using (IDbConnection connection = new SQLiteConnection(GetConnection()))
            {
               result = connection.QueryAsync<T>(sql, argument).Result;
            }

            return Task.FromResult((List<T>)result);
        }

        public static Task<T> BuscarValor<T, R>(string sql, R argument)
        {
            using (IDbConnection connection = new SQLiteConnection(GetConnection()))
            {
               return Task.FromResult(connection.QueryFirstOrDefaultAsync<T>(sql, argument).Result);
            }
        }

        public static void DeletarValor<T>(string sql, T argument)
        {
            using (IDbConnection connection = new SQLiteConnection(GetConnection()))
            {
                connection.Execute(sql, argument);
            }
        }
    }
}