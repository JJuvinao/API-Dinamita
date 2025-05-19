using API_Dinamita.Models;

namespace API_Dinamita.ModelsDto
{
    public class CarritoDto
    {
        public List<Tickets> Tickets { get; set; }
        public float Total { get; set; }
    }
}
