
using System.ComponentModel.DataAnnotations;
namespace API_Dinamita.Models
{
    public class Carrito
    {
        [Key]
        public int Id_Carrito { get; set; }
        public List<Tickets> Tickets { get; set; } = new List<Tickets>();
        public float Total { get; set; }
        public int Id_Usuario { get; set; }
    }
}
