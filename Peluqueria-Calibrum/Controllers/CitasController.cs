using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Peluqueria_Calibrum.Controllers
{
    
    public class CitasController : MyController
    {
        [Route("ListaCitas")]
        public IActionResult Citas()
        {
            GetCitas();
            return View();
        }

        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult GetCitas()
        {
            IEnumerable<Models.CitaModel> lst = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Cita";
                lst = db.Query<Models.CitaModel>(sql);
            }
            return View(lst);
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
        [HttpPut]
        public IActionResult EditCitas(Models.CitaModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "UPDATE Cita set Hora=@hora, Dia=@dia, Nombre_cliente=@nombre_cliente, Telefono=@telefono, Precio_total=@precio_total";
                result = db.Execute(sql, model);
            }
            return Ok(result);
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
