namespace API_Dinamita.ModelsDto
{
    public class TicketDto
    {
        public string Codigo { get; set; }
        public float Precio { get; set; }
        public DateTime Fecha_Expedicion { get; set; }
        public string Nombre_Evento { get; set; }
        public string Id_Evento { get; set; }
        public string Categoria { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public bool Estado { get; set; }
    }
}
