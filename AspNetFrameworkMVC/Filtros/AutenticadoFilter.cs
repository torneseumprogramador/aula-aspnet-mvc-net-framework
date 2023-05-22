using AspNetFrameworkMVC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace AspNetFrameworkMVC.Filtros
{
    public class AutenticadoFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private const string sessionName = "usuario_logado";
        
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var session = filterContext.HttpContext.Session[sessionName];
            if (session != null)
            {
                LoginDTO loginDTO = (LoginDTO)session;

                //
                //
                //
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("/login");
            }
        }
    }
}