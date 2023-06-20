using Fitfuel.Meals.Domain.MealAggregate.Enums;
using Fitfuel.Meals.Domain.MealAggregate.ValueObjects;
using Fitfuel.Shared.Entities;

namespace Fitfuel.Meals.Domain.MealAggregate;

public class Meal : AggregateRoot<MealId>
{
    private Meal(MealId id, string name, int calories, TimeSpan cookingTime, 
        Category category, string recipe, string? imageUrl) 
        : base(id)
    {
        Name = name;
        Calories = calories;
        CookingTime = cookingTime;
        Category = category;
        Recipe = recipe;
        ImageUrl = imageUrl;
    }
    
    public string Name { get; private set; }

    public int Calories { get; private set; }

    public TimeSpan CookingTime { get; private set; }
    
    public Category Category {get; private set;}
    
    public string Recipe { get; private set; }

    public string? ImageUrl { get; private set; }

    public static Meal Create(string name, int calories, TimeSpan cookingTime, 
        Category category, string recipe, string? imageUrl) =>
        new(MealId.CreateUnique(), name, calories, cookingTime, category, recipe, imageUrl);
}