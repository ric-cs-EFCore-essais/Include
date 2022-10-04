using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domaine.MyEntities;


namespace DataAccess.ModelBuilderConfigs
{
    public class BibliothequeConfig : IEntityTypeConfiguration<Bibliotheque>
    {
        public void Configure(EntityTypeBuilder<Bibliotheque> entityModelBuilder)
        {
            entityModelBuilder.Property(b => b.Nom).IsRequired();
        }
    }
}
