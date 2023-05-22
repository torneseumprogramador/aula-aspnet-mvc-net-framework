using AspNetFrameworkMVC.Filtros;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    [AutenticadoFilter]
    public class HomeController : LogadoController
    {
        public ActionResult Index()
        {
            //if (!Logado())
            //{
            //    return null;
            //}

            return new HttpUnauthorizedResult();

            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }
        public ActionResult About(int id)
        {
            ViewBag.Message = "Descrição about cairo.";
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}