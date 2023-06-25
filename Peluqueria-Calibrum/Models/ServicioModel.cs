using Newtonsoft.Json;

namespace Peluqueria_Calibrum.Models
{
    public class ServicioModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("precio")]
        public int Precio { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get;  set; }

    }
}
