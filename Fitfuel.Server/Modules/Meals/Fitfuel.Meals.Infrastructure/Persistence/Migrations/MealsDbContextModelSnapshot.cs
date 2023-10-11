﻿// <auto-generated />
using System;
using Fitfuel.Meals.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Fitfuel.Meals.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(MealsDbContext))]
    partial class MealsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("meals")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Fitfuel.Meals.Domain.MealAggregate.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Calories")
                        .HasColumnType("integer");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("CookingTime")
                        .HasColumnType("interval");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Recipe")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("meals", "meals");
                });

            modelBuilder.Entity("Fitfuel.Meals.Domain.MealScheduleAggregate.MealSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<TimeSpan>("BreakfastTime")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("DinnerTime")
                        .HasColumnType("interval");

                    b.Property<bool>("IsNotified")
                        .HasColumnType("boolean");

                    b.Property<TimeSpan>("LunchTime")
                        .HasColumnType("interval");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("meal_schedules", "meals");
                });

            modelBuilder.Entity("Fitfuel.Meals.Domain.MealAggregate.Meal", b =>
                {
                    b.OwnsOne("Fitfuel.Meals.Domain.MealAggregate.ValueObjects.Nutrients", "Nutrients", b1 =>
                        {
                            b1.Property<Guid>("MealId")
                                .HasColumnType("uuid");

                            b1.Property<double>("Carbs")
                                .HasColumnType("double precision");

                            b1.Property<double>("Fats")
                                .HasColumnType("double precision");

                            b1.Property<double>("Proteins")
                                .HasColumnType("double precision");

                            b1.HasKey("MealId");

                            b1.ToTable("meals", "meals");

                            b1.WithOwner()
                                .HasForeignKey("MealId");
                        });

                    b.Navigation("Nutrients")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
