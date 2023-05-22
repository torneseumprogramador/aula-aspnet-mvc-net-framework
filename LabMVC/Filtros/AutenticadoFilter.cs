using LabMVC.Models;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace LabMVC.Filtros
{
    public class AutenticadoFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private const string name = "usuarioCookie";

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies[name];
            if (cookie != null)
            {
                try
                {
                    //string value = Cripto.Encript.Decrypt(cookie.Value, "12188282sjjabqghhnnwqwqw");
                    //LoginModel login = JsonConvert.DeserializeObject<LoginModel>(value);
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        { "action", "Index" },
                        { "controller", "Usuario" },
                    });
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