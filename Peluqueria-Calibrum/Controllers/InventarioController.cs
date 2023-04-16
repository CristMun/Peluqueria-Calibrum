using Microsoft.AspNetCore.Mvc;

namespace Peluqueria_Calibrum.Controllers
{
    public class InventarioController : Controller
    {
        public IActionResult Inventario()
        {
            return View();
        }
    }
}
