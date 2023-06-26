using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Peluqueria_Calibrum.Controllers
{
    public class GestionController : Controller
    {
        public IActionResult Gestion()
        {
            return View();
        }


        /*Metodo para ingresar datos en la base de datos*/
        [HttpPost]
        public IActionResult InsertNosotros(Models.GestionModel model)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var sql = "INSERT INTO Gestion(Nosotros_Titulo, Nosotros_Subtitulo, Nosotros_Descripcion) " +
                    " values(@nosotros_titulo, @nosotros_subtitulo, @nosotros_descripcion)";
                result = db.Execute(sql, model);
            }
            return RedirectToAction("Gestion");
        }
    }
}
