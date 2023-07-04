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
            GetTables();
            return View();
        }
        public IActionResult Comprobante()
        {
            GenerarComprobante();
            return View();
        }

        /*Union de EmpleadoModel con ServicioModel*/
        public ActionResult GetTables()
        {
            var empleadoServicioModel = new UnionModel();

            var listaEmpleados = ObtenerListaEmpleados();
            var listaServicios = ObtenerListaServicios();
            var listaGestiones = ObtenerListaGestiones();
            var listaHoras = ObtenerListaHoras();

            if (listaEmpleados != null && listaServicios != null)
            {
                empleadoServicioModel.Empleados = listaEmpleados;
                empleadoServicioModel.Servicios = listaServicios;
                empleadoServicioModel.Gestiones = listaGestiones;
                empleadoServicioModel.Horas = listaHoras;
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
                var sql = "SELECT * FROM Servicio";
                listaServicios = db.Query<ServicioModel>(sql).ToList();
            }
            return listaServicios;
        }

        private List<GestionModel> ObtenerListaGestiones()
        {
            List<GestionModel> listaGestiones;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Gestion ORDER BY Id DESC LIMIT 1;";
                listaGestiones = db.Query<GestionModel>(sql).ToList();
            }
            return listaGestiones;
        }
        private List<HorasModel> ObtenerListaHoras()
        {
            List<HorasModel> listaHoras;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Horas";
                listaHoras = db.Query<HorasModel>(sql).ToList();
            }
            return listaHoras;
        }
        /*FIN Union de EmpleadoModel con ServicioModel*/

        [HttpPost]
        public void InsertCitasInicio(CitaModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "INSERT INTO Cita (Hora, Dia, Nombre_cliente, Telefono, Nombre_servicio, Id_Empleado, Id_Servicio, Finalizado) " +
                          "SELECT @hora, @dia, @nombre_cliente, @telefono, Servicio.Nombre, @id_empleado, Servicio.Id, 0 " +
                          "FROM Servicio " +
                          "WHERE Servicio.Id = @id_servicio";
                result = db.Execute(sql, new
                {
                    model.Hora,
                    model.Dia,
                    model.Nombre_cliente,
                    model.Telefono,
                    model.Id_Empleado,
                    model.Id_Servicio
                });
            }
        }

        /*Método para mostrar los últimos datos en el comprobante*/
        [HttpGet]
        public IActionResult GenerarComprobante()
        {
            CitaModel lastInsertedCita;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Cita ORDER BY Id DESC LIMIT 1";
                lastInsertedCita = db.QuerySingleOrDefault<CitaModel>(sql);
            }

            return View(lastInsertedCita);
        }








    }
}