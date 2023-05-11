using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
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

        [JsonProperty("cargo")]
        public string Cargo { get; set; }

        [JsonProperty("dias")]
        public string Dias { get; set; }
        [JsonProperty("hora")]
        public string Hora { get; set; }
        [JsonProperty("servicios")]
        public string Servicios { get; set; }
    }
}
