using Microsoft.EntityFrameworkCore;
using TurismoApp.Models;

namespace TurismoApp.Data
{
    public class TurismoAppContext : DbContext
    {
        public TurismoAppContext(DbContextOptions<TurismoAppContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CidadeDestino> CidadeDestinos { get; set; }
        public DbSet<PacoteTuristico> PacoteTuristicos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
