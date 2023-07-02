using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper;

using Peluqueria_Calibrum.Models;

namespace Peluqueria_Calibrum.Controllers
{
    public class CitasController : MyController
    {
        [Route("ListaCitas")]
        public IActionResult Citas()
        {
            
            GetTables();
            return View();
        }



        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult GetCitas()
        {
            IEnumerable<CitaModel> lst = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT Cita.*, CONCAT(Empleado.Nombre, ' ', Empleado.Apellido) AS Nombre_Empleado, Servicio.Precio AS Precio_Total " +
                          "FROM Cita " +
                          "JOIN Empleado ON Cita.Id_Empleado = Empleado.Id " +
                          "JOIN Servicio ON Cita.Id_Servicio = Servicio.Id";
                lst = db.Query<Models.CitaModel>(sql);
            }
            return View(lst);
        }


        /*Metodo para buscar datos en la base de datos*/
        [HttpGet]
        public IActionResult BuscarCitas(string servicio, string empleado)
        {
            IEnumerable<Models.CitaModel> lst = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT Cita.*, CONCAT(Empleado.Nombre, ' ', Empleado.Apellido) AS Nombre_Empleado, Servicio.Precio AS Precio_Total" +
                            " FROM Cita" +
                            " JOIN Empleado ON Cita.Id_Empleado = Empleado.Id" +
                            " JOIN Servicio ON Cita.Id_Servicio = Servicio.Id" +
                            " WHERE 1 = 1 ";

                if (!string.IsNullOrEmpty(servicio))
                {
                    sql += " AND Nombre_servicio LIKE '%%' ";
                }

                if (!string.IsNullOrEmpty(empleado))
                {
                    sql += " AND CONCAT(Empleado.Nombre, ' ', Empleado.Apellido) LIKE '%Juan Muñoz%'";
                }

                var parameters = new { nombre_servicio = $"%{servicio}%", nombre_empleado = $"%{empleado}%" };



                lst = db.Query<Models.CitaModel>(sql, parameters);
            }
            return PartialView("_TablaCitas", lst);
        }




        /*Metodo para ingresar datos en la base de datos*/
        [HttpPost]
        public IActionResult InsertCitas(Models.CitaModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "INSERT INTO Cita(Hora, Dia, Nombre_cliente,  Telefono, Nombre_servicio) " +
                    " values(@hora, @dia, @nombre_cliente,  @telefono, @nombre_servicio)";
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Citas");
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





        /*Metodo para llamar a la CITA que se va a EDITAR*/
        [HttpGet]
        public IActionResult GetCitaEdit(int id)
        {
            Models.CitaModel cita = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Cita WHERE Id = @id";
                cita = db.QuerySingleOrDefault<Models.CitaModel>(sql, new { id });
            }
            return Json(cita);
        }
        /*Metodo para EDITAR la CITA que se llamo*/
        [HttpPost]
        public IActionResult UpdateCita(Models.CitaModel model, int id)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "UPDATE Cita SET Dia=@dia, Hora=@hora, Nombre_cliente=@nombre_cliente, Telefono=@telefono, Id_Servicio=@id_servicio,   WHERE Id = @id";
                model.Id = id;
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Citas");
        }




        /*Union varias tablas*/
        public ActionResult GetTables()
        {
            var empleadoServicioModel = new EmpleadoServicioModel();

            var listaEmpleados = ObtenerListaEmpleados();
            var listaServicios = ObtenerListaServicios();
            var listaCitas = ObtenerListaCitas();

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

        private List<CitaModel> ObtenerListaCitas()
        {
            List<CitaModel> listaCitas;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT Cita.*, CONCAT(Empleado.Nombre, ' ', Empleado.Apellido) AS Nombre_Empleado, Servicio.Precio AS Precio_Total " +
                          "FROM Cita " +
                          "JOIN Empleado ON Cita.Id_Empleado = Empleado.Id " +
                          "JOIN Servicio ON Cita.Id_Servicio = Servicio.Id";
                listaCitas = db.Query<CitaModel>(sql).ToList();
            }
            return listaCitas;
        }
        /*FIN Union varias tablas*/







    }
}
