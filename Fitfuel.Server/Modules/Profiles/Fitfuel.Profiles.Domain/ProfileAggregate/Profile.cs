﻿using Fitfuel.Profiles.Domain.Common.Errors;
using Fitfuel.Profiles.Domain.ProfileAggregate.Entities;
using Fitfuel.Profiles.Domain.ProfileAggregate.Enums;
using Fitfuel.Profiles.Domain.ProfileAggregate.ValueObjects;
using Fitfuel.Shared.Entities;
using ErrorOr;

namespace Fitfuel.Profiles.Domain.ProfileAggregate;

public class Profile : AggregateRoot
{
    private readonly List<ProfileAchievement> _profileAchievements = new();
    
    public string FirstName { get; private set; }
    
    public string SecondName { get; private set; }
    
    public int Age { get; private set; }
    
    public Weight Weight { get; private set; }
    
    public Height Height { get; private set; }
    
    public Guid UserId { get; init; }
    
    public Level Level { get; private set; }
    
    public string MainPurpose { get; private set; }

    public IReadOnlyList<ProfileAchievement> ProfileAchievements => _profileAchievements;

    private Profile(Guid id, string firstName, string secondName, int age, Weight weight, Height height, 
        Guid userId, Level level, string mainPurpose) : base(id)
    {
        FirstName = firstName;
        SecondName = secondName;
        Age = age;
        Weight = weight;
        Height = height;
        UserId = userId;
        Level = level;
        MainPurpose = mainPurpose;
    }

    public static ErrorOr<Profile> Create(string firstName, string secondName, int age, Weight weight, Height height,
        Guid userId, string level, string mainPurpose)
    {
        if (!Enum.TryParse<Level>(level, true, out var profileLevel))
            return Errors.Profile.IncorrectLevelValue;
        
        var profile = new Profile(Guid.NewGuid(), firstName, secondName,
            age, weight, height, userId, profileLevel, mainPurpose);

        return profile;
    }

    public ErrorOr<Profile> Update(string firstName, string secondName, int age, Weight weight, Height height,
        string level, string mainPurpose)
    {
        if (!Enum.TryParse<Level>(level, true, out var profileLevel))
            return Errors.Profile.IncorrectLevelValue;
        
        FirstName = firstName;
        SecondName = secondName;
        Age = age;
        Weight = weight;
        Height = height;
        Level = profileLevel;
        MainPurpose = mainPurpose;

        return this;
    }
    
    
#pragma warning disable CS8618 // necessary for EF Core
    private Profile() { }
#pragma warning restore CS8618 
}