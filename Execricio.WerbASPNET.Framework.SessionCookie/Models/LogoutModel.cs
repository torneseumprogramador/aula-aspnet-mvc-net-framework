using Execricio.WerbASPNET.Framework.SessionCookie.Configurations;
using Execricio.WerbASPNET.Framework.SessionCookie.Configurations.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Models
{
    public class LogoutModel : AccessDTO
    {
        public AccessType AccessType => AccessType.Logout;
    }
}