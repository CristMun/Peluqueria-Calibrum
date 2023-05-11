using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Peluqueria_Calibrum.Models;
using System.Net.NetworkInformation;

namespace Peluqueria_Calibrum.Controllers
{
    public class InventarioController : MyController
    {
        [Route("Inventario")]
        public IActionResult Inventario()
        {
            GetInventario();
            return View();
        }
        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult GetInventario()
        {
            IEnumerable<InventarioModel> lst = null;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "SELECT * FROM Inventario";
                lst = db.Query<InventarioModel>(sql);
            }
            return View(lst);
        }

        /*Metodo para ingresar datos en la base de datos*/
        [HttpPost]
        
        public IActionResult Insert(Models.InventarioModel model)
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

        [HttpPut]
        public IActionResult Edit(Models.InventarioModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "UPDATE Inventario SET Nombre=@Nombre, Descripcion=@Descripcion, Cantidad=@Cantidad";
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Inventario");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "DELETE FROM Inventario WHERE Id=@id";
                result = db.Execute(sql, new { id });
            }
            return RedirectToAction("Inventario");
        }
    }
}
