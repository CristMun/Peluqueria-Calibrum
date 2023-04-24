using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;


namespace Peluqueria_Calibrum.Models
{
    [Table("Empleado")]
    public class EmpleadoModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellido")]
        public string Apellido { get; set; }

        [JsonProperty("usuario")]
        public string Usuario { get; set; }

        [JsonProperty("contrasena")]
        public string Contrasena { get; set; }

        [JsonProperty("horario")]
        public string Horario { get; set; }

        [JsonProperty("cargo")]
        public string Cargo { get; set; }
    }
}
