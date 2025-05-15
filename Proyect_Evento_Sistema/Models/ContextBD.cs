using Microsoft.EntityFrameworkCore;

namespace Proyect_Evento_Sistema.Models
{
    public class ContextBD : DbContext
    {
        public ContextBD(DbContextOptions<ContextBD> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Palco> Palcos { get; set; }








    }
}
