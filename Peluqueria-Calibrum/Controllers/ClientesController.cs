using Microsoft.AspNetCore.Mvc;

namespace Peluqueria_Calibrum.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Clientes()
        {
            return View();
        }
    }
}