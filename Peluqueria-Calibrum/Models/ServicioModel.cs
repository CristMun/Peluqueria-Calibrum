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
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("mostrar_home")]
        public int? Mostrar_Home { get; set; }

    }
}
