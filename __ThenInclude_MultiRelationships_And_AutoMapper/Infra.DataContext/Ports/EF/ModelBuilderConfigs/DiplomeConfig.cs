using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Ports;

namespace DataAccess.ModelBuilderConfigs
{
    public class DiplomeConfig : IEntityTypeConfiguration<Diplome>
    {
        public void Configure(EntityTypeBuilder<Diplome> entityModelBuilder)
        {
            entityModelBuilder.Property(entity => entity.Intitule).IsRequired();
            entityModelBuilder.HasIndex(entity => entity.Intitule).IsUnique();
        }
    }
}
