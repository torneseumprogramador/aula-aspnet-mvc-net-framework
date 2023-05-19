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
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Title = "Login";
            return View();
        }

        [HttpPost]
        public ActionResult LoginUsuario(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userExists = model.Username == "admin" && model.Password == "admin";

                if (userExists)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Usuário ou senha inválidos.");
                    return View(model);
                }
            }

            return View(model);
        }
    }
}