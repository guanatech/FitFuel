using Fitfuel.Workouts.Domain.ExerciseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Workouts.Infrastructure.Persistence.EntitiesConfigurations;

public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("Exercises");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id");
        
        builder.Property(x => x.WorkoutId).IsRequired();
        
        builder
            .HasOne(x => x.Workout)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.WorkoutId);
        
        builder
            .HasOne(x => x.Equipment)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.EquipmentId);

        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
        
        builder.Property(x => x.Description).HasMaxLength(240).IsRequired();

        builder.Property(x => x.Duration).IsRequired();
        
        builder.Property(x => x.ExerciseType).IsRequired();
        
        builder.Property(x => x.Repetition).IsRequired();

    }
}