using Fitfuel.Meals.Domain.MealAggregate;
using Fitfuel.Meals.Domain.MealAggregate.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Meals.Infrastructure.Persistence.EntitiesConfigurations;

public class MealEntityConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("meals");

        builder.HasKey(meal => meal.Id);
        
        builder.Property(meal => meal.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(meal => meal.Calories).IsRequired();
        builder.Property(meal => meal.Name).IsRequired().HasMaxLength(100);
        builder.Property(meal => meal.Recipe).IsRequired();
        builder.Property(meal => meal.CookingTime).IsRequired();

        builder.OwnsOne(meal => meal.Nutrients);
        
        builder.Property(meal => meal.ImageUrl).IsRequired(false);
        
        builder.Property(meal => meal.Category).IsRequired()
            .HasConversion(
                meal => meal.ToString(), 
                meal => (Category)Enum.Parse(typeof(Category), meal));
    }
}