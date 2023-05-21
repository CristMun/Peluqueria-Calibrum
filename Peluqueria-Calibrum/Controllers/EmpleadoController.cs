using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Common;

namespace Peluqueria_Calibrum.Controllers
{

    public class EmpleadoController : MyController
    {
        [Route("ListaEmpleado")]
        public IActionResult Empleado()
        {
            GetEmpleados();
            return View();
        }

        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult GetEmpleados() 
        {
            IEnumerable<Models.EmpleadoModel> lst = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Empleado";
                lst = db.Query<Models.EmpleadoModel>(sql);
            }
            return View(lst);
        }

        /*Metodo para ingresar datos en la base de datos*/
        [HttpPost]
        public IActionResult InsertEmpleado(Models.EmpleadoModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "INSERT INTO Empleado(Nombre, Apellido, Usuario, Contrasena, Cargo, Dias, Hora, Servicios) " +
                    " values(@nombre, @apellido, @usuario, @contrasena, @cargo, @dias, @hora, @servicios)";
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Empleado");
        }

        /*Metodo para Eliminar datos en la base de datos*/
        [HttpDelete]
        public IActionResult DeleteEmpleado(Models.EmpleadoModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "DELETE FROM Empleado WHERE Id=@id";
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Empleado");
        }




        [HttpGet]
        public IActionResult GetEmpleado(int id)
        {
            Models.EmpleadoModel empleado = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Empleado WHERE Id = @id";
                empleado = db.QuerySingleOrDefault<Models.EmpleadoModel>(sql, new { id });
            }
            return Json(empleado);
        }

        [HttpPost]
        public IActionResult UpdateEmpleado(Models.EmpleadoModel model, int id)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "UPDATE Empleado SET Nombre = @nombre, Apellido = @apellido, Usuario = @usuario, " +
                          "Contrasena = @contrasena, Cargo = @cargo, Dias = @dias, Hora = @hora, Servicios = @servicios " +
                          "WHERE Id = @id";
                model.Id = id; // Actualizar el ID del modelo con el ID recibido en la solicitud
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Empleado");
        }


    }
}
