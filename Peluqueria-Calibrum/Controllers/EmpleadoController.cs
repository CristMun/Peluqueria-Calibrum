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
        [HttpGet]
        public IActionResult BuscarEmpleados(string nombreApellido, string cargo)
        {
            IEnumerable<Models.EmpleadoModel> lst = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Empleado WHERE 1 = 1";

                if (!string.IsNullOrEmpty(nombreApellido))
                {
                    sql += " AND (Nombre LIKE @nombre OR Apellido LIKE @apellido)";
                }

                if (!string.IsNullOrEmpty(cargo))
                {
                    sql += " AND Cargo = @cargo";
                }

                var parameters = new { nombre = $"%{nombreApellido}%", apellido = $"%{nombreApellido}%", cargo };

                lst = db.Query<Models.EmpleadoModel>(sql, parameters);
            }
            return PartialView("_TablaEmpleados", lst);
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


        

        /*Metodo para llamar al EMPLEADO que se va a EDITAR*/
        [HttpGet]
        public IActionResult GetEmpleadoEdit(int id)
        {
            Models.EmpleadoModel empleado = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Empleado WHERE Id = @id";
                empleado = db.QuerySingleOrDefault<Models.EmpleadoModel>(sql, new { id });
            }
            return Json(empleado);
        }
        /*Metodo para EDITAR al EMPLEADO llamada */
        [HttpPost]
        public IActionResult UpdateEmpleado(Models.EmpleadoModel model, int id)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "UPDATE Empleado SET Nombre = @nombre, Apellido = @apellido, Usuario = @usuario, " +
                          "Contrasena = @contrasena, Cargo = @cargo, Dias = @dias, Hora = @hora, Servicios = @servicios " +
                          "WHERE Id = @id";
                model.Id = id; 
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Empleado");
        }


    }
}
