﻿using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Workouts.Infrastructure.Persistence.EntitiesConfigurations;

public class WorkoutEntityConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("Workouts");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id");

        builder.Property(x => x.WorkoutPlanId).IsRequired();

        builder.HasOne(x => x.WorkoutPlan)
            .WithMany(x => x.Workouts)
            .HasForeignKey(x => x.WorkoutPlanId);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.Description).HasMaxLength(240).IsRequired();

        builder.Property(x => x.IsCompleted).IsRequired();
        
        builder.Property(x => x.StartDate).IsRequired();
    }
}