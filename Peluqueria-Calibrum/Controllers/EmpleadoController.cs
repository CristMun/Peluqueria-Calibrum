using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Peluqueria_Calibrum.Models;


namespace Peluqueria_Calibrum.Controllers
{
    [Route("ListaEmpleado")]
    [ApiController]
    public class EmpleadoController : MyController
    {
        private string _connection = @"Server=sql777.main-hosting.eu;Database=u364986239_calibrum;Uid=u364986239_admin_calibrum;Password=2d839@sT";
        public IActionResult Empleado()
        {
            return View();
        }

        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult Get() 
        {
            IEnumerable<Models.EmpleadoModel> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Empleado";
                lst = db.Query<Models.EmpleadoModel>(sql);
            }
            return Ok(lst);
        }
    }
}
