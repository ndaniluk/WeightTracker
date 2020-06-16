﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeightTracker.Models;

namespace WeightTracker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeightTracker.Models.BodyParameters", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Biceps")
                        .HasColumnType("real");

                    b.Property<float>("Calf")
                        .HasColumnType("real");

                    b.Property<float>("Chest")
                        .HasColumnType("real");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("Hips")
                        .HasColumnType("real");

                    b.Property<Guid>("MeasurementRecordGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Thigh")
                        .HasColumnType("real");

                    b.Property<float>("Waist")
                        .HasColumnType("real");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Guid");

                    b.HasIndex("MeasurementRecordGuid")
                        .IsUnique();

                    b.ToTable("BodyParameters");
                });

            modelBuilder.Entity("WeightTracker.Models.LoginInfo", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserInfoGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("UserInfoGuid")
                        .IsUnique();

                    b.ToTable("LoginInfo");
                });

            modelBuilder.Entity("WeightTracker.Models.MeasurementRecord", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserInfoGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.HasIndex("UserInfoGuid");

                    b.ToTable("MeasurementRecords");
                });

            modelBuilder.Entity("WeightTracker.Models.TrainingNote", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TrainingRecordGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.HasIndex("TrainingRecordGuid")
                        .IsUnique();

                    b.ToTable("TrainingNotes");
                });

            modelBuilder.Entity("WeightTracker.Models.TrainingRecord", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserInfoGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.HasIndex("UserInfoGuid");

                    b.ToTable("TrainingRecords");
                });

            modelBuilder.Entity("WeightTracker.Models.UserInfo", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("WeightTracker.Models.BodyParameters", b =>
                {
                    b.HasOne("WeightTracker.Models.MeasurementRecord", "MeasurementRecord")
                        .WithOne("BodyParameters")
                        .HasForeignKey("WeightTracker.Models.BodyParameters", "MeasurementRecordGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeightTracker.Models.LoginInfo", b =>
                {
                    b.HasOne("WeightTracker.Models.UserInfo", null)
                        .WithOne("LoginInfo")
                        .HasForeignKey("WeightTracker.Models.LoginInfo", "UserInfoGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeightTracker.Models.MeasurementRecord", b =>
                {
                    b.HasOne("WeightTracker.Models.UserInfo", null)
                        .WithMany("MeasurementRecords")
                        .HasForeignKey("UserInfoGuid");
                });

            modelBuilder.Entity("WeightTracker.Models.TrainingNote", b =>
                {
                    b.HasOne("WeightTracker.Models.TrainingRecord", "TrainingRecord")
                        .WithOne("TrainingNote")
                        .HasForeignKey("WeightTracker.Models.TrainingNote", "TrainingRecordGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeightTracker.Models.TrainingRecord", b =>
                {
                    b.HasOne("WeightTracker.Models.UserInfo", null)
                        .WithMany("TrainingRecords")
                        .HasForeignKey("UserInfoGuid");
                });
#pragma warning restore 612, 618
        }
    }
}
