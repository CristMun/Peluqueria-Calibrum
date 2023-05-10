using Microsoft.AspNetCore.Mvc;
using Peluqueria_Calibrum;

namespace PeluqueriaCalibrum.Controllers
{

    public class HomeController : MyController
    {
        public IActionResult Home()
        {
            return View();
        }
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
        [Route("Agendar")]
        public IActionResult Agendar()
        {
            return View();
        }
        [Route("Peluqueros")]
        public IActionResult Peluqueros()
        {
            return View();
        }
    }
}