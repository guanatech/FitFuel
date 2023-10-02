using Fitfuel.Profiles.Domain.ProfileAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Profiles.Infrastructure.Persistence.EntitiesConfigurations;

public class ProfileAchievementEntityConfiguration : IEntityTypeConfiguration<ProfileAchievement>
{
    public void Configure(EntityTypeBuilder<ProfileAchievement> builder)
    {
        builder.ToTable("profile_achievements");

        builder.HasKey(p => new {p.ProfileId, p.AchievementId});

        builder.Property(p => p.Id)
            .IsRequired();

        builder.HasOne(p => p.Profile)
            .WithMany(p => p.ProfileAchievements)
            .HasForeignKey(p => p.ProfileId);
    }
}