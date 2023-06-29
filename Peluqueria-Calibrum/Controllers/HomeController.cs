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
            GetEmpServ();
            return View();
        }
        public IActionResult Comprobante()
        {
            return View();
        }

        /*Union de EmpleadoModel con ServicioModel*/
        public ActionResult GetEmpServ()
        {
            var empleadoServicioModel = new EmpleadoServicioModel();

            var listaEmpleados = ObtenerListaEmpleados();
            var listaServicios = ObtenerListaServicios();
            var listaGestiones = ObtenerListaGestiones();

            if (listaEmpleados != null && listaServicios != null)
            {
                empleadoServicioModel.Empleados = listaEmpleados;
                empleadoServicioModel.Servicios = listaServicios;
                empleadoServicioModel.Gestiones = listaGestiones;
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
        /*FIN Union de EmpleadoModel con ServicioModel*/

        /*Metodo para ingresar datos en la base de datos*/
        [HttpPost]
        public IActionResult InsertCitasInicio(CitaModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "INSERT INTO Cita (Hora, Dia, Nombre_cliente, Telefono, Nombre_servicio, Id_Empleado, Id_Servicio) " +
                          "SELECT @hora, @dia, @nombre_cliente, @telefono, Servicio.Nombre, @id_empleado, Servicio.Id " +
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
            return View("Comprobante");
        }







    }
}