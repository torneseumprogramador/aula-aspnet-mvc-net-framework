using LabMVC.ModelViews;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Login";
            return View();
        }

        [HttpPost]
        public ActionResult LoginUsuario(LoginModelView model)
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