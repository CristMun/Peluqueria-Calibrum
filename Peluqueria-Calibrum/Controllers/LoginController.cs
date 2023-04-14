using Microsoft.AspNetCore.Mvc;

namespace PeluqueriaCalibrum.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
