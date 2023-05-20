using Execricio.WerbASPNET.Framework.SessionCookie.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public IDbConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}