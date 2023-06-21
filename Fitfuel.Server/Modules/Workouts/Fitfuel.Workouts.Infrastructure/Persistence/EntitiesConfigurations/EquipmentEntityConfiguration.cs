using Fitfuel.Workouts.Domain.EquipmentAggregate;
using Fitfuel.Workouts.Domain.EquipmentAggregate.ValueObjects;
using Fitfuel.Workouts.Domain.ExerciseAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Workouts.Infrastructure.Persistence.EntitiesConfigurations;

public class EquipmentEntityConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.ToTable("Equipments");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasConversion(x => x.Value,
                x => new EquipmentId(x));

        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();

    }
}