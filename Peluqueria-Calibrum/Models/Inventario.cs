using System.ComponentModel.DataAnnotations;

namespace Peluqueria_Calibrum.Models
{
    public class Inventario
    {
        [Key]
        public int Id_inventario { get; set; }

        public string? Imagen { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Nombre_art { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public int Cantidad { get; set; }

    }
}
