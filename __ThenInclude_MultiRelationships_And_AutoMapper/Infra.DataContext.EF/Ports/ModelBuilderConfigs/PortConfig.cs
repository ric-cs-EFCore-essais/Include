using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Ports;

namespace Infra.DataContext.EF.Ports.ModelBuilderConfigs
{
    public class PortConfig : IEntityTypeConfiguration<Port>
    {
        public void Configure(EntityTypeBuilder<Port> entityModelBuilder)
        {
            entityModelBuilder.Property(entity => entity.Nom).IsRequired();
        }
    }
}
