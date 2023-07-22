using Fitfuel.Meals.Domain.MealScheduleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Meals.Infrastructure.Persistence.EntitiesConfigurations;

public class MealScheduleConfiguration : IEntityTypeConfiguration<MealSchedule>
{
    public void Configure(EntityTypeBuilder<MealSchedule> builder)
    {
        builder.ToTable("mealSchedules");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever();

        builder.Property(m => m.BreakfastTime).IsRequired()
            .HasMaxLength(40);
        
        builder.Property(m => m.LunchTime).IsRequired()
            .HasMaxLength(40);
        
        builder.Property(m => m.DinnerTime).IsRequired()
            .HasMaxLength(40);
        
        builder.Property(m => m.ProfileId);
    }
}