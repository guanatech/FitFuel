using Fitfuel.Workouts.Domain.ExerciseAggregate;
using Fitfuel.Workouts.Domain.ExerciseAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Workouts.Infrastructure.Persistence.EntitiesConfigurations;

public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("Exercises");

        builder.HasKey(e => e.Id);

        builder.Property(o => o.Id)
            .HasColumnName("Id")
            .HasConversion(x => x.Value, 
                x => new ExerciseId(x));

        builder.HasOne(x => x.Equipment)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.EquipmentId);

        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(120)
            .IsRequired();


    }
}

