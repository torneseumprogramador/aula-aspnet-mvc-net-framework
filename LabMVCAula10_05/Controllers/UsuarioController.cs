using LabMVCAula10_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabMVCAula10_05.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuarioModel)
        {
            Usuario usuario = new Usuario
            {
                Nome = usuarioModel.Nome,
                Email = usuarioModel.Email,
                Senha = usuarioModel.Senha,
                Login = usuarioModel.Login
            };

            usuario.CadastrarUsuario();

            return RedirectToAction("Index", "Login");
        }

    }
}