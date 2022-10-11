﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Ports;

namespace DataAccess.ModelBuilderConfigs
{
    public class CapitaineConfig : IEntityTypeConfiguration<Capitaine>
    {
        public void Configure(EntityTypeBuilder<Capitaine> entityModelBuilder)
        {
            entityModelBuilder.Property(entity => entity.Nom).IsRequired();
        }
    }
}
