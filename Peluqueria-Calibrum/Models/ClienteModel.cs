using Newtonsoft.Json;

namespace Peluqueria_Calibrum.Models
{
    public class ClienteModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public string Nombre_cliente { get; set; }
        public string Telefono { get; set; }
    }
}
