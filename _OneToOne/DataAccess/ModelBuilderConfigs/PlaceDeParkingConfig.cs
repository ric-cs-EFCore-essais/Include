using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domaine.MyEntities;


namespace DataAccess.ModelBuilderConfigs
{
    public class PlaceDeParkingConfig : IEntityTypeConfiguration<PlaceDeParking>
    {
        public void Configure(EntityTypeBuilder<PlaceDeParking> entityModelBuilder)
        {
            entityModelBuilder.Property(p => p.Ref).IsRequired();
            //entityModelBuilder.Property(p => p.Voiture).IsRequired();
        }
    }
}
