﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using Dapper;
using Peluqueria_Calibrum.Models;


namespace Peluqueria_Calibrum.Controllers
{
    public class InicioController : MyController
    {
        public IActionResult CitasHoy()
        {
            GetTables();
            return View();
        }

        /* Union varias tablas */
        public ActionResult GetTables()
        {
            var empleadoServicioModel = new UnionModel();

            var listaEmpleados = ObtenerListaEmpleados();
            var listaServicios = ObtenerListaServicios();

            // Obtener el nombre del empleado de la sesión
            var nombreEmpleado = HttpContext.Session.GetString("NombreEmpleado");

            var listaCitas = ObtenerListaCitas(nombreEmpleado);

            if (listaEmpleados != null && listaServicios != null)
            {
                empleadoServicioModel.Empleados = listaEmpleados;
                empleadoServicioModel.Servicios = listaServicios;
                empleadoServicioModel.Citas = listaCitas;
            }
            else
            {
                return View(empleadoServicioModel);
            }

            return View(empleadoServicioModel);
        }



        private List<EmpleadoModel> ObtenerListaEmpleados()
        {
            List<EmpleadoModel> listaEmpleados;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Empleado WHERE Cargo<>'Administrador'";
                listaEmpleados = db.Query<EmpleadoModel>(sql).ToList();
            }
            return listaEmpleados;
        }
        private List<ServicioModel> ObtenerListaServicios()
        {
            List<ServicioModel> listaServicios;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Servicio where Mostrar_Home=1";
                listaServicios = db.Query<ServicioModel>(sql).ToList();
            }
            return listaServicios;
        }

        private List<CitaModel> ObtenerListaCitas(string nombreEmpleado)
        {
            List<CitaModel> listaCitas;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT Cita.*, CONCAT(Empleado.Nombre, ' ', Empleado.Apellido) AS Nombre_Empleado, Servicio.Precio AS Precio_Total " +
                          "FROM Cita " +
                          "JOIN Empleado ON Cita.Id_Empleado = Empleado.Id " +
                          "JOIN Servicio ON Cita.Id_Servicio = Servicio.Id " +
                          "WHERE Empleado.Nombre = @NombreEmpleado AND Cita.Dia = CURDATE() ORDER BY Cita.Finalizado DESC;";
                listaCitas = db.Query<CitaModel>(sql, new { NombreEmpleado = nombreEmpleado }).ToList();
            }
            return listaCitas;
        }

        /*FIN Union varias tablas*/

        /*Metodo para finalizar cita*/
        [HttpPost]
        public JsonResult FinalizarCita(int citaId)
        {
            try
            {
                using (var db = new MySqlConnection(MyController.csCal))
                {
                    var sql = "UPDATE Cita SET Finalizado = 1 WHERE Id = @citaId";
                    var result = db.Execute(sql, new { citaId });
                }

                return Json(new { success = true, message = "Cita marcada como finalizada" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        /*Metodo para editar datos en la base de datos*/
        [HttpDelete]
        public IActionResult DeleteCitas(Models.CitaModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "DELETE FROM Cita WHERE Id=@id";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

    }
}
