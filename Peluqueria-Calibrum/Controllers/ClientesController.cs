using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Peluqueria_Calibrum.Controllers
{

    public class ClientesController : MyController
    {
        private string _connection = @"Server=sql777.main-hosting.eu;Database=u364986239_calibrum;Uid=u364986239_admin_calibrum;Password=2d839@sT";
        [Route("AgendarCita/[controller]")]
       

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
        [Route("Home")]
        public IActionResult Home()
        {
            return View();
        }
        [Route("Agendar")]
        public IActionResult Agendar()
        {
            return View();
        }
        [Route("Peluqueros")]
        public IActionResult Peluqueros()
        {
            return View();
        }
        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.ClienteModel> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Cliente";
                lst = db.Query<Models.ClienteModel>(sql);
            }
            return Ok(lst);
        }
    }
}