using AspNetFrameworkMVC.Cripto;
using AspNetFrameworkMVC.DTO;
using Newtonsoft.Json;
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
            //USANDO SESSION
            //var session = filterContext.HttpContext.Session[sessionName];
            //if (session != null)
            //{
            //    LoginDTO loginDTO = (LoginDTO)session;

            //    //Demais Validacies
            //}
            //else
            //{
            //    filterContext.Result = new HttpUnauthorizedResult();
            //}

            //USANDO COOKIE
            var cookie = filterContext.HttpContext.Request.Cookies[sessionName];
            if (cookie != null)
            {
                try
                {
                    string value = Encript.Decrypt(cookie.Value, "12188282sjjabqghhnnwqwqw");
                    LoginDTO loginDto = JsonConvert.DeserializeObject<LoginDTO>(value);
                }
                catch (Exception)
                {

                    filterContext.Result = new HttpUnauthorizedResult();
                }
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