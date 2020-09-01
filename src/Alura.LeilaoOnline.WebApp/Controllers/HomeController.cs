using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Alura.LeilaoOnline.WebApp.Services;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IProdutoService Service { get; }

        public HomeController(IProdutoService service)
        {
            Service = service;
        }

        public IActionResult Index()
        {
            var categorias = Service.ConsultarCategoriasComTotalDeLeiloesEmPregao();    
            return View(categorias);
        }

        [Route("[controller]/StatusCode/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            if (statusCode == 404) return View("404");
            return View(statusCode);
        }

        [Route("[controller]/Categoria/{categoria}")]
        public IActionResult Categoria(int categoria)
        {
            var categ = Service.ConsultarCategoriaPorIdComLeiloesEmPregao(categoria);
            return View(categ);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = Service.PesquisarLeiloesEmPregaoPorTermo(termo);
            return View(leiloes);
        }
    }
}
