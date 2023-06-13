using LabMVCAula10_05.Request;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace LabMVCAula10_05.Filtros
{
    public class AutenticadoFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private const string sessionName = "usuario_logado";
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //var session = filterContext.HttpContext.Session[sessionName];
            //if (session != null)
            //{

            //    LoginRequest loginRequest = (LoginRequest)session;

            //}
            //else
            //{
            //    filterContext.Result = new HttpUnauthorizedResult();
            //}


            var cookie = filterContext.HttpContext.Request.Cookies[sessionName];
            if (cookie != null)
            {

                LoginRequest loginRequest = JsonConvert.DeserializeObject<LoginRequest>(cookie.Value);

            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }


        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
           if(filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Login");
                 
            }
        }
    }
}