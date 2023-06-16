using Microsoft.AspNetCore.Mvc;
using Peluqueria_Calibrum.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace Peluqueria_Calibrum.Controllers
{
    public class LoginController : Controller
    {
        [Route("IniciarSesion")]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public IActionResult IniciarSesion(EmpleadoModel empleado)
        {
            using (var connection = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT COUNT(*) FROM Empleado WHERE Usuario = @usuario AND Contrasena = @contrasena";
                var count = connection.ExecuteScalar<int>(sql, empleado);

                if (count > 0)
                {
                    return RedirectToAction("CitasHoy","Inicio");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                    return View("Login");
                }
            }
        }
    }
}
