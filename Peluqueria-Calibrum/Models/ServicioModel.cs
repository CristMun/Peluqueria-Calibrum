using System.ComponentModel.DataAnnotations;

namespace Peluqueria_Calibrum.Models
{
    public class ServicioModel
    {
        [Key]
        public int Id_servicio { get; set; }

        [Required]
        public string? Nombre_serv { get; set; }

        [Required]
        public string? Descripcion_serv { get; set; }

        [Required]
        public int Precio { get; set; }

    }
}
