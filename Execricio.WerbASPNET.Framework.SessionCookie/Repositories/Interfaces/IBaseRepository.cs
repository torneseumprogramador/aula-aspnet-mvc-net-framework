using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        IDbConnection GetConnection();
    }
}
