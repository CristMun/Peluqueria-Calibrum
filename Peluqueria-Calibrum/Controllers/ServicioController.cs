using Dapper;
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
                var sql = "INSERT INTO Servicio(Nombre, Descripcion, Precio) " +
                    " values(@nombre, @descripcion, @precio)";
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
    }
}
