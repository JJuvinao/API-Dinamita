using System.ComponentModel.DataAnnotations;

namespace Proyect_Evento_Sistema.Models
{
    public class Evento
    {
        [Key]
        public int Id_evento { get; set; }
        public DateTime Fecha { get; set; }
        public string? Cod_evento { get; set; }
        public string? Nombre_evento { get; set; }
        public string? Apert_silla { get; set; }
        public string? Ubicacion { get; set; }
        public string? Descrip_ubi { get; set; }
        public string? Categoria { get; set; }
        public string? Descrip_evento { get; set; }
        public string? Aforo_max { get; set; }
        public string? Estado { get; set; }


    }

    public class EventoDTO
    {
        public int Id_evento { get; set; }
        public DateTime Fecha { get; set; }
        public string? Cod_evento { get; set; }
        public string? Nombre_evento { get; set; }
        public string? Apert_silla { get; set; }
        public string? Ubicacion { get; set; }
        public string? Descrip_ubi { get; set; }
        public string? Categoria { get; set; }
        public string? Descrip_evento { get; set; }
        public string? Aforo_max { get; set; }
        public string? Estado { get; set; }
    }
}
