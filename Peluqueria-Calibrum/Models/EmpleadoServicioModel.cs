namespace Peluqueria_Calibrum.Models
{
    public class EmpleadoServicioModel
    {
        public IEnumerable<EmpleadoModel> Empleados { get; set; }
        public IEnumerable<ServicioModel> Servicios { get; set; }
        public IEnumerable<GestionModel> Gestiones { get; set; }

        public EmpleadoServicioModel()
        {
            Empleados = new List<EmpleadoModel>();
            Servicios = new List<ServicioModel>();
            Gestiones = new List<GestionModel>();
        }
    }
}
