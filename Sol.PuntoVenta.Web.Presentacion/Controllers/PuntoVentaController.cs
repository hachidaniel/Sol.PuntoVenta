using Microsoft.AspNetCore.Mvc;

namespace Sol.PuntoVenta.Web.Presentacion.Controllers
{
    public class PuntoVentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
