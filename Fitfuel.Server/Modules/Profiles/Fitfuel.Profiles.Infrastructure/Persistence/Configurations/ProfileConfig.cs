using Fitfuel.Profiles.Domain.ProfileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fitfuel.Profiles.Infrastructure.Persistence.Configurations;

public class ProfileConfig : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("profiles");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.OwnsOne(p => p.Height);
        builder.OwnsOne(p => p.Weight);
    }
}