﻿using Fitfuel.Profiles.Domain.AchievementAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Profiles.Infrastructure.Persistence.EntitiesConfigurations;

public class AchievementEntityConfiguration : IEntityTypeConfiguration<Achievement>
{
    public void Configure(EntityTypeBuilder<Achievement> builder)
    {
        builder.ToTable("achievements");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .IsRequired();
    }
}