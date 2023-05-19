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
        public static void SalvarCliente(Cliente cliente)
        {

        }

        private static string GetConnection(string id = "MinhaConexao")
        {
            string dataDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string connectionString = ConfigurationManager.ConnectionStrings[id].ConnectionString;

            connectionString = connectionString.Replace("|DataDirectory|", dataDirectory);

            return connectionString;
        }

        public static Task<List<T>> BuscarLista<T>(string sql)
        {
            IEnumerable<T> result;

            using (SQLiteConnection connection = new SQLiteConnection(GetConnection()))
            {
                result = connection.QueryAsync<T>(sql).Result;                
            }

            return Task.FromResult((List<T>)result);
        }

        public async Task<IEnumerable<T>> BuscarLista<T, S>(string sql, S argument)
        {
            IEnumerable<T> result;

            using (SQLiteConnection connection = new SQLiteConnection(GetConnection()))
            {
               return result = await connection.QueryAsync<T>(sql, argument);
            }
        }

        public async Task<T> BuscarValor<T, R>(string sql, R argument)
        {
            using (SQLiteConnection connection = new SQLiteConnection(GetConnection()))
            {
               return await connection.QueryFirstOrDefaultAsync<T>(sql, argument);
            }
        }
    }
}