using LabMVC.DbSqLite;
using LabMVC.DTO;
using LabMVC.Filtros;
using LabMVC.ModelViews;
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
                Clientes = clientes
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

        public ActionResult CadastrarCliente(Cliente clienteDTO)
        {
            if (clienteDTO == null || string.IsNullOrEmpty(clienteDTO.Nome) || string.IsNullOrEmpty(clienteDTO.Telefone))
            {
                Index();
                return View("index");
            }
            else
            {
                Cliente.Salvar(clienteDTO);

                Index();
                return View("index");
            }

        }

        public ActionResult DeletarCliente(int? id)
        {
            if (id == null)
            {
                Index();
                return View("index");
            }
            else
            {
                Cliente.Deletar(id);

                Index();
                return View("index");
            }
        }
    }
}