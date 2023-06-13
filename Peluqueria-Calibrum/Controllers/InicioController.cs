using Microsoft.AspNetCore.Mvc;
using Peluqueria_Calibrum.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Peluqueria_Calibrum.Controllers
{
    public class InicioController : MyController
    {
        //[Authorize] // Agregar este atributo para restringir el acceso a usuarios autenticados
        public IActionResult CitasHoy()
        {
            return View();
        }
    }
}
