using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class LogadoController : Controller
    {
        public bool Logado()
        {
            if (Session["usuarioSession"] == null || Request.Cookies["usuarioCookie"].Value == null)
            {
                Response.Redirect("/login");
                return false;
            }
            else
            {
                RedirectToAction("Index", "Usuario");
            }

            return true;
        }
    }
}