using System.ComponentModel.DataAnnotations;

namespace Proyect_Evento_Sistema.Models
{
    public class Palco
    {
        [Key]
        public int Id_palco { get; set; }
        public string? Opcion_palco { get; set; }
        public int Num_asiento { get; set; }
        public string? Estado { get; set; }
        public decimal Precio { get; set; }


    }

    public class PalcoDTO
    {
        public int Id_palco { get; set; }
        public string? Opcion_palco { get; set; }
        public int Num_asiento { get; set; }
        public string? Estado { get; set; }
        public decimal Precio { get; set; } 
    }
}
