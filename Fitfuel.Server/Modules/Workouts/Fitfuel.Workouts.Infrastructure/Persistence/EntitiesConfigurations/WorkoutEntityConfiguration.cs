using Fitfuel.Workouts.Domain.WorkoutAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Workouts.Infrastructure.Persistence.EntitiesConfigurations;

public class WorkoutEntityConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        //configure
    }
}