using System.ComponentModel.DataAnnotations;

namespace Proyect_Evento_Sistema.Models
{
    public class Login
    {
        [Key]
        public string? username { get; set; }
        public string? password { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
    }

    public class LoginDto
    {
        public string? username { get; set; }
        public string? password { get; set; }
    }
    public class RegisterDto
    {
        [Key]
        public string? username { get; set; }
        public string? password { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
    }
}
