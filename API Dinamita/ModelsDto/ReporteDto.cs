
namespace API_Dinamita.ModelsDto
{
    public class ReporteDto
    {
        public int Id_ReporteDto { get; set; }
        public string Nombre_Reporte { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Nombre_Evento { get; set; }
        public int N_Ventas { get; set; }
        public int N_Asistencias { get; set; }
        public string Descripcion { get; set; }
    }
}
