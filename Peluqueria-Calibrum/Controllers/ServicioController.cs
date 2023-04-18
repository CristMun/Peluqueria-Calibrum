using Microsoft.AspNetCore.Mvc;

namespace Peluqueria_Calibrum.Controllers
{
    public class ServicioController : Controller
    {
        public IActionResult Servicio()
        {
            return View();
        }
        public IActionResult AgregarServicio()
        {
            return View();
        }
    }
}
