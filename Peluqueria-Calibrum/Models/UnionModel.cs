namespace Peluqueria_Calibrum.Models
{
    public class UnionModel
    {
        public IEnumerable<EmpleadoModel> Empleados { get; set; }
        public IEnumerable<ServicioModel> Servicios { get; set; }
        public IEnumerable<GestionModel> Gestiones { get; set; }
        public IEnumerable<CitaModel> Citas { get; set; }
        public IEnumerable<HorasModel> Horas { get; set; }

        public UnionModel()
        {
            Empleados = new List<EmpleadoModel>();
            Servicios = new List<ServicioModel>();
            Gestiones = new List<GestionModel>();
            Citas   = new List<CitaModel>();
            Horas = new List<HorasModel>();
        }
    }
}
