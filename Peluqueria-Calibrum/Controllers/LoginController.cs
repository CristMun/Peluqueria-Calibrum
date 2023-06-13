using Dapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Peluqueria_Calibrum.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Peluqueria_Calibrum.Controllers
{
    public class LoginController : Controller
    {
        // Acción para mostrar la vista de login
        [HttpGet]
        public ActionResult Login()
        {
            var model = new EmpleadoModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(EmpleadoModel model)
        {
            if (ModelState.IsValid)
            {
                bool loginSuccessful = VerifyLogin(model.Usuario, model.Contrasena);

                if (loginSuccessful)
                {
                    await SignInUser(model.Usuario);
                    return RedirectToAction("CitasHoy", "Inicio");
                }
                else
                {
                    ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
                }
            }

            return View(model);
        }

        private bool VerifyLogin(string username, string contrasena)
        {
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT COUNT(*) FROM Empleado WHERE Usuario = @Username AND Contrasena = @Contrasena";
                var count = db.ExecuteScalar<int>(sql, new { Username = username, Contrasena = contrasena });
                return count > 0;
            }
        }

        private async Task SignInUser(string username)
        {
            var claims = new[] {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Empleado")
            // Puedes agregar más reclamaciones según tus necesidades
        };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}