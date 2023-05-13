using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Peluqueria_Calibrum.Controllers
{
    public class InventarioController : MyController
    {
        [Route("ListaInventario")]
        public IActionResult Inventario()
        {
            GetInventario();
            return View();
        }
        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult GetInventario()
        {
            IEnumerable<Models.InventarioModel> lst = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Inventario";
                lst = db.Query<Models.InventarioModel>(sql);
            }
            return View(lst);
        }

        /*Metodo para ingresar datos en la base de datos*/
        [HttpPost]
        
        public IActionResult InsertInventario(Models.InventarioModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "INSERT INTO Inventario(Nombre, Descripcion, Cantidad) " +
                    " VALUES (@Nombre, @Descripcion, @Cantidad)";
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Inventario");
        }

        /*Metodo para editar datos en la base de datos*/
        [HttpDelete]
        public IActionResult DeleteInventario(Models.InventarioModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "DELETE FROM Inventario WHERE Id=@id";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }
    }
}
