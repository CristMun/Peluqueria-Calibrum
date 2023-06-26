using Newtonsoft.Json;

namespace Peluqueria_Calibrum.Models
{
    public class GestionModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nosotros_titulo")]
        public string Nosotros_Titulo { get; set; }

        [JsonProperty("nosotros_subtitulo")]
        public string Nosotros_Subtitulo { get; set; }

        [JsonProperty("nosotros_descripcion")]
        public string Nosotros_Descripcion { get; set; }

        [JsonProperty("nosotros_imagen")]
        public string Nosotros_Imagen { get; set; }
    }
}
