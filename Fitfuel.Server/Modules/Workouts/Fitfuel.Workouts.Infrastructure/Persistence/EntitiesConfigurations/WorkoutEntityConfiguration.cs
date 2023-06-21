using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Workouts.Infrastructure.Persistence.EntitiesConfigurations;

public class WorkoutEntityConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("Workouts");
        
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.WorkoutPlan)
            .WithMany(x => x.Workouts)
            .HasForeignKey(x => x.WorkoutPlanId);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasConversion(x => x.Value,
                x => new WorkoutId(x));
        
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}