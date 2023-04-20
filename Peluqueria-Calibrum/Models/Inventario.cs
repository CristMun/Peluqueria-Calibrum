using System.ComponentModel.DataAnnotations;

namespace Peluqueria_Calibrum.Models
{
    public class Inventario
    {
        [Key]
        public int Id_inventario { get; set; }

        public string? Imagen_art { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Nombre_art { get; set; }

        [Required]
        public string? Descripcion_art { get; set; }

        [Required]
        public int Cantidad { get; set; }

    }
}
