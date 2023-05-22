using LabMVC.Filtros;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    [AutenticadoFilter]
    public class HomeController : LogadoController
    {
        public ActionResult Index()
        {
            return RedirectToRoute("login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}