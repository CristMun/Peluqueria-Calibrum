using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Peluqueria_Calibrum.Models
{
    public class InventarioModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("imagen")]
        public string Imagen { get; set; }
        [JsonProperty("nombre")]
        public string? Nombre { get; set; }
        [JsonProperty("descripcion")]
        public string? Descripcion { get; set; }
        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }

    }
}
