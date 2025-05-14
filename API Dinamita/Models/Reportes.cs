namespace API_Dinamita.Models
{
    public class Reportes
    {
        public int Id { get; set; }
        public string Nombre_Reporte { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Nombre_Evento { get; set; }
        public string Id_Evento { get; set; }
        public int N_Ventas { get; set; }
        public int N_Asistencias { get; set; }
    }
}
