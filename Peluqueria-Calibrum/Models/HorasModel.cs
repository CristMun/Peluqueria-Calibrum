using Newtonsoft.Json;

namespace Peluqueria_Calibrum.Models
{
    public class HorasModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("hora")]
        public string Hora { get; set; }

        [JsonProperty("disponible")]
        public bool Disponible { get; set; }
    }


}
