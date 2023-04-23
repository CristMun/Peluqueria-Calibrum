using Microsoft.AspNetCore.Mvc;
using Peluqueria_Calibrum.Models;
using System.Diagnostics;

namespace Peluqueria_Calibrum.Controllers
{
    public class HomeController : MyController
    {
        private string _connection = @"Server=sql777.main-hosting.eu;Database=u364986239_calibrum;Uid=u364986239_admin_calibrum;Password=2d839@sT";
        
        [Route("Inicio")]
        public IActionResult Index()
        {
            return View();
        }
        /*Aqui llamar a los clientes dependiendo del trabajador*/

    }
}