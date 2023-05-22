using LabMVC.Models.Response;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index(UsuarioModel usuario)
        {
            if (usuario.Nome == null)
            {
                //usuario = BuscarUsuarioSession();
                usuario = BuscarUsuarioCookie();
            }
            ViewBag.Usuario = usuario;
            var teste = new UsuarioModel().BuscarUsuarios();
            ViewBag.Usuarios = new UsuarioModel().BuscarUsuarios();

            return View();
        }

        private UsuarioModel BuscarUsuarioSession()
        {
            if (string.IsNullOrEmpty(Session["usuarioSession"].ToString()))
            {
                return new UsuarioModel();
            }
            string usuarioEncriptado = Session["usuarioSession"].ToString();
            var usuarioDecriptado = Cripto.Encript.Decrypt(usuarioEncriptado, "12188282sjjabqghhnnwqwqw");
            var usuario = JsonConvert.DeserializeObject<UsuarioModel>(usuarioDecriptado);
            return usuario;
        }

        private UsuarioModel BuscarUsuarioCookie()
        {
            if (string.IsNullOrEmpty(Request.Cookies["usuarioCookie"].Value))
            {
                return new UsuarioModel();
            }
            var usuarioEncriptado = Request.Cookies["usuarioCookie"].Value;
            var usuarioDecriptado = Cripto.Encript.Decrypt(usuarioEncriptado, "12188282sjjabqghhnnwqwqw");
            var usuario = JsonConvert.DeserializeObject<UsuarioModel>(usuarioDecriptado);
            return usuario;
        }
    }
}