using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Repositories.Interfaces.Sqlite
{
    public interface ISqliteRepository
    {
        IEnumerable<UserModel> Users();
        UserModel User(string username);
        LoginModel Login();
        LogoutModel Logout();
        bool Signin(UserModel);
    }
}
