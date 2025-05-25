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
        public int Tickets_Disponible { get; set; }
        public bool Estado { get; set; }
        public string? Categoria { get; set; }
        public IFormFile? Imagen { get; set; }
    }

    public class Eventofrom
    {
        public string? Nombre_Evento { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre_Lugar { get; set; }
        public string? Direccion_Lugar { get; set; }
        public int Aforo_Max { get; set; }
        public float PrecioTicket { get; set; }
        public string? Categoria { get; set; }
        public IFormFile? Imagen { get; set; }
    }
}
