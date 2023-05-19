using LabMVC.Filtros;
using LabWebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class HomeController : LogadoController
    {
        [AutenticadoFilter]
        public ActionResult Index()
        {
            // if (!Logado()) return null;

            // return new HttpUnauthorizedResult();
            var clientes = Cliente.Todos();
            ViewBag.clientes = clientes;
            //ViewData["clientes ssds"] = Cliente.Todos();
            return View(new
            {
                Clientes = clientes,
                Mensagem = "oi"
            });
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