using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
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
            .HasColumnName("Id");
        
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}