using Fitfuel.Meals.Domain.MealScheduleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Meals.Infrastructure.Persistence.Configurations;

public class MealScheduleEntityConfig : IEntityTypeConfiguration<MealSchedule>
{
    public void Configure(EntityTypeBuilder<MealSchedule> builder)
    {
        builder.ToTable("meal_schedules");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever();
        
        builder.Property(m => m.ProfileId)
            .IsRequired();
    }
}