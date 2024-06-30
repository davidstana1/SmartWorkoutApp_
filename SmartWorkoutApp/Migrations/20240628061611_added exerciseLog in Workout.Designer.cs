﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartWorkoutApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240628061611_added exerciseLog in Workout")]
    partial class addedexerciseLoginWorkout
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.BaseEntity.ExerciseLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<double?>("Distance")
                        .HasColumnType("double precision");

                    b.Property<double?>("Duration")
                        .HasColumnType("double precision");

                    b.Property<string>("ExerciseId")
                        .HasColumnType("text");

                    b.Property<int?>("Reps")
                        .HasColumnType("integer");

                    b.Property<int?>("Sets")
                        .HasColumnType("integer");

                    b.Property<double?>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseLogs");
                });

            modelBuilder.Entity("DataAccess.Entities.Exercise", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WorkoutId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccess.Entities.Workout", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("ExerciseLogId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseLogId");

                    b.HasIndex("UserId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("DataAccess.Entities.BaseEntity.ExerciseLog", b =>
                {
                    b.HasOne("DataAccess.Entities.Exercise", null)
                        .WithMany("ExerciseLogs")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("DataAccess.Entities.Exercise", b =>
                {
                    b.HasOne("DataAccess.Entities.Workout", null)
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId");
                });

            modelBuilder.Entity("DataAccess.Entities.Workout", b =>
                {
                    b.HasOne("DataAccess.Entities.BaseEntity.ExerciseLog", "ExerciseLog")
                        .WithMany()
                        .HasForeignKey("ExerciseLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.User", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseLog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Entities.Exercise", b =>
                {
                    b.Navigation("ExerciseLogs");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("DataAccess.Entities.Workout", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
