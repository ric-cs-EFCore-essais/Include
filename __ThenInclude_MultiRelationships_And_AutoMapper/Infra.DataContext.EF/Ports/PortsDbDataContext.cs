using Microsoft.EntityFrameworkCore;

using Domain.Entities.Ports;

using Infra.DataContext.EF.Ports.ModelBuilderConfigs;
using Infra.DataContext.Interfaces;

namespace Infra.DataContext.EF.Ports
{
    public class PortsDbDataContext : DbContext, IDataContext
    {
        public PortsDbDataContext(DbContextOptions<PortsDbDataContext> options) : base(options)
        {
        }

        //--------------------------------------

        public DbSet<Port> Ports { get; set; }
        public DbSet<Ville> Villes { get; set; }

        public DbSet<Ancre> Ancres { get; set; }

        public DbSet<Diplome> Diplomes { get; set; }

        public DbSet<Capitaine> Capitaines { get; set; }

        public DbSet<CapitaineDiplome> CapitainesDiplomes { get; set; }

        public DbSet<Bateau> Bateaux { get; set; }


        //---------- Utilisation de la Fluent API, permet de paramétrer sans passer par des annotations, et donc sans toucher aux classes du Domaine ------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AncreConfig());
            modelBuilder.ApplyConfiguration(new BateauConfig());
            modelBuilder.ApplyConfiguration(new PortConfig());
            modelBuilder.ApplyConfiguration(new VilleConfig());
            modelBuilder.ApplyConfiguration(new DiplomeConfig());
            modelBuilder.ApplyConfiguration(new CapitaineConfig());
            modelBuilder.ApplyConfiguration(new CapitaineDiplomeConfig());

        }

        public void Save()
        {
            base.SaveChanges();
        }
    }
}
