using LabMVC.Cripto;
using LabMVC.DTO;
using LabMVC.Filtros;
using LabMVC.Models;
using LabMVC.ModelViews;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logar(LoginDTO loginDTO)
        {

            if (loginDTO == null || string.IsNullOrEmpty(loginDTO.Login) || string.IsNullOrEmpty(loginDTO.Senha))
                return View("index", new ErroModelView { Mensagem = "Login ou senha inválida" });
   
            if (Usuario.AutenticaUsuario(loginDTO))
            {
                var cookie = new HttpCookie("usuario_logado");

                string encryptedText = LabMVC.Cripto.Encript.Encrypt(JsonConvert.SerializeObject(loginDTO), "12188282sjjabqghhnnwqwqw");

                cookie.Value = encryptedText;
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }
            
            return View("index", new ErroModelView { Mensagem = "Login ou senha inválida" });
        }

        public ActionResult Signout() 
        {
            var cookie = Response.Cookies["usuario_logado"];

            if(cookie != null)
            {
                Response.Cookies["usuario_logado"].Value = null;
                Response.Cookies["usuario_logado"].Expires = DateTime.Now.AddDays(-1);
            }

            return Redirect("/");
        }
    }
}