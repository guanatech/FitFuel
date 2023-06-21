using Fitfuel.Meals.Domain.MealAggregate;
using Fitfuel.Meals.Domain.MealAggregate.Enums;
using Fitfuel.Meals.Domain.MealAggregate.ValueObjects;
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
            .HasConversion(
                id => id.Value,
                value => MealId.Create(value))
            .IsRequired();

        builder.Property(meal => meal.Calories).IsRequired();
        builder.Property(meal => meal.Name).IsRequired().HasMaxLength(100);
        builder.Property(meal => meal.Recipe).IsRequired();
        builder.Property(meal => meal.CookingTime).IsRequired();
        
        builder.Property(meal => meal.Fats).IsRequired();
        builder.Property(meal => meal.Proteins).IsRequired();
        builder.Property(meal => meal.Carbs).IsRequired();
        
        builder.Property(meal => meal.ImageUrl).IsRequired(false);
        
        builder.Property(meal => meal.Category).IsRequired()
            .HasConversion(
                meal => meal.ToString(), 
                meal => (Category)Enum.Parse(typeof(Category), meal));
    }
}