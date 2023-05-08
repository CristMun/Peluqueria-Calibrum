using System.ComponentModel.DataAnnotations;

namespace Peluqueria_Calibrum.Models
{
    public class InventarioModel
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }

    }
}
