using Microsoft.AspNetCore.Mvc;
using Peluqueria_Calibrum;

namespace PeluqueriaCalibrum.Controllers
{

    public class LoginController : MyController
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
