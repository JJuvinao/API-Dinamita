using System.ComponentModel.DataAnnotations;

namespace Proyect_Evento_Sistema.Models
{
    public class Ticket
    {
        [Key]
        public int Id_ticket { get; set; }
        public string? Cod_ticket { get; set; }
        public DateTime Fecha { get; set; }
        public string? Nombre_evento { get; set; }
        public string? Ubicacion { get; set; }
        public string? Descript_ubi { get; set; }
        public int Num_asiento { get; set; }
        public string? Estado { get; set; }
        public Decimal? Precio { get; set; }
        public string? Cc_usuario { get; set; }
        public string? Cod_asiento { get; set; }

        public virtual Persona? Persona { get; set; }



    }

    public class TicketDTO
    {
        public int Id_ticket { get; set; }
        public string? Cod_ticket { get; set; }
        public DateTime Fecha { get; set; }
        public string? Nombre_evento { get; set; }
        public string? Ubicacion { get; set; }
        public string? Descript_ubi { get; set; }
        public int Num_asiento { get; set; }
        public string? Estado { get; set; }
        public Decimal? Precio { get; set; }
        public string? Cc_usuario { get; set; }
        public string? Cod_asiento { get; set; }
    }
}