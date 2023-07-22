using Fitfuel.Shared.Entities;

namespace Fitfuel.Meals.Domain.MealAggregate.ValueObjects;

public class Nutrients : ValueObject
{
    public double Proteins { get; private set; }
    
    public double Fats { get; private set; }

    public double Carbs { get; private set; }

    public Nutrients(double proteins, double fats, double carbs)
    {
        Proteins = proteins;
        Fats = fats;
        Carbs = carbs;
    }
    
    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Proteins;
        yield return Fats;
        yield return Carbs;
    }
}