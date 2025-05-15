using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Proyect_Evento_Sistema.Models
{
    public class Administrador
    {
        [Key]
        public int Id_admin { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Descripcion_tarea { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public string? Cod_evento { get; set; }
        public string? Cod_asiento { get; set; }
        public string? Cod_ticket { get; set; }

    }

    public class AdministradorDTO
    {
        public int Id_admin { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Descripcion_tarea { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public string? Cod_evento { get; set; }
        public string? Cod_asiento { get; set; }
        public string? Cod_ticket { get; set; }
    }
}