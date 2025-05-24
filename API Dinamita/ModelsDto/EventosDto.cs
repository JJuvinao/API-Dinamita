namespace API_Dinamita.ModelsDto
{
    public class EventosDto
    {
        public string? Nombre_Evento { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre_Lugar { get; set; }
        public string? Direccion_Lugar { get; set; }
        public int Aforo_Max { get; set; }
        public float PrecioTicket { get; set; }
        public string? Categoria { get; set; }
    }
}
