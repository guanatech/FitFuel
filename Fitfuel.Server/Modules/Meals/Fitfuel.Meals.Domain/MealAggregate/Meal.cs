using ErrorOr;
using Fitfuel.Meals.Domain.Common.Errors;
using Fitfuel.Meals.Domain.MealAggregate.Enums;
using Fitfuel.Meals.Domain.MealAggregate.ValueObjects;
using Fitfuel.Shared.Entities;

namespace Fitfuel.Meals.Domain.MealAggregate;

public class Meal : AggregateRoot
{
    public string Name { get; private set; }

    public int Calories { get; private set; }
    
    public Nutrients Nutrients { get; private set; }

    public TimeSpan CookingTime { get; private set; }
    
    public Category Category {get; private set;}
    
    public string Recipe { get; private set; }

    public string? ImageUrl { get; private set; }
    
    private Meal(Guid id, string name, int calories, TimeSpan cookingTime, 
        Category category, string recipe, Nutrients nutrients, string? imageUrl) 
        : base(id)
    {
        Name = name;
        Calories = calories;
        CookingTime = cookingTime;
        Category = category;
        Recipe = recipe;
        ImageUrl = imageUrl;
        Nutrients = nutrients;
    }

    public static ErrorOr<Meal> Create(string name, int calories, TimeSpan cookingTime,
        string category, string recipe, Nutrients nutrients, string? imageUrl)
    {
        if (!Enum.TryParse<Category>(category, true, out var mealCategory))
            return Errors.Meal.IncorrectMealCategory;
        
        var meal = new Meal(Guid.NewGuid(), name, calories, cookingTime, mealCategory, recipe, nutrients, imageUrl);
        return meal;
    }
        

    
#pragma warning disable CS8618 //necessary for EF Core 
    private Meal() { }
#pragma warning restore CS8618 
}