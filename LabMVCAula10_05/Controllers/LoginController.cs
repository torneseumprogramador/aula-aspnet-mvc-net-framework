using System;
using System.Web;
using System.Web.Mvc;
using LabMVCAula10_05.Models;
using LabMVCAula10_05.ModelViews;
using LabMVCAula10_05.Request;
using Newtonsoft.Json;

namespace LabMVCAula10_05.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logar(LoginRequest _login)
        {
            if(_login.Login == null || string.IsNullOrEmpty(_login.Login) || string.IsNullOrEmpty(_login.Senha))
            {
                return View("index", new ErroModelView{ Mensagem = "Login ou senha invalida"});
            }

            Usuario usuario = new Usuario
            {
                Senha = _login.Senha,
                Login = _login.Login
            };

            if (usuario.VerificarUsuario())
            {
                var cookie = new HttpCookie("usuario_logado");
                cookie.Value = JsonConvert.SerializeObject(_login);
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);


                
                //Session["usuario_logado"] = _login;
                return Redirect("/");
            }
            return View("index", new ErroModelView { Mensagem = "Login ou senha invalida"});
  
        }
    }
}