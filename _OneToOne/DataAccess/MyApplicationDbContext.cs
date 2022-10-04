using Microsoft.EntityFrameworkCore;


using Domaine.MyEntities;
using DataAccess.ModelBuilderConfigs;

namespace DataAccess
{
    public class MyApplicationDbContext : DbContext
    {
        public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options) : base(options)
        {
        }

        //--------------------------------------
        public DbSet<PlaceDeParking> PlacesDeParking { get; set; }
        public DbSet<Voiture> Voitures { get; set; }

        

        //---------- Utilisation de la Fluent API, permet de paramétrer sans passer par des annotations, et donc sans toucher aux classes du Domaine ------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new PlaceDeParkingConfig() );
            modelBuilder.ApplyConfiguration( new VoitureConfig() );

        }

    }
}
