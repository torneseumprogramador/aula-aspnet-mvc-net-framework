using LabMVC.Models;
using LabWebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace LabMVC.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            if (!Request.Form["nome"].IsEmpty())
            {
                Usuario usuario = new Usuario();
                usuario.Nome = Request.Form["nome"];
                usuario.Email = Request.Form["email"];
                usuario.Login = Request.Form["login"];
                usuario.Senha = Request.Form["senha"];
                usuario.Salvar();

                ViewBag.mensagem = "Cadastrado com sucesso!";
            }

            return RedirectToAction("Index", "Login", new { mensagem = ViewBag.mensagem });
        }
    }
}