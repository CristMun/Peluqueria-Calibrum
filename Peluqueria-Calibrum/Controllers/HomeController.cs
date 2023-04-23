using Microsoft.AspNetCore.Mvc;
using Peluqueria_Calibrum.Models;
using System.Diagnostics;

namespace Peluqueria_Calibrum.Controllers
{
    public class HomeController : MyController
    {
        [Route("Inicio")]
        public IActionResult Index()
        {
            return View();
        }
        /*Aqui llamar a los clientes dependiendo del trabajador*/

    }
}