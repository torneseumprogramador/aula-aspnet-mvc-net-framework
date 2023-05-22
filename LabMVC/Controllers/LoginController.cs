using LabMVC.Filtros;
using LabMVC.Models;
using LabMVC.ModelViews;
using Newtonsoft.Json;
using System;
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

        public ActionResult Logar(LoginModel loginDTO)
        {
            var login = loginDTO;
            if (login == null || string.IsNullOrEmpty(login.Login) || string.IsNullOrEmpty(login.Senha))
                return View("index", new MensagemModelView { Mensagem = "Login ou senha inválida", Sucesso = false });

            if (login.Login.Any() && login.Senha.Any())
            {
                var usuario = new UsuarioModel().ValidarUsuario(login);

                if (usuario.Sucesso)
                {
                    SalvarUsuarioNoCookie(usuario.Usuario);
                    SalvarUsuarioNoSession(usuario.Usuario);
                    return RedirectToAction("Index", "Usuario", usuario.Usuario);
                }
                else
                {
                    return View("index", new MensagemModelView { Mensagem = usuario.Mensagem, Sucesso = false });
                }
                
            }

            return View("index", new MensagemModelView { Mensagem = "Preencha os dois campos!", Sucesso = false });
        }

        public ActionResult Deslogar()
        {
            if (Request.Cookies["usuarioCookie"] != null)
            {
                var cookie = new HttpCookie("usuarioCookie");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            if (Session["usuarioSession"] != null)
            {
                Session.Remove("usuarioSession");
            }

            return View("index");
        }

        public ActionResult Cadastrar(CadastroModel cadastroModel)
        {
            if (string.IsNullOrEmpty(cadastroModel.Nome) || string.IsNullOrEmpty(cadastroModel.Email) ||
                string.IsNullOrEmpty(cadastroModel.Login) || string.IsNullOrEmpty(cadastroModel.Senha))
            {
                return View("index", new MensagemModelView { Mensagem = "Preencha todos os campos!", Sucesso = false });
            }

            bool usuarioCadastrado = new UsuarioModel().InserirUsuario(cadastroModel);

            if (usuarioCadastrado)
            {
                return View("index", new MensagemModelView { Mensagem = "Usuário cadastrado com sucesso!" });
            }
            else
            {
                return View("index", new MensagemModelView { Mensagem = "Erro ao cadastrar! Tente novamente em alguns instantes", Sucesso = false });
            }
  
            return View("index", new MensagemModelView { Mensagem = "Erro ao cadastrar! Tente novamente em alguns instantes", Sucesso = false });
        }

        private void SalvarUsuarioNoCookie(UsuarioModel usuario)
        {
            var cookie = new HttpCookie("usuarioCookie");
            string encryptedText = Cripto.Encript.Encrypt(JsonConvert.SerializeObject(usuario), "12188282sjjabqghhnnwqwqw");

            cookie.Value = encryptedText;
            cookie.Expires = DateTime.Now.AddDays(1);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);
        }

        private void SalvarUsuarioNoSession(UsuarioModel usuario)
        {
            string encryptedText = Cripto.Encript.Encrypt(JsonConvert.SerializeObject(usuario), "12188282sjjabqghhnnwqwqw");
            Session["usuarioSession"] = encryptedText;
        }
    }
}