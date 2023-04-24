namespace Peluqueria_Calibrum.Models
{
    public class CitaModel
    {
        public int Id { get; set; }
        public string Hora { get; set; }
        public string Dia { get; set; }
        public string Nombre_cliente { get; set; }
        public string Nombre_servicio { get; set; }
        public string Telefono { get; set; }
        public int? Precio_total { get; set; }

    }
}
