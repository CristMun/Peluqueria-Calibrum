using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Peluqueria_Calibrum.Controllers
{

    public class EmpleadoController : MyController
    {
        private string _connection = @"Server=sql777.main-hosting.eu;Database=u364986239_calibrum;Uid=u364986239_admin_calibrum;Password=2d839@sT";

        [Route("ListaEmpleado")]
        public IActionResult Empleado()
        {
            GetEmpleados();
            return View();
        }

        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult GetEmpleados() 
        {
            IEnumerable<Models.EmpleadoModel> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Empleado";
                lst = db.Query<Models.EmpleadoModel>(sql);
            }
            return View(lst);
        }
    }
}
