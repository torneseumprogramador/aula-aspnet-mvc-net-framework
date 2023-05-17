using LabMVC.DTO;
using LabMVC.ModelViews;
using LabWebForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if(loginDTO.Login == "cah" && loginDTO.Senha == "123456")
            {
                var cookie = new HttpCookie("usuario_logado");

                string encryptedText = LabMVC.Cripto.Encript.Encrypt(JsonConvert.SerializeObject(loginDTO), "12188282sjjabqghhnnwqwqw");

                cookie.Value = encryptedText;
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                //Session["usuario_logado"] = loginDTO; 

                return Redirect("/");
            }

            return View("index", new ErroModelView { Mensagem = "Login ou senha inválida" });
        }
    }
}