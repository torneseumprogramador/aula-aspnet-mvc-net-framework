using LabMVC.DTO;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace LabMVC.Filtros
{
    public class AutenticadoFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private const string name = "usuario_logado";

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            /*var session = filterContext.HttpContext.Session[name];
            if (session != null)
            {
                LoginDTO loginDTO = (LoginDTO)session;
                
                // Verifique a validade do cookie e faça a autenticação do usuário aqui
                // Por exemplo, você pode verificar se o cookie contém um token válido e autenticar o usuário com base nisso
                // Se a autenticação falhar, defina filterContext.Result como uma instância de HttpUnauthorizedResult
            }
            else
            {
                // O cookie de autenticação não está presente, redirecione para a página de login
                filterContext.Result = new HttpUnauthorizedResult();
            }*/

            var cookie = filterContext.HttpContext.Request.Cookies[name];
            if (cookie != null)
            {
                try
                {
                    string value = LabMVC.Cripto.Encript.Decrypt(cookie.Value, "12188282sjjabqghhnnwqwqw");
                    LoginDTO loginDTO = JsonConvert.DeserializeObject<LoginDTO>(value);
                }
                catch
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }

                // Verifique a validade do cookie e faça a autenticação do usuário aqui
                // Por exemplo, você pode verificar se o cookie contém um token válido e autenticar o usuário com base nisso
                // Se a autenticação falhar, defina filterContext.Result como uma instância de HttpUnauthorizedResult
            }
            else
            {
                // O cookie de autenticação não está presente, redirecione para a página de login
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                // O usuário não está autenticado, redirecione para a página de login
                filterContext.Result = new RedirectResult("~/Login");
            }
        }
    }

}