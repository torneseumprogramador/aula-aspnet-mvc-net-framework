using Execricio.WerbASPNET.Framework.SessionCookie.Models;
using Execricio.WerbASPNET.Framework.SessionCookie.Repositories.Interfaces.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Repositories.Sqlite
{
    public class SqliteRepository : BaseRepository, ISqliteRepository
    {
        private readonly string connectionString;

        public SqliteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<UserModel> Users()
        {
            using (IDbConnection connection = GetConnection())
            {
                string query = "SELECT * FROM Users";
                return connection.Query<UserModel>(query);
            }
        }

        public UserModel User(string username)
        {
            using (IDbConnection connection = new GetConnection())
            {
                string query = "SELECT * FROM Users WHERE Username = @Username";
                return connection.QuerySingleOrDefault<UserModel>(query, new { Username = username });
            }
        }

        public LoginModel Login()
        {
            // Implementação do método Login
            return new LoginModel();
        }

        public LogoutModel Logout()
        {
            // Implementação do método Logout
            return new LogoutModel();
        }

        public bool Signin(UserModel userModel)
        {
            // Implementação do método Signin
            return true;
        }
    }
}