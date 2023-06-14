using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Workouts.Infrastructure.Persistence.EntityConfiguration;

public class WorkoutEntityConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.ToTable("Workouts");
        
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Id)
           .HasColumnName("Id")
           .ValueGeneratedOnAdd()
           .IsRequired();
        
        builder.Property(o => o.Name)
          .HasColumnName("Name")
          .HasMaxLength(50);

        builder.Property(o => o.Description)
            .HasColumnName("Description")
            .HasMaxLength(255);
    }
}