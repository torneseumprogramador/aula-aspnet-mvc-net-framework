using System.Web.Mvc;
using LabMVC.DTO;
using LabWebForms.Models;

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

        public ActionResult Form(int? id, ClienteDTO cliente)
        {

            if(id != null && cliente == null)
            {
                ViewBag.DadosCliente = Cliente.Recuperar((int)id);
                ViewBag.Operacao = "Atualizar";
            }

            return View("FormCliente");
        }

        public ActionResult Excluir(int? id)
        {
            if(id > 0) Cliente.Excluir((int)id);

            return RedirectToAction("Index", "Home");
        }
    }
}