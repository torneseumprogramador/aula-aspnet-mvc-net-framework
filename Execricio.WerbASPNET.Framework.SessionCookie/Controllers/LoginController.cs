﻿using Execricio.WerbASPNET.Framework.SessionCookie.Services;
using Execricio.WerbASPNET.Framework.SessionCookie.ViewModel;
using System.Net.Sockets;
using System.Text;
using System.Web.Mvc;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool loginValido = model.Username == "admin" && model.Password == "admin";

                //var hashed = PasswordHasher.HashPassword(model.Password);
                //var unhashed = PasswordHasher.UnhashPassword(hashed);
                //bool senhaConfere = PasswordHasher.VerifyPassword(unhashed, hashed);

                if (loginValido)
                {
                    TempData["User"] = model.Username;

                    Session["Login"] = model;
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciais inválidas. Tente novamente.");
                }
            }
            return View(model);
        }
    }
}