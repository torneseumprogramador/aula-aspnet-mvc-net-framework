using Execricio.WerbASPNET.Framework.SessionCookie.Configurations.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Configurations
{
    public class AccessDTO
    {
        public string Username { get; set; }
        public string PasswordHashed { get; set; }
        public bool Sucess { get; set; }
        public AuthenticationType Authentication { get; set; }
    }
}