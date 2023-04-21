using Microsoft.AspNetCore.Mvc;

namespace Peluqueria_Calibrum.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Agendar()
        {
            return View();
        }
        public IActionResult Peluqueros()
        {
            return View();
        }
        public IActionResult Principal()
        {
            return View();
        }
    }
}