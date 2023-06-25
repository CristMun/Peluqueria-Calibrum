using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Peluqueria_Calibrum.Controllers
{
    public class ServicioController : MyController
    {
        [Route("ListaServicios")]
        public IActionResult Servicio()
        {
            GetServicios();
            return View();
        }

        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult GetServicios()
        {
            IEnumerable<Models.ServicioModel> lst = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Servicio";
                lst = db.Query<Models.ServicioModel>(sql);
            }
            return View(lst);
        }

        /*Metodo para ingresar datos en la base de datos*/
        [HttpPost]
        public IActionResult InsertServicios(Models.ServicioModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "INSERT INTO Servicio(Nombre, Descripcion, Precio, Categoria) " +
                    " values(@nombre, @descripcion, @precio, @categoria)";
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Servicio");
        }

        /*Metodo para editar datos en la base de datos*/
        [HttpDelete]
        public IActionResult DeleteServicios(Models.ServicioModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "DELETE FROM Servicio WHERE Id=@id";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }




        /*Metodo para llamar a la SERVICIO que se va a EDITAR*/
        [HttpGet]
        public IActionResult GetServiciosEdit(int id)
        {
            Models.ServicioModel servicio = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Servicio WHERE Id = @id";
                servicio = db.QuerySingleOrDefault<Models.ServicioModel>(sql, new { id });
            }
            return Json(servicio);
        }
        /*Metodo para EDITAR la SERVICIO que se llamo*/
        [HttpPost]
        public IActionResult UpdateServicio(Models.ServicioModel model, int id)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "UPDATE Servicio SET Nombre=@nombre, Descripcion=@descripcion, Precio=@precio WHERE Id = @id";
                model.Id = id;
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Servicio");
        }
    }
}
