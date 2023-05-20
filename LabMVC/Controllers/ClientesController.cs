using System;
using System.Web.Mvc;
using LabMVC.DTO;
using LabWebForms.Models;
using Microsoft.Ajax.Utilities;

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

        public ActionResult Cadastrar(ClienteDTO cliente)
        {
            Cliente novoCliente = new Cliente();

            if(cliente.Nome != null && cliente.Telefone != null && cliente.Cidade != null)
            {
                novoCliente.Nome = cliente.Nome;
                novoCliente.Telefone = cliente.Telefone;
                novoCliente.Cidade = cliente.Cidade;
                novoCliente.Salvar();

                //Adicionar mensagem.
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Operacao = "Cadastrar";
            return View("FormCliente", new Cliente());

            //return RedirectToAction("Form", "Clientes", novoCliente);
        }

        public ActionResult Atualizar(int? id, ClienteDTO cliente)
        {
            if (cliente.Nome != null && cliente.Telefone != null && cliente.Cidade != null)
            {

                Cliente novoCliente = new Cliente();
                novoCliente.Id = (int)id;
                novoCliente.Nome = cliente.Nome;
                novoCliente.Telefone = cliente.Telefone;
                novoCliente.Cidade = cliente.Cidade;
                novoCliente.Atualizar();

                //Adicionar mensagem.
                return RedirectToAction("Index", "Home");
            }
            
            var clienteRender = Cliente.Recuperar((int)id);
            ViewBag.Operacao = "Atualizar";
            return View("FormCliente", clienteRender);
        }


        public ActionResult Form()
        {
            ModelState.Clear();

            ViewBag.Target = "Cadastrar";

            ViewBag.Operacao = "Teste";

            return View("FormCliente", new Cliente());
        }

        public ActionResult Excluir(int? id)
        {
            if(id > 0) Cliente.Excluir((int)id);

            return RedirectToAction("Index", "Home");
        }
    }
}