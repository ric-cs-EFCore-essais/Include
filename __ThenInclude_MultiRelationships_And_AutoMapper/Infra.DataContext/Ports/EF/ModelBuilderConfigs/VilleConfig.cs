using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Ports;

namespace DataAccess.ModelBuilderConfigs
{
    public class VilleConfig : IEntityTypeConfiguration<Ville>
    {
        public void Configure(EntityTypeBuilder<Ville> entityModelBuilder)
        {
            entityModelBuilder.Property(entity => entity.Nom).IsRequired();
            entityModelBuilder.HasIndex(entity => entity.Nom).IsUnique();
        }
    }
}
