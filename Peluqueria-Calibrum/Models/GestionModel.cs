using Newtonsoft.Json;
namespace Peluqueria_Calibrum.Models
{
    public class GestionModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nos_titulo")]
        public string Nos_Titulo { get; set; }

        [JsonProperty("nos_subtitulo")]
        public string Nos_Subtitulo { get; set; }

        [JsonProperty("nos_descripcion")]
        public string Nos_Descripcion { get; set; }

        [JsonProperty("nos_imagen")]
        public string Nos_Imagen { get; set; }
    }
}
