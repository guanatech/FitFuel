using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Workouts.Infrastructure.Persistence.EntitiesConfigurations;

public class WorkoutPlanEntityConfiguration : IEntityTypeConfiguration<WorkoutPlan>
{
    public void Configure(EntityTypeBuilder<WorkoutPlan> builder)
    {
        builder.ToTable("WorkoutPlans");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasConversion(x => x.Value,
                x => new WorkoutPlanId(x));
        
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}