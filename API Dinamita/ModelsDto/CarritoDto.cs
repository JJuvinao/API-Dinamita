using API_Dinamita.Models;

namespace API_Dinamita.ModelsDto
{
    public class CarritoDto
    {
        public int Id { get; set; }
        public List<Tickets> Tickets { get; set; }
        public float Total { get; set; }
    }
}
