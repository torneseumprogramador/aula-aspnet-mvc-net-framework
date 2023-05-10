using LabWebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Cidades = new SelectList(Cidade.Todos(new Estado() { Id = 1 }), "Id", "Nome");
            return View();
        }

        public ActionResult HtmlPuro()
        {
            ViewBag.Cidades = Cidade.Todos(new Estado() { Id = 1 });
            return View(new Cliente());
        }
    }
}