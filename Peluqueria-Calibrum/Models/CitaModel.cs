using Newtonsoft.Json;

namespace Peluqueria_Calibrum.Models
{
    public class CitaModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("hora")]
        public string Hora { get; set; }
        [JsonProperty("dia")]
        public string Dia { get; set; }
        [JsonProperty("nombre_cliente")]
        public string Nombre_cliente { get; set; }
        [JsonProperty("nombre_servicio")]
        public string Nombre_servicio { get; set; }
        [JsonProperty("telefono")]
        public string Telefono { get; set; }
        [JsonProperty("precio_total")]
        public int? Precio_total { get; set; }
        [JsonProperty("id_cliente")]
        public int? Id_Cliente { get; set; }
        [JsonProperty("id_empleado")]
        public int? Id_Empleado { get; set; }

    }
}
