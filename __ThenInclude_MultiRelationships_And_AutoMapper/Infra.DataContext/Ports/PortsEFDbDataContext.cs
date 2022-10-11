using Microsoft.EntityFrameworkCore;

using Domain.Entities.Ports;

namespace Infra.DataContext.Ports
{
    public class PortsEFDbDataContext : DbContext
    {
        public PortsEFDbDataContext(DbContextOptions<PortsEFDbDataContext> options) : base(options)
        {
        }

        //--------------------------------------
        public DbSet<Port> Ports { get; set; }
        public DbSet<Ville> Villes { get; set; }



        //---------- Utilisation de la Fluent API, permet de paramétrer sans passer par des annotations, et donc sans toucher aux classes du Domaine ------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
        }
    }
}
