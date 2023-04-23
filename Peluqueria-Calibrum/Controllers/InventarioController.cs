using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Peluqueria_Calibrum.Controllers
{
    public class InventarioController : MyController
    {
        private string _connection = @"Server=sql777.main-hosting.eu;Database=u364986239_calibrum;Uid=u364986239_admin_calibrum;Password=2d839@sT";

        [Route("Inventario")]
        public IActionResult Inventario()
        {
            return View();
        }
        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.InventarioModel> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Inventario";
                lst = db.Query<Models.InventarioModel>(sql);
            }
            return Ok(lst);
        }
    }
}
