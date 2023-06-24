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

            if (listaEmpleados != null && listaServicios != null)
            {
                empleadoServicioModel.Empleados = listaEmpleados;
                empleadoServicioModel.Servicios = listaServicios;
            }
            else
            {
                return View(empleadoServicioModel);
            }

            return View(empleadoServicioModel);
        }

        /*Union de EmpleadoModel con ServicioModel*/
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



        


        /*Metodo para ingresar datos en la base de datos*/
        [HttpPost]
        public IActionResult InsertCitasInicio(Peluqueria_Calibrum.Models.CitaModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "INSERT INTO Cita (Hora, Dia, Nombre_cliente, Telefono, Nombre_servicio, Id_Empleado) " +
                          "SELECT @hora, @dia, @nombre_cliente, @telefono, @nombre_servicio, Empleado.Id " +
                          "FROM Empleado WHERE Empleado.Id = @id_empleado";
                result = db.Execute(sql, model);
            }
            return View("Comprobante");
        }




        

    }
}