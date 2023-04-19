using System.ComponentModel.DataAnnotations;

namespace Peluqueria_Calibrum.Models
{
    public class Empleado
    {
        [Key]
        public int Id_Empleado { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Apellido { get; set; }

        [Required]
        public string? Usuario { get; set; }

        [Required]
        public string? Contrasena { get; set; }

        [Required]
        public string? Horario { get; set; }

        [Required]
        public string? Cargo { get; set; }

    }
}
