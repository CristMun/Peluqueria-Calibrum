using Microsoft.AspNetCore.Mvc;
using Peluqueria_Calibrum.Models;
using System.Diagnostics;

namespace Peluqueria_Calibrum.Controllers
{
    public class InicioEmpleadoController : MyController
    {
        [Route("CitasHoy")]
        public IActionResult CitasHoy()
        {
            return View();
        }
        /*Aqui llamar a los clientes dependiendo del trabajador*/

    }
}