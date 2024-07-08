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
    [Migration("20240708064253_Date noi in Workout")]
    partial class DatenoiinWorkout
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

            modelBuilder.Entity("DataAccess.Entities.Trainer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Trainer");
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

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TrainerId")
                        .HasColumnType("text");

                    b.Property<double?>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccess.Entities.Workout", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<int?>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("DataAccess.Entities.BaseEntity.ExerciseLog", b =>
                {
                    b.HasOne("DataAccess.Entities.Exercise", "Exercise")
                        .WithMany("ExerciseLogs")
                        .HasForeignKey("ExerciseId");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("DataAccess.Entities.Exercise", b =>
                {
                    b.HasOne("DataAccess.Entities.Workout", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("DataAccess.Entities.User", b =>
                {
                    b.HasOne("DataAccess.Entities.Trainer", "Trainer")
                        .WithMany("Users")
                        .HasForeignKey("TrainerId");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("DataAccess.Entities.Workout", b =>
                {
                    b.HasOne("DataAccess.Entities.User", "User")
                        .WithMany("Workouts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Entities.Exercise", b =>
                {
                    b.Navigation("ExerciseLogs");
                });

            modelBuilder.Entity("DataAccess.Entities.Trainer", b =>
                {
                    b.Navigation("Users");
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
