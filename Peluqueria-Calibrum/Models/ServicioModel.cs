using System.ComponentModel.DataAnnotations;

namespace Peluqueria_Calibrum.Models
{
    public class ServicioModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }

    }
}
