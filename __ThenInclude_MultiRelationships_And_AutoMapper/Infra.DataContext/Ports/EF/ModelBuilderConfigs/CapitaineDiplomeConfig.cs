using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Ports;

namespace DataAccess.ModelBuilderConfigs
{
    public class CapitaineDiplomeConfig : IEntityTypeConfiguration<CapitaineDiplome>
    {
        public void Configure(EntityTypeBuilder<CapitaineDiplome> entityModelBuilder)
        {
            entityModelBuilder.Property(entity => entity.AnneeObtention).IsRequired();
            entityModelBuilder.HasIndex(entity => new { entity.CapitaineId, entity.DiplomeId }).IsUnique(); //On exige une clef composée à valeur unique.
        }
    }
}
