using LabMVCAula10_05.Filtros;
using LabMVCAula10_05.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LabMVCAula10_05.Controllers
{
    public class ProdutoController : Controller
    {
        public ApiService _apiService = new ApiService();

        private readonly string urlProduto = "https://localhost:44395/api/Produto";

        public ProdutoController()
        {
            
        }

        [AutenticadoFilter]
        [Route("Produto/")]
        public async Task<ActionResult> Produto()
        {
            ViewBag.ListaProdutos = await _apiService.GetLista(urlProduto);

            return View(new ProdutoModel());
        }

        [Route("Produto/")]
        [HttpPost]
        public async Task<ActionResult> Salvar(ProdutoModel produto)
        {

            var response = await _apiService.Salvar(urlProduto, produto);
            var responseData = await response.Content.ReadAsStringAsync();
            

            // Trate a resposta recebida da API e retorne para a exibição
            return RedirectToAction("Produto");
        }

        public async Task<ActionResult> ExcluirProduto(int? id)
        {
            var response = await _apiService.Excluir (urlProduto, id);
            return RedirectToAction("Produto");
        }

        public async Task<ActionResult> GetProduto(int? id)

        {

            ViewBag.UmProduto = "xxxxxxxxxxxxxxxx";
            return RedirectToAction("Produto");
        }

        [Route("Produto/Editar")]
        public ActionResult EditarProduto(ProdutoModel produto)
        {
            ViewBag.Produto = new ProdutoModel()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao
            };

            return View();
        }

        //[HttpPost]
        //public ActionResult EditarProduto(ProdutoModel produto)
        //{
   
        //    return View();
        //}


        [HttpPost]
        public async Task<ActionResult> SalvarEdicaoProduto(ProdutoModel produto)
        {
            var response = await _apiService.Atualizar(urlProduto, produto);
            var responseData = await response.Content.ReadAsStringAsync();


            // Trate a resposta recebida da API e retorne para a exibição
            return RedirectToAction("Produto");
        }


    }
}