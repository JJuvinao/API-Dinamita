using Microsoft.AspNetCore.Identity;

namespace API_Dinamita.Models
{
    public class Persona
    {
        public int N_Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string PasswordHash { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
    }
}
