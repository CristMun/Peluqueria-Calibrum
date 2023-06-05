using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper;
using Peluqueria_Calibrum;
using System.Reflection;
using Peluqueria_Calibrum.Models;

namespace PeluqueriaCalibrum.Controllers
{

    public class HomeController : MyController
    {
        public IActionResult Home()
        {
            GetEquipo();
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

        /*Metodo para llamar los datos de los empleados para la vista de "Nuestro Equipo"*/
        public IActionResult GetEquipo()
        {
            List<EmpleadoModel> empleados;

            using (var connection = new MySqlConnection(MyController.csCal))
            {
                connection.Open();
                empleados = connection.Query<EmpleadoModel>("SELECT * FROM Empleado").ToList();
            }

            return View(empleados);
        }

        /*Metodo para ingresar datos en la base de datos*/
        [HttpPost]
        public IActionResult InsertCitasInicio(Peluqueria_Calibrum.Models.CitaModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "INSERT INTO Cita(Hora, Dia, Nombre_cliente,  Telefono, Nombre_servicio) " +
                    " values(@hora, @dia, @nombre_cliente,  @telefono, @nombre_servicio)";
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Home");
        }
    }
}