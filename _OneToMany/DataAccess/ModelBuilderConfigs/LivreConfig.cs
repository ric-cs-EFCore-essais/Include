using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domaine.MyEntities;


namespace DataAccess.ModelBuilderConfigs
{
    public class LivreConfig : IEntityTypeConfiguration<Livre>
    {
        public void Configure(EntityTypeBuilder<Livre> entityModelBuilder)
        {
            entityModelBuilder.Property(livre => livre.Titre).IsRequired();

            entityModelBuilder.Property(livre => livre.BibliothequeId).IsRequired();
        }
    }
}
