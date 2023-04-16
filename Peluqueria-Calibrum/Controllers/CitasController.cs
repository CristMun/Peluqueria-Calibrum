using Microsoft.AspNetCore.Mvc;

namespace Peluqueria_Calibrum.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Citas()
        {
            return View();
        }
    }
}
