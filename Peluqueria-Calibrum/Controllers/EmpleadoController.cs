using Microsoft.AspNetCore.Mvc;

namespace Peluqueria_Calibrum.Controllers
{

    public class EmpleadoController : Controller
    {
        public IActionResult Empleado()
        {
            return View();

        }

        [HttpGet]
        public Empleado Get()
        {
            // ESTO ES POR MIENTRAS!
           Empleado oEmpleado= new Empleado() {
               Id_Empleado = 1,
               Nombre = "Cristobal", 
               Apellido = "Munoz",
               Usuario = "cris_mun",
               Contrasena = "123456",
               Horario = "Lunes a Viernes, de 09:00 - 18:00",
               Cargo = "Administrativo"
           };
            return oEmpleado;
        }
    }

    public class Empleado
    {
        public int Id_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Horario { get; set; }
        public string Cargo { get; set; }

    }

}
