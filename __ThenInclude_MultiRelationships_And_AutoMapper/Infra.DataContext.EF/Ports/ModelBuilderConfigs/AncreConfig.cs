using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Ports;

namespace Infra.DataContext.EF.Ports.ModelBuilderConfigs
{
    public class AncreConfig : IEntityTypeConfiguration<Ancre>
    {
        public void Configure(EntityTypeBuilder<Ancre> entityModelBuilder)
        {
        }
    }
}
