namespace API_Dinamita.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public float Precio { get; set; }
        public DateTime Fecha_Expedicion { get; set; }
        public string Nombre_Evento { get; set; }
        public string Id_Evento { get; set; }
        public int Id_Categoria { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public bool Estado { get; set; }
        public bool Pagado { get; set; }

    }
}
