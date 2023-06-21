﻿using Fitfuel.Meals.Domain.MealAggregate;
using Microsoft.EntityFrameworkCore;

namespace Fitfuel.Meals.Infrastructure.Persistence;

public class MealsDbContext : DbContext
{
    public DbSet<Meal> Meals { get; set; } = null!;
    
    public MealsDbContext(DbContextOptions<MealsDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("meals");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}