using System.Web;
using System.Web.Mvc;

namespace Execricio.WerbASPNET.Framework.SessionCookie
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
