using Microsoft.AspNetCore.Mvc;
using Peluqueria_Calibrum.Models;
using MySql.Data.MySqlClient;
using Dapper;
using MySqlX.XDevAPI;
using System;

namespace Peluqueria_Calibrum.Controllers
{
    public class LoginController : Controller
    {
        [Route("IniciarSesion")]
        public IActionResult Login()
        {
            var empleado = new EmpleadoModel(); // Crea una nueva instancia de EmpleadoModel
            return View(empleado); // Pasa el modelo a la vista
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
                    var sqlNombre = "SELECT Nombre FROM Empleado WHERE Usuario = @usuario";
                    var nombre = connection.ExecuteScalar<string>(sqlNombre, new { usuario = empleado.Usuario });

                    ViewData["NombreUsuario"] = nombre;

                    var sqlCargo = "SELECT Cargo FROM Empleado WHERE Usuario = @usuario";
                    var cargo = connection.ExecuteScalar<string>(sqlCargo, new { usuario = empleado.Usuario });

                    if (cargo == "Administrador")
                    {
                        HttpContext.Session.SetString("EsAdministrador", "true");
                        HttpContext.Session.Remove("EsPeluqueroOBarbero"); // Elimina el valor anterior si existe
                    }
                    else if (cargo == "Peluquero" || cargo == "Barbero")
                    {
                        HttpContext.Session.SetString("EsPeluqueroOBarbero", cargo);
                        HttpContext.Session.Remove("EsAdministrador"); // Elimina el valor anterior si existe
                    }
                    else
                    {
                        HttpContext.Session.Remove("EsAdministrador"); // Elimina el valor anterior si existe
                        HttpContext.Session.Remove("EsPeluqueroOBarbero"); // Elimina el valor anterior si existe
                    }

                    return RedirectToAction("CitasHoy", "Inicio");
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
