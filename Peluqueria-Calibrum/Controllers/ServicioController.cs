﻿using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Peluqueria_Calibrum.Controllers
{
    public class ServicioController : MyController
    {
        private string _connection = @"Server=sql777.main-hosting.eu;Database=u364986239_calibrum;Uid=u364986239_admin_calibrum;Password=2d839@sT";
        [Route("ListaServicios")]
        public IActionResult Servicio()
        {
            GetServicios();
            return View();
        }

        /*Metodo para llamar datos en la base de datos*/
        [HttpGet]
        public IActionResult GetServicios()
        {
            IEnumerable<Models.ServicioModel> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Servicio";
                lst = db.Query<Models.ServicioModel>(sql);
            }
            return View(lst);
        }
    }
}
