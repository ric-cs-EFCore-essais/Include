using Microsoft.EntityFrameworkCore;

using Domain.Entities.Ports;
using DataAccess.ModelBuilderConfigs;

namespace Infra.DataContext.Ports
{
    public class PortsEFDbDataContext : DbContext
    {
        public PortsEFDbDataContext(DbContextOptions<PortsEFDbDataContext> options) : base(options)
        {
        }

        //--------------------------------------

        public DbSet<Ancre> Ancres { get; set; }
        public DbSet<Bateau> Bateaux { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Ville> Villes { get; set; }

        public DbSet<Diplome> Diplomes { get; set; }

        public DbSet<Capitaine> Capitaines { get; set; }

        public DbSet<CapitaineDiplome> CapitainesDiplomes { get; set; }



        //---------- Utilisation de la Fluent API, permet de paramétrer sans passer par des annotations, et donc sans toucher aux classes du Domaine ------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.ApplyConfiguration(new AncreConfig());
                modelBuilder.ApplyConfiguration(new BateauConfig());
                modelBuilder.ApplyConfiguration(new PortConfig());
                modelBuilder.ApplyConfiguration(new VilleConfig());
                modelBuilder.ApplyConfiguration(new DiplomeConfig());
                modelBuilder.ApplyConfiguration(new CapitaineConfig());
                modelBuilder.ApplyConfiguration(new CapitaineDiplomeConfig());
            }
        }
    }
}
