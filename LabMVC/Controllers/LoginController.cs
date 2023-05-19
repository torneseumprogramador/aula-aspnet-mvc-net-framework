using LabMVC.DTO;
using LabMVC.Models;
using LabMVC.ModelViews;
using LabWebForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index(string mensagem = null)
        {
            ViewBag.mensagem = mensagem;
            return View();
        }

        public ActionResult Logar(LoginDTO loginDTO)
        {
            List<Usuario> usuarios = Usuario.Todos().Where(u => u.Login == loginDTO.Login && u.Senha == loginDTO.Senha).ToList();

            if (loginDTO == null || string.IsNullOrEmpty(loginDTO.Login) || string.IsNullOrEmpty(loginDTO.Senha) || usuarios.Count == 0) 
                return View("index", new ErroModelView { Mensagem = "Login ou senha inválida" });

            if(usuarios.Count() > 0 && usuarios[0].Login == loginDTO.Login)
            {
                var cookie = new HttpCookie("usuario_logado");

                string encryptedText = LabMVC.Cripto.Encript.Encrypt(JsonConvert.SerializeObject(loginDTO), "12188282sjjabqghhnnwqwqw");

                cookie.Value = encryptedText;
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                //Session["usuario_logado"] = loginDTO; 

                return RedirectToAction("Index", "Home", new { mensagem = "Bem vindo ao sistema" });
            }

            return View("index", new ErroModelView { Mensagem = "Login ou senha inválida" });
        }

        public ActionResult Logout()
        {
            //Matar sessão
            Response.Cookies.Remove("usuario_logado");

            return RedirectToAction("Index", "Login", new { mensagem = ViewBag.mensagem });
        }
    }

    
}