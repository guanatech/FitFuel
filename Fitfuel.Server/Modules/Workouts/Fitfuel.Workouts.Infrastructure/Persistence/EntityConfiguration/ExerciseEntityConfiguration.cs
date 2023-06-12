using Fitfuel.Workouts.Domain.ExerciseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Workouts.Infrastructure.Persistence.EntityConfiguration;

public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("Exercises");

        builder.HasKey(e => e.Id);
        
        builder.Property(o => o.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(e => e.Name)
            .HasColumnName("Name")
            .IsRequired();
        
        builder.Property(e => e.ExerciseType)
            .HasColumnName("ExerciseType")
            .IsRequired();
        
        builder.Property(e => e.Description)
            .HasColumnName("Description")
            .IsRequired();
        
        builder.Property(e => e.Duration)
            .HasColumnName("Duration")
            .IsRequired();
    }
}

