using Microsoft.AspNetCore.Mvc;
using Peluqueria_Calibrum;

namespace PeluqueriaCalibrum.Controllers
{
    [Route("Login")]
    [ApiController]
    public class LoginController : MyController
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
