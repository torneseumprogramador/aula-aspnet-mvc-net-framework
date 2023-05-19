using Execricio.WerbASPNET.Framework.SessionCookie.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

                if (loginValido)
                {
                    ViewBag.UserLoged = $"Olá, {model.Username}";
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