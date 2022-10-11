using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Ports;

namespace DataAccess.ModelBuilderConfigs
{
    public class BateauConfig : IEntityTypeConfiguration<Bateau>
    {
        public void Configure(EntityTypeBuilder<Bateau> entityModelBuilder)
        {
            entityModelBuilder.Property(entity => entity.Nom).IsRequired();
            entityModelBuilder.HasIndex(entity => entity.AncreId).IsUnique();
        }
    }
}
