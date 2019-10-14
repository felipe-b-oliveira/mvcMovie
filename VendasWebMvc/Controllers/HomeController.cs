using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vendasWebMvc.Models.ViewModels;

namespace vendasWebMvc.Controllers
{
    public class HomeController : Controller
    {
        // Os métodos do HomeController são as ações a sererem executadas
        // Ao retornar view o framework ira procurar uma página com o mesmo nome do método
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "App Vendas Web MVC do curso C#";
            ViewData["Nome"] = "Felipe Oliveira";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
