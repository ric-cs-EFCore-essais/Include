﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Ports;

namespace DataAccess.ModelBuilderConfigs
{
    public class AncreConfig : IEntityTypeConfiguration<Ancre>
    {
        public void Configure(EntityTypeBuilder<Ancre> entityModelBuilder)
        {
        }
    }
}
