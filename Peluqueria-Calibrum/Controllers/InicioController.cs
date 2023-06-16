using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Peluqueria_Calibrum.Controllers
{
    public class InicioController : MyController
    {
        public IActionResult CitasHoy()
        {
            return View();
        }

    }
}
