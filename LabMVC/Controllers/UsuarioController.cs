using LabMVC.Cripto;
using LabMVC.DTO;
using LabMVC.Filtros;
using LabMVC.Models;
using LabMVC.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private static RNGCryptoServiceProvider _criptoServiceProvider = new RNGCryptoServiceProvider();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form(int? id, UsuarioDTO usuario)
        {
            if(id == null)
            {
                ViewBag.TituloOperacao = "Cadastro de";
                ViewBag.BotaoOperacao = "Cadastrar";

                Usuario novoUsuario = new Usuario();

                novoUsuario.Nome = usuario.Nome;
                novoUsuario.Login = usuario.Login;
                novoUsuario.Email = usuario.Email;
                if(!string.IsNullOrEmpty(usuario.Senha))
                {
                    novoUsuario.Senha = HashGen.hashficaSenha(usuario.Senha);
                   
                    Session["usuario"] = novoUsuario;
                    return  RedirectToAction("Index","Home");
                }

                return View("FormUsuario");
            }
            else
            {
                ViewBag.TituloOperacao = "Atualização";
                ViewBag.BotaoOperacao = "Atualizar";
            }

            return View();
        }
    }
}