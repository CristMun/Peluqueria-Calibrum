using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Peluqueria_Calibrum.Controllers
{
    
    public class CitasController : MyController
    {
        private string _connection = @"Server=sql777.main-hosting.eu;Database=u364986239_calibrum;Uid=u364986239_admin_calibrum;Password=2d839@sT";
        [Route("ListaCitas")]
        public IActionResult Citas()
        {
            GetCitas();
            return View();
        }

        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult GetCitas()
        {
            IEnumerable<Models.CitaModel> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Cita";
                lst = db.Query<Models.CitaModel>(sql);
            }
            return View(lst);
        }

        /*Metodo para ingresar datos en la base de datos*/
        [HttpPost]
        public IActionResult Insert(Models.CitaModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "INSERT INTO Cita(Hora, Dia, Nombre_cliente, Nombre_servicio, Telefono, Precio_total) " +
                    " values(@hora, @dia, @nombre_cliente, @nombre_servicio, @telefono, @precio_total)";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

        /*Metodo para editar datos en la base de datos*/
        [HttpPut]
        public IActionResult Edit(Models.CitaModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "UPDATE Cita set Hora=@hora, Dia=@dia, Nombre_cliente=@nombre_cliente, Telefono=@telefono, Precio_total=@precio_total";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }

        /*Metodo para editar datos en la base de datos*/
        [HttpDelete]
        public IActionResult Delete(Models.CitaModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "DELETE FROM Cita WHERE Id=@id";
                result = db.Execute(sql, model);
            }
            return Ok(result);
        }
    }
}
