using Microsoft.AspNetCore.Mvc;
using Sol.PuntoVenta.Entidades;
using Sol.PuntoVenta.Negocio.Negocios;
using Sol.PuntoVenta.Web.Presentacion.Models;
using System.Diagnostics;

namespace Sol.PuntoVenta.Web.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;  
        }

        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(View());
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
