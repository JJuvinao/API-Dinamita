using Microsoft.Identity.Client;
using System;   
using System.ComponentModel.DataAnnotations;

namespace Proyect_Evento_Sistema.Models
{
    public class Persona
    {
        [Key]
        public int Id_usuario { get; set; }

        [Required]
        [MaxLength(20)]
        public string Cc_usuario { get; set; } // Propiedad que será única
        public DateTime F_nacimiento { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Sexo { get; set; }
        public string? Nom_Ubi_pais { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public string? Rol { get; set; }
        public string? Estado { get; set; }
        public virtual List<Ticket>? Tickets { get; set; }

    }


    public class PersonaDTO
    {
        public int Id_usuario { get; set; }
        public string? Cc_usuario { get; set; }
        public DateTime F_nacimiento { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Sexo { get; set; }
        public string? Nom_Ubi_pais { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public string? Rol { get; set; }
        public string? Estado { get; set; }
    }


}

