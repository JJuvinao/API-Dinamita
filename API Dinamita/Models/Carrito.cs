namespace API_Dinamita.Models
{
    public class Carrito
    {
        public int Id { get; set; }
        public List<Tickets> Tickets { get; set; }
        public float Total { get; set; }
        public int Id_Usuario { get; set; }
    }
}
