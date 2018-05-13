using Lojinha.Data;
using Lojinha.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Lojinha.Controllers
{
    public class HomeController : Controller
    {

        private readonly LojinhaContext _lojinhaContext;
        public HomeController(LojinhaContext lojinhaContext)
        {
            _lojinhaContext = lojinhaContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var pedido_item = new Itens();
            var cont = 0;
            decimal soma = 0;

            foreach(var it in _lojinhaContext.Itens.ToList())
            {
                cont = cont + 1;
                foreach(var pr in _lojinhaContext.Produtos.ToList())
                {
                    if(pr.Id == it.ProdutoId)
                    {
                        soma = soma + pr.PrecoUnitario;
                    }
                }
            }

            ViewData["cont"] = cont;
            ViewData["soma"] = soma;
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
