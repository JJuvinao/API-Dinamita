namespace API_Dinamita.Models
{
    public class Eventos
    {
        public int Id { get; set; }
        public string Nombre_Evento { get; set; }
        public string Descripcion { get; set; }
        public string Nombre_Lugar { get; set; }
        public string Dirreccion_Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public int Duracion { get; set; }
        public int Aforo_Max { get; set; }
        private List<Tickets> Titcket { get; set; }
        public bool Estado { get; set; }
        public int Categoria { get; set; }
    }
}
