using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Peluqueria_Calibrum.Controllers
{
    [Route("ListaCitas")]
    [ApiController]
    public class CitasController : MyController
    {
        private string _connection = @"Server=sql777.main-hosting.eu;Database=u364986239_calibrum;Uid=u364986239_admin_calibrum;Password=2d839@sT";
        public IActionResult Citas()
        {
            return View();
        }

        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.CitaModel> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Cita";
                lst = db.Query<Models.CitaModel>(sql);
            }
            return Ok(lst);
        }
    }
}
