using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Aula()
        {
            var aula = new AulaModel { Nome = "Aula de .NET", Turma = "1TDSPR" };

            return View(aula);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(AulaModel aula)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Listar");
            }
            return View(aula);
        }

        public IActionResult Listar()
        {
            var aulas = new List<AulaModel>
            {
                new AulaModel { Nome = "Aula de .NET", Turma = "1TDSPR" },
                new AulaModel { Nome = "Aula de Java", Turma = "2TDSPR" },
                new AulaModel { Nome = "Aula de PHP", Turma = "3TDSPR" }
            };

            return View(aulas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
