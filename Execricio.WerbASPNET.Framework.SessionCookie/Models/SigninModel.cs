using Execricio.WerbASPNET.Framework.SessionCookie.Configurations;
using Execricio.WerbASPNET.Framework.SessionCookie.Configurations.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Models
{
    public class SigninModel : AccessDTO
    {
        public AccessType AccessType => AccessType.Signin;
        public UserModel User { get; set; }
    }
}