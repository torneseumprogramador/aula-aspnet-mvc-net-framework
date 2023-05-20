using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Filters
{
    public class AuthenticateCookieFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies["AuthenticationCookie"] == null)
                filterContext.Result = new HttpUnauthorizedResult();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result is HttpUnauthorizedResult)
                filterContext.Result = new RedirectResult("~/Login/Index");

        }
    }


}