using Dapper;
using Microsoft.AspNetCore.Authorization;
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


        /*Metodo para buscar datos en la base de datos*/
        [HttpGet]
        public IActionResult BuscarInventario(string nombre, string descripcion)
        {
            IEnumerable<Models.InventarioModel> lst = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Inventario WHERE 1 = 1 ";

                if (!string.IsNullOrEmpty(nombre))
                {
                    sql += " AND Nombre LIKE @nombre ";
                }

                if (!string.IsNullOrEmpty(descripcion))
                {
                    sql += " AND Descripcion LIKE @descripcion ";
                }

                var parameters = new { nombre = $"%{nombre}%", descripcion = $"%{descripcion}%" };

                lst = db.Query<Models.InventarioModel>(sql, parameters);
            }
            return PartialView("_TablaInventario", lst);
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




        /*Metodo para llamar al elemento del INVENTARIO que se va a EDITAR*/
        [HttpGet]
        public IActionResult GetInventarioEdit(int id)
        {
            Models.InventarioModel inventario = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Inventario WHERE Id = @id";
                inventario = db.QuerySingleOrDefault<Models.InventarioModel>(sql, new { id });
            }
            return Json(inventario);
        }
        /*Metodo para EDITAR el elemento del INVENTARIO que se llamo*/
        [HttpPost]
        public IActionResult UpdateInventario(Models.InventarioModel model, int id)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "UPDATE Inventario SET Nombre=@nombre, Descripcion=@descripcion, Cantidad=@cantidad WHERE Id = @id";
                model.Id = id;
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Inventario");
        }
    }
}
