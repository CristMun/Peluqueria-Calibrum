using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.IO;

namespace Peluqueria_Calibrum.Controllers
{
    public class GestionController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public GestionController(IWebHostEnvironment environment)
        {
            hostingEnvironment = environment;
        }

        public IActionResult Gestion()
        {
            var imagePath = Path.Combine(hostingEnvironment.WebRootPath, "images", "Nosotros");

            var pngFilePath = Path.Combine(imagePath, "nosotrosfoto.png");
            if (System.IO.File.Exists(pngFilePath))
            {
                ViewBag.ImagePath = "/images/Nosotros/nosotrosfoto.png";
            }
            else
            {
                ViewBag.ImagePath = "/images/Nosotros/nosotrosfoto.jpg";
            }


            return View();
        }

        [HttpPost]
        public IActionResult InsertNosotros(Models.GestionModel model, IFormFile Nos_Imagen)
        {
            int result = 0;
            using (var db = new MySqlConnection(MyController.csCal))
            {
                var nosImagenFileName = "nosotrosfoto";
                var nosImagenExtension = Path.GetExtension(Nos_Imagen.FileName);
                var nosImagenFileNameWithExtension = nosImagenFileName + nosImagenExtension;

                var imagePath = Path.Combine(hostingEnvironment.WebRootPath, "images", "Nosotros");
                Directory.CreateDirectory(imagePath);

                var existingFilePath = Path.Combine(imagePath, nosImagenFileNameWithExtension);
                if (System.IO.File.Exists(existingFilePath))
                {
                    System.IO.File.Delete(existingFilePath);
                }

                using (var stream = new FileStream(Path.Combine(imagePath, nosImagenFileNameWithExtension), FileMode.Create))
                {
                    Nos_Imagen.CopyTo(stream);
                }

                var sql = "INSERT INTO Gestion(Nos_Titulo, Nos_Subtitulo, Nos_Descripcion, Nos_Imagen) " +
                          "VALUES (@nos_titulo, @nos_subtitulo, @nos_descripcion, @nos_imagen)";
                result = db.Execute(sql, new
                {
                    nos_titulo = model.Nos_Titulo,
                    nos_subtitulo = model.Nos_Subtitulo,
                    nos_descripcion = model.Nos_Descripcion,
                    nos_imagen = nosImagenFileNameWithExtension
                });
            }
            return RedirectToAction("Gestion");
        }
    }
}
