using AspNetFrameworkMVC.DTO;
using AspNetFrameworkMVC.ModelViews;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logar(LoginDTO loginDto)
        {
            //string login = Request.Form["login"];
            //string senha = Request.Form["senha"];

            if (loginDto == null || string.IsNullOrEmpty(loginDto.Login) || string.IsNullOrEmpty(loginDto.senha))
            {
                return View("index", new ErroModelView{ Mensagem = "Login ou senha inválida" });
            }

            if (loginDto.Login == "kairobc@hotmail.com" && loginDto.senha == "123456")
            {
                Session["usuario_logado"] = loginDto;

                return RedirectToAction("/");
            }

            return Redirect("/");
        }
       
    }
}